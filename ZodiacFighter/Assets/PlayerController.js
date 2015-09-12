#pragma strict

private var fighter : Fighter;

function Start () {
	fighter = GetComponent(Fighter);
}

function Update () {
	fighter.direction = Input.GetAxis("Horizontal");
	fighter.jumping = Input.GetButtonDown("Jump");
	if(Input.GetButtonDown("Light Attack")) fighter.LightAttack();
	if(Input.GetButtonDown("Medium Attack")) fighter.MediumAttack();
	if(Input.GetButtonDown("Heavy Attack")) fighter.HeavyAttack();
}