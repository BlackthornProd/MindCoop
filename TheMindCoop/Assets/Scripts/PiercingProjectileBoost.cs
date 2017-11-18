using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectileBoost : MonoBehaviour {

	public GameObject piercingProjectile;
	Player playerOne;
	Player playerTwo;

	void Start(){

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		playerOne = players[0].GetComponent<Player>();
		playerTwo = players[1].GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
				if(other.GetComponent<Player>().player1 == true){
					playerTwo.usedWeapon.bullet = piercingProjectile;
					Destroy(gameObject);
				} else if(other.GetComponent<Player>().player1 == false){
					playerOne.usedWeapon.bullet = piercingProjectile;
					Destroy(gameObject);
				}
			}
		}
	}

