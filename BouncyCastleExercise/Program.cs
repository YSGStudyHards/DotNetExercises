using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace BouncyCastleExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region AES加密解密示例

            string aesPlaintext = "Hello, 追逐时光者！！！";
            byte[] aesKey = new byte[16];
            byte[] aesIV = new byte[16];
            byte[] aesCiphertext = EncryptAES(aesPlaintext, aesKey, aesIV);
            string decryptedAesPlaintext = DecryptAES(aesCiphertext, aesKey, aesIV);

            Console.WriteLine("AES plaintext: " + aesPlaintext);
            Console.WriteLine("AES ciphertext: " + Convert.ToBase64String(aesCiphertext));
            Console.WriteLine("Decrypted AES plaintext: " + decryptedAesPlaintext);

            #endregion

            #region DES 加密解密示例

            string desPlaintext = "Hello, DES!";
            byte[] desKey = new byte[8];
            byte[] desIV = new byte[8];

            byte[] desCiphertext = EncryptDES(desPlaintext, desKey, desIV);
            string decryptedDesPlaintext = DecryptDES(desCiphertext, desKey, desIV);

            Console.WriteLine("DES plaintext: " + desPlaintext);
            Console.WriteLine("DES ciphertext: " + Convert.ToBase64String(desCiphertext));
            Console.WriteLine("Decrypted DES plaintext: " + decryptedDesPlaintext);

            #endregion

            #region RC4 加密解密示例

            string rc4Plaintext = "Hello, RC4!";
            byte[] rc4Key = new byte[16];

            byte[] rc4Ciphertext = EncryptRC4(rc4Plaintext, rc4Key);
            string decryptedRc4Plaintext = DecryptRC4(rc4Ciphertext, rc4Key);

            Console.WriteLine("RC4 plaintext: " + rc4Plaintext);
            Console.WriteLine("RC4 ciphertext: " + Convert.ToBase64String(rc4Ciphertext));
            Console.WriteLine("Decrypted RC4 plaintext: " + decryptedRc4Plaintext);

            #endregion

            #region 哈希算法示例

            // MD5 示例
            string md5Plaintext = "Hello, MD5!";
            string md5Hash = CalculateMD5Hash(md5Plaintext);
            Console.WriteLine("MD5 hash of 'Hello, MD5!': " + md5Hash);

            // SHA1 示例
            string sha1Plaintext = "Hello, SHA1!";
            string sha1Hash = CalculateSHA1Hash(sha1Plaintext);
            Console.WriteLine("SHA1 hash of 'Hello, SHA1!': " + sha1Hash);

            // SHA256 示例
            string sha256Plaintext = "Hello, SHA256!";
            string sha256Hash = CalculateSHA256Hash(sha256Plaintext);
            Console.WriteLine("SHA256 hash of 'Hello, SHA256!': " + sha256Hash);

            #endregion
        }

        #region AES加密解密示例

        /// <summary>
        /// AES 加密方法
        /// </summary>
        /// <param name="plaintext">plaintext</param>
        /// <param name="key">key</param>
        /// <param name="iv">iv</param>
        /// <returns></returns>
        public static byte[] EncryptAES(string plaintext, byte[] key, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/PKCS7Padding");
            cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", key), iv));
            return cipher.DoFinal(System.Text.Encoding.UTF8.GetBytes(plaintext));
        }

        /// <summary>
        /// AES 解密方法
        /// </summary>
        /// <param name="ciphertext">ciphertext</param>
        /// <param name="key">key</param>
        /// <param name="iv">iv</param>
        /// <returns></returns>
        public static string DecryptAES(byte[] ciphertext, byte[] key, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/PKCS7Padding");
            cipher.Init(false, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", key), iv));
            byte[] plaintext = cipher.DoFinal(ciphertext);
            return System.Text.Encoding.UTF8.GetString(plaintext);
        }

        #endregion

        #region DES 加密解密示例

        /// <summary>
        /// DES 加密方法
        /// </summary>
        /// <param name="plaintext">plaintext</param>
        /// <param name="key">key</param>
        /// <param name="iv">iv</param>
        /// <returns></returns>
        public static byte[] EncryptDES(string plaintext, byte[] key, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("DES/CBC/PKCS7Padding");
            cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("DES", key), iv));
            return cipher.DoFinal(System.Text.Encoding.UTF8.GetBytes(plaintext));
        }

        /// <summary>
        /// DES 解密方法
        /// </summary>
        /// <param name="ciphertext">ciphertext</param>
        /// <param name="key">key</param>
        /// <param name="iv">iv</param>
        /// <returns></returns>
        public static string DecryptDES(byte[] ciphertext, byte[] key, byte[] iv)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("DES/CBC/PKCS7Padding");
            cipher.Init(false, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("DES", key), iv));
            byte[] plaintext = cipher.DoFinal(ciphertext);
            return System.Text.Encoding.UTF8.GetString(plaintext);
        }

        #endregion

        #region RC4 加密解密示例

        /// <summary>
        /// RC4 加密方法
        /// </summary>
        /// <param name="plaintext">plaintext</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static byte[] EncryptRC4(string plaintext, byte[] key)
        {
            IStreamCipher cipher = new RC4Engine();
            cipher.Init(true, new KeyParameter(key));
            byte[] data = System.Text.Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertext = new byte[data.Length];
            cipher.ProcessBytes(data, 0, data.Length, ciphertext, 0);
            return ciphertext;
        }

        /// <summary>
        /// RC4 解密方法
        /// </summary>
        /// <param name="ciphertext">ciphertext</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string DecryptRC4(byte[] ciphertext, byte[] key)
        {
            IStreamCipher cipher = new RC4Engine();
            cipher.Init(false, new KeyParameter(key));
            byte[] plaintext = new byte[ciphertext.Length];
            cipher.ProcessBytes(ciphertext, 0, ciphertext.Length, plaintext, 0);
            return System.Text.Encoding.UTF8.GetString(plaintext);
        }

        #endregion

        #region 哈希算法示例

        /// <summary>
        /// 计算 MD5 哈希
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {
            IDigest digest = new MD5Digest();
            byte[] hash = new byte[digest.GetDigestSize()];
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(data, 0, data.Length);
            digest.DoFinal(hash, 0);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// 计算 SHA1 哈希
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public static string CalculateSHA1Hash(string input)
        {
            IDigest digest = new Sha1Digest();
            byte[] hash = new byte[digest.GetDigestSize()];
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(data, 0, data.Length);
            digest.DoFinal(hash, 0);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// 计算 SHA256 哈希
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public static string CalculateSHA256Hash(string input)
        {
            IDigest digest = new Sha256Digest();
            byte[] hash = new byte[digest.GetDigestSize()];
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            digest.BlockUpdate(data, 0, data.Length);
            digest.DoFinal(hash, 0);
            return Convert.ToBase64String(hash);
        }

        #endregion

    }
}
