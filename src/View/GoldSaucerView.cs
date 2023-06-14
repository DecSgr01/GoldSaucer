using Dalamud.Interface.Windowing;
using System;
using ImGuiNET;
using FFXIVClientStructs.FFXIV.Common.Math;
using Dalamud.Interface;
using Dalamud.Logging;
using ECommons.DalamudServices;

namespace GoldSaucer.View;
public sealed class GoldSaucerView : Window
{
    public GoldSaucerView() : base("GoldSaucerView", ImGuiWindowFlags.NoScrollbar)
    {
        Vector2 minSize = new Vector2(400, 220);
        Vector2 maxiSize = new Vector2(400, 320);
        this.Size = minSize;
        this.SizeCondition = ImGuiCond.FirstUseEver;
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = minSize,
            MaximumSize = maxiSize
        };
    }

    public override void Draw()
    {
        Configuration configuration = Svc.PluginInterface.GetPluginConfig() as Configuration;

        ImGui.BeginChild("", ImGui.GetContentRegionAvail() with { Y = ImGui.GetContentRegionAvail().Y - ImGuiHelpers.GetButtonSize("保存并关闭").Y - 6 });

        if (ImGui.Checkbox("孤树无援", ref Configuration.Out_on_a_Limb))
        {
            PluginLog.Log("14点13分");
            Svc.PluginInterface.SavePluginConfig(configuration);
        }

        ImGui.EndChild();
        ImGui.Separator();
        ImGui.NewLine();
        ImGui.SameLine(ImGui.GetContentRegionAvail().X - ImGuiHelpers.GetButtonSize("保存并关闭").X - 6);

        if (ImGui.Button("保存并关闭"))
        {
            Svc.PluginInterface.SavePluginConfig(configuration);
            IsOpen = false;
            PluginLog.Log("Settings saved.");
        }

        ImGui.End();
    }
}
