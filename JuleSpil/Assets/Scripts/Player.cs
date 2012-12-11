using UnityEngine;
using System.Collections;

public class Player : AttackScript {

    public float MAXSPEED = 6.0F;
    public float accSpeed = 0.1f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float secoundsToJump = 2;
    public float maxRage = 100;
    

    public GameObject health;
    public GameObject rageGameObj;

    public bool isLatter { get; set; }

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 startVector;
    
    private float jumpTime = float.MinValue;
    private float life;
    public float rage { get; set; }

    private bool jumping = false;
    public bool hasEnemySeenYou { get; set; }

    public float speed { get; set; }
    public float horizontalMovement { get; set; }

    public GUIStyle mGuiLife;
    public GUIStyle mGuiHelthBar;

    private Enemy mEnemy;

    private Transform healthBar;

    private Enemy target;
    private GameObject[] mtarget;
 

    private float startJumping;
    private float lastLife;
   

  //  private DrawLifeAndRage drawLifeAndRage;

	// Use this for initialization
	void Start ()
	{
        Screen.SetResolution(800, 600, true);
	 //   drawLifeAndRage = GameObject.Find("DrawLifeAndRage").GetComponent<DrawLifeAndRage>();
	    life = MAXLIFE;
	    lastLife = 0;
        mAnimation = GetComponent<AnimationPlayer>();
        isLatter = false;
	    startVector = transform.position;
	    startJumping = jumpSpeed;
	}

   
    void Update()
    {
    //    healthBar = GameObject.Find("HealthBar").transform;
        mtarget = GameObject.FindGameObjectsWithTag("Enemy");
       
        if (mtarget.Length > 0)
        {
           
            mEnemy =  findTarget("Enemy").GetComponent<Enemy>();
            target = mEnemy;
            distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
          
                attack(); 

        }
        move();
            isDead();
 
        hasEnemySeenYou = false;
        
    }

    void OnGUI()
    {
      
        GUI.Box(new Rect(0, 22, 185 * (life / 100), 8), "", mGuiLife);
    }
   


        
    

    public GameObject findTarget(string tag)
    {
        float minX = float.MaxValue;
        GameObject tempTarget = null;
        foreach (GameObject targetTemp in GameObject.FindGameObjectsWithTag(tag))
        {
            float tempDistance = Vector2.Distance(transform.position, targetTemp.transform.position);
            if (tempDistance < minX)
            {
                minX = tempDistance;
                tempTarget = targetTemp;
            }

        }

        return tempTarget;
    
    
}

    public void takeDamage(float damage)
    {
        life -= damage;
        
    }

    void isDead()
    {
        if(life <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void howCloseCanWeBeToTarget()
    {

        closesYouCanBeToTarget = (target.transform.localScale.x / 2) ;


    }

    void move()
    {
        CharacterController controller = GetComponent<CharacterController>();
      
        horizontalMovement = Input.GetAxis("Horizontal");

        if (jumping)
        {
            horizontalMovement /= 1.5f;
           
        }
        if (speed < MAXSPEED)
        {
            speed += accSpeed;
        }

       if(!isLatter)
       {
           moveDirection = new Vector3(horizontalMovement*speed * Time.deltaTime, 0, 0);
           Debug.Log("Movement latter : " + horizontalMovement * speed * Time.deltaTime);
       }
     
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;


        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            jumpTime = Time.time + secoundsToJump;
            moveDirection.y = jumpSpeed;
            jumping = true;

        }

        if (jumpTime >= Time.time)
        {
            moveDirection.y = jumpSpeed;
            jumpSpeed -= 0.6F;

        }
        else
        {
            jumpSpeed = startJumping;
        }

        moveDirection.y -= gravity; 
         if(isLatter)
         {
             moveDirection.y = 0;
             
             moveDirection = new Vector3(horizontalMovement * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

             moveDirection = transform.TransformDirection(moveDirection);
             moveDirection *= speed;
       }
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag =="Spike")
        {
            takeDamage(100);
        }
        Debug.Log("hit name : " + hit.collider.name);
        if (hit.collider.name == "Glow")
        {
            takeDamage(100);
        }
        if (hit.collider.tag == "FallingIceCube")
        {
            FallingIceCubes tfallingIceCube = hit.collider.GetComponent<FallingIceCubes>();
            if (tfallingIceCube.whenToFall == float.MaxValue)
            {
                tfallingIceCube.whenToFall = Time.time + tfallingIceCube.touchDelay;
            }
        
          
        }
        if (hit.collider.tag == "Latter")
        {
            isLatter = true;
        }
        jumping = false;
       
    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (nextAttack <= Time.time)
            {
               
                nextAttack = Time.time + attackIntervalHeavy;
                mAnimation.shouldAnimate = animationEnum.secoundAnimation;
                if (distanceFromTarget < attackRange)
                {

                   
                        damangeToDeal = Mathf.Abs(distanceFromTarget - attackDamangeHeavy);
                        Debug.Log("Damage : " + damangeToDeal);
                        mEnemy.takeDamage(damangeToDeal);

                }
            }
        }
       if (Input.GetKeyDown(KeyCode.E))
        {
            if (nextAttack <= Time.time)
            {
                nextAttack = Time.time + attackIntervalLight;
                mAnimation.shouldAnimate = animationEnum.firstAnimation;
                if (distanceFromTarget < attackRange)
                {
                        damangeToDeal = Mathf.Abs(distanceFromTarget - attackDamangeLight);
                        Debug.Log("Damage : " + damangeToDeal);
                        mEnemy.takeDamage(damangeToDeal);
                    }

                
            }
        }
       
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
     
    }
}
