using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour {

    public int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
	}
    public void toggleId(int id)
    {
      if(id == 0 ||id == 1||id == 2)
      {

                if (GetComponent<Detonator>() != null )
                {
                    Debug.Log("Detonating");
                    GetComponent<Detonator>().Explode();
                    Destroy(transform.FindChild("BOX").gameObject);
                    Destroy(gameObject, GetComponent<Detonator>().duration);
                }
      }
            
          
            if(id == 10)
            {
            GameObject.Find("Elevator").GetComponent<Elevator>().shouldOperate = true;
            }
          
        
    }
}
