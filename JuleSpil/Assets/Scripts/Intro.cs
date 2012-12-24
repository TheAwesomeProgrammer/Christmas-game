using UnityEngine;
using System.Collections;




public class Intro : MonoBehaviour {

    public Color colorStart = Color.white;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;

    private float endTime;
    private bool isItTheBeginning;

	// Use this for initialization
	void Start ()
	{
	    isItTheBeginning = true;
	    endTime = Time.time + duration;
	}
	
	// Update is called once per frame

    void Update()
    {
        if(endTime > Time.time)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            renderer.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
        
        else if(endTime < Time.time && isItTheBeginning)
        {
            endTime = Time.time + duration;
            colorStart = Color.black;
            colorEnd = Color.white;
            isItTheBeginning = false;
        }
        else if (endTime < Time.time && !isItTheBeginning)
        {
             Application.LoadLevel("Menu");
        }

    }
}
