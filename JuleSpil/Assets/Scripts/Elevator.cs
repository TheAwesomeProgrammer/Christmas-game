using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Material greenSign;
    public Material redSign;

    public float speed;

    public bool shouldOperate { get; set; }

    private bool shouldSignOperate;

    private Vector3 startVector;
    public Vector3 endVector { get; set; }

    private GameObject sign;

    public bool playerIsOnElevator { get; set; }

	// Use this for initialization
	void Start ()
	{
        if (Application.loadedLevelName == "level1")
        {
            endVector = new Vector3(66.72536f, 4.054714f, 1f);
        }
        if (Application.loadedLevelName == "level3")
        {
            endVector = new Vector3(17.46829f, -51.78516f, -2.689121f);
        }
       
	    playerIsOnElevator = false;
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
        if (Application.loadedLevelName == "level1")
        {
            rigidbody.velocity = Vector3.up;
        }
        shouldSignOperate = true;
        if (Application.loadedLevelName == "level3")
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
