﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("W"))
        {
            UnityEngine.Debug.Log("W was pressed");
        }
	}
}
