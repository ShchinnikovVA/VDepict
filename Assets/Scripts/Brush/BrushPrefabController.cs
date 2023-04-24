using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushPrefabController : MonoBehaviour
{
    public Sprite image;
    public Color color;
    public float size;
    public float minDistance;
    public GameObject brushPrefab;
    public GameObject lookTarget;


    private void FixedUpdate()
    {
        StartCoroutine(DotDistance(minDistance));
    }
    public void OnClickButton()
    {
        StartCoroutine(DotDistance(minDistance));
    }

    public void CreateParticleDot(float _size, GameObject _brushPrefab, Color _color, Sprite _image)
    {
        var _scale = new Vector3(_size, _size, _size);
        Vector3 _locate = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        _brushPrefab.transform.GetComponent<PointLookAtTarget>().target = lookTarget.transform;
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _image;
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
        _brushPrefab.transform.localScale = _scale;
        Instantiate(_brushPrefab, _locate, new Quaternion(0,0,0,0));
    }

    IEnumerator DotDistance(float _minDistance)
    {
        yield return new WaitForSeconds(_minDistance / 100);
        CreateParticleDot(size, brushPrefab, color, image);
    }
}
