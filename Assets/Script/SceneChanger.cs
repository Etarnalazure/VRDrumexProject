using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public int sceneTime;
    
    // Start is called before the first frame update
    void Start()
    {
        //Here we change the scene using an invoke which allows for a timer
        Invoke("ChangeScene", sceneTime);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(9);
    }
    
}
