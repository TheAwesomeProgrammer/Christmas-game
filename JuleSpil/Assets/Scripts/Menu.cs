using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public float delayBetweenText = 0.2f;

    private float nextCall = 1;

    private int count = 0;

    private Animation animation;

	// Use this for initialization
	void Start ()
	{
	    animation = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
        animation.Play("CreditsUd");
	/*if(nextCall <= Time.time)
	{
	    nextCall = delayBetweenText + Time.time;
	    for (int i = 0; i < animations.Length; i++)
	    {
	        if(i == count)
	        {
	           
	        }
	     
	    }
        count++;
	   
	}*/

	   

	}

}
