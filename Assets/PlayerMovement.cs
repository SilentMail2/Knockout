using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public string playerNo;
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

	//Controlls
	public string jumpButton;
	public string horizontalButton;
	public string FireButton;




	public float jumpTime;
	public float jumpTimer;
	public float jumpCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNo == "1") 
		{
			Vector2 Movement = new Vector2 (Input.GetAxis (horizontalButton) * moveSpeed, JumpSpeed*jump);
			if (Input.GetButtonDown (jumpButton) && canjump)
			{
				jump = 1;
				//canjump = false;
			}
			if (jumpTimer > 0 && jump > 0) {
				jumpTimer = jumpTimer - jumpCount + Time.deltaTime;
				jump = jump - 0.0001f;
			}
			if (jumpTimer <= 0) {
				jump = 0;
			}
			if (jump == 0) {
				jumpTimer = jumpTime + Time.deltaTime;
			}
			if (Input.GetAxis (horizontalButton)< 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis (horizontalButton)> 0) {
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

		

			if (Input.GetAxis (FireButton) <= 0) 
			{
				punchTimer = punchTime + Time.deltaTime;
				swing.SetActive (false);

				punch.SetActive (false);
			}
			if (Input.GetButtonUp (FireButton)) 
			{
				hasSwing = false;
			}
			rb2d.velocity = Movement;
		}

		if (hp <= 0) 
		{
			rb2d.AddForce (new Vector2 (knockbackDir * knockbackSpeed, 0));
		}
		selfLocation = this.transform.position.x;
		if (hasSwing) {
			Weapon.SetActive (true);
		}
		if (!hasSwing) {
			Weapon.SetActive (false);
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
