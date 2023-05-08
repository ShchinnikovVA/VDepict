using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class DrawingController : MonoBehaviour
{
    // Start is called before the first frame update
    private InputDevice targetDevice;
    BrushPrefabController brushPrefabController = new BrushPrefabController();
    void Start()
    {
        List<InputDevices> devices = new List<InputDevices>();

        
    }

    void Update()
    {


        //if (Input.GetKeyDown(""))
        //{
            
        //    brushPrefabController.isDrawing = true;

        //}
        //brushPrefabController.isDrawing = false;
    }
}
