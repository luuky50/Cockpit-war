using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    DeathMatch,
    SuddenDeath,
}
public class GameManager : MonoBehaviour
{
    public GameObject plane1;
    public GameObject plane2;
    public GameObject Map;

    GameMode currentGameMode = new GameMode();
    public void SelectMap()
    {
        Instantiate(Map);
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
