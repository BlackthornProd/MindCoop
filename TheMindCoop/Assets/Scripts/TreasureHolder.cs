using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHolder : MonoBehaviour {


	public GameObject[] lootDrops;
	private GameMaster gm;
	private int costInDamage;
	public int priceIncrease;

	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		costInDamage = gm.costInDamage;
	}

	void Update(){
		costInDamage = gm.costInDamage;
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.GetComponent<Projectile>() != null){
			Destroy(other.gameObject);
			DestroyObject();
		} else if(other.CompareTag("Player")){
			DestroyObject();
		}
	}

	void DestroyObject(){
		gm.costInDamage += priceIncrease;
		gm.TakeDamage(costInDamage);
		int rand = Random.Range(0, lootDrops.Length);
		Instantiate(lootDrops[rand], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
