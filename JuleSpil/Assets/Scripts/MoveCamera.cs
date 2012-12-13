using UnityEngine;
using System.Collections;

public enum Speed
{
    slowDown,
    faster,
    doNothing
}

public class MoveCamera : MonoBehaviour
{
    
    public float speed = 0;
    public bool isCentered = false;
    public float howFarFromCenter = 5;
    public float howCloseToCenter;
    public float riseSpeed = 1f;
    public float fallSpeed = 1f;
    public int id = 1;

    public Speed speedEnum;

    public static bool startAgain = false;
    private Vector3 startVector;
    private float startSpeed;
    private Player player;
    private float distanceFromPlayer;
    private MoveCamera moveCamera;
    

	// Use this for initialization
	void Start ()
	{
	    speedEnum = Speed.faster;
        startSpeed = speed;
	    startVector = transform.position;
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	    moveCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	

	    if (Mathf.Abs(transform.position.x - player.transform.position.x) < howCloseToCenter ||
	        Mathf.Abs(transform.position.x + player.transform.position.x) < howCloseToCenter)
	    {
             if(( Mathf.Abs(transform.position.y - player.transform.position.y) < howCloseToCenter ||
	        Mathf.Abs(transform.position.y + player.transform.position.y) < howCloseToCenter))
             {

            if (speed > startSpeed)
            {
                speedEnum = Speed.slowDown;
            }
	        isCentered = true;

             }
	    }
        if(speed < startSpeed && speedEnum == Speed.slowDown)
	    
        {
            speedEnum = Speed.doNothing;
        }
       
        if (speedEnum == Speed.faster)
        {
          
            speed += (riseSpeed * Time.deltaTime);
        }
      if(speedEnum == Speed.slowDown)
      {
          speed -= (fallSpeed* Time.deltaTime);
      }

      Debug.Log("speedEnum : " + speedEnum);
      if (Mathf.Abs(transform.position.x - player.transform.position.x) > howFarFromCenter ||
          Mathf.Abs(transform.position.y - player.transform.position.y) > howFarFromCenter)
      {
          speedEnum = Speed.faster;
          isCentered = false;
      }

      if (Mathf.Abs(transform.position.y - player.transform.position.y) > howCloseToCenter)
      {
          if (player.transform.position.y > transform.position.y && speedEnum != Speed.doNothing)
          {
              transform.Translate(Vector3.up * Time.deltaTime * speed);
          }
          else if (player.transform.position.y < transform.position.y && speedEnum != Speed.doNothing)
          {
              transform.Translate(Vector3.down * Time.deltaTime * speed);
          }
      }
      if (Mathf.Abs(transform.position.x - player.transform.position.x) > howCloseToCenter)
      {
          if (player.transform.position.x > transform.position.x && speedEnum != Speed.doNothing)
          {
              transform.Translate(Vector3.right*Time.deltaTime*speed);
          }
          else if (player.transform.position.x < transform.position.x && speedEnum != Speed.doNothing)
          {
              transform.Translate(Vector3.left*Time.deltaTime*speed);
          }
      }







	}
}
