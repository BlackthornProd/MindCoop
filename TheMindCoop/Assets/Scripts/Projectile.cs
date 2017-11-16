using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float range;
	public int damage;

	private GameMaster gm;
	private Animator anim;
	public float destructionTime;

	void Start(){

		anim = GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

	}

	void Update(){

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
		
		if(other.CompareTag("Player") && damage > 0){
			gm.TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Enemy")){
			other.GetComponent<Enemy>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Obstacle")){
			StartCoroutine(AnimWait());
		}  else if(other.CompareTag("Boss")){
			other.GetComponent<Boss1>().TakeDamage(damage);
			StartCoroutine(AnimWait());
		} else if(other.CompareTag("Bomb")){
			other.GetComponent<Bomb>().DestroyBomb(damage);
			StartCoroutine(AnimWait());
		}
	}


	// When the projectile has hit something or has died out...
	IEnumerator AnimWait(){
		anim.SetTrigger("Impact");
		speed = 0;
		damage = 0;
		yield return new WaitForSeconds(destructionTime);
		Destroy(gameObject);
	}
}
