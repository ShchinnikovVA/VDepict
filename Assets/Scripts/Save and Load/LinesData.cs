using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LineData : MonoBehaviour
{
    public List<Vector3> curentLine = new List<Vector3>();
    public List<LineRenderer> lines = new List<LineRenderer>();
    public List<Vector3> GetLines(List<Vector3> curentLine)
    {
        //List<LineRenderer> lines = GetComponents<LineRenderer>();
        
        return curentLine;
    }
}


public class LineRecorder : MonoBehaviour
{
    
}