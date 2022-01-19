using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelecter : MonoBehaviour
{
    public GameManager gameManager;
    public void SelectMap(GameObject map)
    {
        
            gameManager.Map = map;
          
        

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
