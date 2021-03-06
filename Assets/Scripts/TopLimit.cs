﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLimit : MonoBehaviour
{
    public CameraMovement cameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cameraMovement.MoveUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraMovement.StopUp();
        }
    }

}
