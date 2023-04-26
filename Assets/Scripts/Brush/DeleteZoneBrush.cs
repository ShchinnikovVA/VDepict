using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZoneBrush : MonoBehaviour
{
    [HideInInspector]
    public float radius = 0.5f;
    void Update()
    {
        if (radius != GetComponent<SphereCollider>().radius)
        {
            GetComponent<SphereCollider>().radius = radius; // думаю, это можно лучше сделать. Если игрок меняет радиус у себя, то меняется и у тригера
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " удалён");
        //if (Input.GetKey(KeyCode.E)) //поменять на кнопку контроллера
        //{
            //Debug.Log("кнопка Е нажата");
            if (other.tag == "Paint")
            {
                Destroy(other.gameObject);
            }
        //}
    }
}
