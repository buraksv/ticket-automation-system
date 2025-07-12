using System.Security.Cryptography;
using System.Text;

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
            string username = "buraksavaskan@gmail.com";
            string password = "951214Gs!";
            string captchaGuid = "c2d295d2-2b7b-40f9-80e8-cc382fdbf478";

            string encryptedUserName = CryptoHelper.EncryptUserName(username, captchaGuid);
            string encryptedPassword = CryptoHelper.EncryptUserName(password, captchaGuid);
            Console.WriteLine(encryptedUserName);
            Console.WriteLine(encryptedPassword);
        }
    }
}

public static class CryptoHelper
{
    public static string EncryptUserName(string userName, string captchaGuid)
    {
        // 1. Key: captchaGuid'in "-" karakterleri silinir, ilk 16 karakter alınır
        string keyStr = captchaGuid.Replace("-", "").Substring(0, 16);
        byte[] key = Encoding.UTF8.GetBytes(keyStr);

        // 2. IV: 16 byte'lık random veri
        byte[] iv = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(iv);
        }

        // 3. PKCS7 padding ile plaintext'i hazırla
        byte[] plainBytes = PadPkcs7(Encoding.UTF8.GetBytes(userName), 16);

        // 4. AES-128-CBC ile şifrele
        byte[] encrypted;
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None; // Padding'i kendimiz yaptık!

            using (var encryptor = aes.CreateEncryptor())
            {
                encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
        }

        // 5. IV ve ciphertext'i birleştir ve base64 encode et
        byte[] combined = new byte[iv.Length + encrypted.Length];
        Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
        Buffer.BlockCopy(encrypted, 0, combined, iv.Length, encrypted.Length);
        return Convert.ToBase64String(combined);
    }

    // PKCS7 padding fonksiyonu
    public static byte[] PadPkcs7(byte[] data, int blockSize)
    {
        int pad = blockSize - (data.Length % blockSize);
        byte[] padded = new byte[data.Length + pad];
        Buffer.BlockCopy(data, 0, padded, 0, data.Length);
        for (int i = data.Length; i < padded.Length; i++)
            padded[i] = (byte)pad;
        return padded;
    }
}