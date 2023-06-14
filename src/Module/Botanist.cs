namespace GoldSaucer.Module;
public unsafe sealed class Botanist
{
    public float rotation { get; set; } = -0.45f;
    public void setState(int state)
    {
        if (rotation == -0.45f)
        {
            if (state == 0)
            {
                rotation = 0.45f;
            }
            else if (state == 1)
            {
                rotation = -0.28f;
            }
        }
        else if (rotation == -0.28f)
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
                rotation = -0.03f;
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
                rotation = -0.45f;
            }
        }
    }
}
