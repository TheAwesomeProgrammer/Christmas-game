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
        switch (id)
        {
            case 0 :
                if (GetComponent<Detonator>() != null)
                {
                    Debug.Log("Detonating");
                    GetComponent<Detonator>().Explode();
                    Destroy(transform.FindChild("BOX").gameObject);
                    Destroy(gameObject, GetComponent<Detonator>().duration);
                }
            break;
        }
    }
}
