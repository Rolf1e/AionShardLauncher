using System;

namespace AionShardLauncher.infra.exception
{
    public class VersionException  : Exception
    {
        public VersionException() : base("Failed to get version from aion shard api")
        {
        }
    }
}