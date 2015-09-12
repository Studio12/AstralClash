#pragma strict

private var fighter : Fighter;

public var target : Transform;

private var meshAgent : NavMeshAgent;


function Start () {
	fighter = GetComponent(Fighter);
	meshAgent = GetComponent(NavMeshAgent);
	meshAgent.speed = fighter.speed;
}

function Update () {
	//fighter.direction = (target.position - transform.position).normalized.x;
	meshAgent.SetDestination (target.transform.position);
	if(Physics.Raycast(transform.position,transform.forward, 1.5))
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