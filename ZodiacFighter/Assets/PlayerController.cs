﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Fighter fighter;

	// Use this for initialization
	void Start () {
		fighter = GetComponent<Fighter>();
	}
	
	// Update is called once per frame
	void Update () {

		switch(fighter.playID){

		case 1:
			fighter.direction = Input.GetAxis ("Horizontal1");
			fighter.jumping = Input.GetAxis ("Jump1");
			if(Input.GetButton("Block1") && fighter.attacking == false){fighter.blocking = true;}
			if(Input.GetButton("Block1")==false){
				fighter.blocking = false;
				if (Input.GetButtonDown ("Light Attack1"))
					fighter.LightAttack ();
				if (Input.GetButtonDown ("Medium Attack1"))
					fighter.MediumAttack ();
				if (Input.GetButtonDown ("Heavy Attack1"))
					fighter.HeavyAttack ();
			}
			break;

		case 2:
			fighter.direction = Input.GetAxis ("Horizontal2");
			fighter.jumping = Input.GetAxis ("Jump2");
			if(Input.GetButton("Block2") && fighter.attacking == false){fighter.blocking = true;}
			if(Input.GetButton("Block2")==false){
				fighter.blocking = false;
			if (Input.GetButtonDown ("Light Attack2"))
				fighter.LightAttack ();
			if (Input.GetButtonDown ("Medium Attack2"))
				fighter.MediumAttack ();
			if (Input.GetButtonDown ("Heavy Attack2"))
				fighter.HeavyAttack ();
			}
			break;

		case 3:
			fighter.direction = Input.GetAxis ("Horizontal3");
			fighter.jumping = Input.GetAxis ("Jump3");
			if(Input.GetButton("Block3") && fighter.attacking == false){fighter.blocking = true;}
				if(Input.GetButton("Block3")==false){
					fighter.blocking = false;
			if (Input.GetButtonDown ("Light Attack3"))
				fighter.LightAttack ();
			if (Input.GetButtonDown ("Medium Attack3"))
				fighter.MediumAttack ();
			if (Input.GetButtonDown ("Heavy Attack3"))
				fighter.HeavyAttack ();
				}
			break;

		case 4:
			fighter.direction = Input.GetAxis ("Horizontal4");
			fighter.jumping = Input.GetAxis ("Jump4");
			if(Input.GetButton("Block4") && fighter.attacking == false){fighter.blocking = true;}
					if(Input.GetButton("Block4")==false){
						fighter.blocking = false;
			if (Input.GetButtonDown ("Light Attack4"))
				fighter.LightAttack ();
			if (Input.GetButtonDown ("Medium Attack4"))
				fighter.MediumAttack ();
			if (Input.GetButtonDown ("Heavy Attack4"))
				fighter.HeavyAttack ();
					}
			break;

		default:
			break;

		}
	}
}
