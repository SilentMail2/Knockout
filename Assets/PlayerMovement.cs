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
	public GameObject Weapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNo == "1") 
		{
			Vector2 Movement = new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed,0);

			if (Input.GetAxis ("Horizontal")< 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis ("Horizontal")> 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = 1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis ("Fire1") > 0) {
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
			if (Input.GetAxis ("Fire1") <= 0) 
			{
				punchTimer = punchTime + Time.deltaTime;
				swing.SetActive (false);

				punch.SetActive (false);
			}
			if (Input.GetButtonUp ("Fire1")) 
			{
				hasSwing = false;
			}
			rb2d.velocity = Movement;
		}
		if (playerNo == "2") 
		{
			Vector2 Movement = new Vector2 (Input.GetAxis ("Horizontal2") * moveSpeed,0);

			if (Input.GetAxis ("Horizontal2") < 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis ("Horizontal2") > 0) {
				Vector3 newScale = obj.transform.localScale;
				newScale.x = 1;
				obj.transform.localScale = newScale;
			}
			if (Input.GetAxis ("Fire2") > 0) {
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
			if (Input.GetAxis ("Fire2") <= 0) 
			{
				punchTimer = punchTime + Time.deltaTime;
				swing.SetActive (false);

				punch.SetActive (false);
			}
			if (Input.GetButtonUp ("Fire2")) 
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
