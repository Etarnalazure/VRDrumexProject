using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVelocity : MonoBehaviour
{
    public float speed;
    public GameObject SpawnPoint;
    private Rigidbody rb;

    //A small hack to tell the difference
    //between which controller the script belongs to
    public bool Left = false;
    public bool Right = false;

    public bool IsColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        //Here we get the rigidbody component stuck to the gameobject
        rb = GetComponent<Rigidbody>();
        //Here we reset the velocity so the drumsticks wont continue to be pushed back forever
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Left)
        {
            //Here we get the speed of the controller
            speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;

        }
        else if(Right)
        {
            speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
        }
        //If the drumstick is not currently colliding, then reset the drumstick to the spawn's position
        if (!IsColliding)
        {

            //If the controller isnt currently colliding, then reset the drum stick to the position of the ghost drumstick and reset the velocity
            this.gameObject.transform.position = SpawnPoint.gameObject.transform.position;
            this.gameObject.transform.rotation = SpawnPoint.gameObject.transform.rotation;
            this.rb.velocity = Vector3.zero;
            this.rb.angularVelocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //We're currently hitting something
        IsColliding = true;
        //If the drumstick is colliding, then start the rumbling.
        if (IsColliding)
        {
            Rumble(1f);
        }
    }
    void OnCollisionExit(Collision other)
    {
        //We're no longer hitting something.
        IsColliding = false;
        //If the drumstick is not colliding, then stop the rumbling.
        if (!IsColliding)
        {
            Rumble(0);
        }
    }

    public void Rumble(float amplitude = 1)
    {
        //Here we make sure to differentiate which controller needs to rumble
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
