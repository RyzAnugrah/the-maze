﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f;   
    public float sprintSpeed = 25f; 
    public float walkSpeed = 15f;    
    public float gravity = -49.05f; 
    public float jumpHeight = 3f;  

    public Transform groundCheck;   
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;   
    bool isGrounded;   

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");    

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); 

        if (Input.GetButtonDown("Jump") && isGrounded)  
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);    
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)  
            speed = sprintSpeed;   
        else
            speed = walkSpeed;  

        velocity.y += gravity * Time.deltaTime; 

        controller.Move(velocity * Time.deltaTime); 
    }
}
