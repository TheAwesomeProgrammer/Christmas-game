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
         
            if (speed < MAXSPEED)
            {
                speed += accSpeed;
            }
            rigidbody.isKinematic = false;
            rigidbody.velocity = new Vector2(0, -speed);
        }
	}

    void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.collider.tag != "IceWall")
        {
            Destroy(gameObject);
        }
      
    }
}
