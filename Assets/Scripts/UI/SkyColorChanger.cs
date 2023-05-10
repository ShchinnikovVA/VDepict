using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyColorChanger : MonoBehaviour
{
    #region Properties
    public GroupCreater groupCreater;
    [Header("Выбранные цвета")]
    public Image topImage;
    public Image midImage;
    public Image botImage;
    [Header("Стрелки для пролистывания")]
    public GameObject leftArrow;
    public GameObject rightArrow;
    [Header("Слайдеры RGB")]
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
    public void ChangeColor(bool isNext) // функция листает страницы
    {
        if (isNext && _id + 1 < 3) _id++;
        else if (!isNext && _id - 1 >= 0) _id--;
        ImageSize(false, topImage);
        ImageSize(false, midImage);
        ImageSize(false, botImage);
        switch (_id) // показать выбранную картинку
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
    public void ImageSize(bool isUp, Image image) // показать выбранный цвет
    {
        if (isUp)
        {
            image.rectTransform.sizeDelta = new Vector2(110, 120);
            
        }
        else image.rectTransform.sizeDelta = new Vector2(100, 100);
        // ЭТА ПАРАША НЕ МОЖЕТ ЗАБРАТЬ ЗВЕТОВОЕ ЗНАЧЕНИЕ В ДИАПАЗОНЕ 0-255 Я НЕ МОГУ УЖЕ ПОЧЕМУ ТУТ 0-1 ААААААААААААААА
        //s_R = (byte)image.color.r;
        //s_G = (byte)image.color.g;
        //s_B = (byte)image.color.b;
        //r_slider.value = image.color.r;
        //g_slider.value = image.color.g;
        //b_slider.value = image.color.b;
        Debug.Log("Смена Номера: Красный (" + image.color.r +"; "+ s_R + ") / Зелёный (" + image.color.g +"; "+ s_G + ") / Синий (" + image.color.b +"; "+ s_B + ")");
}

    public void ChangeColorImage() // назначить новый цвет
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
        var count = 255; //или 0
        topImage.color = new Color(count, count, count);
        midImage.color = new Color(count, count, count);
        botImage.color = new Color(count, count, count);
        s_R = r_slider.value = count;
        s_G = g_slider.value = count;
        s_B = b_slider.value = count;
    }
    #endregion
}
