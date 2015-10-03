using UnityEngine;
using System.Collections;

public class CometBug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.right.x * 5, GetComponent<Rigidbody2D> ().velocity.y);
		RaycastHit2D hit = Physics2D.Raycast (transform.position + transform.right, -transform.up, 2);
		if(!hit)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y + 180,transform.eulerAngles.z);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<Fighter> ()) {
			coll.gameObject.SendMessage ("Damage", 5);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
		}
	}
}