using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushCanvasManager : MonoBehaviour
{
    public GameObject mainGroup;
    public GameObject brushPrefab;
    public GameObject eraserPrefab;
    public Text brushSizeText, eraserSizeText;


    private void Start()
    { 
        // я пока сделал функции для выбора кисти или стёрки по кнопку на канвасе, потом надо переделать под кнопки на джойстике, я думаю
        brushPrefab.SetActive(false);
        eraserPrefab.SetActive(false);
    }
    public void VisibilityGroup(GameObject _group)
    {
        if (_group.active)
        {
            _group.SetActive(false);
            mainGroup.SetActive(true);
        }
        else
        {
            _group.SetActive(true);
            mainGroup.SetActive(false);
        }
    }
    public void SetBrushImage(GameObject _spriteTemplate) => brushPrefab.GetComponent<BrushPrefabController>().image = _spriteTemplate.GetComponent<Button>().image.sprite;
    public void SetBrushDistance(float _distance) => brushPrefab.GetComponent<BrushPrefabController>().minDistance = _distance;
    public void SetBrushSize(Slider slider)
    {
        brushPrefab.GetComponent<BrushPrefabController>().size = slider.value;
        brushSizeText.text = slider.value.ToString();
    }

    public void SetEraserSize(Slider slider)
    {
        eraserPrefab.GetComponent<DeleteZoneBrush>().radius = slider.value;
        eraserSizeText.text = slider.value.ToString();
    }
}
