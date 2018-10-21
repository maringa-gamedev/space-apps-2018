using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapLocation : MonoBehaviour, IPointerClickHandler
{
    private static Sprite blue;
    private static Sprite green;

    [SerializeField]
    public int minYear;

    [SerializeField]
    public string locationName;

    private GameManager manager;

    void Start()
    {
        if (blue == null)
            blue = Resources.LoadAll<Sprite>("Images/spritesheet_tilesBlue")[0];
        if (green == null)
            green = Resources.LoadAll<Sprite>("Images/spritesheet_tilesGreen")[0];
        manager = FindObjectsOfType<GameManager>()[0];
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (manager != null)
        {
            manager.SetInitialLocation(locationName);
        }
    }

    void Update()
    {
        if (manager.GetLocation() == locationName)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = green;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = blue;
        }
    }
}
