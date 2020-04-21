using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InteractionTest : MonoBehaviour
{
    public int color = 0;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Debug.Log("test22");
        color =Random.Range(0, 10);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("test");
        switch (color)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.cyan; break;
            case 2: rend.material.color = Color.blue; break;
            case 3: rend.material.color = Color.black; break;
            case 4: rend.material.color = Color.red; break;
            case 5: rend.material.color = Color.green; break;
            case 6: rend.material.color = Color.grey; break;
            case 7: rend.material.color = Color.magenta; break;
            case 8: rend.material.color = Color.yellow; break;
            case 9: rend.material.color = Color.gray; break;
        }
    }
}
