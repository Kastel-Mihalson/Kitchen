namespace Kitchen.Common.Utils
{
    public static class PasswordHashingManager
    {
        public static string HashPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
