using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Fighter[] players;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3((transform.position - PlayerAverage ()).x * 0.1f,(transform.position - PlayerAverage ()).y * 0.1f,0.0f);
	}

	Vector3 PlayerAverage () {
		Vector3 positions = Vector3.zero;
		for(int i = 0; i < players.Length; i++)
		{
			positions += players[i].transform.position;
		}

		positions /= players.Length;
		return positions;
	}
}