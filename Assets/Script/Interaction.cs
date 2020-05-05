using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class Interaction : MonoBehaviour
{
    public int color = 0;
    public Renderer rend;
    public float force;
    public AudioSource SoundSource;
    public AudioClip[] Sound;

    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        SoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //force = other.GetComponent<ControllerVelocity>().speed;
        color =Random.Range(0, 10);
    }
    private void OnTriggerExit(Collider other)
    {
     
        other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.angularVelocity = Vector3.zero;
        
        force = other.GetComponent<ControllerVelocity>().speed;
        if (force <= 1f)
        {
            SoundSource.clip = Sound[0];
        }
        else if (force > 1f && force < 2f)
        {
            SoundSource.clip = Sound[1];
        }
        else
        {
            SoundSource.clip = Sound[2];
        }
        SoundSource.Play(0);
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
