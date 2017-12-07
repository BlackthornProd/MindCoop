using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHolder : MonoBehaviour {

	[Header ("Refernces")]
	public GameObject[] loot;
	private GameMaster gm;		
	private HurtPanel hurtPanel;
	public GameObject effect;

	public int damage;


	void Start(){

		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Death();
		}
	}

	public void Death(){
		Instantiate(effect, transform.position, Quaternion.identity);
		hurtPanel.Anim();
		gm.fire -= damage;
		int rand = Random.Range(0, loot.Length);
		Instantiate(loot[rand], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
