using ECommons.DalamudServices;

namespace GoldSaucer.Module;
public unsafe sealed class Botanist
{
    public float rotation { get; set; } = -0.50f;
    public void setState(int state)
    {
        if (state == 2)
        {
            return;
        }

        if (rotation == -0.50f)
        {
            if (state == 0)
            {
                rotation = 0.45f;
            }
            else if (state == 1)
            {
                rotation = -0.33f;
            }
        }
        else if (rotation == -0.33f)
        {
            if (state == 0)
            {
                rotation = -0.75f;
            }
        }
        else if (rotation == 0.45f)
        {
            if (state == 0)
            {
                rotation = -0.0175f;
            }
            else if (state == 1)
            {
                rotation = 0.28f;
            }
        }
        else if (rotation == 0.28f)
        {
            if (state == 0)
            {
                rotation = 0.70f;
            }
        }
        else if (rotation == 0.70f)
        {
            if (state == 0)
            {
                rotation = -0.50f;
            }
        }
    }
    public void statistics()
    {
        if (rotation == -0.75f)
        {
            GoldSaucer.config.count1++;
        }
        else if (rotation == -0.50f)
        {
            GoldSaucer.config.count2++;
        }
        else if (rotation == -0.33f)
        {
            GoldSaucer.config.count3++;
        }
        else if (rotation == -0.0175f)
        {
            GoldSaucer.config.count4++;
        }
        else if (rotation == 0.28f)
        {
            GoldSaucer.config.count5++;
        }
        else if (rotation == 0.45f)
        {
            GoldSaucer.config.count6++;
        }
        else if (rotation == 0.70f)
        {
            GoldSaucer.config.count7++;
        }
        Svc.PluginInterface.SavePluginConfig(GoldSaucer.config);
    }
}
