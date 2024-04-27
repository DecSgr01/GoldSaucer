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
    private readonly WindowSystem windowSystem;

    public static Configuration Config { get; private set; } = null!;
    public GoldSaucer(DalamudPluginInterface Interface)
    {
        Dalamud.Initialize(Interface);

        Config = Configuration.Load();
        Click.Initialize();

        GoldSaucerView goldSaucerView = new();
        windowSystem = new WindowSystem(Name);
        windowSystem.AddWindow(goldSaucerView);
        Dalamud.PluginInterface.UiBuilder.Draw += windowSystem.Draw;
        Dalamud.PluginInterface.UiBuilder.OpenConfigUi += delegate { goldSaucerView.IsOpen = true; };
        Dalamud.PluginInterface.UiBuilder.OpenMainUi += delegate { goldSaucerView.IsOpen = true; };

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
        Dalamud.PluginInterface.UiBuilder.Draw -= windowSystem.Draw;
        Dalamud.Framework.Update -= Run;
    }
}
