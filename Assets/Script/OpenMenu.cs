using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{

    // public OVRInput.GetDown menu = OVRInput.GetDown.Start;
    public GameObject menuOpen;
    public GameObject removeDrums;

    void Start()
    {

    }

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            menuOpen.gameObject.SetActive(!menuOpen.gameObject.activeSelf);
            removeDrums.gameObject.SetActive(!removeDrums.gameObject.activeSelf);
        }

    }
}



