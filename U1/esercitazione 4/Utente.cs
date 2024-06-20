using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercitazione_4

{
    static class Utente
    {
        private static Dictionary<string, string> registeredUsers = new Dictionary<string, string>
        {
            { "admin", "GCHEFF" } // Admin predefinito
        };

        public static string? Username { get; private set; }
        private static string? Password { get; set; }
        public static DateTime? LoginTime { get; private set; }
        public static List<string> AccessList { get; private set; } = new List<string>();

        public static bool Register(string username, string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(username) && password == confirmPassword)
            {
                if (!registeredUsers.ContainsKey(username))
                {
                    registeredUsers[username] = password;
                    return true;
                }
                else
                {
                    Console.WriteLine("Username già esistente. Scegli un altro username.");
                    return false;
                }
            }
            return false;
        }

        public static bool Login(string username, string password)
        {
            if (registeredUsers.ContainsKey(username) && registeredUsers[username] == password)
            {
                Username = username;
                Password = password;
                LoginTime = DateTime.Now;
                AccessList.Add($"{LoginTime}: {Username}");
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            Username = null;
            Password = null;
            LoginTime = null;
        }

        public static DateTime? GetLoginTime()
        {
            return LoginTime;
        }

        public static List<string> GetAccessList()
        {
            return AccessList;
        }

        public static bool IsAdmin()
        {
            return Username == "admin";
        }
    }
}
