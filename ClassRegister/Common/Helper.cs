using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace ClassRegister.Common
{
    public static class Helper
    {
        public static byte[] HashPassword(string password, byte[] salt)
        {
            using var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8, // four cores
                Iterations = 4,
                MemorySize = 1024 // 1 GB
            };

            
            return argon2.GetBytes(16);
        }

        public static byte[] GenerateSalt()
        {
            var buffer = new byte[16];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(buffer);

            return buffer;
        }

        public static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        public static void MergeObjects<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
    }
}
