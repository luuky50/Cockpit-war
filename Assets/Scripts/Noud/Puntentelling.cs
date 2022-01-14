using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntentelling : MonoBehaviour
{
    

    public Transform respawnPoint;
    private int puntenPlane;
    public Text pointTekst;
    void Start()
    {
        
        puntenPlane = 0;
        
    }

    // Update is called once per frame
   
    public void AddPoint()
    {
        puntenPlane++;
        pointTekst.text = "Amount of points " + puntenPlane.ToString();
    }
        
        

    
}
