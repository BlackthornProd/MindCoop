using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float range;

	[Header ("Damage Tiers")]
	public int damage;
	public int damOne;
	public int damTwo;
	public int damThree;
	public int damFour;
	public int damFive;

	private GameMaster gm;
	private Animator anim;
	public float destructionTime;

	private HurtPanel hurtPanel;
	public GameObject halo;
	public bool player1 = false;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		anim = GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){

		// Fire ball VISUALS depending on DAMAGE
		if(gm.damage > 0 && gm.damage <= 5){
			transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			damage = damOne;
		} else if(gm.damage > 5 && gm.damage <= 10){
			transform.localScale = new Vector3(1f, 1f, 1f);
			damage = damTwo;
		} else if(gm.damage > 10 && gm.damage <= 15){
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			damage = damThree;
		} else if(gm.damage > 15 && gm.damage <= 20){
			transform.localScale = new Vector3(2f, 2f, 2f);
			damage = damFour;
		} else if(gm.damage > 20){
			transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
			damage = damFive;
		}


		// Destroys the projectile after X seconds !
		if(range <= 0){
			StartCoroutine(AnimWait());
		} else {
			range -= Time.deltaTime;
		}

		// Move forward
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}


	// Checks Collisions !
	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Enemy") || other.CompareTag("Merchant")){
				other.GetComponent<Enemy>().TakeDamage(damage);
				StartCoroutine(AnimWait());
		}

		
		if(other.CompareTag("Player") && damage > 0){
			if(other.GetComponent<Player>().player1 == true && player1 == false){
				gm.TakeDamage(damage);
				hurtPanel.Anim();
			} else if(other.GetComponent<Player>().player1 == false && player1 == true){
				gm.TakeDamage(damage);
				hurtPanel.Anim();
			}

			StartCoroutine(AnimWait());
		} 
		 else if(other.CompareTag("Obstacle")){
			StartCoroutine(AnimWait());
		}  else if(other.CompareTag("Boss")){
			other.GetComponent<Boss1>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Bomb")){
			other.GetComponent<Bomb>().DestroyBomb(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Boss2")){
			other.GetComponent<Boss2>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("QuestionMark")){
			other.GetComponent<QuestionMark>().SpawnRandom();
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("LootHolder")){
			other.GetComponent<LootHolder>().Death();
			StartCoroutine(AnimWait());
		}

	}


	// When the projectile has hit something or has died out...
	IEnumerator AnimWait(){
		Destroy(halo);
		anim.SetTrigger("Impact");
		speed = 0;
		damage = 0;
		yield return new WaitForSeconds(destructionTime);
		Destroy(gameObject);
	}
}
