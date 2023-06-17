using ECommons.DalamudServices;

namespace GoldSaucer.Module;
public unsafe sealed class Botanist
{
    public float rotation { get; set; } = -0.025f;
    public void setState(int state)
    {
        if (state == 2)
        {
            return;
        }
        if (rotation == -0.025f)
        {
            if (state == 0)
            {
                rotation = -0.375f;
            }
            else if (state == 1)
            {
                rotation = -0.20f;
            }
        }
        else if (rotation == -0.375f)
        {
            if (state == 0)
            {
                rotation = 0.325f;
            }
            else if (state == 1)
            {
                rotation = -0.68f;
            }
        }
        else if (rotation == -0.20f)
        {
            if (state == 0)
            {
                rotation = 0.15f;
            }
        }
        else if (rotation == 0.325f)
        {
            if (state == 0)
            {
                rotation = -0.68f;
            }
            else if (state == 1)
            {
                rotation = 0.63f;
            }
        }
        else if (rotation == -0.68f)
        {
            if (state == 0)
            {
                rotation = 0.63f;
            }
        }
        else if (rotation == 0.63f)
        {
            if (state == 0)
            {
                rotation = -0.025f;
            }
        }
    }
    public void statistics()
    {
        if (rotation == -0.68f)
        {
            GoldSaucer.config.count1++;
        }
        else if (rotation == -0.375f)
        {
            GoldSaucer.config.count2++;
        }
        else if (rotation == -0.20f)
        {
            GoldSaucer.config.count3++;
        }
        else if (rotation == -0.025f)
        {
            GoldSaucer.config.count4++;
        }
        else if (rotation == 0.15f)
        {
            GoldSaucer.config.count5++;
        }
        else if (rotation == 0.325)
        {
            GoldSaucer.config.count6++;
        }
        else if (rotation == 0.63f)
        {
            GoldSaucer.config.count7++;
        }
        Svc.PluginInterface.SavePluginConfig(GoldSaucer.config);
    }
}
