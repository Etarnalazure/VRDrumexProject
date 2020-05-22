using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPedal : MonoBehaviour
{
    public float test= 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rot = (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) * 50);
        this.gameObject.transform.rotation = Quaternion.Euler(rot,0,0);
    }
}
