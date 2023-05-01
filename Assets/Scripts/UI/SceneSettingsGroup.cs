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
    [Header("Небо")]
    public Skybox emptySky;
    public Skybox citySky;
    public Skybox mountainsSky;

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
    public void SetFloorColor(Image colorDonor) => floorMaterial.color = colorDonor.color;
}
