using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	Fighter fighter;
	
	public Transform target;

	// Use this for initialization
	void Start () {
		fighter = GetComponent<Fighter>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance (target.position, transform.position) > 1.5f) fighter.direction = (target.position - transform.position - (2f * transform.right)).normalized.x;
		Debug.DrawLine(transform.position, transform.position + (target.position - transform.position - (2f * transform.right)), Color.red);
		if(Physics.Raycast(transform.position,transform.right, 2f))
		{
			print("RADARADARADA");
			switch(Random.Range(0,2)) {
			case 0:
				fighter.LightAttack();
				break;
			case 1:
				fighter.MediumAttack();
				break;
			case 2:
				fighter.HeavyAttack();
				break;
			}
		}
	}
}
