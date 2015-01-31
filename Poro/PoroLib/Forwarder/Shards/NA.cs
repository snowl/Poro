
namespace PoroLib.Forwarder.Shards
{
    public class NA : BaseShard
    {
        public override string Name { get { return "NA"; } }
        public override string URL { get { return "prod.na1.lol.riotgames.com"; } }
        public override string Locale { get { return "en_US"; } }
        public override string LoginQueue { get { return "https://lq.na1.lol.riotgames.com/"; } }

    }
}
