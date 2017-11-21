using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {

	[Header ("Stats")]
	public int health = 40;
	public SpriteRenderer head;
	public Sprite[] heads;
	public float speed = 10f;
	public int damage = 100;
	public float startTimeBtwBomb;
	private float timeBtwBomb;

	[Header ("References")]
	private FireTracker tracker;
	private CameraShake shake;
	private GameMaster gm;
	public GameObject bomb;
	private HurtPanel hurtPanel;

	bool dealDam = true;
	float dealDamTime = 1.5f;

	public Transform[] poses;
	private int randomPos;
	private float timeMovingTowards;
	public float minMovingTowards;
	public float maxMovingTowards;


	void Start(){	
		randomPos = Random.Range(0, poses.Length);
		timeMovingTowards = Random.Range(minMovingTowards, maxMovingTowards);

		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		tracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){

		// CHANGE HEAD GRAPHICS
		if(health > 0 && health <= 5){
			head.sprite = heads[0];
		} else if(health > 5 && health <= 10){
			head.sprite = heads[1];
		} else if(health > 10 && health <= 15){
			head.sprite = heads[2];
		} else if(health > 15 && health <= 20){
			head.sprite = heads[3];
		}


		tracker.bossDisplay.text = "Friendly Horror : " + health;

		// PATROL
		if(timeMovingTowards <= 0){
			timeMovingTowards = Random.Range(minMovingTowards, maxMovingTowards);
			randomPos = Random.Range(0, poses.Length);
		} else {
			timeMovingTowards -= Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, poses[randomPos].position, speed * Time.deltaTime);
		}

		if(transform.position == poses[randomPos].position){
			timeMovingTowards = 0;
		}


		// BOMBS
		if(timeBtwBomb <= 0){
			Instantiate(bomb, transform.position, Quaternion.identity);
			timeBtwBomb = startTimeBtwBomb;
		} else {
			timeBtwBomb -= Time.deltaTime;
		}



		// MAKES SURE THE PLAYER HAS SOME INVINSIBILITY TIME !
		if(dealDam == false){
			if(dealDamTime <= 0){
				dealDamTime = 1.5f;
				dealDam = true;
			} else {
				dealDamTime -= Time.deltaTime;
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") && dealDam == true){
			hurtPanel.Anim();
			dealDam = false;
			gm.TakeDamage(damage);
		}
	}


	public void TakeDamage(int damage){
		shake.Shake(.1f, .1f);
		health -= damage;
	}
}
