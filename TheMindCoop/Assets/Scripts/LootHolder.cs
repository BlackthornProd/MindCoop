using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHolder : MonoBehaviour {

	public GameObject[] loot;
	private GameMaster gm;		
	HurtPanel hurtPanel;

	public int damage;

	void Start(){

		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}


	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("LOOOT");
		if(other.CompareTag("Player")){
			Death();
		}
	}

	public void Death(){
		hurtPanel.Anim();
		gm.fire -= damage;
		int rand = Random.Range(0, loot.Length);
		Instantiate(loot[rand], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
