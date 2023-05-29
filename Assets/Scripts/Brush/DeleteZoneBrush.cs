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
            GetComponent<SphereCollider>().radius = radius; // �����, ��� ����� ����� �������. ���� ����� ������ ������ � ����, �� �������� � � �������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " �����");
        if (other.tag == "Paint" && isDelete) // ���� � ���� ����� ������� � ����� �����
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
