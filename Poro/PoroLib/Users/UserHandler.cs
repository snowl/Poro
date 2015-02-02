using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace PoroLib.Users
{
    public class UserHandler
    {
        private Guid _uniqueGuid;

        public UserHandler()
        {
            if (!Directory.Exists(Path.Combine("app", "user")))
                Directory.CreateDirectory(Path.Combine("app", "user"));

            string MAC = GetMacAddress();
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(MAC));
                _uniqueGuid = new Guid(hash);

                if (!File.Exists(Path.Combine("app", "user", _uniqueGuid.ToString())))
                    File.Create(Path.Combine("app", "user", _uniqueGuid.ToString())).Dispose();
            }
        }

        public void AddUser(User Person)
        {
            if (!File.Exists(Path.Combine("app", "user", _uniqueGuid.ToString())))
                throw new Exception("Users database is missing.");

            string Database = File.ReadAllText(Path.Combine("app", "user", _uniqueGuid.ToString()));
            List<User> UserList = JsonConvert.DeserializeObject<List<User>>(Database);

            if (UserList == null)
                UserList = new List<User>();

            foreach (User DatabaseUser in UserList)
            {
                if (DatabaseUser.Username == Person.Username
                   && DatabaseUser.Region == Person.Region)
                    return;
            }

            Person.Password = DPAPI.Encrypt(DPAPI.KeyType.UserKey,
                                              Person.Password,
                                              null, //Could possibly use as a password required to login
                                              "evidence.zip"); //just a random note if base64 is decoded

            UserList.Add(Person);

            File.WriteAllText(Path.Combine("app", "user", _uniqueGuid.ToString()), JsonConvert.SerializeObject(UserList));
        }

        /// <summary>
        /// Remove a user from the user file.
        /// </summary>
        /// <param name="Person">The user to remove.</param>
        public void RemoveUser(User Person)
        {
            if (!File.Exists(Path.Combine("app", "user", _uniqueGuid.ToString())))
                throw new Exception("Users database is missing.");

            string Database = File.ReadAllText(Path.Combine("app", "user", _uniqueGuid.ToString()));
            List<User> UserList = JsonConvert.DeserializeObject<List<User>>(Database);

            if (UserList == null)
                UserList = new List<User>();

            foreach (User DatabaseUser in UserList.ToArray())
            {
                if (DatabaseUser.Username == Person.Username
                   && DatabaseUser.Region == Person.Region)
                    UserList.Remove(DatabaseUser);
            }

            File.WriteAllText(Path.Combine("app", "user", _uniqueGuid.ToString()), JsonConvert.SerializeObject(UserList));
        }

        /// <summary>
        /// Gets a user based on their username & region
        /// </summary>
        /// <param name="Name">The username of the user</param>
        /// <param name="Region">The shard region of the user.</param>
        /// <returns>The requested user.</returns>
        public User GetUser(string Name, string Region)
        {
            if (!File.Exists(Path.Combine("app", "user", _uniqueGuid.ToString())))
                throw new Exception("Users database is missing.");

            string Database = File.ReadAllText(Path.Combine("app", "user", _uniqueGuid.ToString()));
            List<User> UserList = JsonConvert.DeserializeObject<List<User>>(Database);

            if (UserList == null)
                UserList = new List<User>();

            foreach (User DatabaseUser in UserList)
            {
                if (DatabaseUser.Username == Name
                   && DatabaseUser.Region == Region)
                    return DatabaseUser;
            }

            return null;
        }

        /// <summary>
        /// Gets a list of all the users without passwords
        /// </summary>
        /// <returns>A list of users without passwords</returns>
        public List<User> GetUserList()
        {
            if (!File.Exists(Path.Combine("app", "user", _uniqueGuid.ToString())))
                throw new Exception("Users database is missing.");

            string Database = File.ReadAllText(Path.Combine("app", "user", _uniqueGuid.ToString()));
            List<User> UserList = JsonConvert.DeserializeObject<List<User>>(Database);

            if (UserList == null)
                UserList = new List<User>();

            //Don't leak any information we don't want to give out
            foreach (User u in UserList)
                u.Password = "";

            return UserList;
        }

        /// <summary>
        /// Gets the mac address of the user.
        /// </summary>
        /// <returns>The mac address of the user</returns>
        private string GetMacAddress()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            if (string.IsNullOrEmpty(mac))
            {
                mac = "empty";
            }
            return mac.Replace(":", "");
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string SummonerName { get; set; }
        public string Password { get; set; }
        public string Region { get; set; }
    }
}
