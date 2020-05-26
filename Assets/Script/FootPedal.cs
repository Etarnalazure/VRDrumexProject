using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPedal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the rotation based on how hard the button is pushed
        float rot = (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) * 50);
        //Apply the rotatation to the object
        this.gameObject.transform.rotation = Quaternion.Euler(rot,0,0);
    }
}
