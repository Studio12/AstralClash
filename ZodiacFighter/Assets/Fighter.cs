using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	[System.Serializable]
	public class Attack
	{
		public int damage;
		public float prep;
		public GameObject projectile;
		public float recovery;
		public float reach;
		public float armor;
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

	public bool jumping  = false;
	
	private bool isGrounded = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(direction * speed * 0.25f,0.0f,0.0f);
		transform.LookAt(transform.position + new Vector3(0,0,direction));
		if(jumping && isGrounded)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0,jumpPower,0);
			isGrounded = false;
		}
		if(cooldown > 0) cooldown -= Time.deltaTime;
		Debug.DrawLine(transform.position, transform.position + transform.right * 5);
	}

	void OnCollisionEnter2D ()
	{
		isGrounded = true;
	}
	
	IEnumerator PerformAttack (Attack attack, float push)
	{
		print("Whoosh");
		armor = attack.armor;
		cooldown = attack.recovery;
		yield return new WaitForSeconds(attack.prep);
		RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right, 5);
		if(hit.collider != null && hit.collider != gameObject.GetComponent<Collider2D>())
		{
			print("Pow");
			hit.collider.SendMessage("Damage", attack.damage);
			hit.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * push,0), ForceMode2D.Impulse);
			if(attack.projectile) Instantiate(attack.projectile, transform.position, transform.rotation); 
		}
		armor = 0;
	}
	
	public void LightAttack()
	{
		if(cooldown <= 0) StartCoroutine(PerformAttack(lightAttack, 1));
	}
	
	public void MediumAttack()
	{
		if(cooldown <= 0) StartCoroutine(PerformAttack(mediumAttack, 1));
	}
	
	public void HeavyAttack()
	{
			if(cooldown <= 0) StartCoroutine(PerformAttack(heavyAttack, 1));
	}
	
	void Damage (float amount)
	{
		health -= amount;
	}
}
