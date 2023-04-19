using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public List<GameObject> controllerPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
