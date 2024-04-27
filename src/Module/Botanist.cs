
namespace GoldSaucer.Module;
public unsafe sealed class Botanist
{
    public float Rotation { get; set; } = -0.025f;
    public void SetState(int state)
    {
        if (state == 2)
        {
            return;
        }
        if (Rotation == -0.025f)
        {
            if (state == 0)
            {
                Rotation = -0.375f;
            }
            else if (state == 1)
            {
                Rotation = -0.20f;
            }
        }
        else if (Rotation == -0.375f)
        {
            if (state == 0)
            {
                Rotation = 0.325f;
            }
            else if (state == 1)
            {
                Rotation = -0.68f;
            }
        }
        else if (Rotation == -0.20f)
        {
            if (state == 0)
            {
                Rotation = 0.15f;
            }
        }
        else if (Rotation == 0.325f)
        {
            if (state == 0)
            {
                Rotation = -0.68f;
            }
            else if (state == 1)
            {
                Rotation = 0.63f;
            }
        }
        else if (Rotation == -0.68f)
        {
            if (state == 0)
            {
                Rotation = 0.63f;
            }
        }
        else if (Rotation == 0.63f)
        {
            if (state == 0)
            {
                Rotation = -0.025f;
            }
        }
    }
    public void Statistics()
    {
        if (Rotation == -0.68f)
        {
            GoldSaucer.Config.count1++;
        }
        else if (Rotation == -0.375f)
        {
            GoldSaucer.Config.count2++;
        }
        else if (Rotation == -0.20f)
        {
            GoldSaucer.Config.count3++;
        }
        else if (Rotation == -0.025f)
        {
            GoldSaucer.Config.count4++;
        }
        else if (Rotation == 0.15f)
        {
            GoldSaucer.Config.count5++;
        }
        else if (Rotation == 0.325f)
        {
            GoldSaucer.Config.count6++;
        }
        else if (Rotation == 0.63f)
        {
            GoldSaucer.Config.count7++;
        }
        Dalamud.PluginInterface.SavePluginConfig(GoldSaucer.Config);
    }
}
