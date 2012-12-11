using UnityEngine;
using System.Collections;

public class FallingIceCubes : MonoBehaviour {

    public float MAXSPEED = 5;
    public float touchDelay = 1;
    public float accSpeed;

    private float speed;

    private float whenToFall = float.MaxValue;

	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (whenToFall <= Time.time)
        {
            if (speed < MAXSPEED)
            {
                speed += accSpeed;
            }
            rigidbody.velocity = new Vector2(0, -speed);
        }
	}

    void OnTriggerEnter(Collider collidingObject)
    {
        Debug.Log("Colliding tag : " + collidingObject.tag);
        if (collidingObject.tag == "Player")
        {
            whenToFall = Time.time + touchDelay;
        }
    }
}
