using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineBrushManager : MonoBehaviour
{
    [Header("–азмещение рисунка")]
    public TimeLineManager frameContainer;
    [Header("Ћинейна€ кисть")]
    public Transform lineBrushPrefab;
    public Material lineMaterial;
    #region HiddenProperties
    [HideInInspector]
    public float lineWidth = 0.05f;
    [HideInInspector]
    public Color lineColor;
    [HideInInspector]
    public float distance = 0.1f;
    #endregion
    [Header("Ќажат курок рисовани€")]
    public bool isDrawing;

    
    private LineRenderer _currentDrawing;
    private int _index;

    
    private void Update()
    {

        if (isDrawing) //если курок нажат
        {
            DrawLine();
        }
        else if (_currentDrawing != null)
        {
            GenerateMash(); // создаЄм меш дл€ готовой линии
            frameContainer.SetPaintToFrame(_currentDrawing.gameObject);
            _currentDrawing = null; 
        }
        
    }

    
    public void SetDrawingTrue()
    {
        isDrawing = true;
        Debug.Log(isDrawing);
    }
    public void SetDrawingFalse()
    {
        isDrawing = false;
        Debug.Log(isDrawing);
    }
    public void DrawLine()
    {
        if (_currentDrawing == null) // если линии нет, создаЄм новую
        {
            _index = 0;
            _currentDrawing = new GameObject().AddComponent<LineRenderer>();
            _currentDrawing.name = "Line Picture";
            _currentDrawing.tag = "Paint";
            _currentDrawing.gameObject.AddComponent<MeshCollider>();
            _currentDrawing.gameObject.AddComponent<Rigidbody>(); // физика, чтобы можно было стереть линию
            _currentDrawing.GetComponent<Rigidbody>().mass = 0;
            _currentDrawing.GetComponent<Rigidbody>().useGravity = false;
            _currentDrawing.GetComponent<Rigidbody>().isKinematic = true;
            _currentDrawing.material = lineMaterial; // характеристики рисуемой линии
            _currentDrawing.startColor = _currentDrawing.endColor = lineColor;
            _currentDrawing.startWidth = _currentDrawing.endWidth = lineWidth;
            _currentDrawing.positionCount = 1; // перва€ точка линии
            _currentDrawing.SetPosition(0, lineBrushPrefab.position);
        }
        else
        {
            var currentPosition = _currentDrawing.GetPosition(_index); // создание новых точек
            if (Vector3.Distance(currentPosition, lineBrushPrefab.position) > distance)
            {
                _index++;
                _currentDrawing.positionCount = _index + 1;
                _currentDrawing.SetPosition(_index, lineBrushPrefab.position);
            }
        }
    }

    public void GenerateMash() // создание меша
    {
        MeshCollider collider = new MeshCollider();
        if (collider == null)
        {
            collider = _currentDrawing.GetComponent<MeshCollider>();
        }
        Mesh mesh = new Mesh();
        _currentDrawing.BakeMesh(mesh, true);
        collider.sharedMesh = mesh;
    }

    
}
