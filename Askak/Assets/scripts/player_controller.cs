﻿using System.Collections;
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

    void Start()
    {
        Button btn = jump.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        transform.Translate(Vector3.up * 600 * (Time.deltaTime/2), Space.World);
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
