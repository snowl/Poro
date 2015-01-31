namespace PoroLib.Redirector.Properties
{
    class PoroProperties
    {
        private string _host = "snowl.local";
        private string _xmpp_server_url = "chat.oc1.lol.riotgames.com";
        private string _lq_uri = "http://localhost:8080";//"https://lq.oc1.lol.riotgames.com";
        private string _lobbyLandingURL = "http://localhost:8080";
        private string _featuredGamesURL = "http://spectator.oc1.lol.riotgames.com:80/observer-mode/rest/featured";

        //-------------------------------------------------------------------------------------

        public string host { get { return _host; } set { _host = value; } }

        public string xmpp_server_url { get { return _xmpp_server_url; } set { _xmpp_server_url = value; } }

        public string ladderURL { get { return "http://www.leagueoflegends.com/ladders"; } }

        public string storyPageURL { get { return "http://www.leagueoflegends.com/story"; } }

        public string lq_uri { get { return _lq_uri; } set { _lq_uri = value; } }

        public string ekg_uri { get { return "https://ekg.riotgames.com"; } }

        public string rssStatusURLs { get { return "null"; } }

        public string lobbyLandingURL { get { return _lobbyLandingURL; } set { _lobbyLandingURL = value; } }

        public string loadModuleChampionDetail { get { return "true"; } }

        public string featuredGamesURL { get { return _featuredGamesURL; } set { _featuredGamesURL = value; } }

        public string riotDataServiceDataSendProbability { get { return "1.0"; } }

        public string platformId { get { return "OC1"; } }

        public string regionTag { get { return "oce"; } }
    }
}
