using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Polyglot;
using System;

public class ShopManager : MonoBehaviour
{

    private int selected = 0;
    private List<Image> buttons;
    private LocalizedText title, description;
    private int[] quantities = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private Text quantity, weight, price;

    private static string[] titleKeys = {
        "EREBUS_CAMERA",
        "EREBUS_HAMMER",
        "EREBUS_MICROSCOPE",
        "EREBUS_SYRINGE",
        "EREBUS_TELESCOPE",
        "EREBUS_SATELLITE",
        "EREBUS_TRUCK",
        "EREBUS_FUEL",
        "EREBUS_FOOD",
        "EREBUS_WRENCH",
        "EREBUS_BASE",
    };

    private static string[] descriptionKeys = {
        "EREBUS_CAMERA_DESC",
        "EREBUS_HAMMER_DESC",
        "EREBUS_MICROSCOPE_DESC",
        "EREBUS_SYRINGE_DESC",
        "EREBUS_TELESCOPE_DESC",
        "EREBUS_SATELLITE_DESC",
        "EREBUS_TRUCK_DESC",
        "EREBUS_FUEL_DESC",
        "EREBUS_FOOD_DESC",
        "EREBUS_WRENCH_DESC",
        "EREBUS_BASE_DESC",
    };

    public static int[] weights = {
        10,
        5,
        5,
        5,
        20,
        1000,
        -1400,
        1000,
        1000,
        50,
        30000,
    };

    public static int[] prices = {
        50000,
        500,
        15000,
        2000,
        15000,
        100000,
        220000,
        4000,
        50000,
        2000,
        100000000,
    };

    public static int[] limits = {
        99,
        99,
        99,
        99,
        99,
        1,
        1,
        99,
        99,
        99,
        1,
    };

    void Start()
    {
        buttons = new List<Image>();
        foreach (Transform child in transform)
        {
            switch (child.name)
            {
                case "more":
                    title = child.GetChild(0).GetComponent<LocalizedText>();
                    description = child.GetChild(1).GetComponent<LocalizedText>();
                    quantity = child.GetChild(2).GetChild(2).GetComponent<Text>();
                    weight = child.GetChild(3).GetChild(1).GetComponent<Text>();
                    price = child.GetChild(4).GetChild(1).GetComponent<Text>();
                    break;
                case "icons":
                    for (var i = 0; i < 11; i++)
                        buttons.Add(child.GetChild(i).GetComponent<Image>());
                    break;
            }
        }
    }

    public void SelectMe(int index)
    {
        selected = index;
    }

    void Update()
    {
        foreach (var button in buttons)
            button.color = new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1.0f);
        buttons[selected].color = UnityEngine.Color.white;

        title.Key = titleKeys[selected];
        description.Key = descriptionKeys[selected];
        quantity.text = quantities[selected] + "";
        weight.text = Math.Abs(weights[selected]) + " KG";
        price.text = "$" + prices[selected];

        if (weights[selected] > 0)
            weight.color = UnityEngine.Color.red;
        else
            weight.color = UnityEngine.Color.green;
    }

    public void ChangeSelected(int value)
    {
        quantities[selected] += value;
        if (quantities[selected] < 0) quantities[selected] = 0;
        if (quantities[selected] > limits[selected]) quantities[selected] = limits[selected];
    }

    public int GetQuantityAt(int index)
    {
        return quantities[index];
    }
}
