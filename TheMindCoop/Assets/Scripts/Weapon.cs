using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private float fireRate;
	public float startFireRate;
	public GameObject bullet;
	public Transform shotPoint;

	public bool player1;
	public bool currentWeapon = false;

	private GameObject[] playerPositions;

	void Start(){

		if(playerPositions == null){
			playerPositions = GameObject.FindGameObjectsWithTag("Player");
		}
		
		fireRate = startFireRate;
	}

	void Update(){

		if(player1 == true && currentWeapon == true){
			if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)){
					// shhots 
				if(fireRate <= 0){
					Instantiate(bullet, shotPoint.position, transform.rotation);
					fireRate = startFireRate;
				} else {
					fireRate -= Time.deltaTime;
				}
			}
		} else if(player1 == false && currentWeapon == true){
			if(Input.GetKey(KeyCode.Q)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.Z)){
				if(fireRate <= 0){
					Instantiate(bullet, shotPoint.position, transform.rotation);
					fireRate = startFireRate;
				} else {
					fireRate -= Time.deltaTime;
				}
			}


		}
	}
}
