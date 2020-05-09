using System;

namespace AionShardLauncher.infra.exception
{
    public class PathException : Exception
    {
        public PathException() : base("Failed to find game")
        {
        }
    }
}