using UnityEngine;
using System.Collections;

public class WinText : MonoBehaviour {

    public Color colorStart = Color.white;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        renderer.material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
