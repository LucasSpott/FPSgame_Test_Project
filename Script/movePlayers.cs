using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayers : MonoBehaviour{

    public float velocity = 2.0f;
    public float jump = 5.0f;
    public float gravity = 9.8f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    Rigidbody rb;
    void Awake(){
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update(){
        if(controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= velocity;
            if(Input.GetButton("Jump")){
                moveDirection.y = jump;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
