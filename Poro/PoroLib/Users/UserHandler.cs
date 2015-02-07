using LiteDB;
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
        private string _uniqueGuid;
        private string _location;

        public UserHandler()
        {
            if (!Directory.Exists(Path.Combine("app", "user")))
                Directory.CreateDirectory(Path.Combine("app", "user"));

            string MAC = GetMacAddress();
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(MAC));
                _uniqueGuid = new Guid(hash).ToString().Replace("-", "").Substring(0, 30);
            }

            _location = Path.Combine("app", "user", "users");
        }

        private int GetIndex(IEnumerable<User> inumeration)
        {
            int Index = 1;
            foreach(User u in inumeration)
            {
                if (u.Id >= Index)
                {
                    Index = u.Id + 1;
                }
            }
            return Index;
        }

        public void AddUser(User Person)
        {
            using (var db = new LiteEngine(_location))
            {
                var col = db.GetCollection<User>(_uniqueGuid);

                var allUsers = col.All();
                foreach (User u in allUsers)
                {
                    if (u.Username == Person.Username &&
                        u.Region == Person.Region)
                    {
                        throw new Exception("User already exists!");
                    }
                }

                Person.Id = GetIndex(col.All());
                Person.Password = DPAPI.Encrypt(DPAPI.KeyType.UserKey,
                                              Person.Password,
                                              null, //Could possibly use as a password required to login
                                              "evidence.zip"); //just a random note if base64 is decoded

                col.Insert(Person);
            }
        }

        /// <summary>
        /// Remove a user from the user file.
        /// </summary>
        /// <param name="Person">The user to remove.</param>
        public void RemoveUser(User Person)
        {
            using (var db = new LiteEngine(_location))
            {
                var col = db.GetCollection<User>(_uniqueGuid);

                var allUsers = col.All();
                foreach (User u in allUsers)
                {
                    if (u.Username == Person.Username &&
                        u.Region == Person.Region)
                    {
                        col.Delete(u.Id);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a user based on their username & region
        /// </summary>
        /// <param name="Name">The username of the user</param>
        /// <param name="Region">The shard region of the user.</param>
        /// <returns>The requested user.</returns>
        public User GetUser(string Name, string Region)
        {
            using (var db = new LiteEngine(_location))
            {
                var col = db.GetCollection<User>(_uniqueGuid);

                var allUsers = col.All();
                foreach (User u in allUsers)
                {
                    if (u.Username == Name &&
                        u.Region == Region)
                    {
                        return u;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a list of all the users without passwords
        /// </summary>
        /// <returns>A list of users without passwords</returns>
        public List<User> GetUserList()
        {
            using (var db = new LiteEngine(_location))
            {
                var col = db.GetCollection<User>(_uniqueGuid);

                var allUsers = col.All();
                foreach (User u in allUsers)
                {
                    u.Password = "";
                }
                return allUsers.ToList();
            }
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
        public int Id { get; set; }
        public string Username { get; set; }
        public string SummonerName { get; set; }
        public string Password { get; set; }
        public string Region { get; set; }
    }
}
