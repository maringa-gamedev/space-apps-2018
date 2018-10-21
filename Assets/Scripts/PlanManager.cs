using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanManager : MonoBehaviour
{

	private Text weight, food, fuel, price, boat;

	private Hire astronomy, biology, construction, geography, journalism, medicine;

	private int weightValue, weightCapacity;
	private int foodValue, fuelValue, priceValue, boatValue;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "jobs")
            {
                foreach (Transform info in child)
                {
					switch (info.name) {
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
					switch (job.name) {
						case "boat":
							boat = job.GetChild(1).GetComponent<Text>();
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
        }
    }

    void Update()
    {
		weight.text = weightValue +  "/" + weightCapacity + " KG";
		food.text = foodValue + " KG";
		fuel.text = fuelValue + " L";

        boatValue = 0;
		boatValue += astronomy.getCount();
		boatValue += biology.getCount();
		boatValue += construction.getCount();
		boatValue += geography.getCount();
		boatValue += journalism.getCount();
		boatValue += medicine.getCount();
        boat.text = boatValue + "/12"; 

		priceValue = 0;
		priceValue += 10000 * astronomy.getCount();
		priceValue += 10000 * biology.getCount();
		priceValue += 10000 * construction.getCount();
		priceValue += 10000 * geography.getCount();
		priceValue += 10000 * journalism.getCount();
		priceValue += 10000 * medicine.getCount();
		price.text = "$" + priceValue;
    }
}
