using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Player")
        {
            otherObject.GetComponent<Player>().takeDamage(100);
        }
    }
}
