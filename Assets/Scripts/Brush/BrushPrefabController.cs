using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushPrefabController : MonoBehaviour
{
    public Color color;
    public float size;
    public float minDistance;
    public GameObject brushPrefab;
    public GameObject lookTarget;

    public void OnClickButton()
    {
        CreateParticleDot(size, minDistance, brushPrefab, color);
    }

    public void CreateParticleDot(float _size, float _minDistance, GameObject _brushPrefab, Color _color)
    {
        var _scale = new Vector3(_size, _size, _size);
        Vector3 _locate = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        _brushPrefab.transform.GetComponent<PointLookAtTarget>().target = lookTarget.transform;
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
        _brushPrefab.transform.localScale = _scale;
        Instantiate(_brushPrefab, _locate, new Quaternion(0,0,0,0));
    }
}
