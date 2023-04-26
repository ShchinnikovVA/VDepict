using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushCanvasManager : MonoBehaviour
{
    [Header("Главное меню")]
    public GameObject mainGroup;
    [Header("Префабы кистей и стёрки")]
    public GameObject brushPrefab;
    public GameObject lineBrushPrefab;
    public GameObject eraserPrefab;
    [Header("Обозначения размера кистей")]
    public Text brushSizeText;
    public Text eraserSizeText;
    public Text lineSizeText;
    public Text lineDistanceText;


    private void Start()
    { 
        brushPrefab.SetActive(false);
        lineBrushPrefab.SetActive(false);
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
    #region DotBrush
    public void SetBrushImage(GameObject _spriteTemplate) => brushPrefab.GetComponent<BrushPrefabController>().image = _spriteTemplate.GetComponent<Button>().image.sprite;
    public void SetBrushDistance(float _distance) => brushPrefab.GetComponent<BrushPrefabController>().minDistance = _distance;
    public void SetColorBrush(Color _color) => brushPrefab.GetComponent<BrushPrefabController>().color = _color;
    public void SetBrushSize(Slider slider)
    {
        brushPrefab.GetComponent<BrushPrefabController>().size = slider.value;
        brushSizeText.text = slider.value.ToString();
    }
    #endregion
    #region Eraser
    public void SetEraserSize(Slider slider)
    {
        eraserPrefab.GetComponent<DeleteZoneBrush>().radius = slider.value;
        eraserSizeText.text = slider.value.ToString();
    }
    #endregion
    #region LineBrush
    public void SetLineDistance(Slider slider)
    {
        lineBrushPrefab.GetComponent<LineBrushManager>().distance = slider.value;
        lineDistanceText.text = slider.value.ToString();
    }

    public void SetLineColor(Color _color) => lineBrushPrefab.GetComponent<LineBrushManager>().lineColor = _color;

    public void SetLineWidth(Slider slider)
    {
        lineBrushPrefab.GetComponent<LineBrushManager>().lineWidth = slider.value;
        lineSizeText.text = slider.value.ToString();
    }
    #endregion

}
