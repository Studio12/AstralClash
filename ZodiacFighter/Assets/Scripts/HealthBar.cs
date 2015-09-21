using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public float maxValue;
	public float curValue;
	public float scaleMax;
	public GameObject character;
	public float propScale;
	public float gradScaleSpeed;

	// Use this for initialization
	void Start () {
	
		maxValue = character.GetComponent<Fighter> ().health;
		scaleMax = this.transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {

		curValue = character.GetComponent<Fighter> ().health;
		propScale = curValue / maxValue;

		if (curValue >= 0) {

			if (this.name == "instaBar") {
		
				this.transform.localScale = new Vector3 (scaleMax * propScale, this.transform.localScale.y, this.transform.localScale.z);
		
			} else if (this.name == "gradBar" && this.transform.localScale.x > scaleMax * propScale) {

				this.transform.localScale = new Vector3 (this.transform.localScale.x - gradScaleSpeed, this.transform.localScale.y, this.transform.localScale.z);
		
			}
	
		} else {
		
			this.transform.localScale = new Vector3 (0, this.transform.localScale.y, this.transform.localScale.z);

		}
	}
}
