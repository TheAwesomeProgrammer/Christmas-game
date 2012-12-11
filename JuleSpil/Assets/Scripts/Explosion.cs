using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public int id;
    private float range = 10;

	// Use this for initialization
	void Start () {
      range =  GetComponent<Detonator>().size - 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        Handle tHandle = null;
        foreach(GameObject handle in GameObject.FindGameObjectsWithTag("Handle"))
        {
            if(handle.GetComponent<Handle>().id == id)
            {
                  tHandle = handle.GetComponent<Handle>();
            }
        }
     
        Player tPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	if(Vector2.Distance(transform.position,tPlayer.transform.position) < range && tHandle.hasTogggled )
    {
       
        tPlayer.takeDamage(100);
    }
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
              if (Vector2.Distance(transform.position, enemy.transform.position) < range && tHandle.hasTogggled)
                 {

                     Destroy(enemy.gameObject);
                 }
	    }
    }
  

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
