using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Material greenSign;
    public Material redSign;

    public float speed;
    public float length = 5;

    public bool shouldOperate { get; set; }

    private bool shouldSignOperate;

    private Vector3 startVector;
    public Vector3 endVector { get; set; }

    private GameObject sign;

    
	// Use this for initialization
	void Start ()
	{
	    endVector = new Vector3(transform.position.x, transform.position.y + length, transform.position.z);
	    shouldOperate = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	 
        if (Mathf.Abs(transform.position.y - endVector.y) < 0.1f)
        {
            rigidbody.velocity = Vector3.zero;
            shouldOperate = false;
        }

        if (shouldSignOperate)
        {
            GameObject.Find("Sign").renderer.material = greenSign;
        }
        else
        {
            GameObject.Find("Sign").renderer.material = redSign;
        }

    if(shouldOperate)
    {
        shouldSignOperate = true;
        if (endVector.y > transform.position.y)
        {
             rigidbody.velocity = Vector3.up;
        }
        else if (endVector.y < transform.position.y)
        {
            rigidbody.velocity = Vector3.down;
        }
           
    }
    else
    {
        sign = GameObject.Find("Sign");
        sign.rigidbody.velocity = Vector3.zero;
        
    }
    }

    void OnTriggerEnter(Collider otherObject)
    {
       Debug.Log("Comming into ontrigger ELEVATOR");
        if(otherObject.name == "Sign")
        {
            otherObject.collider.rigidbody.AddForce(Vector3.up * 50);
        }
    }
}
