﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanManager : MonoBehaviour
{

    [SerializeField]
    public bool payForBoat = true;
    private Text weight, food, fuel, price, boat;

    private Hire astronomy, biology, construction, geography, journalism, medicine;

    private int weightValue, weightCapacity;
    private int foodValue, fuelValue, priceValue, boatValue;

    private ShopManager shop;

	public bool canProceed {
		get;
		private set;
	}

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "jobs")
            {
                foreach (Transform info in child)
                {
                    switch (info.name)
                    {
                        case "astronomy":
                            astronomy = info.GetComponent<Hire>();
                            break;
                        case "biology":
                            biology = info.GetComponent<Hire>();
                            break;
                        case "construction":
                            construction = info.GetComponent<Hire>();
                            break;
                        case "geography":
                            geography = info.GetComponent<Hire>();
                            break;
                        case "journalism":
                            journalism = info.GetComponent<Hire>();
                            break;
                        case "medicine":
                            medicine = info.GetComponent<Hire>();
                            break;
                    }
                }
            }
            else if (child.name == "info")
            {
                foreach (Transform job in child)
                {
                    switch (job.name)
                    {
                        case "boat":
                            boat = job.GetChild(2).GetComponent<Text>();
                            break;
                        case "weight":
                            weight = job.GetChild(2).GetComponent<Text>();
                            break;
                        case "food":
                            food = job.GetChild(2).GetComponent<Text>();
                            break;
                        case "fuel":
                            fuel = job.GetChild(2).GetComponent<Text>();
                            break;
                        case "price":
                            price = job.GetChild(2).GetComponent<Text>();
                            break;
                    }
                }
            }
            else if (child.name == "shop")
            {
                shop = child.GetComponent<ShopManager>();
            }
        }
    }

    void Update()
    {
        weightValue = 0;
		weightCapacity = 35000;
        for (var i = 0; i < 11; i++)
            if (ShopManager.weights[i] > 0)
                weightValue += shop.GetQuantityAt(i) * ShopManager.weights[i];
            else
                weightCapacity += shop.GetQuantityAt(i) * ShopManager.weights[i];
        weight.text = weightValue + "/" + weightCapacity + " KG";

        fuel.text = shop.GetQuantityAt(7) + " T";
        food.text = shop.GetQuantityAt(8) + " T";

        boatValue = 0;
        boatValue += astronomy.getCount();
        boatValue += biology.getCount();
        boatValue += construction.getCount();
        boatValue += geography.getCount();
        boatValue += journalism.getCount();
        boatValue += medicine.getCount();
        boat.text = boatValue + " / 14";

        if (boatValue > 14)
        {
            boat.color = UnityEngine.Color.red;
        }
        else
        {
            boat.color = new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1.0f);
        }

        priceValue = payForBoat ? 350000 : 0;
        priceValue += 10000 * astronomy.getCount();
        priceValue += 10000 * biology.getCount();
        priceValue += 10000 * construction.getCount();
        priceValue += 10000 * geography.getCount();
        priceValue += 10000 * journalism.getCount();
        priceValue += 10000 * medicine.getCount();
        for (var i = 0; i < 11; i++)
            priceValue += shop.GetQuantityAt(i) * ShopManager.prices[i];
        price.text = "$" + priceValue;

		canProceed = boatValue <= 14 && weightValue <= weightCapacity;
    }
}
