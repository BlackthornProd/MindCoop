using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourSidedShooter : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject shot;

	private Animator anim;

	float timeBtwShots;
	public float startTimeBtwShots;

	void Start(){
		anim = GetComponent<Animator>();
		timeBtwShots = startTimeBtwShots;
	}

	void Update(){

		if(timeBtwShots <= 0){
			anim.SetTrigger("Jump");
			StartCoroutine(Attack());
			timeBtwShots = startTimeBtwShots;
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}

	IEnumerator Attack(){

		yield return new WaitForSeconds(0.5f);

		for (int i = 0; i < spawnPoints.Length; i++) {
				Instantiate(shot, spawnPoints[i].position, spawnPoints[i].rotation);
			}
	}
}
