using UnityEngine;
using System.Collections;

public class HealthBarPostion : MonoBehaviour {

    private float mStartWidth;

    private Camera mCamera;

    public GUIStyle mGuiHelthBar;

	// Use this for initialization
	void Start () {
        mStartWidth = (float)Screen.width/64;
	}
	
	// Update is called once per frame
	void Update () {
        mCamera = Camera.mainCamera;
 
        transform.position = new Vector3(mCamera.transform.position.x - ((((float)Screen.width / 64)/2)+transform.lossyScale.x/4), transform.position.y,-10);
     //  transform.position = mCamera.ScreenToViewportPoint(transform.position);
	}
    void OnGUI()
    {
        
     //   GUI.Box(new Rect(0, 25, 200, 100), "", mGuiHelthBar);
       
    }
}
