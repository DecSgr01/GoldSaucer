using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using ClickLib;
using GoldSaucer.View;

using GoldSaucer.Module;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Plugin.Services;

namespace GoldSaucer;
public unsafe sealed class GoldSaucer : IDalamudPlugin
{
    public static string Name => "GoldSaucer";
    public readonly WindowSystem WindowSystem = new(Name);
    public static Configuration Config { get; private set; } = null!;
    GoldSaucerView GoldSaucerView { get; init; }
    public GoldSaucer(DalamudPluginInterface Interface)
    {
        Dalamud.Initialize(Interface);
        Config = Configuration.Load();
        Click.Initialize();
        GoldSaucerView = new();
        WindowSystem.AddWindow(GoldSaucerView);
        Interface.UiBuilder.Draw += WindowSystem.Draw;
        Interface.UiBuilder.OpenConfigUi += GoldSaucerView.Toggle;
        Interface.UiBuilder.OpenMainUi += GoldSaucerView.Toggle;

        Dalamud.Framework.Update += Run;
        Dalamud.ChatGui.ChatMessage += Chat_ChatMessage;
    }

    private void Run(IFramework framework)
    {
        if (Config.Out_on_a_Limb)
        {
            Out_on_a_Limb.RunModule(Dalamud.Condition);
            return;
        }
    }

    private void Chat_ChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
    {
        if (message.TextValue.EndsWith("没什么手感……"))
        {
            Out_on_a_Limb.Botanist!.SetState(0);
        }
        else if (message.TextValue.EndsWith("感觉接触到了什么东西。"))
        {
            Out_on_a_Limb.Botanist!.SetState(1);
        }
        else if (message.TextValue.EndsWith("感觉正中目标！") || message.TextValue.EndsWith("感觉离目标相当接近了。"))
        {
            Out_on_a_Limb.Botanist!.SetState(2);
        }
    }

    public void Dispose()
    {
        Dalamud.PluginInterface.UiBuilder.Draw -= WindowSystem.Draw;
        Dalamud.Framework.Update -= Run;
    }
}
