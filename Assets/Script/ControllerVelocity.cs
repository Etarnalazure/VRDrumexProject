using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVelocity : MonoBehaviour
{
    public float speed;
    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        speed = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
    }

    void OnCollisionExit(Collision other)
    {
        this.gameObject.transform.position = SpawnPoint.gameObject.transform.position;
        this.gameObject.transform.rotation = SpawnPoint.gameObject.transform.rotation;
    }

}
