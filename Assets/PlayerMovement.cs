using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public int playerNo;
	public Rigidbody2D rb2d;
	public GameObject obj;
	public GameObject punch;
	public float punchTime;
	public float punchTimer;
	public float punchCount;
	public GameObject swing;
	public bool hasSwing;
	public int hp;
	public float punchLocal;
	public GameObject enemyPunch;
	public float selfLocation;
	public float punchDir;
	public float knockbackSpeed;
	public float knockbackDir;
	public float JumpSpeed;
	public GameObject Weapon;
	public bool canjump;
	public float jump;
	//scoresystem
	public ScoreKeeper scoreSystem;

	//Controlls
	public string jumpButton;
	public string horizontalButton;
	public string FireButton;


	public float gravity;
	public float gravIncrease;

	public float jumpTime;
	public float jumpTimer;
	public float jumpCount;

	public LayerMask groundLayer;
	public bool IsGrounded ()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 2.0f;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);

		if (hit.collider != null) {
			return true;
		} 

		return false;
	}
	// Use this for initialization
	void Start () {
		Time.timeScale = 0.8f;
	}
	

	// Update is called once per frame
	void Update () {
		if (hp > 0) {
			Vector2 Movement = new Vector2 (Input.GetAxis (horizontalButton) * moveSpeed, JumpSpeed * jump - gravity);
			if (Input.GetButtonDown (jumpButton) && IsGrounded ()) {
				jump = 1;
				gravity = 10;
				
			}
			if (/*jumpTimer > 0 &&*/ jump > 0) {
				//jumpTimer = jumpTimer - jumpCount + Time.deltaTime;
				jump = jump - gravIncrease;
				//gravity = gravity + gravIncrease;
			}
			//if (jumpTimer <= 0) {
			//jump = 0;
			//}
			if (jump == 0) {
				jumpTimer = jumpTime + Time.deltaTime;
			}
			if (Input.GetAxis (horizontalButton) < 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis (horizontalButton) > 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = 1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis (FireButton) > 0) {
				if (!hasSwing) {
					punch.SetActive (true);
				}
				if (hasSwing) {
					swing.SetActive (true);
				}
				punchTimer = punchTimer - punchCount + Time.deltaTime;
				if (punchTimer <= 0) {
					punch.SetActive (false);
					hasSwing = false;
					swing.SetActive (false);
				}
			}

		

			if (Input.GetAxis (FireButton) <= 0) {
				punchTimer = punchTime + Time.deltaTime;
				swing.SetActive (false);

				punch.SetActive (false);
			}
			if (Input.GetButtonUp (FireButton)) {
				hasSwing = false;
			}
			rb2d.velocity = Movement;



			selfLocation = this.transform.position.x;
			if (hasSwing) {
				Weapon.SetActive (true);
			}
			if (!hasSwing) {
				Weapon.SetActive (false);
			}
		}
		if (hp <= 0) {
			rb2d.AddForce (new Vector2 (knockbackDir * knockbackSpeed, 0));
		}
	}
	public void Death ()
	{
		scoreSystem.dead++;
		if (scoreSystem.dead == 1) {
			scoreSystem.points [playerNo] += 5;
		}
		if (scoreSystem.dead == 2) {
			scoreSystem.points [playerNo] += 10;
		}
		if (scoreSystem.dead == 3) {
			scoreSystem.points [playerNo] += 15;
		}
		if (scoreSystem.dead == 4) {
			scoreSystem.points [playerNo] += 20;
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Damage") {
			enemyPunch = other.gameObject;
			punchLocal = enemyPunch.transform.position.x;
			punchDir = selfLocation - punchLocal;
			if (punchDir < 0) {
				knockbackDir = -1;
			}
			if (punchDir > 0) {
				knockbackDir = 1;
			}
			hp--;
		}
		if (other.gameObject.tag == "Melee") {
			hasSwing = true;
		}
	}
	
}
