#pragma strict

private var fighter : Fighter;

function Start () {
	fighter = GetComponent(Fighter);
}

function Update () {
	if(this.name == "Player"){
		fighter.direction = Input.GetAxis("Horizontal1");
		fighter.jumping = Input.GetAxis("Jump1");
		if(Input.GetButtonDown("Light Attack")) fighter.LightAttack();
		if(Input.GetButtonDown("Medium Attack")) fighter.MediumAttack();
		if(Input.GetButtonDown("Heavy Attack")) fighter.HeavyAttack();
	}else if(this.name == "Player (1)"){
	
		fighter.direction = Input.GetAxis("Horizontal2");
		fighter.jumping = Input.GetAxis("Jump2");
		
		}
	
}