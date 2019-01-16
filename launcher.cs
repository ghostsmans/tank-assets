using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour {

    public Rigidbody launch;
    public Vector3 coords;
    public float launch_speed, life_time;
    private float time_start;
    private bool started = true;
    public Transform self;
    // Use this for initialization
    void Start () {
        UnityEngine.Debug.Log("g");
        time_start = Time.time;
        Destroy(gameObject, life_time);
        launch = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "First Tank" || collision.gameObject.tag == "Second Tank")
        {
            //destroy
        }
        else
        {
            if (collision.contacts.Length > 1)
            {
                launch.velocity = -launch.velocity;
            }
            else
            {
                ContactPoint g = collision.contacts[0];
                if (g.normal.x == 1 || g.normal.x == -1)
                {
                    launch.velocity = new Vector3(-launch.velocity.x, launch.velocity.y, launch.velocity.z);
                }
                if (g.normal.z == 1 || g.normal.z == -1)
                {
                    launch.velocity = new Vector3(launch.velocity.x, launch.velocity.y, -launch.velocity.z);
                }
            }
        }
    }*/
    void Update () {
        if (coords != new Vector3(0,0,0) && started)
        {
            UnityEngine.Debug.Log(coords*launch_speed);
            UnityEngine.Debug.Log(launch_speed);
            started = false;
            launch.velocity = coords*launch_speed;
        }

	}
}
