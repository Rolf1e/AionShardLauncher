namespace AionShardLauncher.infra.dto
{
    public class ApiInfos
    {
        public static ApiInfos AionShard = new ApiInfos("api.aion-shard.com", 8081);
        
        public readonly string Url;
        public readonly int Port;

        ApiInfos(string url, int port)
        {
            Url = url;
            Port = port;
        }
    }
}