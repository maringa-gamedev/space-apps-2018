using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpDownClick : MonoBehaviour
{

    private Hire hiring;
    [SerializeField]
    public int value;

    void Start()
    {
        hiring = gameObject.transform.parent.GetComponent<Hire>();
    }

    public void clickMe()
    {
        if (hiring != null) hiring.hire(value);
    }
}
