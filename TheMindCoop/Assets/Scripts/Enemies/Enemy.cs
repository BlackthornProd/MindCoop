using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[Header ("Enemy Stats")]
	public int health;
	public int damage;

	[Header ("Drops")]
	public int dropChance = 50;
	public GameObject[] drops;
	public GameObject[] bloodSplash;

	private GameMaster gm;
	private CameraShake shake;

	public bool isFatty = false;
	private Fatty fatty;
	public bool isCarrier;
	private FireCarrier carrier;


	private HurtPanel hurtPanel;

	void Start(){
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		if(isFatty == true){
			fatty = GetComponent<Fatty>();
		}

		if(isCarrier == true){
			carrier = GetComponent<FireCarrier>();
		}
	}

	void Update(){
		if(health <= 0){
			int randomSplash = Random.Range(0, bloodSplash.Length);
			Instantiate(bloodSplash[randomSplash], transform.position, transform.rotation);

			int dropOrNot = Random.Range(0, 100);
			if(dropChance > dropOrNot){
				int randomDrop = Random.Range(0, drops.Length);
				Instantiate(drops[randomDrop], transform.position, transform.rotation);
			}
			if(fatty != null){
				fatty.Spawn();
			}
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage){
		shake.Shake(.1f, .1f);

		if(isCarrier == true){
			carrier.enabled = true;
		}

		health -= damage;

	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){

			hurtPanel.Anim();
			gm.TakeDamage(damage);
			health = 0;
		} 
	}
}
