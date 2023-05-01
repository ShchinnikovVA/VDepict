using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageContainerManager : MonoBehaviour
{
    [Header("Коробка с камерой")]
    public Transform cameraBox;
    #region CamProperties
    [Space]
    public bool camRot_x;
    public bool camRot_y;
    public bool camRot_z;
    public bool camPos_x;
    public bool camPos_y;
    public bool camPos_z;
    [Space]
    public Image imgRot_x;
    public Image imgRot_y;
    public Image imgRot_z;
    public Image imgPos_x;
    public Image imgPos_y;
    public Image imgPos_z;
    #endregion
    [Header("Окно сообщения")]
    public GameObject imgMassege;
    public float closeTime = 3f;

    void Start()
    {
        imgMassege.SetActive(false);
    }

    #region Save Massege
    public void ShowMassege()
    {
        if (imgMassege.activeSelf == false)
            StartCoroutine(MassegeVisibility());
    }
    IEnumerator MassegeVisibility()
    {
        imgMassege.SetActive(true);
        yield return new WaitForSeconds(closeTime);
        imgMassege.SetActive(false);
        StopCoroutine(MassegeVisibility());
    }
    #endregion

    #region Set Bool and Color
    public bool SetTransformBool(bool _b, Image _im)
    {
        if (_b)
        {
            _im.color = Color.red;
        }
        else
        {
            _im.color = Color.green;
        }
        _b = !_b;
        return _b;
    }
    public void SetRot_X() => camRot_x = SetTransformBool(camRot_x, imgRot_x);
    public void SetRot_Y() => camRot_y = SetTransformBool(camRot_y, imgRot_y);
    public void SetRot_Z() => camRot_z = SetTransformBool(camRot_z, imgRot_z);
    public void SetPos_X() => camPos_x = SetTransformBool(camPos_x, imgPos_x);
    public void SetPos_Y() => camPos_y = SetTransformBool(camPos_y, imgPos_y);
    public void SetPos_Z() => camPos_z = SetTransformBool(camPos_z, imgPos_z);

    #endregion
}
