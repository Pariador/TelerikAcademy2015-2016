namespace Matrix.ObjectLibrary
{
    using System;

    //A version attribute with definse a Main and Sub vesion.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    class VersionAttribute : Attribute
    {
        public VersionAttribute(int mainVersion, int subVersion)
        {
            this.MainVersion = mainVersion;
            this.SubVersion = subVersion;
        }

        public int MainVersion { get; set; }
        public int SubVersion { get; set; }

        public override string ToString()
        {
            return String.Format("Version: {0}.{1}", this.MainVersion, this.SubVersion);
        }
    }
}   