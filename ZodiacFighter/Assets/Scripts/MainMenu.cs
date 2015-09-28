using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	public GameObject[] MenuOptions;
	public GameObject selector;
	public int selected;
	public int max;
	public bool axisPressed;

	// Use this for initialization
	void Start ()
	{

		selected = 0;
		max = 2;
		selectionEffect ();
		axisPressed = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (axisPressed == false) {
			if (Input.GetAxis ("MenuDPad") < 0) {

			//	deSelect ();

				if (selected == max) {

					selected = 0;

				} else {
					selected++;
				}

				selectionEffect ();
				axisPressed = true;
		
			} else if (Input.GetAxis ("MenuDPad") > 0) {

			//	deSelect ();

				if (selected == 0) {
				
					selected = max;
				
				} else {
					selected--;
				}

				selectionEffect ();
				axisPressed = true;
		
			}
		}

		if (Input.GetAxis ("MenuDPad") == 0) {
		
			axisPressed = false;
		
		}

		if(Input.GetButtonDown("Submit")){

			selectOption ();

		}



	}

	void selectionEffect ()
	{

		selector.transform.position = MenuOptions [selected].transform.position;

	}

	void deSelect ()
	{

		MenuOptions [selected].transform.localScale = new Vector2 (5f, 5f);

	}

	void selectOption(){

		//Option for Game Manager. Expandable easily.

		GameManager.ChooseLevel(MenuOptions[selected].name);

		//Option for now.
//		switch (selected) {
//		
//		case 0:
//			Application.LoadLevel("SingleDemo");
//			break;
//		case 1:
//			Application.LoadLevel("MultiDemo");
//			break;
//		case 2:
//			Application.Quit();
//			break;
//		default:
//			break;
//			
//		}

	}

}
