/*
 * Author: BouncyCastle.
 * Website: https://github.com/Infymus/vaultasaur
*/

﻿using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace VaultASaur3.Encryption
{
    public static class EncryptDecrypt
    {
        private const int SaltSize = 16;
        private const int Iterations = 10000;
        private const int KeySize = 256;

        public static string Encrypt(string plainText, string passphrase)
        {
            var salt = GenerateRandomBytes(SaltSize);
            var key = GenerateKey(passphrase, salt);

            var engine = new PaddedBufferedBlockCipher(new AesEngine());
            engine.Init(true, new KeyParameter(key));

            var inputBytes = Encoding.UTF8.GetBytes(plainText);
            var outputBytes = engine.DoFinal(inputBytes);

            // Combine salt and encrypted bytes
            var result = new byte[salt.Length + outputBytes.Length];
            Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
            Buffer.BlockCopy(outputBytes, 0, result, salt.Length, outputBytes.Length);

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string cipherText, string passphrase)
        {
            var inputBytes = Convert.FromBase64String(cipherText);

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(inputBytes, 0, salt, 0, SaltSize);

            var encryptedBytes = new byte[inputBytes.Length - SaltSize];
            Buffer.BlockCopy(inputBytes, SaltSize, encryptedBytes, 0, encryptedBytes.Length);

            var key = GenerateKey(passphrase, salt);
            var engine = new PaddedBufferedBlockCipher(new AesEngine());
            engine.Init(false, new KeyParameter(key));

            var decrypted = engine.DoFinal(encryptedBytes);
            return Encoding.UTF8.GetString(decrypted);
        }

        private static byte[] GenerateKey(string passphrase, byte[] salt)
        {
            var generator = new Pkcs5S2ParametersGenerator();
            generator.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(passphrase.ToCharArray()), salt, Iterations);
            var keyParam = (KeyParameter)generator.GenerateDerivedMacParameters(KeySize);
            return keyParam.GetKey();
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            var random = new SecureRandom();
            var bytes = new byte[length];
            random.NextBytes(bytes);
            return bytes;
        }
    }
}
