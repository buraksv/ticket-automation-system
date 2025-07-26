using Gronio.Utility.Extensions;
using Microsoft.Playwright;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;
using TicketSystem.Business.Contract.Managers;
using TicketSystem.Business.Contract.Services;
using TicketSystem.Common.Constants;
using TicketSystem.Dto.ExternalApiResponseModels;
using TicketSystem.Dto.TicketAccountDefinitions;
using TicketSystem.Dto.TicketProviderSetting;
using TicketSystem.Enums;

namespace TicketSystem.Business.Services;

internal sealed class PassoLigService : IPassoLigService
{
    private readonly ITicketProviderSettingsManager _ticketProviderSettingsManager;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITicketAccountDefinitionManager _ticketAccountDefinitionManager;

    public PassoLigService(ITicketProviderSettingsManager ticketProviderSettingsManager, IHttpClientFactory httpClientFactory, ITicketAccountDefinitionManager ticketAccountDefinitionManager)
    {
        _ticketProviderSettingsManager = ticketProviderSettingsManager;
        _httpClientFactory = httpClientFactory;
        _ticketAccountDefinitionManager = ticketAccountDefinitionManager;
    }

    public async ValueTask<bool> GenerateMainTokenRequestAsync(CancellationToken cancellationToken = new())
    {
        var providerSettings = await GetProviderSettings(cancellationToken);

        var currentUserAgent = await GetOrCreateUserAgent(providerSettings, cancellationToken);

        if (providerSettings.TryGetValue(ApplicationConstants.PassoLigMainPhoneNumberSettingsKey, out var mainPhoneGsmNumber))
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var apiRequest = new
                {
                    PhoneNumber = mainPhoneGsmNumber,
                };

                httpClient.DefaultRequestHeaders.Add("User-Agent", currentUserAgent);

                var json = JsonSerializer.Serialize(apiRequest);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await httpClient.PostWithCurlAsync(ApplicationConstants.PassoLigGsPlusLoginCodeEndpoint, content, cancellationToken, true, CurlDefinitionType.Debug);

            }

