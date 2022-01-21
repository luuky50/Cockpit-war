using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameMode
{
    DeathMatch,
    SuddenDeath,
}
public class GameManager : SingletonComponent<GameManager>
{


    public GameObject plane1;
    public GameObject plane2;
    public GameObject Map;
    public float roundTime = 120;
    public int startingHealth = 10;
    public AudioClip explosionClip;
    private AudioSource audioSource;
    public List<GameObject> spawnedPlanes = new List<GameObject>();
    bool isNewGame = false;

    [SerializeField]
    List<GameObject> spawnLocations = new List<GameObject>();

    public Puntentelling puntentelling;

    [SerializeField]
    DeathmatchTimer deathmatchTimer;


    [SerializeField]
    MenuManager menuManager;

    [SerializeField]
    GameObject spawnPrefab;

    GameMode currentGameMode = new GameMode();
    public void SelectMap()
    {
        Instantiate(Map);
    }
    // Start is called before the first frame update
    void Start()
    {
        isNewGame = false;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainGame")
        {
            Time.timeScale = 1;
            audioSource = FindObjectOfType<DeathmatchTimer>().GetComponent<AudioSource>();
            deathmatchTimer = FindObjectOfType<DeathmatchTimer>();
            puntentelling = FindObjectOfType<Puntentelling>();
            menuManager = FindObjectOfType<MenuManager>();
            deathmatchTimer.timeRemaining = roundTime;
            spawnedPlanes.Clear();
            spawnLocations.Clear();
            GameObject newPlane1 = Instantiate(plane1);
            newPlane1.GetComponent<PlaneHealthManagement>().health = startingHealth;
            spawnedPlanes.Add(newPlane1);
            GameObject newPlane2 = Instantiate(plane2);
            newPlane2.GetComponent<PlaneHealthManagement>().health = startingHealth;
            spawnedPlanes.Add(newPlane2);
            Instantiate(Map);
            CreateSpawnLocations();
        }
    }

    void CreateSpawnLocations()
    {
        spawnLocations.Clear();
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(Random.value, Random.value, 10);
            pos = Camera.main.ViewportToWorldPoint(pos);
            GameObject newSpawn = Instantiate(spawnPrefab, pos, transform.rotation);
            spawnLocations.Add(newSpawn);
        }
    }


    public GameObject RandomSpawnObject()
    {
        int randomNum = Random.Range(0, spawnLocations.Count);
        return spawnLocations[randomNum];
    }

    public void Respawn(string playerNumber, GameObject oldPlane)
    {
        StartCoroutine(RespawnPlane(playerNumber, oldPlane));
    }

    public IEnumerator RespawnPlane(string playerNumber, GameObject oldPlane)
    {
        audioSource.clip = explosionClip;
        audioSource.Play();
        Destroy(oldPlane.gameObject);
        spawnedPlanes.Remove(oldPlane);
        yield return new WaitForSeconds(3f);
        GameObject newSpawnPoint = RandomSpawnObject();
        if (playerNumber == "1" && spawnedPlanes.Count < 2)
        {
            GameObject newPlane1 = Instantiate(GameManager.instance.plane1, newSpawnPoint.transform.position, transform.rotation);
            spawnedPlanes.Add(newPlane1);
        }
        else if(spawnedPlanes.Count < 2)
        {
            GameObject newPlane2 = Instantiate(GameManager.instance.plane2, newSpawnPoint.transform.position, transform.rotation);
            spawnedPlanes.Add(newPlane2);
        }

    }


    public void EndGame()
    {
        isNewGame = true;
        menuManager.ShowEndMenu();
        if(puntentelling.puntenPlane1 > puntentelling.puntenPlane2)
        {
            menuManager.winnerText.text = "Player 1 wins with " + puntentelling.puntenPlane1 + " point(s)!";
        }
        else if(puntentelling.puntenPlane2 > puntentelling.puntenPlane1)
        {
            menuManager.winnerText.text = "Player 2 wins with " + puntentelling.puntenPlane2 + " point(s)!";
        }
        else if(puntentelling.puntenPlane1 == puntentelling.puntenPlane2)
        {
            menuManager.winnerText.text = "It's a draw!";
        }
        Time.timeScale = 0;
    }


    public void RestartGame()
    {
        Time.timeScale = 1;
        foreach (var item in spawnLocations)
        {
            Destroy(item);
        }
        spawnLocations.Clear();
        CreateSpawnLocations();
        foreach (var item in spawnedPlanes)
        {
            Destroy(item.gameObject);
        }
        spawnedPlanes.Clear();
        deathmatchTimer.ResetTime();
        puntentelling.ResetPoints();
        GameObject newPlane1 = Instantiate(plane1);
        spawnedPlanes.Add(newPlane1);
        GameObject newPlane2 = Instantiate(plane2);
        spawnedPlanes.Add(newPlane2);
        isNewGame = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
