using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZoneBrush : MonoBehaviour
{
    [HideInInspector]
    public float radius = 0.5f;
    //[HideInInspector]
    public bool isDelete;
    private bool isDrawing;

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
        if (other.tag == "Paint" && isDelete) // если в зоне стёрки рисунок и нажат курок
        {
            Destroy(other.gameObject);
        }
    }
    public void SetIsDeleteTrue()
    {
        if (isDelete)
        {
            isDelete = false;
        }
        else
        {
            isDelete = true;
        }

    }

    public void SetDeletTrue()
    {
        isDelete= true;

    }
    public void SetDeletFalse()
    {
        isDelete = false;

    }

}
