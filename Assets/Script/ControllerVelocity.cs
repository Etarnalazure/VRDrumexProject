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

    public bool IsColliding = false;
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
        }
        if (!IsColliding)
        {
            this.gameObject.transform.position = SpawnPoint.gameObject.transform.position;
            this.gameObject.transform.rotation = SpawnPoint.gameObject.transform.rotation;
            this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        IsColliding = true;
        if (IsColliding)
        {
            Rumble(1f);
        }
    }
    void OnCollisionExit(Collision other)
    {
        IsColliding = false;
        if (!IsColliding)
        {
            Rumble(0);
        }
    }

    public void Rumble(float amplitude = 1)
    {
        if (Left)
        {
            OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.LTouch);
        }
        else if(Right)
        {
            OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.RTouch);
        }
    }

}