            return true;
        }

        return false;
    }

    public async ValueTask<bool> GenerateMainRefreshTokenRequestAsync(CancellationToken cancellationToken = new())
    {
        var providerSettings = await GetProviderSettings(cancellationToken);

        var currentUserAgent = await GetOrCreateUserAgent(providerSettings, cancellationToken);

        if (providerSettings.TryGetValue(ApplicationConstants.PassoLigGsMobileMainRefreshTokenSettingsKey, out var refreshToken) && providerSettings.TryGetValue(ApplicationConstants.PassoLigGsMobileMainRefreshTokenExpireDateSettingsKey, out var refreshTokenExpire))
        {
            if (providerSettings.TryGetValue(ApplicationConstants.PassoLigGsMobileMainTokenSettingsKey, out var accessToken))
            {
                if (providerSettings.TryGetValue(ApplicationConstants.PassoLigGsMobileMainTokenExpireDateSettingsKey, out var accessTokenExpire))
                {
                    var accessTokenExpireDate = DateTime.Parse(accessTokenExpire);
                    var refreshTokenExpireDate = DateTime.Parse(refreshTokenExpire);

                    if ((accessTokenExpireDate - DateTime.Now).TotalMinutes < 10)
                    {
                        if ((refreshTokenExpireDate - DateTime.Now).TotalMinutes > 30)
                        {

                            using (var httpClient = _httpClientFactory.CreateClient())
                            {
                                var apiRequest = new
                                {
                                    AccessToken = accessToken,
                                    RefreshToken = refreshToken,
                                };

                                httpClient.DefaultRequestHeaders.Add("User-Agent", currentUserAgent);

                                var json = JsonSerializer.Serialize(apiRequest);

                                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                                var result = await httpClient.PostWithCurlAsync(ApplicationConstants.PassoLigGsPlusRefreshTokenEndpoint, content, cancellationToken);

                                if (result.IsSuccessStatusCode)
                                {
                                    var resultJson = await result.Content.ReadAsStringAsync(cancellationToken);

                                    var resultJsonObject = JsonDocument.Parse(resultJson);

                                    var responseAccessToken = resultJsonObject.RootElement.GetProperty("payload").GetProperty("accessToken").GetString();
                                    var responseRefreshToken = resultJsonObject.RootElement.GetProperty("payload").GetProperty("refreshToken").GetString();

                                    return await SynchorinzeTokens(responseAccessToken, responseRefreshToken, cancellationToken);
                                }
                            }
                        }
                    }
                }
            }
        }

        return true;
    }

    public async ValueTask<bool> ApproveMainTokenAsync(PassoLigMainRequestGsmApproveRequestDto request, CancellationToken cancellationToken = new())
    {
        var providerSettings = await GetProviderSettings(cancellationToken);

        var currentUserAgent = await GetOrCreateUserAgent(providerSettings, cancellationToken);

        if (providerSettings.TryGetValue(ApplicationConstants.PassoLigMainPhoneNumberSettingsKey, out var mainPhoneGsmNumber))
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var apiRequest = new
                {
                    Otpcode = request.OtpCode,
                    PhoneNumber = mainPhoneGsmNumber,
                };

                httpClient.DefaultRequestHeaders.Add("User-Agent", currentUserAgent);

                var json = JsonSerializer.Serialize(apiRequest);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                await httpClient.PostWithCurlAsync(ApplicationConstants.PassoLigGsPlusApproveOtpCodeEndpoint, content, cancellationToken, true, CurlDefinitionType.Debug);
                var result = await httpClient.PostWithCurlAsync(ApplicationConstants.PassoLigGsPlusLoginWithCodeEndpoint, content, cancellationToken, true, CurlDefinitionType.Debug);

                if (result.IsSuccessStatusCode)
                {
                    var resultJson = await result.Content.ReadAsStringAsync(cancellationToken);

                    var resultJsonObject = JsonDocument.Parse(resultJson);

                    var accessToken = resultJsonObject.RootElement.GetProperty("payload").GetProperty("accessToken").GetString();
                    var refreshToken = resultJsonObject.RootElement.GetProperty("payload").GetProperty("refreshToken").GetString();

                    return await SynchorinzeTokens(accessToken, refreshToken, cancellationToken);
                }
            }
        }

        return false;
    }

    public async ValueTask<PassoLigLoginResponseModel> GetOrCreateCustomerPassoLigTokenDetailAsync(PassoLigLoginRequestModel request, CancellationToken cancellationToken = new())
    {
        var response = new PassoLigLoginResponseModel
        {
            Success = false,
        };

        var loginFormUrl = string.Empty;

        var providerSettings = await GetProviderSettings(cancellationToken);

        using (var httpClient = _httpClientFactory.CreateClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", providerSettings[ApplicationConstants.PassoLigGsMobileMainTokenSettingsKey]);

            var result = await httpClient.GetAsync(string.Format(ApplicationConstants.PassoLigLoginFormUrlRequestEndpoint, providerSettings[ApplicationConstants.PassoLigMainPhoneNumberSettingsKey]),
                cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                var responseString = await result.Content.ReadAsStringAsync(cancellationToken);

                var jsonContent = JsonDocument.Parse(responseString);

                loginFormUrl = jsonContent.RootElement.GetProperty("payload").GetProperty("url").GetString();
            }
        }


        if (loginFormUrl.IsNotNullOrEmptyAndWhiteSpace())
        {
            var accountDetail = await _ticketAccountDefinitionManager.GetByIdAsync(new TicketAccountDefinitionGetByIdRequestDto
            {
                Id = request.AccountId,
            }, cancellationToken).ConfigureAwait(false);

            if (accountDetail is { IsActive: true, TicketSystem: TicketSystemTypeEnum.PassoLig })
            {
                accountDetail.TicketSystemLoginInformation.TryGetValue("emailAddress", out var emailAddress);
                accountDetail.TicketSystemLoginInformation.TryGetValue("password", out var password);

                if (emailAddress.IsNotNullOrEmptyAndWhiteSpace() && password.IsNotNullOrEmptyAndWhiteSpace())
                {
                    var userApiTokenResult = await OpenBrowserAndGetUserPassoLigToken(loginFormUrl, emailAddress, password, cancellationToken);
                    if (userApiTokenResult.Count > 0)
                    {
                        response.Success = true;
                        response.LoginDetails = userApiTokenResult;
                    }
                }
            }
        }


        return response;
    }

    #region Private Methods

    private async ValueTask<bool> SynchorinzeTokens(string accessToken, string refreshToken, CancellationToken cancellationToken)
    {
        if (accessToken.IsNotNullOrEmptyAndWhiteSpace())
        {
            await _ticketProviderSettingsManager.UpdateAsync(new TicketProviderSettingUpdateRequestDto
            {
                Key = ApplicationConstants.PassoLigGsMobileMainTokenSettingsKey,
                Provider = TicketSystemTypeEnum.PassoLig,
                Value = accessToken,
            }, cancellationToken);

            var accssTokenHandler = new JwtSecurityTokenHandler();
            var accessTokenPayload = accssTokenHandler.ReadJwtToken(accessToken);

            if (accessTokenPayload.Payload.TryGetValue("exp", out var accessTokenExpiredDeail))
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(accessTokenExpiredDeail));
                DateTime dateTime = dateTimeOffset.LocalDateTime;

                await _ticketProviderSettingsManager.UpdateAsync(new TicketProviderSettingUpdateRequestDto
                {
                    Key = ApplicationConstants.PassoLigGsMobileMainTokenExpireDateSettingsKey,
                    Provider = TicketSystemTypeEnum.PassoLig,
                    Value = dateTime.ToString(),
                }, cancellationToken);
            }

            var refreshTokenHandler = new JwtSecurityTokenHandler();
            var refreshTokenPayload = refreshTokenHandler.ReadJwtToken(refreshToken);

            await _ticketProviderSettingsManager.UpdateAsync(new TicketProviderSettingUpdateRequestDto
            {
                Key = ApplicationConstants.PassoLigGsMobileMainRefreshTokenSettingsKey,
                Provider = TicketSystemTypeEnum.PassoLig,
                Value = refreshToken,
            }, cancellationToken);


            if (refreshTokenPayload.Payload.TryGetValue("exp", out var refreshTokenExpiredDetail))
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(refreshTokenExpiredDetail));
                DateTime dateTime = dateTimeOffset.LocalDateTime;

                await _ticketProviderSettingsManager.UpdateAsync(new TicketProviderSettingUpdateRequestDto
                {
                    Key = ApplicationConstants.PassoLigGsMobileMainRefreshTokenExpireDateSettingsKey,
                    Provider = TicketSystemTypeEnum.PassoLig,
                    Value = dateTime.ToString(),
                }, cancellationToken);
            }

            return true;
        }

        return false;
    }

    private async ValueTask<string> GetOrCreateUserAgent(Dictionary<string, string> providerSettings, CancellationToken cancellationToken)
    {
        var currentUserAgent = ApplicationConstants.UserAgents.GetRandom(1)?.FirstOrDefault();

        if (providerSettings.TryGetValue(ApplicationConstants.PassoLigGsMobileMainPhoneNumberUserAgentSettingsKey,
                out currentUserAgent) == false)
        {
            await _ticketProviderSettingsManager.UpdateAsync(new TicketProviderSettingUpdateRequestDto
            {
                Key = ApplicationConstants.PassoLigGsMobileMainPhoneNumberUserAgentSettingsKey,
                Provider = TicketSystemTypeEnum.PassoLig,
                Value = currentUserAgent,
            }, cancellationToken);
        }

        return currentUserAgent;
    }

    private async ValueTask<Dictionary<string, string>> GetProviderSettings(CancellationToken cancellationToken)
    {
        return await _ticketProviderSettingsManager.GetProviderSettingsAsync(
            new TicketProviderSettingGetByProviderRequestDto
            {
                Provider = TicketSystemTypeEnum.PassoLig,
            }, cancellationToken);
    }

    private async ValueTask<Dictionary<string, string>> OpenBrowserAndGetUserPassoLigToken(string url, string emailAddress, string password, CancellationToken cancellationToken)
    {
        var result = new Dictionary<string, string>();

        var rnd = new Random();

        var userAgent = ApplicationConstants.UserAgents.GetRandom(1)?.FirstOrDefault();

        using var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
            SlowMo = 50,
        });

        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            UserAgent = userAgent,
            ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
            Locale = "tr-TR",
            ScreenSize = new ScreenSize { Width = 1920, Height = 1080 },
            DeviceScaleFactor = 1.0f,
            IsMobile = false,
            HasTouch = false,

        });

        var page = await context.NewPageAsync();

        Debug.WriteLine("Sayfa yükleniyor: " + url);
        await page.GotoAsync(url);

        var responseTask = page.WaitForResponseAsync(r =>
            r.Url.Contains("/api/passoweb/oauth") && r.Status == 200);

        Thread.Sleep(rnd.Next(2_000, 8_000));

        await page.ClickAsync("input[autocomplete='username']");
        await Task.Delay(rnd.Next(2_000, 12_000), cancellationToken);
        await page.FillAsync("input[autocomplete='username']", emailAddress);

        await Task.Delay(rnd.Next(1_000, 6_000), cancellationToken);
        await page.ClickAsync("input[type='password']");
        await page.FillAsync("input[type='password']", password);

        await page.WaitForSelectorAsync("button.black-btn:has-text(\"GİRİŞ\")");
        await page.ClickAsync("button.black-btn:has-text(\"GİRİŞ\")");

        var response = await responseTask;
        if (response.Ok)
        {
            var body = await response.TextAsync();

            var loginBodyJson = JsonDocument.Parse(body);

            if (loginBodyJson.RootElement.GetProperty("isError").GetBoolean() == false)
            {
                result["accessToken"] = loginBodyJson.RootElement.GetProperty("value").GetProperty("access_token").GetString();
                result["refreshToken"] = loginBodyJson.RootElement.GetProperty("value").GetProperty("refresh_token").GetString();

                var expiredTokenDate = loginBodyJson.RootElement.GetProperty("value").GetProperty("expire_token_date")
                    .GetInt64();

                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(expiredTokenDate);
                result["expireDate"] = dateTimeOffset.LocalDateTime.ToString();
            }
        }

        return result;
    }
    #endregion
}