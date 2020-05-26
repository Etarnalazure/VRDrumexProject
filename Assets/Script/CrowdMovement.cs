using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Vector3 targetPoint;
    private float speed = 3;
    private void Start()
    {
        targetPoint = pointA.position;
    }

    // Move target between targets
    public void Update()
    {
        //Here we make sure they jump up and down by giving them a start, an end and how long to take to get from the two
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint,
            Time.deltaTime * speed);

        if (transform.position == targetPoint)
        {
            if (targetPoint == pointA.position)
            {
                targetPoint = pointB.position;
            }
            else
            {
                targetPoint = pointA.position;
            }
        }
    }
}