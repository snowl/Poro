
using System.Collections.Generic;
namespace PoroLib.Data.JSON
{
    public class Masteries
    {
        public string type { get; set; }

        public string version { get; set; }

        public Dictionary<int, MasteryData> data { get; set; }

        public Dictionary<string, List<List<MasteryLite>>> tree { get; set; }
    }
}
