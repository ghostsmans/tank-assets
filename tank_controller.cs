using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_controller : MonoBehaviour {
    public int throttle_speed=5, reverse_speed=5, hits_remaining=1, charge_limit=20;
    public string throttle, reverse, left, right;
    private float start;
    public CharacterController _controller;
    public Transform rotator;
    public GameObject bullet, gun;
    public Vector3 coords;
    public string name;
	// Use this for initialization
	void Start () {
        gameObject.name = name;   
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.SimpleMove(move*throttle_speed);
        if (Input.GetKeyDown("joystick button 5"))
        {
            start = Time.time;
        }
        //UnityEngine.Debug.Log("3rd " + test1.ToString("0.000"));
        //UnityEngine.Debug.Log("6th " + test2.ToString("0.000"));
        if (Input.GetKeyUp("joystick button 5"))
        {
            float x_vec = Input.GetAxis("3rd Axis");
            float z_vec = Input.GetAxis("6th Axis");
            //Vector3 shoot = new Vector3(Input.GetAxis("3rd Axis"), 0, Input.GetAxis("6th Axis"));
            Vector3 shoot = new Vector3(x_vec, 0, z_vec);
            float max = Time.time - start;
            if (max > charge_limit)
            {
                max = charge_limit;
            }
            //UnityEngine.Debug.Log("boom, charged for " + max.ToString());

            coords = new Vector3(x_vec, 0, z_vec);
            UnityEngine.Debug.Log(x_vec.ToString("0.000") + ' ' + coords.y.ToString() + ' ' + z_vec.ToString("0.000"));
            GameObject bullet1 = Instantiate(bullet, rotator.position+coords, Quaternion.identity) as GameObject;
            /*foreach (Transform child in bullet1.transform)
            {
                // try to get the child script:
                launcher script = child.GetComponent<launcher>();
                UnityEngine.Debug.Log(script.ToString());
                if (script)
                { // if it has such script...
                    script.coords = coords; // set its variable
                }
            }*/
            bullet1.transform.GetComponent<launcher>().coords = coords;

        }
        }
}

