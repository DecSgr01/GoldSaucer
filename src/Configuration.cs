using Dalamud.Configuration;
using System;

namespace GoldSaucer;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;
    public bool Out_on_a_Limb;
    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;
    public int count4 = 0;
    public int count5 = 0;
    public int count6 = 0;
    public int count7 = 0;
}