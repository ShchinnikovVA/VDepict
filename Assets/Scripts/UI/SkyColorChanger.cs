using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyColorChanger : MonoBehaviour
{
    #region Properties
    public GroupCreater groupCreater;
    [Header("��������� �����")]
    public Image topImage;
    public Image midImage;
    public Image botImage;
    [Header("������� ��� �������������")]
    public GameObject leftArrow;
    public GameObject rightArrow;
    [Header("�������� RGB")]
    public Slider r_slider;
    public Slider g_slider;
    public Slider b_slider;

    [Range(0, 255)]
    private float s_R;
    [Range(0, 255)]
    private float s_G;
    [Range(0, 255)]
    private float s_B;

    private int _id = 0;
    #endregion

    #region Image Chenger
    public void ChangeColor(bool isNext) // ������� ������� ��������
    {
        if (isNext && _id + 1 < 3) _id++;
        else if (!isNext && _id - 1 >= 0) _id--;
        ImageSize(false, topImage);
        ImageSize(false, midImage);
        ImageSize(false, botImage);
        switch (_id) // �������� ��������� ��������
        {
            case 0:
                ImageSize(true, topImage);
                break;
            case 1:
                ImageSize(true, midImage);
                break;
            case 2:
                ImageSize(true, botImage);
                break;
        }

        if (_id == 0) leftArrow.SetActive(false);
        else leftArrow.SetActive(true);
        if (_id >= 2) rightArrow.SetActive(false);
        else rightArrow.SetActive(true);
    }
    public void ImageSize(bool isUp, Image image) // �������� ��������� ����
    {
        if (isUp)
        {
            image.rectTransform.sizeDelta = new Vector2(110, 120);
            
        }
        else image.rectTransform.sizeDelta = new Vector2(100, 100);
        // ��� ������ �� ����� ������� �������� �������� � ��������� 0-255 � �� ���� ��� ������ ��� 0-1 ���������������
        //s_R = (byte)image.color.r;
        //s_G = (byte)image.color.g;
        //s_B = (byte)image.color.b;
        //r_slider.value = image.color.r;
        //g_slider.value = image.color.g;
        //b_slider.value = image.color.b;
        Debug.Log("����� ������: ������� (" + image.color.r +"; "+ s_R + ") / ������ (" + image.color.g +"; "+ s_G + ") / ����� (" + image.color.b +"; "+ s_B + ")");
}

    public void ChangeColorImage() // ��������� ����� ����
    {
        switch (_id)
        {
            case 0:
                topImage.color = new Color32((byte)s_R, (byte)s_G, (byte)s_B, 255);
                break;
            case 1:
                midImage.color = new Color32((byte)s_R, (byte)s_G, (byte)s_B, 255);
                break;
            case 2:
                botImage.color = new Color32((byte)s_R, (byte)s_G, (byte)s_B, 255);
                break;
        }
    }
    #endregion

    #region Sliders
    public void RedCount(Slider r)
    {
        s_R = r.value;
        ChangeColorImage();
    }
    public void GreenCount(Slider g)
    {
        s_G = g.value;
        ChangeColorImage();
    }
    public void BlueCount(Slider b)
    {
        s_B = b.value;
        ChangeColorImage();
    }
    #endregion

    #region Default
    private void Start()
    {
        ChangeColor(false);
        UpdatePalette();
    }

    public void AcceptColors()
    {
        _id = 0;
        ChangeColor(false);
        groupCreater.GetItem().GetComponent<SkySetterButton>().TopColor(topImage.color);
        groupCreater.GetItem().GetComponent<SkySetterButton>().MidColor(midImage.color);
        groupCreater.GetItem().GetComponent<SkySetterButton>().BotColor(botImage.color);
    }
    public void UpdatePalette()
    {
        var count = 255; //��� 0
        topImage.color = new Color(count, count, count);
        midImage.color = new Color(count, count, count);
        botImage.color = new Color(count, count, count);
        s_R = r_slider.value = count;
        s_G = g_slider.value = count;
        s_B = b_slider.value = count;
    }
    #endregion
}
