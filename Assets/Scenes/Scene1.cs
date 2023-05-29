using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    void GoToPlayScene()
    {
        SceneManager.LoadScene(1);   
    }
}
