using System.Diagnostics;

namespace AionShardLauncher.infra.game
{
    public class GameLauncher
    {

        private const string Start = "start ";
        public void Launch(string name, string parameter)
        {
            ProcessStartInfo info = new ProcessStartInfo(name, parameter);
            info.UseShellExecute = false;
            Process process = new Process {StartInfo = info};
            process.Start();
        }
    }
}