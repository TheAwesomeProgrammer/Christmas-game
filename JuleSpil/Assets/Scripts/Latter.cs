using UnityEngine;
using System.Collections;

public class Latter : MonoBehaviour
{
  
    public int id = 1;
    private Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        
	 
	}

    void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("Comming into latter tag " + otherObject.tag);

        if (otherObject.tag == "Player")
        {
           Debug.Log("Enter");
            otherObject.GetComponent<Player>().isLatter = true;
           }
    }
    void OnTriggerStay(Collider otherObject)
    {

        if (otherObject.tag == "Player")
        {
            Debug.Log("Stay");
            otherObject.GetComponent<Player>().isLatter = true;
        }
    }
    void OnTriggerExit(Collider otherObject)
    {
        
        if (otherObject.tag == "Player")
        {
            Debug.Log("Exit");
            if(id == 2)
            otherObject.GetComponent<Player>().isLatter = false;
        }
    }
}
