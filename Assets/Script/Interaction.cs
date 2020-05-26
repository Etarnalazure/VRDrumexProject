using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class Interaction : MonoBehaviour
{

    public float force=0;
    public AudioSource SoundSource;
    public AudioClip[] Sound;
 
    
    // Start is called before the first frame update
    void Start()
    {
        SoundSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //If the object colliding with the this object does not have the component
        //ControllerVelocity, then do nothing.
        if (other.GetComponent<ControllerVelocity>() != null)
        {
            //Get the speed of the controller
            force = other.GetComponent<ControllerVelocity>().speed;
            //If the speed is a certain amount, play different sounds.
            if (force <= 1f)
            {
                //Play the sound
                SoundSource.PlayOneShot(Sound[0]);
            }
            else if (force > 1f && force < 2f)
            {
                //Play the sound
                SoundSource.PlayOneShot(Sound[1]);
            }
            else if (force < 2.1f)
            {
                //Play the sound
                SoundSource.PlayOneShot(Sound[2]);
            }
            else
            {
                //Play the sound
                SoundSource.PlayOneShot(Sound[0]);
            }
            
        }
        else if (other.GetComponent<FootPedalCheatScript>() != null)
        {
            //This is for the foot drum part, it only has 1 sound.
            SoundSource.PlayOneShot(Sound[0]);
        }

    }

}
