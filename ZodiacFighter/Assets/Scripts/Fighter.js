#pragma strict

public class Attack
{
	public var damage : int;
	public var prep : float;
	public var recovery : float;
	public var reach : float;
}

public var health : float;
public var armor : float;
public var speed : float;
public var lightAttack : Attack;
public var mediumAttack : Attack;
public var heavyAttack : Attack;
public var cooldown : float;

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
	if(cooldown > 0) cooldown -= Time.deltaTime;
}

function OnCollisionEnter ()
{
	isGrounded = true;
}

function Attack (attack : Attack, armorValue : float, push : float)
{
	armor = armorValue;
	cooldown = attack.recovery;
	yield WaitForSeconds(attack.prep);
	var hit : RaycastHit;
	if(Physics.Raycast(transform.position,transform.forward, hit, attack.reach))
	{
		print("Pow");
		hit.collider.SendMessage("Damage", attack.damage);
		hit.collider.GetComponent(Rigidbody).AddForce(transform.forward * push, ForceMode.Impulse);
	}
	armor = 0;
}

function LightAttack()
{
	if(cooldown <= 0) Attack(lightAttack, 20, 1);
}

function MediumAttack()
{
	if(cooldown <= 0) Attack(mediumAttack, 20, 1);
}

function HeavyAttack()
{
	if(cooldown <= 0) Attack(heavyAttack, 20, 1);
}

function Damage (amount : int)
{
	health -= amount;
}