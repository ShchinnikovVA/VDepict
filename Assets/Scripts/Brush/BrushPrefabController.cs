using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushPrefabController : MonoBehaviour
{
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
    [Header("Префаб точечной кисти")]
    public GameObject brushPrefab;
    [Header("Камера игрока")]
    public GameObject lookTarget;
    [Header("Нажат курок рисования")]
    public bool isDrawing;

    private Vector3 _lastPosition = new Vector3(0,0,0);
    private bool _isLookAtCamera, _isRandom, _isAsBrushRotation;


    private void FixedUpdate() 
    {
        if (isDrawing) // когда курок нажат
        {
            CreateParticleDot(size, brushPrefab, color, image, minDistance);
        }
    }

    public void CreateParticleDot(float _size, GameObject _brushPrefab, Color _color, Sprite _image, float _minDistance)
    {
        var _scale = new Vector3(_size, _size, _size); // размер спрайта
        Vector3 _locate = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z); // похиция в кисти
        
        _brushPrefab.transform.GetComponent<PointLookAtTarget>().target = lookTarget.transform; // цель поворота
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _image; // картнка, которую выбрал юзер
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
        _brushPrefab.transform.localScale = _scale;
        if (Vector3.Distance(_lastPosition, transform.position) > _minDistance) // расстояние между спрайтами
        {
            _brushPrefab.GetComponent<PointLookAtTarget>().isLookAtTarget = _isLookAtCamera;
            if (_isLookAtCamera) // если выбран поворот к игроку
            {
                Instantiate(_brushPrefab, _locate, Quaternion.Euler(0, 0, 0));
            }
            if (_isRandom) // случайный поворот спрайта
            {
                Instantiate(_brushPrefab, _locate, Quaternion.Euler(Random.RandomRange(0, 360), Random.RandomRange(0, 360), Random.RandomRange(0, 360)));
            }
            if (_isAsBrushRotation) // поворот спрайта как у кисти
            {
                Instantiate(_brushPrefab, _locate, Quaternion.Euler(gameObject.transform.rotation.eulerAngles));
            }
            
            _lastPosition = transform.position;
        }
    }
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
}
