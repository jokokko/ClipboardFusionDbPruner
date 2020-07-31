using System;
using System.Globalization;
using System.Text;

namespace ClipboardFusionDbPruner.Services
{
    internal static class StringHelper
    {
        public static string Get()
        {
            return Xor(Base64Decode("Rx8QdxRCDGAAEVgBbWgUXgg="), Math.Round(Math.PI, 15).ToString(CultureInfo.InvariantCulture));
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private static string Xor(string text, string key)
        {
            var result = new StringBuilder();

            for (var c = 0; c < text.Length; c++)
                result.Append((char)(text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
    }
}