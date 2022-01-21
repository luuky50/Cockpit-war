using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntentelling : MonoBehaviour
{
    

    public Transform respawnPoint;
    public int puntenPlane1;
    public int puntenPlane2;
    public Text pointTekst1;
    public Text pointTekst2;
    void Start()
    {
        
        puntenPlane1 = 0;
        puntenPlane2 = 0;

    }

    // Update is called once per frame
   
    public void AddPoint(bool isPlayer2)
    {
        if (!isPlayer2)
        {
            puntenPlane1++;
            pointTekst1.text = "Player 1: " + puntenPlane1.ToString();
        }
        else
        {
            puntenPlane2++;
            pointTekst2.text = "Player 2: " + puntenPlane2.ToString();
        }
    }

    public void ResetPoints()
    {
        puntenPlane1 = 0;
        puntenPlane2 = 0;
        pointTekst1.text = "Player 1: " + puntenPlane1.ToString();
        pointTekst2.text = "Player 2: " + puntenPlane2.ToString();
    }

        
        

    
}
