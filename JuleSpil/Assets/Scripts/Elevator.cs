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
    private Vector3 endVector = new Vector3(68.69097f, 6.272288f, 13.53933f);

    private GameObject sign;

    public bool playerIsOnElevator { get; set; }

	// Use this for initialization
	void Start ()
	{
	    playerIsOnElevator = false;
	    shouldOperate = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	 
        if (Mathf.Abs(transform.position.y - endVector.y) < 2.2f)
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
       
            rigidbody.velocity = Vector3.up;
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
