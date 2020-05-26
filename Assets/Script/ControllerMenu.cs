using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Switch scene if the below button is pressed
        if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            SceneManager.LoadScene(1);
        }
    }
}
