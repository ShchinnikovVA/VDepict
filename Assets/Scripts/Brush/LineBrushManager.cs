using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBrushManager : MonoBehaviour
{
    [Header("Линейная кисть")]
    public Transform lineBrushPrefab;
    public Material lineMaterial;
    #region HiddenProperties
    //[HideInInspector]
    public float lineWidth = 0.05f;
    [HideInInspector]
    public Color lineColor;
    [HideInInspector]
    public float distance = 0.1f;
    #endregion
    [Header("Нажат курок рисования")]
    public bool isDrawing;

    private LineRenderer _currentDrawing;
    private int _index;

    private void Update()
    {
        if (isDrawing)
        {
            DrawLine();
        }
        else if (_currentDrawing != null)
        {
            _currentDrawing = null;
        }
    }

    public void DrawLine()
    {
        if (_currentDrawing == null)
        {
            _index = 0;
            _currentDrawing = new GameObject().AddComponent<LineRenderer>();
            _currentDrawing.material = lineMaterial;
            _currentDrawing.startColor = _currentDrawing.endColor = lineColor;
            _currentDrawing.startWidth = _currentDrawing.endWidth = lineWidth;
            _currentDrawing.positionCount = 1;
            _currentDrawing.SetPosition(0, lineBrushPrefab.position);
        }
        else
        {
            var currentPosition = _currentDrawing.GetPosition(_index);
            if (Vector3.Distance(currentPosition, lineBrushPrefab.position) > distance)
            {
                _index++;
                _currentDrawing.positionCount = _index + 1;
                _currentDrawing.SetPosition(_index, lineBrushPrefab.position);
            }
        }
    }

    //public void SetColor()
    //{
    //    lineMaterial.color = lineColor;
    //}
    //public void SetColor(Color _newColor)
    //{
    //    lineColor = _newColor;
    //    //lineMaterial.color = lineColor;
    //}
}
