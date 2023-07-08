namespace ReadyUpPlugin
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug messages should be shown in the console.")]
        public bool Debug { get; set; }

        [Description("How long the broadcast message should show for someone being ready/unready.")]
        public ushort BroadcastLength { get; set; } = 5;


    }
}
