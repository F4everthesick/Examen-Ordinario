using Examen_Ordinario.Models.DBComprasTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Examen_Ordinario.Controller
{
    public class ValidarLogin
    {
        private readonly string encryptionKey = "12345"; // Tu clave de cifrado

        // Método para cifrar texto
        public string Encrypt(string plainText)
        {
            // Ajustar la clave a 16 bytes
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey.PadRight(16));

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.GenerateIV();
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted;

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); // Guardar IV al inicio
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                    }
                    encrypted = ms.ToArray();
                }
                return Convert.ToBase64String(encrypted);
            }
        }

        // Método para descifrar texto
        public string Decrypt(string encryptedText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey.PadRight(16));
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] iv = new byte[16]; // AES usa un IV de 16 bytes
                Array.Copy(encryptedBytes, iv, iv.Length);
                aes.IV = iv;

                byte[] cipherText = new byte[encryptedBytes.Length - iv.Length];
                Array.Copy(encryptedBytes, iv.Length, cipherText, 0, cipherText.Length);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                        cs.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        // Método para validar usuario
        public bool ValidarUsuario(string usuario, string contrasenaIngresada)
        {
            // Usuario y contraseña de prueba
            string usuarioBase = "klopez";
            string contrasenaBaseCifrada = Encrypt("12345"); // Cifrar contraseña base

            // Validar usuario
            if (usuario == usuarioBase)
            {
                string contrasenaIngresadaCifrada = Encrypt(contrasenaIngresada); // Cifrar la ingresada
                return contrasenaBaseCifrada == contrasenaIngresadaCifrada; // Comparar
            }
            return false;
        }
    }
}