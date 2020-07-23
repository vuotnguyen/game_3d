using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_cam_player : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 start0S;
    private Vector3 moveVT;
    private float transition = 0.0f;
    private float animation_time = 4.0f;

    private Vector3 animation_ofset = new Vector3(0,3,5);
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        // khởi tạo khoảng cách ofset
        start0S = transform.position -lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
         //cam di chuyển
        moveVT = lookAt.position + start0S;
        moveVT.x = 0f;
        moveVT.y = Mathf.Clamp(moveVT.y,5,5);
        if(transition > 1.0f){
            transform.position = moveVT;
        }else{
             transform.position = Vector3.Lerp(moveVT+animation_ofset,moveVT, transition);
             transition +=Time.deltaTime*1/animation_time;
             transform.LookAt(lookAt.position+Vector3.up);
        }
    }
}
