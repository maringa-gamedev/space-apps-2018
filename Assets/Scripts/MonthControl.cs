using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MonthControl : MonoBehaviour
{

    private Text label;
    private static string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
    private int month;

    void Start()
    {
        month = 9;
        label = transform.GetChild(0).GetComponent<Text>();
    }

    public void UpMonth()
    {
        month = Math.Min(month + 1, 11);
    }

    public void DownMonth()
    {
        month = Math.Max(month - 1, 0);
    }

    public string GetMonth()
    {
        return months[month];
    }

    public bool IsWinter()
    {
        return month >= 3 && month <= 8;
    }

    void Update()
    {
        label.text = GetMonth();
    }
}
