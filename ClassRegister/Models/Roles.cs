namespace ClassRegister.Models
{
    public static class Roles
    {
        public const string Admin = "admin";
        public const string Teacher = "teacher";
        public const string Student = "student";

        public static bool IsRole(string input)
        {
            if (input != Admin && input != Teacher && input != Student)
                return false;

            return true;
        }
    }
}
