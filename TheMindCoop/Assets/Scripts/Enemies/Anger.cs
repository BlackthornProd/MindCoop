using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : MonoBehaviour {

	[Header ("Stats")]
	private float timeBtwBlasts;
	public float startTimeBtwBlasts;
	public int health;
	public int damage;
	private int angerLevel = 1;

	[Header ("References")]
	public Transform[] blastPoints;
	public GameObject blast;
	private CameraShake shake;
	private GameMaster gm;
	private HurtPanel hurtPanel;
	private FireTracker tracker;
	private Animator anim;

	bool dealDam = true;
	float dealDamTime = 1.5f;

	void Start(){
		anim = GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		tracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
	}

	void Update(){

		if(health <= 500 && health > 400){
			angerLevel = 1;
		} else if(health <= 400 && health > 250){
			angerLevel = 2;
		}else if(health <= 250){
			angerLevel = 3;
		}
			
		if(timeBtwBlasts <= 0){
			anim.SetTrigger("Summon");
			if(angerLevel == 1){
				int randomPosOne = Random.Range(0, blastPoints.Length);
				int randomPosTwo = Random.Range(0, blastPoints.Length);
				Instantiate(blast, blastPoints[randomPosOne].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosTwo].position, Quaternion.identity);
			} else if(angerLevel == 2){
				int randomPosOne = Random.Range(0, blastPoints.Length);
				int randomPosTwo = Random.Range(0, blastPoints.Length);
				int randomPosThree = Random.Range(0, blastPoints.Length);
				int randomPosFour = Random.Range(0, blastPoints.Length);
				Instantiate(blast, blastPoints[randomPosThree].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosFour].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosOne].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosTwo].position, Quaternion.identity);
			} else if(angerLevel == 3){
				int randomPosOne = Random.Range(0, blastPoints.Length);
				int randomPosTwo = Random.Range(0, blastPoints.Length);
				int randomPosThree = Random.Range(0, blastPoints.Length);
				int randomPosFour = Random.Range(0, blastPoints.Length);
				int randomPosFive = Random.Range(0, blastPoints.Length);
				int randomPosSix = Random.Range(0, blastPoints.Length);
				Instantiate(blast, blastPoints[randomPosFive].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosSix].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosThree].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosFour].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosOne].position, Quaternion.identity);
				Instantiate(blast, blastPoints[randomPosTwo].position, Quaternion.identity);
			}

		

			timeBtwBlasts = startTimeBtwBlasts;
		} else {
			timeBtwBlasts -= Time.deltaTime;
		}

		tracker.bossDisplay.text = "" + health;

		if(dealDam == false){
			if(dealDamTime <= 0){
				dealDamTime = 1.5f;
				dealDam = true;
			} else {
				dealDamTime -= Time.deltaTime;
			}
		}
	}

	public void TakeDamage(int damage){
		shake.Shake(.1f, .1f);
		health -= damage;
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
}
