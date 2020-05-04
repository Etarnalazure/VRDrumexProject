using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Grabber : MonoBehaviour
{
    public Transform grabAnchor;

    [Header("Only used for ReleaseBehaviour 'Shoot'")]
    public float shootSpeed = 20f;
    [Header("Only used for ReleaseBehaviour 'Throw'")]
    public float throwSpeed = 5f;
    public int laserLength = 100;
    public OVRInput.Button grabButton = OVRInput.Button.SecondaryHandTrigger;

    private LineRenderer lineRenderer;
    private Vector3 gunDirection;
    private bool attemptGrabbing = false;
    private Grabbable grabbedObject = null;
    private Vector3 grabbedOriginalPosition = Vector3.zero;
    
    private void Start()
    {
        this.lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        this.gunDirection = grabAnchor.transform.TransformDirection(Vector3.up).normalized;
        this.attemptGrabbing = OVRInput.Get(grabButton) || Input.GetMouseButton(0);

        // Drawing the laser
        lineRenderer.SetPosition(0, this.grabAnchor.position);
        lineRenderer.SetPosition(1, this.grabAnchor.position + gunDirection * laserLength);
        
        // Do some grabbing
        if (this.attemptGrabbing && grabbedObject == null)
        {
            this.AttemptGrab();
        }
        else if (!this.attemptGrabbing && grabbedObject != null)
        {
            this.ReleaseGrab();
        }
    }

    private void AttemptGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(grabAnchor.position, this.gunDirection, out hit, laserLength))
        {
            GameObject target = hit.collider.gameObject;
            Debug.Log("This object was hit with raycast: " + target.name);
            Grabbable grabbable = target.GetComponent<Grabbable>();

            // The grabbable component exists if the object is grabbable
            if (grabbable != null)
            {
                Debug.Log("Grabbing object '" + target.name + "'!");
                grabbable.Grab(this.transform);
                Rigidbody rb = target.GetComponent<Rigidbody>();
                this.grabbedOriginalPosition = target.transform.position;
                this.grabbedObject = grabbable;
                target.transform.parent = grabAnchor.transform;
                target.transform.localPosition = Vector3.zero;

                // If the object has a rigidbody
                if (rb != null)
                {
                    rb.useGravity = false;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
        }
    }

    private void ReleaseGrab()
    {
        // Release the object from the 'Grabber'
        this.grabbedObject.Release(this.transform);
        this.grabbedObject.transform.parent = null;

        // If it has a rigidbody, reenable gravity and remove constraints
        Rigidbody rb = this.grabbedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }

        // Pick the right behaviour
        if (this.grabbedObject.releaseBehaviour == Grabbable.ReleaseBehaviour.Shoot)
        {
            if (rb != null)
            {
                rb.AddForce(this.gunDirection * this.shootSpeed, ForceMode.Impulse);
            }
        }
        else if (this.grabbedObject.releaseBehaviour == Grabbable.ReleaseBehaviour.Reset)
        {
            this.grabbedObject.transform.position = grabbedOriginalPosition;
        }
        else if (this.grabbedObject.releaseBehaviour == Grabbable.ReleaseBehaviour.Throw)
        {
            if (rb != null)
            {
                rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * this.throwSpeed;
            }
        }

        // Remove the reference so new objects can be grabbed.
        this.grabbedObject = null;
    }
}
