
using System.Collections.Generic;
namespace PoroLib.Data.JSON
{
    public class MasteryData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string preReq { get; set; }
        public int ranks { get; set; }
        public List<string> description { get; set; }
    }
}
