#pragma strict

private var fighter : Fighter;

public var target : Transform;

function Start () {
	fighter = GetComponent(Fighter);
}

function Update () {
	fighter.direction = (target.position - transform.position - (1.25 * transform.right)).normalized.x;
	if(Physics.Raycast(transform.position,transform.right, 1.5))
	{
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