﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lektion24.Models.Repositories;
using System.Text;
using Lektion24.Models.Entities;
using BCrypt.Net;

namespace Lektion24.Models.Membership
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password,
               string email, string passwordQuestion, string passwordAnswer,
               bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args =
               new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser user = GetUser(username, true);

            if (user == null)
            {
                User newUser = new User();
                newUser.UserName = username;
                newUser.Salt = BCrypt.Net.BCrypt.GenerateSalt();
                newUser.PasswordHash = GetBcryptHash(password, newUser.Salt);
                newUser.Email = email;

                IUserRepository userRepo = new UserRepository();
                userRepo.RegisterUser(newUser);

                status = MembershipCreateStatus.Success;

                return GetUser(username, true);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            IUserRepository userRepo = new UserRepository();
            var user = userRepo.FindAll(u => u.UserName == username).FirstOrDefault();
            if (user != null)
            {
                MembershipUser memUser = new MembershipUser("CustomMembershipProvider",
                                               username, user.ID, user.Email,
                                               string.Empty, string.Empty,
                                               true, false, DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.MinValue,
                                               DateTime.Now, DateTime.Now);
                return memUser;
            }
            return null;
        }

        public override bool ValidateUser(string username, string password)
        {
            IUserRepository userRepo = new UserRepository();
            var user = userRepo.FindAll(u => u.UserName.ToLower() == username.ToLower()).FirstOrDefault();
            if (user == null || string.IsNullOrEmpty(user.Salt))
                return false;
            string bcryptHash = GetBcryptHash(password, user.Salt);
            if (bcryptHash == user.PasswordHash)
                return true;
            return false;
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override bool RequiresUniqueEmail
        {
            // In a real application, you will essentially have to return true
            // and implement the GetUserNameByEmail method to identify duplicates
            get { return false; }
        }

        public static string GetBcryptHash(string value, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(value, salt);
        }


        // Change these?
        public override MembershipPasswordFormat PasswordFormat { get { return MembershipPasswordFormat.Hashed; } }        
        public override string ApplicationName { get; set; }
        public override bool EnablePasswordReset { get { return false; } }
        public override bool EnablePasswordRetrieval { get { return false; } }
        public override int MaxInvalidPasswordAttempts { get { return 15; } }
        public override int MinRequiredNonAlphanumericCharacters { get { return 0; } }
        public override int PasswordAttemptWindow { get { return 15; } }
        public override bool RequiresQuestionAndAnswer { get { return false; } }
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            IUserRepository userRepo = new UserRepository();
            try
            {
                userRepo.DeleteUserByUserName(username);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string GetUserNameByEmail(string email)
        {
            IUserRepository userRepo = new UserRepository();
            return userRepo.FindAll(u => u.Email == email).Select(u => u.UserName).FirstOrDefault();
        }

        // Not Implemented:

        public override string PasswordStrengthRegularExpression { get { throw new NotImplementedException(); } }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
            //IAppUserRepository userRepo = new AppUserRepository();
            //return userRepo.FindAll().Select(u => new MembershipUser("CustomMembershipProvider",
            //                                   u.UserName, u.ID, u.UserEmailAddress,
            //                                   string.Empty, string.Empty,
            //                                   true, false, DateTime.MinValue,
            //                                   DateTime.MinValue,
            //                                   DateTime.MinValue,
            //                                   DateTime.Now, DateTime.Now));
        }
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        // Not Used:

        //protected virtual byte[] DecryptPassword(byte[] encodedPassword);

        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        //protected virtual byte[] EncryptPassword(byte[] password);

        //protected virtual byte[] EncryptPassword(byte[] password, MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode);
    }
}