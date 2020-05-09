namespace AionShardLauncher.infra.dto
{
    public class AionGame
    {
        public static AionGame Aion = new AionGame("bin64/aion.bin",
            "-ip:51.178.130.119 -port:2106 -cc:2 -lang:eng -noweb -nowebshop -nokicks -ncg -noauthgg -ls -charnamemenu -ingameshop -loginex -win10-mouse-fix");

        public static AionGame Test = new AionGame("WINDOWS\\system32/notepad.exe", "");

        public readonly string Path;
        public readonly string Parameters;

        private AionGame(string path, string parameters)
        {
            Path = path;
            Parameters = parameters;
        }
    }
}