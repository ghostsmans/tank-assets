using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_control_test : MonoBehaviour {

    public float walkSpeed;
    public float curSpeed;
    public float maxSpeed;
    public Rigidbody characontrol;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        characontrol.velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),0, Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

    }
}
