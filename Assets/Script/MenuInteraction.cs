﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuInteraction : MonoBehaviour
{
    public int SceneNr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        //Here we load a scene based on a collision
        SceneManager.LoadScene(SceneNr);

    }

}

