using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

  

	// Use this for initialization
	void Start () {
	
	}


    public float scrollSpeed = 0.5F;
    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
}
