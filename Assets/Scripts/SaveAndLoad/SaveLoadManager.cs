using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{

    public class SceneDTO
    {
        public List<FrameDTO> FramesData { get; set; }

    }

    public class FrameDTO
    {
        public LineRendererData[] LineInFrames { get; set; }
        public int OrderInFrames { get; set; }

    }
    public class LineRendererData
    {
        public Vector3DTO[] Points { get; set; }
    }

    public class Vector3DTO
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }



    public string pathToSave = Application.dataPath + "/saves/";
    public Transform FramesContainer;
    public void Save()
    {

        SceneDTO sceneDTO = new SceneDTO
        {
            FramesData = new List<FrameDTO>()

        };
        int counter = 0;
        foreach (Transform frame in FramesContainer)
        {

            FrameDTO frameDTO = new FrameDTO
            {
                OrderInFrames = counter,
                LineInFrames = frame.GetComponentsInChildren<LineRenderer>().Select(l =>
                {
                    var vector = new Vector3[l.positionCount];
                    
                    l.GetPositions(vector); 
                    //l.SetPositions(vector)
                    return new LineRendererData { Points = vector.Select(v => new Vector3DTO { X = v.x, Y = v.y, Z = v.z }).ToArray() };
                }).ToArray()
            };
            counter++;
            sceneDTO.FramesData.Add(frameDTO);
        }
        string json = JsonConvert.SerializeObject(sceneDTO);
        string fileName = DateTime.Now.ToString();
        var path = Path.Combine(Application.dataPath,"/saves/" + fileName + ".json");
        path = path.Replace("/", "\\");
        FileInfo file = new FileInfo(path);
        if (!file.Exists)
        {
            file.Create();
        }

        using var fs = file.OpenWrite();
        var byteBuffer = Encoding.UTF8.GetBytes(json);
        fs.Write(byteBuffer, 0, byteBuffer.Length);
        Debug.Log(path);
    }

    public void Load(string name)
    {

        //string jsonString = File.ReadAllText(fileName);
        //JsonConvert.DeserializeObject<SceneDTO>();

    }

    //public void Check()
    //{
    //    System.IO.FileInfo[] GetFiles(".json", )
    //}

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}


