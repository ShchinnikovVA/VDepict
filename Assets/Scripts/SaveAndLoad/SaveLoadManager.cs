using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public LineRendererData[] FrameLines { get; set; }
        public int FrameOrderId { get; set; }

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

    private string _pathToSave { get => Path.Combine(Application.dataPath, "saves"); }
    public Transform FramesContainer;
    public LineRenderer LinePrefab;
    
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
                FrameOrderId = counter,
                FrameLines = frame.GetComponentsInChildren<LineRenderer>().Select(l =>
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
        
        Debug.Log(fileName);
        var path = Path.Combine(_pathToSave, fileName + ".json");
        // path = path.Replace("/", "\\");
        FileInfo file = new FileInfo(path);
        if (!file.Exists)
        {
            file.Create();
        }

        using var fs = file.OpenWrite();
        var byteBuffer = Encoding.UTF8.GetBytes(json);
        fs.Write(byteBuffer, 0, byteBuffer.Length);
        //Debug.Log(path);
    }

    public async Task Load(string name)
    {
        //string jsonString = File.ReadAllText(fileName);
        //JsonConvert.DeserializeObject<SceneDTO>();
        var savesFolder = new DirectoryInfo(_pathToSave);
        if (savesFolder.Exists)
        {
            var file = savesFolder.EnumerateFiles().
                OrderByDescending(f => f.LastWriteTimeUtc)
                .FirstOrDefault();

            if (!file.Exists) return;
            using var fs = file.OpenRead();
            var bytes = new byte[file.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);

            var json = Encoding.UTF8.GetString(bytes);


            var scene = JsonConvert.DeserializeObject<SceneDTO>(json);

            foreach (Transform ch in FramesContainer)
            {
                Destroy(ch.gameObject);
            }

            foreach (var fr in scene.FramesData.OrderBy(fr => fr.FrameOrderId))
            {
                var gayObj = new GameObject();
                gayObj.transform.SetParent(FramesContainer, false);
                gayObj.transform.localPosition = Vector3.zero;

                foreach(var line in fr.FrameLines)
                {
                    var points = line.Points
                        .Select(p => new Vector3(x: p.X, y: p.Y, z: p.Z))
                        .ToArray();
                    var lr = Instantiate(LinePrefab, gayObj.transform, false);
                    lr.transform.localPosition = points.First();
                    lr.SetPositions(points);
                }
            }
        }
    }
    public void Loading()
    {
    
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


