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
		fighter.direction = (target.position - transform.position - (1.25f * transform.right)).normalized.x;
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
