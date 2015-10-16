using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public void NewLevel(string level)
	{
		print ("Hooah");
		Application.LoadLevel (level);
	}

}
