namespace PoroLib
{
    public class PoroServerSettings
    {
        public string RTMPSHost = "192.168.1.149";
        public int RTMPSPort = 2099;
        public string[] AuthLocations = new string[] { "http://localhost:8080/login-queue/rest/queue/authenticate/", "http://localhost:8080/login-queue/rest/queues/lol/authenticate/" };
        public string CertFilename = "localhost.p12";
    }
}
