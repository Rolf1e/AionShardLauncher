using System.Diagnostics;

namespace AionShardLauncher.infra.game
{
    public static class GameLauncher
    {
        public static void Launch(string name, string parameter)
        {
            var info = new ProcessStartInfo();
            info.FileName = name;
            info.Arguments = parameter;
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }
    }
}