using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using AionShardLauncher.infra.dto;
using AionShardLauncher.infra.exception;
using AionShardLauncher.infra.game;
using AionShardLauncher.infra.loader;
using AionShardLauncher.infra.rest;

namespace AionShardLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string Default = "default";
        private const string ConfigTxt = "config.txt";

        public MainWindow()
        {
            InitializeComponent();
            GamePath.Text = ParseConfigFile.GetDefaultPath();
        }

        private void LaunchGame(object sender, RoutedEventArgs e)
        {
            var restClient = AionShardApiRestClient.GetInstance(ApiInfos.AionShard);
            var gamePath = GamePath.Text;
            try
            {
                var versionApi = restClient.GetVersionLauncher();
                if (!versionApi.Equals(Version.Launcher))
                {
                    MessageBox.Show("Launcher is not up to date");
                    return;
                }

                var aionServer = ServerInfos.Aion;

                var finalGamePath = ResolvePath(gamePath, aionServer);
                if (!File.Exists(finalGamePath))
                {
                    throw new PathException();
                }


                using (var writer = new StreamWriter(ConfigTxt))
                {
                    writer.Write(finalGamePath.Replace("/" + aionServer.Path, ""));
                }

                GameLauncher.Launch(finalGamePath, aionServer.Parameters);
            }
            catch (VersionException ve)
            {
                MessageBox.Show(ve.Message);
            }
            catch (PathException pe)
            {
                MessageBox.Show(pe.Message + " in " + gamePath);
            }
        }

        private string ResolvePath(string gamePath, ServerInfos aionServer)
        {
            var pathBuilder = new StringBuilder();
            if (gamePath.Equals(Default))
            {
                var directoryName = GetGamePath();
                pathBuilder.Append(directoryName);
            }
            else
            {
                pathBuilder.Append(gamePath);
            }

            if (!gamePath.EndsWith("/"))
            {
                pathBuilder.Append("/");
            }

            pathBuilder.Append(aionServer.Path);
            return pathBuilder.ToString();
        }

        private string GetGamePath()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null)
            {
                throw new PathException();
            }

            return Path.GetDirectoryName(entryAssembly.Location);
        }
    }
}