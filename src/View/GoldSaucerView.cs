using Dalamud.Interface.Windowing;
using ImGuiNET;
using FFXIVClientStructs.FFXIV.Common.Math;
using Dalamud.Interface.Utility;

namespace GoldSaucer.View;
public sealed class GoldSaucerView : Window
{
    public GoldSaucerView() : base("GoldSaucerView###Dec.Sgr01")
    {
        Flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse;
        Vector2 minSize = new(400, 220);
        Vector2 maxiSize = new(400, 320);
        Size = minSize;
        SizeCondition = ImGuiCond.Always;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = minSize,
            MaximumSize = maxiSize
        };
    }
    public override void Draw()
    {
        ImGui.BeginChild("Child", ImGui.GetContentRegionAvail() with { Y = ImGui.GetContentRegionAvail().Y - ImGuiHelpers.GetButtonSize("保存并关闭").Y - 6 });

        if (ImGui.Checkbox("孤树无援", ref GoldSaucer.Config.Out_on_a_Limb))
        {
            GoldSaucer.Config.Save();
        }

        ImGui.EndChild();
        ImGui.Separator();
        ImGui.NewLine();
        ImGui.SameLine(ImGui.GetContentRegionAvail().X - ImGuiHelpers.GetButtonSize("保存并关闭").X - 6);

        if (ImGui.Button("保存并关闭"))
        {
            GoldSaucer.Config.Save();
            IsOpen = false;
            Dalamud.PluginLog.Info("Settings saved.");
        }
    }
}
