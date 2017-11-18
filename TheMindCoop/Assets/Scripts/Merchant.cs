using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Merchant : MonoBehaviour {


	public float buyDistance = 15f;
	public Transform giftSpawnPos;

	private GameObject[] targets;
	private GameMaster gm;
	private Animator anim;
	private Enemy enemy;
	public bool isAngry;

	void Start(){
		anim = GetComponent<Animator>();
		enemy = GetComponent<Enemy>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}

	void Update(){

		Debug.Log(isAngry);

		if(isAngry == true){
			gm.buyPrompt.enabled = false;
			anim.SetBool("Angry", true);
		}

		if(Vector2.Distance(transform.position, targets[0].transform.position) < buyDistance && isAngry == false){
			gm.buyPrompt.enabled = true;

			if(Input.GetKeyDown(KeyCode.Space)){
				gm.TakeDamage(75);
				int randomDrop = Random.Range(0, enemy.drops.Length);
				Instantiate(enemy.drops[randomDrop], giftSpawnPos.position, Quaternion.identity);
			}
		} else {
			gm.buyPrompt.enabled = false;
		}
	}


}
