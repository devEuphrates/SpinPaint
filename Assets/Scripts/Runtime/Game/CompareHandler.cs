using UnityEngine;

public static class CompareHandler
{
    public static float CompareTextures(Texture2D texture1, Texture2D texture2)
    {
        //Check if the widths and heights of textures are the same and return 0 if not (Meaning not similar at all.).
        if (texture1.width != texture2.width
            || texture1.height != texture2.height)
        {
            Debug.LogError("Textures are not the same size");
            return 0;
        }

        //Get color values of given texture2Ds
        Color[] colors1 = texture1.GetPixels();
        Color[] colors2 = texture2.GetPixels();

        //While inside colors1 compare colors1 with colors2
        //for identical bytes
        int coloredPixels = 0;
        int identicalPixels = 0;

        for (int i = 0; i < colors1.Length; i++)
        {
            /*
            if (colors1[i] == Color.black || colors1[i] == Color.white)
                continue;
            */
            coloredPixels++;

            if (colors1[i] == colors2[i])
                identicalPixels++;
        }

        float similarity = (float)identicalPixels / (float)coloredPixels;
        similarity = similarity >= .98 ? 1 : similarity;

        return similarity;
    }
}
