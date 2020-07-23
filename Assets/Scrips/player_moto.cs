using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moto : MonoBehaviour
{
    private float speed = 5.0f;
    private CharacterController controller;
    //điều phối 
    private float velocity = 0.0f;
    // vận tốc ngang
    private float gravity = 11.0f;
    //trọng lượng
    private float time_ami = 3.0f;

    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // ánh xạ 

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero; 
        if (Time.time < time_ami)
        {
        //di chuyển
        controller.Move(Vector3.forward * speed * Time.deltaTime);
        return;
    }
    if (controller.isGrounded)
    {
        velocity = -0.5f;
    }
    else //ko phải đất thì trọng lượng hút xuống
    {
        velocity -= gravity*Time.deltaTime;
    }
    //định nghĩa di chuyển
    moveVector.x = Input.GetAxisRaw("Horizontal")*speed; 
    moveVector.y = velocity;
    moveVector.z = speed;
    controller.Move(moveVector*Time.deltaTime);
}
    public void SetSpeed(float modifi){
        speed = 5.0f + modifi;
    }
}

