using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using ClickLib;
using ECommons.DalamudServices;

using ECommons;
using Dalamud.Game;
using Dalamud.IoC;
using GoldSaucer.View;
using Dalamud.Game.ClientState.Conditions;

using GoldSaucer.Module;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;

namespace GoldSaucer;
public unsafe sealed class GoldSaucer : IDalamudPlugin
{
    public string Name => "GoldSaucer";
    public WindowSystem windowSystem;

    internal Configuration config { get; }
    [PluginService]
    internal static Condition Condition { get; private set; } = null!;
    public GoldSaucer(DalamudPluginInterface pluginInterface)
    {
        ECommonsMain.Init(pluginInterface, this);
        config = Svc.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Click.Initialize();
        GoldSaucerView goldSaucerView = new GoldSaucerView();
        windowSystem = new WindowSystem(Name);
        windowSystem.AddWindow(goldSaucerView);

        Svc.PluginInterface.UiBuilder.Draw += windowSystem.Draw;
        Svc.Framework.Update += Run;
        Svc.Chat.ChatMessage += Chat_ChatMessage;
        Svc.PluginInterface.UiBuilder.OpenConfigUi += delegate { goldSaucerView.IsOpen = true; };
    }

    private void Chat_ChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
    {
        if (message.TextValue.EndsWith("没什么手感……"))
        {
            Out_on_a_Limb.Botanist.setState(0);
        }
        else if (message.TextValue.EndsWith("感觉接触到了什么东西。"))
        {
            Out_on_a_Limb.Botanist.setState(1);
        }
        else if (message.TextValue.EndsWith("感觉正中目标！") || message.TextValue.EndsWith("感觉离目标相当接近了。"))
        {
            Out_on_a_Limb.Botanist.setState(2);
        }
    }
    private unsafe void Run(Framework framework)
    {
        if (Configuration.Out_on_a_Limb)
        {
            Out_on_a_Limb.RunModule(Condition);
            return;
        }

    }

    public void Dispose()
    {
        Svc.PluginInterface.UiBuilder.Draw -= windowSystem.Draw;
        Svc.Framework.Update -= Run;
        ECommonsMain.Dispose();
    }
}
