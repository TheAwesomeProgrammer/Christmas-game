using UnityEngine;
using System.Collections;

public class DrawLifeAndRage : MonoBehaviour
{

    private int count;

    // Use this for initialization
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
      
    }

    public void drawThings(GameObject gameObejctToInstatiente, float howManyTimesToDraw,Transform parent,Vector3 placeToDraw)
    {
        for (int i = 0; i < howManyTimesToDraw; i++)
        {
            GameObject instans = Instantiate(gameObejctToInstatiente, new Vector3(placeToDraw.x+(i * gameObejctToInstatiente.transform.lossyScale.x)
                ,placeToDraw.y,placeToDraw.z), transform.rotation) as GameObject;
            instans.transform.parent = parent;
     
        }
    
       
        Debug.Log("parent : " + parent.name);
    }
 
        public void destroyThings(GameObject[] gameObjectsToDraw,Transform parent)
        {
            foreach (GameObject gameObjToDraw in gameObjectsToDraw)
            {
                if(gameObjToDraw.transform.parent == parent)
                {
                    Destroy(gameObjToDraw);
                }
           
            }
        }

        public int sizeOfHealth(GameObject[] gameObjectsToRunThrough,Transform parentToIdentifyWith)
        {
            count = 0;
            foreach (GameObject gameObjToCheck in gameObjectsToRunThrough)
            {
                if (gameObjToCheck.transform.parent == parentToIdentifyWith)
                {
                    count++;
                }
            }
            return count;

        }
}
