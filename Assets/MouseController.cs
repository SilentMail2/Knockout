using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseController : MonoBehaviour {
	public string verticalControl;
	public string horizontalControl;
	public string clickButton;

	public float horizontalMovement;
	public float verticalMovement;
	public float speed;
	public Rigidbody2D rb2d;
	public Vector3 movement;
	public MatchVariables buttonController;
	public bool buttonSelected;
	public Button button;
	public string selectedTag;

	public SceneStore sceneStore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMovement = Input.GetAxis (horizontalControl);
		verticalMovement = Input.GetAxis (verticalControl);
		movement = new Vector3 (horizontalMovement*speed*Time.unscaledDeltaTime, verticalMovement*speed*Time.unscaledDeltaTime, 0);

		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x+movement.x,this.gameObject.transform.position.y+movement.y,this.gameObject.transform.position.z+movement.z);

		if (Input.GetButtonDown (clickButton)) {
			PressButton ();
		}
		
	}
	void PressButton ()
	{
		if (buttonSelected) {
			if (selectedTag == "Tourtament") 
			{
				buttonController.Tournament ();
			}
			if (selectedTag == "Quickplay") 
			{
				buttonController.QuickPlay ();
			}
			if (selectedTag == "Exit") 
			{
				buttonController.ExitApp ();
			}
			if (selectedTag == "2") 
			{
				buttonController.TwoPlayer();
			}
			if (selectedTag == "3") 
			{
				buttonController.ThreePlayer();
			}
			if (selectedTag == "4") 
			{
				buttonController.FourPlayer();
			}
			if (selectedTag == "Continue") 
			{
				buttonController.UnPauseGame();
			}
			if (selectedTag == "MainMenu") 
			{
				buttonController.MainMenu();
			}
			if (selectedTag == "Setting") 
			{

			}
			if (selectedTag == "Scene") {
				buttonController.ChangeLevel ();
			}

		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Tourtament" || other.tag == "Quickplay" || other.tag == "Exit" || other.tag == "2" || other.tag == "3" || other.tag == "4"|| other.tag == "MainMenu"|| other.tag == "Setting"|| other.tag == "Continue"||other.tag == "Scene") {
			buttonSelected = true;
		}
		selectedTag = other.tag;
		if (other.tag == "Scene") {
			sceneStore = other.gameObject.GetComponent<SceneStore> ();
			buttonController.sceneNumber = sceneStore.sceneNumber;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Tourtament" || other.tag == "Quickplay" || other.tag == "Exit" || other.tag == "2" || other.tag == "3" || other.tag == "4"|| other.tag == "MainMenu"|| other.tag == "Setting"|| other.tag == "Continue"||other.tag == "Scene")
		{
			buttonSelected = false;
		}
	}
}
