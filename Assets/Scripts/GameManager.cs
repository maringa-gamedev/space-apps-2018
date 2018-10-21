using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool starting = true, expedition = false;
    private string startingLocation;

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void SetInitialLocation(string location)
    {
        startingLocation = location;
        Debug.Log("starting?");
    }

    public string GetLocation()
    {
        return startingLocation;
    }

    public void SetYear(int year)
    {

    }

    public bool CanStart()
    {
        return startingLocation != "";
    }

    public void Start()
    {
        starting = false;
    }

    public bool CanTravel()
    {
        return FindObjectsOfType<PlanManager>()[0].canProceed;
    }

    public void Travel()
    {
        starting = false;
        expedition = true;
    }

    public bool CanRestart()
    {
        return !starting && !expedition;
    }

    public void Restart()
    {
        starting = true;
        expedition = false;
    }
}