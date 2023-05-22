using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineManager : MonoBehaviour
{
    #region Preferences
    [Header("Префаб кадра")]
    public GameObject frame;
    //public GameObject lineFrame;
    [Header("Настройки таймлайна")]
    [Range(1, 60)]
    public int frameCount = 60;
    [Range(1, 60)]
    public int fps = 5;
    [Header("Визуальное обозначение кадра")]
    public Image frameExist;
    [Header("Текстовые обозначения")]
    public Text thisFrame;
    public Text frameRate;
    private GameObject[] _frames;
    private int _index; //текущий номер кадра
    private int _fr = 0; //сохранение номера кадра для отображения предыдущего
    [HideInInspector]
    public bool _isAnimate;
    public Transform FramesFolder;
    #endregion

    void Start()
    {
        _index = 0;
        thisFrame.text = _index.ToString();
        frameRate.text = fps.ToString();
        _frames = new GameObject[frameCount];
        //Debug.Log(_frames.Length);
        CreateFrame();
    }

    #region Frame Settings
    public void CreateFrame()
    {

        //Debug.Log(_index);
        if (_frames[_index] == null)
        {
            _frames[_index] = Instantiate(frame, FramesFolder);
            frameExist.color = Color.green;
            for (int j = 0; j <= frameCount - 1; j++)
            {
                if (j != _index && _frames[j] != null)
                {
                    _frames[j].SetActive(false);
                }
            }
        }
    }
    public void DeleteFrame()
    {
        frameExist.color = Color.gray;
        Destroy(_frames[_index]);
        _frames[_index] = null;
        Debug.Log(_frames[_index] == null);

    }
    public void SetPaintToFrame(GameObject _paint)
    {
        if (_frames[_index] == null)
        {
            while (_frames[_index] == null)
            {
                _index--;
            }
            thisFrame.text = _index.ToString();
        }
        _paint.transform.SetParent(_frames[_index].transform);
    }
    #endregion

    #region FrameScroll
    public void NextFrame()
    {
        if (_index < _frames.Length-1)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }
        thisFrame.text = _index.ToString();
        VisibilityFrame();
    }
    public void PreviousFrame()
    {
        if (_index > 0)
        {
            _index--;
        }
        else
        {
            _index = _frames.Length - 1;
        }
        thisFrame.text = _index.ToString();
        VisibilityFrame();
    }
    #endregion

    #region Visibiliry
    private void VisibilityFrame()
    {
        if (_frames[_index] != null)
        {
            PreviosVisibility(_index);
            frameExist.color = Color.green;
            _frames[_index].SetActive(true);
        }
        else
        {
            frameExist.color = Color.gray;
        }
    }
    private void PreviosVisibility(int i) // есть не критичный косяк, когда создаёшь кадр между двумя существующими и иногда отображается сразу два. Перемотка кадров исправляет ситуацию
    { // отображение кадров на незанятых фреймрейтах
        if (i == 0) _frames[i].SetActive(true);
        if (_frames[i] != null && _fr != i)
        {
            _frames[_fr].SetActive(false);
            _fr = i;
        }
        else if (_frames[i] == null)
        {
            _frames[_fr].SetActive(true);
        }
    }
    #endregion

    #region FPS Scroll
    public void UpFrameRate()
    {
        if (fps + 5 > 60)
        {
            fps = 60;
        }
        else
        {
            if (fps == 1)
            {
                fps = fps + 4;
            }
            else
            {
                fps = fps + 5;
            }
        }
        frameRate.text = fps.ToString();
    }
    public void DownFrameRate()
    {
        if (fps - 5 < 1)
        {
            fps = 1;
        }
        else
        {
            fps = fps - 5;
        }
        frameRate.text = fps.ToString();
    }
    #endregion

    #region Animarion
    public void PlayAnim()
    {
        _isAnimate = true;
        StartCoroutine(PlayPaintAnimation());
    }
    public void StopAnim()
    {
        _isAnimate = false;
        StopCoroutine(PlayPaintAnimation());
    }
    IEnumerator PlayPaintAnimation() 
    {
        while (_isAnimate)
        {
            yield return new WaitForSeconds(1f / fps); // поэксперементировать со временем, некоторые кадры не успевают появиться при значениях 15+
            //_index++;
            thisFrame.text = _index.ToString();
            NextFrame();
        }
    }
    #endregion
}
