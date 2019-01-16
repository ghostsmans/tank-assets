using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_turner : MonoBehaviour {
    Vector3 center1;
    public Transform self, center;
    public Vector3 saved;
    private float current_angle, new_angle;
	// Use this for initialization
	void Start () {
        current_angle = 0;
    }
	
	// Update is called once per frame
	void Update () {
        center1 = self.parent.position;
        new_angle = Mathf.Rad2Deg* Mathf.Atan(Input.GetAxis("6th Axis") / Input.GetAxis("3rd Axis"));
        if (Input.GetAxis("6th Axis")>Mathf.Sqrt(1/2) || Input.GetAxis("3rd Axis")>Mathf.Sqrt(1/2) || Input.GetAxis("6th Axis") < -Mathf.Sqrt(1 / 2) || Input.GetAxis("3rd Axis") < -Mathf.Sqrt(1 / 2))
        {
            //self.RotateAround(center1, Vector3.up, Mathf.Rad2Deg * Mathf.Atan(Input.GetAxis("6th Axis") / Input.GetAxis("3rd Axis")));
            if (new_angle != current_angle){
                self.Rotate(new Vector3(0, - new_angle + current_angle, 0));
                self.position = center.position + new Vector3(Input.GetAxis("3rd Axis"), 0, Input.GetAxis("6th Axis"));
                current_angle = new_angle;
            }
        }
        //UnityEngine.Debug.Log(Input.GetAxis("6th Axis") / Input.GetAxis("3rd Axis"));
        //UnityEngine.Debug.Log(Input.GetAxis("6th Axis"));
        //UnityEngine.Debug.Log(Input.GetAxis("3rd Axis"));
	}
}
