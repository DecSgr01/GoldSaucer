using Dalamud.Interface.Windowing;
using ImGuiNET;
using FFXIVClientStructs.FFXIV.Common.Math;
using Dalamud.Interface.Utility;

namespace GoldSaucer.View;
public sealed class GoldSaucerView : Window
{
    public GoldSaucerView() : base("GoldSaucerView", ImGuiWindowFlags.NoScrollbar)
    {
        Vector2 minSize = new(400, 220);
        Vector2 maxiSize = new(400, 320);
        Size = minSize;
        SizeCondition = ImGuiCond.FirstUseEver;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = minSize,
            MaximumSize = maxiSize
        };
    }

    public override void Draw()
    {

        ImGui.BeginChild("", ImGui.GetContentRegionAvail() with { Y = ImGui.GetContentRegionAvail().Y - ImGuiHelpers.GetButtonSize("保存并关闭").Y - 6 });

        if (ImGui.Checkbox("孤树无援", ref GoldSaucer.Config.Out_on_a_Limb))
        {
            Dalamud.PluginInterface.SavePluginConfig(GoldSaucer.Config);
        }

        ImGui.EndChild();
        ImGui.Separator();
        ImGui.NewLine();
        ImGui.SameLine(ImGui.GetContentRegionAvail().X - ImGuiHelpers.GetButtonSize("保存并关闭").X - 6);

        if (ImGui.Button("保存并关闭"))
        {
            Dalamud.PluginInterface.SavePluginConfig(GoldSaucer.Config);
            IsOpen = false;
            Dalamud.PluginLog.Info("Settings saved.");
        }

        ImGui.End();
    }
}
