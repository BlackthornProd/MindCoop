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

	[Header("Death Choices")]
	public GameObject deathChoices;
	public Transform[] deathChoicesPoses;

	[Header ("Blood Trail Effect")]
	public GameObject[] bloodTrailSmall;
	public GameObject[] bloodTrailBig;
	public Transform rewardPos;
	public GameObject[] reward;
	public float timeBtwBlood = 0.5f;

	[Header ("Death Stuff")]
	public GameObject bloodSplash;
	public GameObject portal;
	public GameObject deathEffect;

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
		if(health > 0 && health <= 150){
			head.sprite = heads[0];
			speed = 25;
			startTimeBtwBomb = .39f;
			if(timeBtwBlood <=  0){
				int randomBlood = Random.Range(0, bloodTrailBig.Length);
				GameObject fx = (GameObject)Instantiate(bloodTrailBig[randomBlood], transform.position, Quaternion.identity);
				Destroy(fx, 3f);
				timeBtwBlood = 0.12f;
			} else {
				timeBtwBlood-= Time.deltaTime;
			}
		} else if(health > 150 && health <= 300){
			head.sprite = heads[1];
			speed = 20;
			startTimeBtwBomb = .75f;
			if(timeBtwBlood <=  0){
				int randomBlood = Random.Range(0, bloodTrailSmall.Length);
				GameObject fx = (GameObject)Instantiate(bloodTrailSmall[randomBlood], transform.position, Quaternion.identity);
				Destroy(fx, 3f);
				timeBtwBlood = 0.12f;
			} else {
				timeBtwBlood-= Time.deltaTime;
			}
		} else if(health > 300 && health <= 450){
			head.sprite = heads[2];
			speed = 18;
			startTimeBtwBomb = 1.5f;
			if(timeBtwBlood <=  0){
				int randomBlood = Random.Range(0, bloodTrailBig.Length);
				GameObject fx = (GameObject)Instantiate(bloodTrailSmall[randomBlood], transform.position, Quaternion.identity);
				Destroy(fx, 3f);
				timeBtwBlood = 0.12f;
			} else {
				timeBtwBlood-= Time.deltaTime;
			}
		} else if(health > 450 && health <= 600){
			head.sprite = heads[3];
			speed = 15;
			startTimeBtwBomb = 2f;
		}


		tracker.bossDisplay.text = "" + health;

		// PATROL


		if(transform.position == poses[randomPos].position){
			timeMovingTowards = 0;
		}

		if(timeMovingTowards <= 0){
			randomPos = Random.Range(0, poses.Length);
			timeMovingTowards = Random.Range(minMovingTowards, maxMovingTowards);

		} else {
			timeMovingTowards -= Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, poses[randomPos].position, speed * Time.deltaTime);
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


		if(health <= 0){

			for (int i = 0; i < deathChoicesPoses.Length; i++) {
				Instantiate(deathChoices, deathChoicesPoses[i].position, Quaternion.identity);
			}

			int randomReward = Random.Range(0, reward.Length);
			Instantiate(reward[randomReward], transform.position, Quaternion.identity);
			
			Instantiate(bloodSplash, transform.position, Quaternion.identity);
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Instantiate(portal, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") && dealDam == true){
			hurtPanel.Anim();
			dealDam = false;
			gm.TakeDamage(damage);
		}

		if(other.CompareTag("GoldenBirdShot")){
			health -= other.GetComponent<GoldenBirdShot>().damage;
		}
	}


	public void TakeDamage(int damage){
		shake.Shake(.1f, .1f);
		health -= damage;
	}
}
