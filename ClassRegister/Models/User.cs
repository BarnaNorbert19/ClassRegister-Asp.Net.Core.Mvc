﻿using ClassRegister.Common;
using ClassRegister.Models.Tables;

namespace ClassRegister.Models
{
    /// <summary>
    /// Wraps together the persons and the accounts table
    /// </summary>
    public class User
    {
        public string Id { get => UserInfo.Id; }
        public Accounts? UserAccount { get; set; }
        public Persons? UserInfo { get; set; }

        public User(Accounts? userAccount, Persons? userInfo)
        {
            UserAccount = userAccount;
            UserInfo = userInfo;
        }

        public User()
        { }

        public bool GenerateUserData()
        {
            if (!IsRequiredDataProvided() || !Roles.IsRole(UserAccount.Role))
                return false;


            string id = Guid.NewGuid().ToString();
            byte[] salt = Helper.GenerateSalt();

            UserInfo.Id = id;
            UserInfo.Accounts = UserAccount;

            UserAccount.Id = id;
            UserAccount.Persons = UserInfo;
            UserAccount.Salt = Convert.ToBase64String(salt);

            UserAccount.Password = Convert.ToBase64String(Helper.HashPassword(UserAccount.Password, salt));

            return true;
        }

        private bool IsRequiredDataProvided()
        {
            if (UserInfo.Firstname is null || UserInfo.Lastname is null || UserAccount.LoginName is null || UserAccount.Password is null)
                return false;

            return true;
        }

        public void IsInputSecure()
        {
            if (UserInfo.Accounts is not null && UserAccount.Salt is not null)
                throw new Exception($"Insecure input values: UserInfo.Accounts->value:{UserInfo.Accounts} UserAccount.Salt->value:{UserAccount.Salt}");
        }
    }
}
