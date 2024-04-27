using System;
using FFXIVClientStructs.FFXIV.Common.Math;
using System.Linq;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.UI;
using ClickLib.Clicks;
using FFXIVClientStructs.FFXIV.Component.GUI;
using Dalamud.Hooking;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Plugin.Services;
using Dalamud.Game.ClientState.Objects.Types;

namespace GoldSaucer.Module;
public unsafe sealed class Out_on_a_Limb
{
    private delegate nint UnknownFunction(nint a1, ushort a2, int a3, void* a4);
    private static Hook<UnknownFunction>? FuncHook;
    public static Botanist? Botanist;
    public unsafe static void RunModule(ICondition condition)
    {

        if (!condition[ConditionFlag.OccupiedInQuestEvent])
        {

            FFXIVClientStructs.FFXIV.Client.Game.Object.GameObject* out_on_a_Limb = (FFXIVClientStructs.FFXIV.Client.Game.Object.GameObject*)Dalamud.ObjectTable.FirstOrDefault(x => x.DataId == 2005423 && GetTargetDistance(x) <= 2f)!.Address;

            if ((nint)out_on_a_Limb == IntPtr.Zero)
            {
                return;
            }
            TargetSystem* tg = TargetSystem.Instance();
            tg->InteractWithObject(out_on_a_Limb);
        }
        if (condition[ConditionFlag.OccupiedInQuestEvent])
        {
            AddonSelectString* startMenu = (AddonSelectString*)Dalamud.GameGui.GetAddonByName("SelectString");

            if ((nint)startMenu != IntPtr.Zero && startMenu->AtkUnitBase.IsVisible)
            {
                Botanist = null;
                ClickSelectString.Using((IntPtr)startMenu).SelectItem1();
                return;
            }


            var addon1 = Dalamud.GameGui.GetAddonByName("MiniGameAimg", 1);
            if (addon1 != IntPtr.Zero)
            {
                var ui = (AtkUnitBase*)addon1;

                if (ui->IsVisible)
                {
                    var slidingNode = ui->UldManager.NodeList[19];
                    var btn = ui->UldManager.NodeList[20];
                    if (slidingNode->Y > 0 && slidingNode->Y <= 400)
                    {
                        RunClick(btn, addon1);
                    }
                }
                return;
            }
            var addon2 = Dalamud.GameGui.GetAddonByName("MiniGameBotanist", 1);
            if (addon2 != IntPtr.Zero)
            {
                var ui = (AtkUnitBase*)addon2;

                if (ui->IsVisible)
                {
                    var slidingNode = ui->UldManager.NodeList[18];
                    var btn = ui->UldManager.NodeList[9];
                    if (Botanist == null)
                    {
                        Botanist = new Botanist();
                    }
                    float less = Botanist.Rotation;
                    float greater = less + 0.05f;

                    if (less == -0.0175f)
                    {
                        greater = 0.0175f;
                    }
                    if (less < slidingNode->Rotation && slidingNode->Rotation < greater)
                    {
                        RunClick(btn, addon2);
                    }

                    AddonSelectYesno* startMenu1 = (AddonSelectYesno*)Dalamud.GameGui.GetAddonByName("SelectYesno");
                    if ((nint)startMenu1 != IntPtr.Zero && startMenu1->AtkUnitBase.IsVisible)
                    {
                        string s = startMenu1->PromptText->NodeText.ToString();
                        s = s.Substring(s.IndexOf('间'), 6).Split(':')[1];
                        Botanist.Statistics();
                        Botanist = null;
                        if (int.Parse(s) <= 15)
                        {
                            ClickSelectYesNo.Using((IntPtr)startMenu1).No();
                        }
                        else
                        {
                            ClickSelectYesNo.Using((IntPtr)startMenu1).Yes();
                        }
                        return;
                    }
                }
                return;
            }

        }
    }
    public static nint FuncDetour(nint a1, ushort a2, int a3, void* a4)
    {
        return FuncHook!.Original(a1, a2, a3, a4);
    }
    public static float GetTargetDistance(GameObject target)
    {
        var LocalPlayer = Dalamud.ClientState.LocalPlayer;

        if (LocalPlayer is null)
            return 0;

        if (target.ObjectId == LocalPlayer.ObjectId)
            return 0;

        Vector2 position = new(target.Position.X, target.Position.Z);
        Vector2 selfPosition = new(LocalPlayer.Position.X, LocalPlayer.Position.Z);

        return Math.Max(0, Vector2.Distance(position, selfPosition) - target.HitboxRadius - LocalPlayer.HitboxRadius);

    }

    private static void RunClick(AtkResNode* btn, nint addon)
    {

        var evt = stackalloc AtkEvent[]
        {
            new()
            {
                Node = btn,
                Target = (AtkEventTarget*)btn,
                Param = 0,
                NextEvent = null,
                Type = (AtkEventType)0x17,
                Unk29 = 0,
                Flags = 0xDD
            }
        };

        FuncHook ??= Dalamud.GameInteropProvider.HookFromAddress<UnknownFunction>(Dalamud.SigScanner.ScanText("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 0F B7 FA"), FuncDetour);
        FuncHook.Original(addon, 0x17, 0, evt);
    }

}
