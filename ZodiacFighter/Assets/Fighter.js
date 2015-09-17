#pragma strict

public class Attack
{
	public var damage : int;
	public var prep : float;
	public var projectile : GameObject;
	public var recovery : float;
	public var reach : float;
	public var armor : float;
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
	transform.LookAt(transform.position + Vector3(0,0,direction));
	if(jumping && isGrounded)
	{
		GetComponent(Rigidbody2D).velocity.y = jumpPower;
		isGrounded = false;
	}
	if(cooldown > 0) cooldown -= Time.deltaTime;
	Debug.DrawLine(transform.position, transform.position + transform.right * 5);
}

function OnCollisionEnter2D ()
{
	isGrounded = true;
}

function Attack (attack : Attack, armorValue : float, push : float)
{
	print("Whoosh");
	armor = attack.armor;
	cooldown = attack.recovery;
	yield WaitForSeconds(attack.prep);
	var hit = Physics2D.Raycast(transform.position,transform.right, 5);
	if(hit.collider != null && hit.collider != gameObject.GetComponent(Collider2D))
	{
		print("Pow");
		hit.collider.SendMessage("Damage", attack.damage);
		hit.collider.GetComponent(Rigidbody2D).AddForce(Vector2(direction * push,0), ForceMode2D.Impulse);
		if(attack.projectile) Instantiate(attack.projectile, transform.position, transform.rotation); 
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