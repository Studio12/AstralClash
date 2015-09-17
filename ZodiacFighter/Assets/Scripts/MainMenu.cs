using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

	public GameObject[] MenuOptions;
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

				deSelect ();

				if (selected == max) {

					selected = 0;

				} else {
					selected++;
				}

				selectionEffect ();
				axisPressed = true;
		
			} else if (Input.GetAxis ("MenuDPad") > 0) {

				deSelect ();

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

	}

	public void selectionEffect ()
	{

		MenuOptions [selected].transform.localScale = new Vector2 (6f, 6f);

	}

	public void deSelect ()
	{

		MenuOptions [selected].transform.localScale = new Vector2 (5f, 5f);

	}
}
