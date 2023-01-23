using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompareHandler : MonoBehaviour
{
    [SerializeField]
    Texture2D _goalTexture;

    [SerializeField]
    Texture2D _playersTexture;

    [SerializeField]
    TextMeshPro _evaluationText;

    public void CheckTexture()
    {
        //Chekc width and height for errors
        if (_goalTexture.width != _playersTexture.width
            || _goalTexture.height != _playersTexture.height)
        {
            Debug.LogError("Textures are not the same size");
            return;
        }

        //Get the bytes of given texture2Ds
        Color[] goalColors = _goalTexture.GetPixels();
        Color[] playerColors = _playersTexture.GetPixels();

        //While inside goalColors compare goalColors with players
        //for identical bytes
        int identicalBytes = 0;
        for (int i = 0; i < goalColors.Length; i++)
        {
            if (goalColors[i] == playerColors[i])
            {
                identicalBytes++;
            }
        }

        float similarity = (float)identicalBytes / goalColors.Length * 100;

        _evaluationText.text = "It's a " + similarity + "% match!!";

    }


}
