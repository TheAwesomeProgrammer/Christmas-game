using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float attackDamange = 5;
    public float attackRange = 5;
    public float MAXLIFE = 100;
    public float attackInterval = 1.5f;
    public float mHowMuchToSlowPlayer = 3;


    public GameObject health;

    protected float closesYouCanBeToTarget;
    protected float nextAttack = 0;
    protected float damangeToDeal;
    protected float distanceFromTarget;
    protected float life;

    public float delay = 0.3f;
    public float lookRange = 20;
    public float speed = 5;

    private float closesYouCanBeToPlayer;
    private float lastLife;

    private Player player;

    private bool hasNotAttacked = true;

    private DrawLifeAndRage drawLifeAndRage;


	// Use this for initialization
	public void  Start ()
    {
        drawLifeAndRage = GameObject.Find("DrawLifeAndRage").GetComponent<DrawLifeAndRage>();
	    life = MAXLIFE;
	    lastLife = 0;
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
	}
	
	// Update is called once per frame
	 public void  Update ()
	{
        distanceFromTarget = Vector2.Distance(player.transform.position, transform.position);
         if(renderer.isVisible)
         {
             GameObject[] healths = GameObject.FindGameObjectsWithTag("Health");
             if (drawLifeAndRage.sizeOfHealth(healths,transform) <= 0 || life != lastLife)
             {
                 drawLifeAndRage.destroyThings(healths, transform);
                 drawLifeAndRage.drawThings(health, life, transform, new Vector3(transform.position.x - (transform.lossyScale.x / 2) + 0.3f,
                     transform.position.y + (transform.lossyScale.y / 2) + 0.3f, transform.position.z + 0.5f));
                 lastLife = life;
             }

         }
         isDead();
       locatePlayerAndMoveToHim();
	     howCloseCanWeBeToTarget();
	    attack();

	}


    public void howCloseCanWeBeToTarget()
    {

        closesYouCanBeToPlayer = player.transform.lossyScale.x;


    }


   void locatePlayerAndMoveToHim()
    {
        if (distanceFromTarget < lookRange)
        {
            player.hasEnemySeenYou = true;
           
            if(distanceFromTarget > closesYouCanBeToPlayer)
            {
              if(transform.position.x < player.transform.position.x)
              {
                  transform.Translate(Vector3.right*speed*Time.deltaTime);
              }
              if (transform.position.x > player.transform.position.x)
              {
                  transform.Translate(Vector3.left * speed * Time.deltaTime);
              }
            }
        
           
        }
    }



   public void takeDamage(float damage)
   {
       life -= damage;
      
   }

   void isDead()
   {
       if (life <= 0)
       {
           if(player.maxRage > player.rage)
           {
               player.rage += 5;
           }
           
           player.findTarget();
           Destroy(gameObject);
       }
   }

   public void attack()
    {
        if (distanceFromTarget < attackRange)
        {
            if (hasNotAttacked)
            {
                nextAttack = Time.time + attackInterval-1;
                hasNotAttacked = false;
            }
            if (nextAttack <= Time.time)
            {
                nextAttack = Time.time + attackInterval;
                damangeToDeal = Mathf.Abs(attackDamange -distanceFromTarget);
                Debug.Log("Damage : " + damangeToDeal);
                player.takeDamage(damangeToDeal);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,attackRange);
        Gizmos.DrawWireSphere(transform.position, lookRange);
    }


    void OnTriggerStay()
    {
        if (player.speed > (player.MAXSPEED - mHowMuchToSlowPlayer))
        {

            player.speed -= mHowMuchToSlowPlayer;
        }
    }
   
}
