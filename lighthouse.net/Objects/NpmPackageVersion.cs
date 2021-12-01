using System;

namespace lighthouse.net.Objects
{
    internal class NpmPackageVersion
    {
        public NpmPackageVersion(string version)
        {
            var arr = version.Split('.');
            if (arr.Length == 0) throw new ArgumentException("Invalid version");
            MajorVersion = int.Parse(arr[0]);
            MinorVersion = int.Parse(arr[1]);
            PatchVersion = int.Parse(arr[2]);
        }
        public int MajorVersion { get; }
        public int MinorVersion { get; }
        public int PatchVersion { get; }
    }
}
