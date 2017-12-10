using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHolder : MonoBehaviour {

	[Header ("Refernces")]
	public GameObject[] loot;
	private GameMaster gm;		
	private HurtPanel hurtPanel;
	public GameObject effect;
	private CameraShake shake;

	public int damage;
	public int health;

	void Start(){
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}


	void Update(){

		if(health <= 0){
			Death();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Death();
		} 
	}

	public void TakeDamage(int damageTaken){
		shake.Shake(0.125f, 0.125f);
		health -= damageTaken;
	}

	public void Death(){
		shake.Shake(0.125f, 0.125f);
		Instantiate(effect, transform.position, Quaternion.identity);
		hurtPanel.Anim();
		gm.fire -= damage;
		int rand = Random.Range(0, loot.Length);
		Instantiate(loot[rand], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
