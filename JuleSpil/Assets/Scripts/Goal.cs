using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collisionObject)
    {
        Debug.Log("CollisionTag : "+ collisionObject.tag );
        if(collisionObject.tag == "Player")
        {
            if(Application.loadedLevelName == "level1")
            {
                Application.LoadLevel("level2");
            }
            if (Application.loadedLevelName == "level2")
            {
                Application.LoadLevel("level3");
            }
            if (Application.loadedLevelName == "level3")
            {
                Application.LoadLevel("WinScreen");
            }
        }
       
    }
}
