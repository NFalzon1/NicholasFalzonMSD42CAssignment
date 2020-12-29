﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float test = 5f;

    [SerializeField] float moveSpeed = 10f;

    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    //setup the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;

        //xMin = 0 xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    //moves the Player car
    private void Move()
    {
        //deltaX is updated with the movement in the x-axis 
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos = current x-pos of player
        //+ difference in X by keyboard Input
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);


        //move the car to the newXPos
        this.transform.position = new Vector2(newXPos, transform.position.y);

    }
}
