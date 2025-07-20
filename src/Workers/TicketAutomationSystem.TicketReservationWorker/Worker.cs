using Microsoft.Playwright;

namespace TicketAutomationSystem.TicketReservationWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var rnd = new Random();

            string username = "....";
            string password = "....";

            using var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                UserAgent
                    = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0 Safari/537.36",
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                Locale = "tr-TR",
                ScreenSize = new ScreenSize { Width = 1920, Height = 1080 },
                DeviceScaleFactor = 1.0f,
                IsMobile = false,
                HasTouch = false,
            });

            var page = await context.NewPageAsync();

            var url
                = "https://passo.com.tr/tr/oauth?oauthClientId=e56bf1e4-0c46-3332-c3ca-803789069727&oauthClientVerifier=4108a9918b8c0a98c2baf4cfd1caf527ea58b12d6a17ed09e140aafbd2f7d279&utcTime=20250714213703&identifier=3fb97105-6c79-4c04-80b4-d2682c9f8e6f";

            Console.WriteLine("Sayfa yükleniyor: " + url);
            await page.GotoAsync(url);

            var responseTask = page.WaitForResponseAsync(r =>
                r.Url.Contains("/api/passoweb/oauth") && r.Status == 200);

            Thread.Sleep(5_000);
            await page.ClickAsync("input[autocomplete='username']");
            await Task.Delay(500, stoppingToken);
            await page.FillAsync("input[autocomplete='username']", username);

            await Task.Delay(1500, stoppingToken);
            await page.ClickAsync("input[type='password']");
            await page.FillAsync("input[type='password']", password);

            await page.WaitForSelectorAsync("button.black-btn:has-text(\"GİRİŞ\")");
            await page.ClickAsync("button.black-btn:has-text(\"GİRİŞ\")");

            var response = await responseTask;
            var body = await response.TextAsync();

            Thread.Sleep(500_000);
        }
    }
}