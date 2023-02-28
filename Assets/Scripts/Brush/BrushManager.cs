using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public Collider brushSize; 

    public float _brushSize = 1; // потом сделать приватным
    // _brushSize лучше стоит занести в какой-нибудь скрипт, который будет хранить изменения и после перезапуска программы

    public void OpenBrushSettigs()
    {
        //открывает окошко с вариантами кистей и их цветом
    }
    public void CloseBrushSettigs()
    {
        // Закрывает это окошко
    }

    public void UseEraser()
    {
        //стёрка
    }

    public void ChangeBrushSize()
    {
        //Изменить размер области кисти
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
