#pragma strict

public var health : float;
public var armor : float;
public var speed : float;
public var lightAttackDamage : float;
public var mediumAttackDamage : float;
public var heavyAttackDamage : float;

public var jumpPower : float;

public var direction : float;
@HideInInspector
public var jumping : boolean = false;

private var isGrounded : boolean = true;

function Start () {

}

function Update () {
	transform.position.x += direction * speed * 0.25;
	transform.LookAt(transform.position + Vector3(direction,0,0));
	if(jumping && isGrounded)
	{
		GetComponent(Rigidbody).velocity.y = jumpPower;
		isGrounded = false;
	}
}

function OnCollisionEnter ()
{
	isGrounded = true;
}

function Attack (damage : float, delay : float, push : float)
{
	WaitForSeconds(delay);
	var hit : RaycastHit;
	if(Physics.Raycast(transform.position,transform.forward, hit, 1))
	{
		print("Pow");
		hit.collider.SendMessage("Damage", damage);
		hit.collider.GetComponent(Rigidbody).AddForce(transform.forward * push, ForceMode.Impulse);
	}
}

function LightAttack()
{
	Attack(lightAttackDamage,0.5, 1);
}

function MediumAttack()
{
	Attack(mediumAttackDamage,0.75, 1);
}

function HeavyAttack()
{
	Attack(heavyAttackDamage,1, 1);
}

function Damage (amount : float)
{
	health -= amount;
}