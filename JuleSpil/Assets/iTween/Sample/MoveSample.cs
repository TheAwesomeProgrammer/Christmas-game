using UnityEngine;
using System.Collections;

public enum menuType
{
    Play,
    Credits,
    Back,
    Exit
}

public class MoveSample : MonoBehaviour
{
    public menuType mMenuType;
    public string MoveXYOrZ;
    public float length;
    public Material NormalMaterial;
    public Material HoverMaterial;

    public Vector2 startVector { get; private set; }

    private bool hasClicked;
    private bool startedMovingButtonsOut = false;

    private float moveCameraHowMuch;


	void Start()
	{


        moveCameraHowMuch = ((2f * Camera.main.orthographicSize) * Camera.main.aspect);
	    startVector = transform.position;
	    hasClicked = false;
	}
    void Update()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
        {
            MoveSample buttonMove = button.GetComponent<MoveSample>();
            if (buttonMove.mMenuType != menuType.Back && buttonMove != this)
            {
                if(buttonMove.renderer.isVisible)
                {
                    return;
                }

            }
        }

        if(hasClicked)
        {
            if (mMenuType == menuType.Play)
            {
                Application.LoadLevel("level1");
            }
            else if (mMenuType == menuType.Exit && !renderer.isVisible)
            {
                Application.Quit();
            }
        }
       
     
}
    void OnMouseDown()
    {
        hasClicked = true;
        if(mMenuType != menuType.Back)
        {
         move();
        }
   
        if (mMenuType == menuType.Credits)
        {
            iTween.MoveBy(Camera.mainCamera.gameObject, iTween.Hash(MoveXYOrZ, moveCameraHowMuch, "easeType", "easeInOutExpo", "once", "pingPong", "delay", .1));
        }

        else if(mMenuType == menuType.Back)
        {
            MoveSample creditsButtonMove = GameObject.Find("CreditsButton").GetComponent<MoveSample>();
            Vector2 playButtonVector = GameObject.Find("Play").transform.position;
              creditsButtonMove.transform.position = creditsButtonMove.startVector;
            if(playButtonVector.x < transform.position.x)
            {
                iTween.MoveBy(Camera.mainCamera.gameObject, iTween.Hash(MoveXYOrZ, -moveCameraHowMuch, "easeType", "easeInOutExpo", "once", "pingPong", "delay", .1));
            }
              if(playButtonVector.x > transform.position.x)
            {
                iTween.MoveBy(Camera.mainCamera.gameObject, iTween.Hash(MoveXYOrZ, moveCameraHowMuch, "easeType", "easeInOutExpo", "once", "pingPong", "delay", .1));
            }
        }
    }

    void move()
    {

        if ((mMenuType == menuType.Exit || mMenuType == menuType.Play) && renderer.isVisible && !startedMovingButtonsOut)
        {
            startedMovingButtonsOut = true;
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
            {
                MoveSample buttonMove = button.GetComponent<MoveSample>();
                if(buttonMove.mMenuType != menuType.Back && buttonMove != this)
                {
                    buttonMove.move();
                    
                }
            }
        }

        iTween.MoveBy(gameObject, iTween.Hash(MoveXYOrZ, length, "easeType", "easeInOutExpo", "once", "pingPong", "delay", .1));
    }

    void OnMouseEnter()
    {
        renderer.material = HoverMaterial;
    }
    void OnMouseExit()
    {
        renderer.material = NormalMaterial;
    }

}

