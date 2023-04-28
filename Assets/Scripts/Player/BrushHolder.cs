using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushHolder : MonoBehaviour
{
    [Header("Префабы кистей")]
    public GameObject dotBrush; // dotBrush.GetComponent<BrushPrefabController>().isDrawing; <- обращение к булевой для рисования
    public GameObject lineBrush; // lineBrush.GetComponent<LineBrushManager>().isDrawing; <- обращение к булевой для рисования
    public GameObject eraserBrush; // eraserBrush.GetComponent<DeleteZoneBrush>().isDelete; <- обращение к булевой для стирания
    [Header("Канвас кистей")]
    public Canvas brushCanvas;
    public BrushCanvasManager brushCanvasManager;
    [Header("Руки")]
    public Transform rightHand;
    public Transform leftHand;

    private void Start()
    {
        brushCanvasManager.lineBrushPrefab = lineBrush;
        brushCanvasManager.brushPrefab = dotBrush;
        brushCanvasManager.eraserPrefab = eraserBrush;
    }
    public void ChangeHand()
    {
        if (transform.parent == rightHand)
        {
            transform.SetParent(leftHand);
            transform.localPosition = new Vector3(0, 0, 0);
            brushCanvas.transform.parent.SetParent(rightHand);
            brushCanvas.transform.parent.localPosition = new Vector3(0, 0, 0);
            brushCanvas.transform.localRotation =  Quaternion.Euler(50, 0, -90);
        }
        else if (transform.parent == leftHand)
        {
            transform.SetParent(rightHand);
            transform.localPosition = new Vector3(0, 0, 0);
            brushCanvas.transform.parent.SetParent(leftHand);
            brushCanvas.transform.parent.localPosition = new Vector3(0, 0, 0);
            brushCanvas.transform.localRotation = Quaternion.Euler(50, 0, 90);
        }
    }
}
