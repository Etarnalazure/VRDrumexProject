using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumAlong : MonoBehaviour
{
    // public OVRInput.GetDown menu = OVRInput.GetDown.Start;
    public GameObject removePrevMenu;
    public GameObject menuDrum;

    void Start()
    {

    }

    void Update()
    {


    }


    private void OnTriggerEnter(Collider other)
    {
        //force = other.GetComponent<ControllerVelocity>().speed;

        // color = Random.Range(0, 10);

        removePrevMenu.gameObject.SetActive(!removePrevMenu.gameObject.activeSelf);
        menuDrum.gameObject.SetActive(!menuDrum.gameObject.activeSelf);

    }

}
