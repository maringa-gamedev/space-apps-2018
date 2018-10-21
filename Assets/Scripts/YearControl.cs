using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class YearControl : MonoBehaviour
{

    private Text label;
    private static int minYear = 1904, maxYear = 2018;
    private int year;

    void Start()
    {
        label = transform.GetChild(0).GetComponent<Text>();
        year = maxYear;
    }

    public void UpYear()
    {
        year = Math.Min(year + 1, maxYear);
    }

    public void DownYear()
    {
        year = Math.Max(year - 1, minYear);
    }

    public void UpYear10()
    {
        year = Math.Min(year + 10, maxYear);
    }

    public void DownYear10()
    {
        year = Math.Max(year - 10, minYear);
    }

    public int GetYear()
    {
        return year;
    }

    public void Update()
    {
        label.text = year + "";
    }
}
