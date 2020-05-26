using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{

    public GameObject menuOpen;
    public GameObject removeDrums;

    void Start()
    {

    }

    void Update()
    {
        //Here we open or close the menu based on a button press
        if (OVRInput.GetDown(OVRInput.Button.Start) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            menuOpen.gameObject.SetActive(!menuOpen.gameObject.activeSelf);
            removeDrums.gameObject.SetActive(!removeDrums.gameObject.activeSelf);
        }

    }
}



