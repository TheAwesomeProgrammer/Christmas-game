using UnityEngine;
using System.Collections;

public class FallingIceCubes : MonoBehaviour {

    public float MAXSPEED = 5;
    public float touchDelay = 1;
    public float accSpeed;

    private float speed;

    public float whenToFall { get; set; }

	// Use this for initialization
	void Start () {
        whenToFall = float.MaxValue;
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (whenToFall <= Time.time)
        {
            GetComponent<BoxCollider>().isTrigger = true;
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
           
        }
    }
}
