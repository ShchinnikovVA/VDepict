using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSettingsGroup : MonoBehaviour
{
    [Header("Пол")]
    public GameObject floor;
    public Material floorMaterial;
    public Texture grid;
    public void SetGrid(Toggle toggle)
    {
        if (toggle.isOn)
        {
            floorMaterial.mainTexture = grid;
        }
        else
        {
            floorMaterial.mainTexture = null;
        }
    }
    public void SetFloorColor(Image colorDonor)
    {
        //RenderSettings.skybox.color = colorDonor.color;
        floorMaterial.color = colorDonor.color;
    }

    public void SetSky(Material mat)
    {
        //mat.color = floorMaterial.color;
        RenderSettings.skybox = mat;
    }
}
