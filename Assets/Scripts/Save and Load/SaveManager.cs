using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class SaveVanager : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public Color color;
    public currentDrawing
    public void Save(string filename)
    {
        LineData data = new LineData();
        for (int i = 0; i < _currentDrawing.positionCount; i++)
        {
            data.positions.Add(_currentDrawing.GetPosition(i));
        }
        data.color = _currentDrawing.startColor; // assuming startColor and endColor are the same
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(filename, json);
    }

    public void Load(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            LineData data = JsonConvert.DeserializeObject<LineData>(json);
            _currentDrawing.positionCount = data.positions.Count;
            for (int i = 0; i < data.positions.Count; i++)
            {
                _currentDrawing.SetPosition(i, data.positions[i]);
            }
            _currentDrawing.startColor = _currentDrawing.endColor = data.color;
        }
        else
        {
            Debug.LogError("File not found");
        }
    }
}



