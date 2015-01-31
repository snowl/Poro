
namespace PoroLib.Forwarder.Shards
{
    public class OCE : BaseShard
    {
        public override string Name { get { return "OCE"; } }
        public override string URL { get { return "prod.oc1.lol.riotgames.com"; } }
        public override string Locale { get { return "en_US"; } }
        public override string LoginQueue { get { return "https://lq.oc1.lol.riotgames.com/"; } }
    }
}
