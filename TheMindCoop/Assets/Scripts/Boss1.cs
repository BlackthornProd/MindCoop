using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss1 : MonoBehaviour {

	[Header ("Stats")]
	public int health = 40;
	public float speed = 10f;
	public int damage = 100;


	[Header ("References")]
	public GameObject[] spawns;
	public Transform[] spawnPos;
	private GameObject[] targets;
	private GameMaster gm;
	private CameraShake shake;

	public GameObject bloodSplash;
	public GameObject deathFx;
	public GameObject portal;

	bool dealDam = true;
	float dealDamTime = 1.5f;

	void Start(){
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}

	void Update(){
		// Makes the chaser follow the nearest player !
		if(Vector2.Distance(transform.position, targets[0].transform.position) > Vector2.Distance(transform.position, targets[1].transform.position)){
			transform.position = Vector2.MoveTowards(transform.position, targets[1].transform.position, speed * Time.deltaTime);
		} else {
			transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);
		}

		gm.bossDisplay.text = "The Dark Mother : " + health;

		if(health <= 0){
			Instantiate(deathFx, transform.position, Quaternion.identity);
			Instantiate(bloodSplash, transform.position, Quaternion.identity);
			Instantiate(portal, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}	

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
			dealDam = false;
			gm.TakeDamage(damage);
		}
	}


	public void TakeDamage(int damage){
		shake.Shake(.1f, .1f);
		health -= damage;
		int randomSpawn = Random.Range(0, spawns.Length);
		int randomPos = Random.Range(0, spawnPos.Length);
		Instantiate(spawns[randomSpawn], spawnPos[randomPos].position, Quaternion.identity);
	}
}
