//using UnityEngine;
//using System.Collections;
//
//public class FighterCopy : MonoBehaviour {
//
//public class Attack
//{
//	public int damage;
//	public float prep;
//	public float recovery;
//	public float reach;
//}
//
//	public float health;
//	public float armor;
//	public float speed;
//	public Attack lightAttack;
//	public Attack mediumAttack;
//	public Attack heavyAttack;
//	public float cooldown;
//
//	public float jumpPower;
//
//	public float direction;
////@HideInInspector
//	public float jumping;
//
//private bool isGrounded = true;
//
//void Start () {
//	
//}
//
//void Update () {
//	this.transform.position = new Vector3(transform.position.x*direction * speed * 0.25, transform.position.y, transform.position.z);
//	//this.transform.LookAt(transform.position + Vector3(direction,0,0));
//	if(jumping>0)
//	{
//		if(isGrounded){
//			GetComponent<Rigidbody>().velocity= jumpPower;
//			isGrounded = false;
//		}
//	}
//	if(cooldown > 0) cooldown -= Time.deltaTime;
//}
//
//void OnCollisionEnter ()
//{
//	isGrounded = true;
//}
//
//IEnumerator AttackFunc (Attack attack, float armorValue, float push)
//{
//	armor = armorValue;
//	cooldown = attack.recovery;
//	yield return new WaitForSeconds(attack.prep);
//	RaycastHit hit;
//	if(Physics.Raycast(transform.position,transform.forward, hit, attack.reach))
//	{
//		print("Pow");
//		hit.collider.SendMessage("Damage", attack.damage);
//		hit.collider.GetComponent(Rigidbody).AddForce(transform.forward * push, ForceMode.Impulse);
//	}
//	armor = 0;
//}
//
//void LightAttack()
//{
//
//		if(cooldown <= 0) StartCoroutine("AttackFunc", lightAttack, 20, 1);
//}
//
//void MediumAttack()
//{
//	if(cooldown <= 0) StartCoroutine("AttackFunc", mediumAttack, 20, 1);
//}
//
//void HeavyAttack()
//{
//			if(cooldown <= 0) StartCoroutine("AttackFunc", heavyAttack, 20, 1);
//}
//
//void Damage (int amount)
//{
//	health -= amount;
//}
//
//}