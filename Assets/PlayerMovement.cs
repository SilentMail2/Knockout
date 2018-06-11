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

	//animation
	public bool flipX;
	public SpriteRenderer mySpriteRenderer;

	//scoresystem
	public ScoreKeeper scoreSystem;
	public GameObject BackShield;
	public GameObject FrontShield;
	public bool fShield;
	public bool bShield;
	public Text Score;
	//Controlls
	public string jumpButton;
	public string horizontalButton;
	public string FireButton;
	public string DuckButton;

	public float gravity;
	public float gravIncrease;

	public float jumpTime;
	public float jumpTimer;
	public float jumpCount;

	public float SelfDir;

	//public GameObject Trigger;
	public GameObject ScreenExplosion;

	public float CameraPointy;
	public Vector3 CameraPoint;

	public bool isPunching;
	float lastPunchTime;
	public float timeBetweenDamages = 0.2f;
	bool alive = true;

	public bool isDucking;

	public LayerMask groundLayer;

	//animations
	/*public string jumping;
	public string jumpPunching;
	public string jumpSwinging;
	public string duck;
	public string punching;
	public string swinging;*/
	public string skinType;

	public Animator animate;
	public SpriteRenderer SpriteRenderer;
	public AnimatorOverrideController animationOverrideRegular;
	public AnimatorOverrideController animationOverrideKnight;

	
	public bool isMoving;


	public bool canMove;
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
		//animationOverride.runtimeAnimatorController = Resources.Load ("Assets/AnimationController/Player1/Player2OverrideRegular") as RuntimeAnimatorController;
		Time.timeScale = 0.8f;
		animate = gameObject.GetComponent<Animator> ();
		animate.SetInteger ("State", 0);
		//CameraDirectionX = 
		//animate.runtimeAnimatorController = Resources.Load ("Assets/AnimationController/Player"+ (1+playerNo).ToString()+"/"+skinType+".controller") as RuntimeAnimatorController;
		//animate.runtimeAnimatorController = Resources.Load ("Assets/AnimationController/Player1/Regular") as RuntimeAnimatorController;
		if (skinType == "Regular") {
			animate.runtimeAnimatorController = animationOverrideRegular;
		}
		if (skinType == "Knight") {
			animate.runtimeAnimatorController = animationOverrideKnight;
		}
	}
	

	// Update is called once per frame
	void Update () {
		



		Score.text = (scoreSystem.points [playerNo].ToString());
		if ((scoreSystem.playerMode-1) < playerNo) {
			this.gameObject.SetActive (false);
		}
		CameraPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, CameraPointy, 0));
		if (Input.GetAxis (horizontalButton) <0 && !isPunching && !isDucking) {
			SelfDir = 1;

		}
		if (Input.GetAxis (horizontalButton) > 0 && !isPunching && !isDucking) {
			SelfDir = -1;

		}
		if (Input.GetButton (horizontalButton)) {
			isMoving = true;
		}
		if (Input.GetButtonUp (horizontalButton)) {
			isMoving = false;
		}
		if (Input.GetButtonDown (FireButton)) {
			isPunching = true;
		}
		if (Input.GetButtonUp (FireButton)) {
			isPunching = false;
		}

		if (isMoving && isPunching && !isDucking) {
			animate.SetInteger ("State", 2);

		}
		if (!isMoving && isPunching &&!isDucking) {
			animate.SetInteger ("State", 2);
		}
		if (!isMoving && !isPunching && !isDucking) {
			animate.SetInteger ("State", 0);
		}
		if (isMoving && !isPunching && !isDucking) {
				animate.SetInteger ("State", 1);
		}
		if (isMoving && !isPunching && isDucking) {
			animate.SetInteger ("State", 3);
		}
		if (!isMoving && !isPunching && isDucking) {
			animate.SetInteger ("State", 3);
		}

		if (IsGrounded()) {
			canjump = true;
		}










		if (hp > 0) {
			
			if (!isDucking) {
				if (Input.GetButtonDown (jumpButton) && canjump) {
					jump = 1;
					gravity = 10;
					canjump = false;
				}
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

			if (flipX) {
				mySpriteRenderer.flipX = true;
				punch.transform.position = new Vector3 (this.transform.position.x-0.42f, this.transform.position.y+0.47f, this.transform.position.z);
				swing.transform.position = new Vector3 (this.transform.position.x - 0.95f, this.transform.position.y + 0.47f, this.transform.position.z);
				this.gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (1.37f, 0);
			} else if (!flipX){
				mySpriteRenderer.flipX = false;
				punch.transform.position = new Vector3 (this.transform.position.x + 0.42f, this.transform.position.y+0.47f, this.transform.position.z);
				swing.transform.position = new Vector3 (this.transform.position.x + 0.95f, this.transform.position.y + 0.47f, this.transform.position.z);
				this.gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 (-1.37f, 0);
			}
			 
			if (!isDucking) {
				if (Input.GetAxis (horizontalButton) < 0 ) {
					flipX = true;
					/*Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				newScale.y = 1;
				newScale.z = 1;
				obj.transform.localScale = obj.transform.localScale.x*newScale;*/
				}
				if (Input.GetAxis (horizontalButton) > 0 ) {
					flipX = false;
					/*Vector3 newScale = obj.transform.localScale;
				newScale.x = -1;
				newScale.y = 1;
				newScale.z = 1;
				obj.transform.localScale = new Vector3 (obj.transform.localScale.x*newScale.x, obj.transform.localScale.y, obj.transform.localScale.z);*/
				}
				/*
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
			}*/
				if (Input.GetButtonDown (FireButton) && !isPunching) {
					//punch


				}
				Vector2 Movement = new Vector2 (Input.GetAxis (horizontalButton) * moveSpeed, JumpSpeed * jump - gravity);
				rb2d.velocity = Movement;
			}

			if (Input.GetButtonDown (FireButton) && !isDucking) {
				animate.SetBool ("Ispunching", true);

			}
			if (Input.GetButtonUp (FireButton)) {
				hasSwing = false;
				animate.SetBool ("Ispunching", false);

			}
			if (Input.GetButtonDown (DuckButton) && !isPunching) {
				StartDuck ();
			}
			/*if (Input.GetButtonUp (DuckButton)) {
				isDucking = false;
			}*/




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
			rb2d.gravityScale = 0;
		}
		if (bShield) {
			BackShield.gameObject.SetActive (true);
		}
		if (!bShield) {
			BackShield.gameObject.SetActive (false);
		}
		if (fShield) {
			FrontShield.gameObject.SetActive (true);
		}
		if (!fShield) {
			FrontShield.gameObject.SetActive (false);
		}
		CameraPointy = this.gameObject.transform.position.y;
		if (scoreSystem.dead == scoreSystem.playerMode - 1 && alive) {
			scoreSystem.LogDeath (playerNo);
			//scoreSystem.points.
		}
	}

	void EndPunch()
	{
		punch.SetActive (false);
		isPunching = false;
		animate.SetBool ("Ispunching", false);
	}
	void StartPunch()
	{
		
		if (!isPunching) {
			punch.SetActive (true);
			isPunching = true;
			Invoke ("EndPunch", 0.5f);
		
		}
	}

	void StartDuck ()
	{
		
		isDucking = true;
	}
	void EndDuck()
	{
		isDucking = false;
	}

	void Death ()
	{
		if (alive) {
			Debug.Log ("Player " + playerNo + " has died.");
			alive = false;
			scoreSystem.LogDeath (playerNo);
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			/*scoreSystem.dead += 1;
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
			}*/
		}

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Damage" && Time.time > (lastPunchTime + timeBetweenDamages) || other.gameObject.tag == "Wall") {
			lastPunchTime = Time.time;
			Debug.Log ("Gameobject " + gameObject + " has been punched by " + other.gameObject + " at time " + Time.deltaTime);
			enemyPunch = other.gameObject;
			punchLocal = enemyPunch.transform.position.x;
			punchDir = (selfLocation - punchLocal)*SelfDir;
			if (punchDir > 0 && !isDucking) {
				if (!fShield||bShield) {
					knockbackDir = 1;
					hp--;

				}
				if (fShield)
				{
					fShield = false;
				}
			}
			if (punchDir < 0 && !isDucking) {
				if (!bShield||fShield) {
					knockbackDir = -1;
					hp--;

				}
				if (bShield) {
					bShield = false;
				}
			}


		}
		if (other.gameObject.tag == "Melee") {
			hasSwing = true;
		}
		if (other.gameObject.tag == "ShieldF") {
			fShield= true;
		}
		if (other.gameObject.tag == "ShieldB") {
			bShield = true;
		}
		/*if (other.gameObject.tag == "Wall") {
			Death ();
		}*/
			

		if (hp <= 0) 
		{
			Death ();
		}
	}
	void OnBecameInvisible ()
	{
		//Instantiate (ScreenExplosion, CameraPoint, this.gameObject.transform.rotation);
		//Debug.Log (ScreenExplosion + "has spawned");
	}
}
