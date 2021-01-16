using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {
    // Start is called before the first frame update

    public FixedJoystick  mjs;
    public DynamicJoystick ljs;
    public Button jump;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float thrust = -5.0f;
    public Rigidbody rb;

    public float distToGround;

    Collider collider;


    void Start()    {
        Button btn = jump.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }

    public Boolean IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

void TaskOnClick()    {
        
        if (IsGrounded()) {
        Debug.Log("You have clicked the button!");
            rb.velocity = rb.velocity + Vector3.up * 5;
            }

        }

    // Update is called once per frame
    void Update(){
        float hoz = mjs.Horizontal;
        float ver = mjs.Vertical;

        float rotx = ljs.Horizontal;
        float roty = ljs.Vertical;

        //Vector2 convertedXY = convertWCamera(Camera.main.transform.position, hoz, ver);

        Vector3 ldir = new Vector3(0, rotx, 0);
        transform.Rotate(ldir * 1f, Space.World);

        Vector3 direction = new Vector3(hoz, 0, ver);
        transform.Translate(direction * 0.02f, Space.Self);
    }

    //private Vector2 convertWCamera(Vector3 camPos, float hoz, float ver)
    //{

    //    return null;
    //}


}
