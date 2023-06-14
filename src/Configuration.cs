using Dalamud.Configuration;
using System;

namespace GoldSaucer;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;
    public static bool Out_on_a_Limb;
}