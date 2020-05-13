using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVelocity : MonoBehaviour
{
    public float speed;
    public GameObject SpawnPoint;
    private Rigidbody rb;

    public bool Left = false;
    public bool Right = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
        if (Left)
        {
            speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;
        }
        else if(Right)
        {
            speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
           OVRInput.SetControllerVibration(1,1, OVRInput.Controller.RTouch);
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        this.gameObject.transform.position = SpawnPoint.gameObject.transform.position;
        this.gameObject.transform.rotation = SpawnPoint.gameObject.transform.rotation;
    }

}
