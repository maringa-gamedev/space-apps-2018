using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hire : MonoBehaviour
{

    private int count;
    private Text label;

    private List<SpriteRenderer> subs;

    void Start()
    {
        subs = new List<SpriteRenderer>();
        foreach (Transform child in transform)
        {
            if (child.name == "count")
            {
                label = child.GetComponent<Text>();
            }
            else if (child.name == "subs")
            {
                foreach (Transform sub in child)
                {
                    subs.Add(sub.GetComponent<SpriteRenderer>());
                }
            }
        }
    }

    void Update()
    {
        label.text = count + "";
        if (count == 0)
        {
            foreach (SpriteRenderer sub in subs)
            {
                sub.color = new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1.0f);
            }
        }
        else
        {
            foreach (SpriteRenderer sub in subs)
            {
                sub.color = UnityEngine.Color.white;
            }
        }
    }

    public void hire(int value)
    {
        count += value;
        if (count < 0) count = 0;
    }

    public int getCount() {
      return count;
    }
}
