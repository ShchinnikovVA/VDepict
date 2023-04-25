using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushPrefabController : MonoBehaviour
{
    [HideInInspector]
    public Sprite image;
    public Color color;
    public float size = 1f;
    [HideInInspector]
    public float minDistance = 0.1f;
    public GameObject brushPrefab;
    public GameObject lookTarget;
    private Vector3 lastPosition = new Vector3(0,0,0);


    private void FixedUpdate()
    {
        //StartCoroutine(DotDistance(minDistance));
        OnClickControllerButton();
    }
    public void OnClickControllerButton()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            CreateParticleDot(size, brushPrefab, color, image, minDistance);
        //}
        //StartCoroutine(DotDistance(minDistance));
    }

    public void CreateParticleDot(float _size, GameObject _brushPrefab, Color _color, Sprite _image, float _minDistance)
    {
        var _scale = new Vector3(_size, _size, _size);
        Vector3 _locate = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        _brushPrefab.transform.GetComponent<PointLookAtTarget>().target = lookTarget.transform;
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _image;
        _brushPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = _color;
        _brushPrefab.transform.localScale = _scale;
        if (Vector3.Distance(lastPosition, transform.position) > _minDistance)
        { 
            Instantiate(_brushPrefab, _locate, new Quaternion(0,0,0,0));
            lastPosition = transform.position;
        }
    }

    //IEnumerator DotDistance(float _minDistance) //not worced corunine
    //{
    //    yield return new WaitForSeconds(_minDistance / 10f);
    //    CreateParticleDot(size, brushPrefab, color, image);
    //    StopCoroutine(DotDistance(minDistance));
    //}
}
