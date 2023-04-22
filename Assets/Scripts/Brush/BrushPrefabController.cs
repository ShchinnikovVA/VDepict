using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushPrefabController : MonoBehaviour
{
    public Color color;
    public float size;
    public float minDistance;
    public GameObject brushPrefab;

    public void OnClickButton()
    {
        CreateParticleDot(size, minDistance, brushPrefab, color);
    }

    public void CreateParticleDot(float _size, float _minDistance, GameObject _brushPrefab, Color _color)
    {
        var _scale = new Vector3(_size, _size, _size);

        _brushPrefab.transform.GetChild(0).GetComponent<Material>().SetColor("kavo", _color);
        _brushPrefab.transform.localScale = _scale;
        Instantiate(_brushPrefab, gameObject.transform);
    }
}
