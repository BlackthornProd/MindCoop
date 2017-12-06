using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour {

	public GameObject[] spawns;
	public Transform[] surprisePoses;
	public GameObject bloodSplash;
	public GameObject deathFx;

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			SpawnRandom();
		}
	}

	public void SpawnRandom(){
		GameObject fx = (GameObject)Instantiate(deathFx, transform.position, Quaternion.identity);
		Destroy(fx, 3f);

		int randomSpawnOne = Random.Range(0, spawns.Length);
		int randomSpawnTwo = Random.Range(0, spawns.Length);
		int randomSpawnThree = Random.Range(0, spawns.Length);
		Instantiate(spawns[randomSpawnOne], surprisePoses[0].position, Quaternion.identity);
		Instantiate(spawns[randomSpawnTwo], surprisePoses[1].position, Quaternion.identity);
		Instantiate(spawns[randomSpawnThree], surprisePoses[2].position, Quaternion.identity);
		Instantiate(bloodSplash, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
