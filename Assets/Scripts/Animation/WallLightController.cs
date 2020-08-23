using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using S = UnityEngine.SerializeField;

public class WallLightController : MonoBehaviour
{
    [S] Renderer lightRenderer;
    [S] Material materialLerpBlue;
    [S] Material materialLerpRed;
    [S] float animationDuration;
    [S] AnimationCurve animationTimeRemap;
    [S] bool animatingToRed;

    Color blueDestinationColor;
    Color redDestinationColor;

    static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");


    IEnumerator Start()
    {
        blueDestinationColor = materialLerpBlue.GetColor(EmissionColor);
        redDestinationColor = materialLerpRed.GetColor(EmissionColor);
        lightRenderer.sharedMaterial = Instantiate(lightRenderer.material);
        var startColor = lightRenderer.sharedMaterial.GetColor(EmissionColor);

        var time = 0f;
        while (true)
        {
            time = time + (Time.deltaTime / animationDuration);
            var remappedTime = animationTimeRemap.Evaluate(time);
            var destinationColor = animatingToRed ? redDestinationColor : blueDestinationColor;
            var finalColor = Color.Lerp(startColor, destinationColor, remappedTime);
            lightRenderer.sharedMaterial.SetColor(EmissionColor, finalColor);

            if (Math.Abs(finalColor.r - destinationColor.r) < 0.001f &&
                Math.Abs(finalColor.b - destinationColor.b) < 0.001f &&
                Math.Abs(finalColor.g - destinationColor.g) < 0.001f)
            {
                time = 0f;
                startColor = lightRenderer.sharedMaterial.GetColor(EmissionColor);
                animatingToRed = !animatingToRed;
            }
            yield return null;
        }
    }
}