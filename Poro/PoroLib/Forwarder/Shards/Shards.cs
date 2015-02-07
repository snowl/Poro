using Newtonsoft.Json;
using PoroLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PoroLib.Forwarder.Shards
{
    public static class Shards
    {
        public static List<ShardStatus> GetStatus()
        {
            Random r = new Random();
            List<ShardStatus> Status = new List<ShardStatus>();
            using (var webClient = new System.Net.WebClient())
            {
                List<BaseShard> Shards = GetInstances<BaseShard>();

                foreach (BaseShard shard in Shards)
                {
                    string status = webClient.DownloadString("http://status.leagueoflegends.com/shards/" + shard.Name.ToLower());
                    Holder SerializedList = JsonConvert.DeserializeObject<Holder>(status);
                    foreach (Services s in SerializedList.services)
                    {
                        if (s.name == "Game")
                        {
                            Status.Add(new ShardStatus { name = shard.Name, status = s.status });
                        }
                    }
                }
            }
            return Status;
        }

        public static List<T> GetInstances<T>()
        {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == typeof(T) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T)Activator.CreateInstance(t)).ToList();
        }
    }

    class Holder
    {
        public string hostname { get; set; }
        public List<string> locales { get; set; }
        public string name { get; set; }
        public string region_tag { get; set; }
        public List<Services> services { get; set; }
    }

    class Services
    {
        public List<object> incidents { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
    }

    public class ShardStatus
    {
        public string name { get; set; }
        public string status { get; set; }
    }
}
