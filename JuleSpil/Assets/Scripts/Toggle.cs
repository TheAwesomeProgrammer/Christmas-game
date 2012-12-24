using UnityEngine;
using System.Collections;

public enum toggleType
{
    Explosion,
    Elevator,
    NoType
}

public class Toggle : MonoBehaviour {

    public int id;
    public toggleType mToggleType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
	}
    public void toggle()
    {
      if(mToggleType == toggleType.Explosion)
      {

                if (GetComponent<Detonator>() != null )
                {
                    Debug.Log("Detonating");
                    GetComponent<Detonator>().Explode();
                    Destroy(transform.FindChild("BOX").gameObject);
                    Destroy(gameObject, GetComponent<Detonator>().duration);
                }
      }
            
         
    if(mToggleType == toggleType.Elevator)
      {
            GameObject.Find("Elevator").GetComponent<Elevator>().shouldOperate = true;
      }
          
        
    }
}
