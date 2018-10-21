using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MapManager : MonoBehaviour
{

    private List<MapLocation> points;
    private YearControl year;
    private MonthControl month;

    void Start()
    {
        points = new List<MapLocation>();
        foreach (Transform child in transform)
        {
            if (child.name == "points")
            {
                foreach (Transform point in child)
                {
                    points.Add(point.GetComponent<MapLocation>());
                }
            }
            else if (child.name == "notebook")
            {
                year = child.GetChild(0).GetChild(0).GetComponent<YearControl>();
                month = child.GetChild(0).GetChild(1).GetComponent<MonthControl>();
            }
        }
    }

    void Update()
    {
        foreach (var point in points)
        {
            point.gameObject.SetActive(year.GetYear() >= point.minYear);
        }
    }
}
