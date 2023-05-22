using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushPrefabController : MonoBehaviour
{
    [Header("���������� �������")]
    public TimeLineManager frameContainer;
    #region HiddenProperties
    [HideInInspector]
    public Sprite image;
    [HideInInspector]
    public Color color = Color.white;
    [HideInInspector]
    public float size = 1f;
    [HideInInspector]
    public float minDistance = 0.1f;
    #endregion
    [Header("������ �������� �����")]
    public GameObject brushPrefab;
    [Header("������ ������")]
    public GameObject lookTarget;
    [Header("����� ����� ���������")]
    public bool isDrawing;

    private Vector3 _lastPosition = new Vector3(0,0,0);
    private bool _isLookAtCamera, _isRandom, _isAsBrushRotation;
    private GameObject _dot;

    private void FixedUpdate() 
    {
        if (isDrawing) // ����� ����� �����
        {
            CreateParticleDot(size, brushPrefab, color, image, minDistance);
        }
    }

    public void CreateParticleDot(float _size, GameObject _brushPrefab, Color _color, Sprite _image, float _minDistance)
    {
        var _scale = new Vector3(_size, _size, _size); // ������ �������
        Vector3 _locate = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); // ������� � �����
        
        _brushPrefab.transform.GetComponent<PointLookAtTarget>().target = lookTarget.transform; // ���� ��������
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _image; // �������, ������� ������ ����
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
        _brushPrefab.transform.localScale = _scale;
        if (Vector3.Distance(_lastPosition, transform.position) > _minDistance) // ���������� ����� ���������
        {
            _brushPrefab.GetComponent<PointLookAtTarget>().isLookAtTarget = _isLookAtCamera;
            if (_isLookAtCamera) // ���� ������ ������� � ������
            {
               _dot = Instantiate(_brushPrefab, _locate, Quaternion.Euler(0, 0, 0));
            }
            if (_isRandom) // ��������� ������� �������
            {
                _dot = Instantiate(_brushPrefab, _locate, Quaternion.Euler(Random.RandomRange(0, 360), Random.RandomRange(0, 360), Random.RandomRange(0, 360)));
            }
            if (_isAsBrushRotation) // ������� ������� ��� � �����
            {
                _dot = Instantiate(_brushPrefab, _locate, Quaternion.Euler(gameObject.transform.rotation.eulerAngles));
            }
               
            frameContainer.SetPaintToFrame(_dot); // ���������� ����� � ����
            _dot = null;
            _lastPosition = transform.position;
        }
    }
    #region Bool Zone
    public void SetBoolCamera()
    {
        _isLookAtCamera = true;
        _isRandom = false;
        _isAsBrushRotation = false;
    }
    public void SetBoolRandom()
    {
        _isLookAtCamera = false;
        _isRandom = true;
        _isAsBrushRotation = false;
    }
    public void SetBoolBrush()
    {
        _isLookAtCamera = false;
        _isRandom = false;
        _isAsBrushRotation = true;
    }
    #endregion
}
