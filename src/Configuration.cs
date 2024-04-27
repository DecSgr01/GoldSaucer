using Dalamud.Configuration;
using System;

namespace GoldSaucer;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;
    internal bool Out_on_a_Limb;
    internal int count1 = 0;
    internal int count2 = 0;
    internal int count3 = 0;
    internal int count4 = 0;
    internal int count5 = 0;
    internal int count6 = 0;
    internal int count7 = 0;

    internal void Save()
    {
        Dalamud.PluginInterface.SavePluginConfig(this);
    }
    internal static Configuration Load()
    {
        if (Dalamud.PluginInterface.GetPluginConfig() is Configuration config)
        {
            return config;
        }
        config = new Configuration();
        config.Save();
        return config;
    }
}