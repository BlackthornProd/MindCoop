using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Merchant : MonoBehaviour {


	public float buyDistance = 15f;
	public Transform giftSpawnPos;

	private GameObject[] targets;
	private FireTracker tracker;
	private GameMaster gm;
	private Animator anim;
	private Enemy enemy;
	public bool isAngry;
	public bool hasBought;

	public GameObject fireSpit;
	public float startTimeBtwFireSpit;
	private float timeBtwFireSpit;


	HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		timeBtwFireSpit = startTimeBtwFireSpit;
		anim = GetComponent<Animator>();
		enemy = GetComponent<Enemy>();
		tracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}

	void Update(){


		if(isAngry == true){
			tracker.buyPrompt.enabled = false;
			anim.SetBool("Angry", true);
		}

		if(Vector2.Distance(transform.position, targets[0].transform.position)< buyDistance && isAngry == false && hasBought == false){
			tracker.buyPrompt.enabled = true;

			if(Input.GetKeyDown(KeyCode.Space) && hasBought == false){
				hurtPanel.Anim();
				hasBought = true;
				gm.TakeDamage(100);
				int randomDrop = Random.Range(0, enemy.drops.Length);
				Instantiate(enemy.drops[randomDrop], giftSpawnPos.position, Quaternion.identity);
			}
		} else if(Vector2.Distance(transform.position, targets[1].transform.position)< buyDistance && isAngry == false && hasBought == false){
			tracker.buyPrompt.enabled = true;

			if(Input.GetKeyDown(KeyCode.Space) && hasBought == false){
				hurtPanel.Anim();
				hasBought = true;
				gm.TakeDamage(100);
				int randomDrop = Random.Range(0, enemy.drops.Length);
				Instantiate(enemy.drops[randomDrop], giftSpawnPos.position, Quaternion.identity);
			}
		}else {
			tracker.buyPrompt.enabled = false;
		}


		if(isAngry == true){
			if(timeBtwFireSpit <= 0){
				Instantiate(fireSpit, transform.position, Quaternion.identity);
				timeBtwFireSpit = startTimeBtwFireSpit;
			} else {
				timeBtwFireSpit -= Time.deltaTime;
			}
		}
	}


}
