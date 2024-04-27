using Dalamud.Game;
using Dalamud.Hooking;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using Lumina.Excel.GeneratedSheets;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace GoldSaucer;
internal class Dalamud
{
    internal static void Initialize(DalamudPluginInterface pluginInterface) => pluginInterface.Create<Dalamud>();
    [PluginService][RequiredVersion("1.0")] internal static DalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IPluginLog PluginLog { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IClientState ClientState { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IGameGui GameGui { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static ICondition Condition { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IFramework Framework { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IChatGui ChatGui { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static ISigScanner SigScanner { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IObjectTable ObjectTable { get; private set; } = null!;
    [PluginService][RequiredVersion("1.0")] internal static IGameInteropProvider GameInteropProvider { get; private set; } = null!;
}