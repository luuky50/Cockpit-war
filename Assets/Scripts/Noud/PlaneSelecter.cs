using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelecter : MonoBehaviour
{
    public GameManager gameManager;
    public bool isPlayer2 = false;

    public void SelectPlane(GameObject plane)
    {

        if (isPlayer2 == true)
        {
            gameManager.plane2 = plane;
        }
        else
        {
            gameManager.plane1 = plane;

            isPlayer2 = true;
        }




    }
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
