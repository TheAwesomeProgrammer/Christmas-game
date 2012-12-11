using UnityEngine;
using System.Collections;



public class AttackScript : MonoBehaviour {

    public float attackDamangeLight = 5;
    public float attackDamangeHeavy = 5;
    public float attackRange = 5;
    public  float MAXLIFE= 100;
    public float attackIntervalLight = 1.5f;
    public float attackIntervalHeavy = 1.5f;

    protected float closesYouCanBeToTarget;
    protected float nextAttack = 0;
    protected float damangeToDeal;
    protected float distanceFromTarget;

    protected AnimationPlayer mAnimation;

    


	// Use this for initialization
	public virtual void Start ()
	{
	   
	}
	
	// Update is called once per frame
	public virtual void Update () {
       
	}

  

  

  


}
