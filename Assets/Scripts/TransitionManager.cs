using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {

	private GameManager manager;

	void Start () {
        manager = FindObjectsOfType<GameManager>()[0];
	}

    public void StartPlanning()
    {
        if (manager.CanStart())
        {
            SceneManager.LoadScene("PlanningScene", LoadSceneMode.Single);
			manager.Start();
        }
    }

    public void ReturnToStart()
    {
        if (manager.CanRestart())
        {
            SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
			manager.Restart();
        }
    }

    public void StartExpedition()
    {
        if (manager.CanTravel())
        {
            SceneManager.LoadScene("ExpeditionScene", LoadSceneMode.Single);
			manager.Travel();
        }
    }
}
