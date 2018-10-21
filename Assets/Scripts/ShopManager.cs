using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	private int selected = 0;
    private List<Image> buttons;
	private Text title, description;

	void Start () {
        buttons = new List<Image>();
        foreach (Transform child in transform)
        {
			switch (child.name) {
				case "more":
					title = child.GetChild(0).GetComponent<Text>();
					description = child.GetChild(1).GetComponent<Text>();
				break;
				case "icons":
					for (var i = 0; i < 12; i++)
						buttons.Add(child.GetChild(i).GetComponent<Image>());
				break;
			}
		}
	}

	public void SelectMe(int index) {
		selected = index;
	}
	
	void Update () {
        foreach (var button in buttons)
			button.color = new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1.0f);
		buttons[selected].color = UnityEngine.Color.white;

		title.text = "";
		description.text = "";
	}
}
