using UnityEngine;
using System.Collections;

public class CBWaveManager : MonoBehaviour {
	public int wave = 0;
	public GameObject bug;
	public CometBug[] BugCount;
	public bool roundComplete = false;

	// Use this for initialization
	void Start () {
		NewWave ();
	}
	
	// Update is called once per frame
	void Update () {
		BugCount = FindObjectsOfType (typeof(CometBug)) as CometBug[];
		if (BugCount.Length == 0 && !roundComplete)
			StartCoroutine (WaveComplete ());
	}

	void NewWave () {
		wave++;
		for (int i = 0; i < wave; i++) {
			Instantiate (bug, transform.position, transform.rotation);
		}
		BugCount = FindObjectsOfType (typeof(CometBug)) as CometBug[];
		roundComplete = false;
	}

	IEnumerator WaveComplete () {
		roundComplete = true;
		print ("Wave Complete");
		yield return new WaitForSeconds (5f);
		NewWave ();
		print ("Round " + wave + ": FIGHT!");
	}

}
