using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class Interaction : MonoBehaviour
{
    //public int color = 0;
    public Renderer rend;
    public float force=0;
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



        if (other.GetComponent<ControllerVelocity>() != null)
        {
            force = other.GetComponent<ControllerVelocity>().speed;
            if (force <= 1f)
            {
                SoundSource.clip = Sound[0];
            }
            else if (force > 1f && force < 2f)
            {
                SoundSource.clip = Sound[1];
            }
            else if (force < 2.1f)
            {
                SoundSource.clip = Sound[2];
            }
            else
            {
                SoundSource.clip = Sound[0];
            }
        }
        else
        {
            SoundSource.clip = Sound[0];
        }

        SoundSource.Play(0);

    }
    private void OnTriggerExit(Collider other)
    {

 
    }
}
