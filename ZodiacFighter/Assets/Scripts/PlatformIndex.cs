using UnityEngine;
using System.Collections;

public class PlatformIndex : MonoBehaviour {

	public GameObject[] platforms;
	public float[] distances;

	// Use this for initialization
	void Start () {

		int i = 0;

		foreach (GameObject p in platforms) {
		
			distances[i] = Vector2.Distance(this.transform.position, p.transform.position);
			i++;

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
