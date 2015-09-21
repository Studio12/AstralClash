using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Fighter fighter;

	// Use this for initialization
	void Start () {
		fighter = GetComponent<Fighter>();
	}
	
	// Update is called once per frame
	void Update () {
		fighter.direction = Input.GetAxis("Horizontal");
		fighter.jumping = Input.GetButtonDown("Jump");
		if(Input.GetButtonDown("Light Attack")) fighter.LightAttack();
		if(Input.GetButtonDown("Medium Attack")) fighter.MediumAttack();
		if(Input.GetButtonDown("Heavy Attack")) fighter.HeavyAttack();
	}
}
