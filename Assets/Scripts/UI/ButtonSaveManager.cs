using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSaveManager : MonoBehaviour
{
    public string _name;
    [HideInInspector]
    public SaveLoadManager saveLoadManager;

    private void Start()
    {
       saveLoadManager = GameObject.Find("Button (NewProject)").GetComponent<SaveLoadManager>();
    }

    public void setClick()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => saveLoadManager.Load(_name));
    }
}
