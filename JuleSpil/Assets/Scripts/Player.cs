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
    public GUIStyle mGuiRage;

    private Enemy mEnemy;

    private Transform healthBar;

    private Enemy target;
    private GameObject[] mtarget;
 

    private float startJumping;
    private float lastLife;
     

    private Vector3 mHealthBarPosition;
    private Vector3 mHealthBarScale;

    private bool hasScreenChangedOrIsStart = true;

    private DrawLifeAndRage drawLifeAndRage;

   



	// Use this for initialization
	void Start ()
	{
        
      //  Screen.SetResolution(1600, 900, true);
	    drawLifeAndRage = GameObject.Find("DrawLifeAndRage").GetComponent<DrawLifeAndRage>();
	    life = MAXLIFE;
	    lastLife = 0;
        mAnimation = GetComponent<AnimationPlayer>();
        isLatter = false;
	    startVector = transform.position;
	    startJumping = jumpSpeed;
        healthBar = GameObject.Find("HealthBar").transform;
      
    }
   
    void Update()
    {
        
        mtarget = GameObject.FindGameObjectsWithTag("Enemy");
        if (mtarget.Length > 0)
        {
            mEnemy =  findTarget("Enemy").GetComponent<Enemy>();
            target = mEnemy;
            distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
        }
        attack(); 
        move();
        isDead();

        if (hasScreenChangedOrIsStart && Time.time > 0.6f)
        {
            hasScreenChangedOrIsStart = false;
            mHealthBarPosition = Camera.mainCamera.WorldToScreenPoint(healthBar.position);
            mHealthBarScale = Camera.mainCamera.WorldToScreenPoint(healthBar.lossyScale);
            
        }
        hasEnemySeenYou = false;
      
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
        float tSpeedToLoseLifeWith = 15f * (damage / 5); ;
        health.transform.Translate(Vector3.left * Time.deltaTime * tSpeedToLoseLifeWith);
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
  
        if (hit.collider.tag == "FallingIceCube")
        {
            FallingIceCubes tfallingIceCube = hit.collider.GetComponent<FallingIceCubes>();
            if (tfallingIceCube.whenToFall == float.MaxValue)
            {
                tfallingIceCube.whenToFall = Time.time + tfallingIceCube.touchDelay;
            }
        
          
        }
        if (hit.collider.tag == "NormalBox" && GetComponent<AnimationPlayer>().mIsAnimating)
        {
            Destroy(hit.collider.gameObject);
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
