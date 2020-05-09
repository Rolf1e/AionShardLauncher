namespace AionShardLauncher.infra.dto
{
    public class ServerInfos
    {
        public static ServerInfos Aion = new ServerInfos("bin64/aion.bin",
            "-ip:51.178.130.119 -port:2106 -cc:2 -lang:eng -noweb -nowebshop -nokicks -ncg -noauthgg -ls -charnamemenu -ingameshop -loginex -win10-mouse-fix");

        public static ServerInfos Test = new ServerInfos("WINDOWS\\system32/notepad.exe", "");

        public readonly string Path;
        public readonly string Parameters;

        private ServerInfos(string path, string parameters)
        {
            Path = path;
            Parameters = parameters;
        }
    }
}