
namespace PoroLib.Forwarder.Shards
{
    public abstract class BaseShard
    {
        public abstract string Name { get; }
        public abstract string URL { get; }
        public abstract string Locale { get; }
        public abstract string LoginQueue { get; }
    }
}
