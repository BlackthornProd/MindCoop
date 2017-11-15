using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public bool player1;

	private Animator anim;
	public Weapon usedWeapon;
	private Rigidbody2D rb;

	float spawnFootprint = .2f;
	public GameObject[] footprint;
	int black;
	float time = 1f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update(){
		if(black == 1){
			if(time <= 0){
				black = 0;
				time = 1f;
			} else {
				time -= Time.deltaTime;
			}
		}
	}

	void FixedUpdate(){


		// Moves first player, also rotates the weapon and sets the run / idle animation
		if(player1 == true){
			if(Input.GetKey(KeyCode.LeftArrow)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, 90);
				rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();

			} else if(Input.GetKey(KeyCode.RightArrow)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, -90);
				rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else if(Input.GetKey(KeyCode.UpArrow)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, 0);
				rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else if(Input.GetKey(KeyCode.DownArrow)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, -180);
				rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else {
				anim.SetBool("isRunning", false);
			}
		}

		// Moves second player, also rotates the weapon and sets the run / idle animation
		if(player1 == false){
			if(Input.GetKey(KeyCode.Q)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, 90);
				rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else if(Input.GetKey(KeyCode.D)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, -90);
				rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else if(Input.GetKey(KeyCode.Z)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, 0);
				rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else if(Input.GetKey(KeyCode.S)){
				usedWeapon.transform.eulerAngles = new Vector3(0, 0, -180);
				rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
				anim.SetBool("isRunning", true);
				Tst();
			} else {
				anim.SetBool("isRunning", false);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Blood")){
			black = 1;
		}
	}

	void Tst(){

		if(spawnFootprint <= 0){
			Instantiate(footprint[black], transform.position, Quaternion.identity);
			spawnFootprint = 0.2f;
		} else {
			spawnFootprint -= Time.deltaTime;
		}
	}
}
