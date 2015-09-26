using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour
{

	[System.Serializable]
	public class Attack
	{
		public int damage;
		public float prep;
		public GameObject projectile;
		public float recovery;
		public float reach;
		public float armor;
		public float armorBreak;
		public float knockback;
	}
	
	public float health;
	public float armor;
	public float speed;
	public Attack lightAttack;
	public Attack mediumAttack;
	public Attack heavyAttack;
	public float cooldown;
	public float jumpPower;
	public float direction;
	public float jumping;
	private bool isGrounded = true;
	public int playID;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		transform.position += new Vector3 (direction * speed * 0.25f, 0.0f, 0.0f);
		transform.LookAt (transform.position + new Vector3 (0, 0, direction));
		if (jumping > 0) {
			if (isGrounded) {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, jumpPower, 0);
				isGrounded = false;
			}
		}
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
		Debug.DrawLine (transform.position, transform.position + transform.right * 1);
	}

	void OnCollisionEnter2D ()
	{
		isGrounded = true;
	}
	
	IEnumerator PerformAttack (Attack attack)
	{
		float tempSpeed = speed;
		print ("Whoosh from " + gameObject.name);
		armor = attack.armor;
		cooldown = attack.recovery + attack.prep;
		while (armor > 0) {
			speed = 0;
			yield return new WaitForSeconds (attack.prep);
			RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right, attack.reach);
			if(hit)Debug.DrawLine(transform.position, hit.transform.position, Color.blue, 3);
			if (hit.collider != null && hit.collider != gameObject.GetComponent<Collider2D> ()) {
				print ("Pow from " + gameObject.name);
				hit.collider.SendMessage ("Damage", attack.damage);
				hit.collider.SendMessage ("ArmorDamage", attack.armorBreak);
				hit.collider.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (direction * attack.knockback, 0), ForceMode2D.Impulse);
			}
			if (attack.projectile)
				Instantiate (attack.projectile, transform.position, transform.rotation);
			armor = 0;
			speed = tempSpeed;
		}
	}
	
	public void LightAttack ()
	{
		if (cooldown <= 0) {
			StartCoroutine (PerformAttack (lightAttack));
			this.GetComponentInChildren<Animator> ().SetTrigger ("Light");
		}
	}
	
	public void MediumAttack ()
	{
		if (cooldown <= 0) {
			StartCoroutine (PerformAttack (mediumAttack));
			this.GetComponentInChildren<Animator> ().SetTrigger ("Medium");
		}
	}
	
	public void HeavyAttack ()
	{
		if (cooldown <= 0) {
			StartCoroutine (PerformAttack (heavyAttack));
			this.GetComponentInChildren<Animator> ().SetTrigger ("Heavy");
		}
	}
	
	void Damage (float amount)
	{
		health -= amount;
	}

	void ArmorDamage (float amount)
	{
		armor -= amount;
	}
}
