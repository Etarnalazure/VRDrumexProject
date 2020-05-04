using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public enum ReleaseBehaviour { Reset, Shoot, Throw }
    public ReleaseBehaviour releaseBehaviour;

    public void Grab(Transform grabber)
    {
        Debug.Log(this.name + " is being grabbed by " + grabber.name);
    }

    public void Release(Transform grabber)
    {
        Debug.Log(this.name + " is being released by " + grabber.name);
    }
}
