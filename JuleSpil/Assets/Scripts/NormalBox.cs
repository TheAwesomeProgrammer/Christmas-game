using UnityEngine;
using System.Collections;

public class NormalBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collidingObject)
    {
        Debug.Log("Colliding object : " + collidingObject.collider.tag);
        if (collidingObject.collider.tag == "Player" && collidingObject.collider.GetComponent<AnimationPlayer>().mIsAnimating)
        {
            Destroy(gameObject);

        }
    }
}
