using System;
using System.Text;
using System.Windows;
using AionShardLauncher.infra.dto;
using AionShardLauncher.infra.game;
using AionShardLauncher.infra.rest;

namespace AionShardLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchGame(object sender, RoutedEventArgs e)
        {
            AionShardApiRestClient restClient = AionShardApiRestClient.GetInstance(ApiInfos.AionShard);
            string versionApi = restClient.GetVersionLauncher();
            if (versionApi.Equals(infra.dto.Version.Launcher))
            {
                GameLauncher gameLauncher = new GameLauncher();
                AionGame aionGame = AionGame.Aion;
                StringBuilder path = new StringBuilder(GamePath.Text);

                if (!GamePath.Text.EndsWith("/"))
                {
                    path.Append("/");
                }

                path.Append(aionGame.Path);
                gameLauncher.Launch(path.ToString(), aionGame.Parameters);
            }
        }
    }
}