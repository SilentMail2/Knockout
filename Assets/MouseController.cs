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


	public float minXposition;

	public string selectedSkin;

	public float maxXposition;


	public float maxYposition;

	public float minYposition;

	public Vector3 pos;

	public SceneStore sceneStore;

	public RectTransform myRecTransform;
	public Vector2 guiSizehalf;
	public Vector2 screenSize;
	public Vector2 targetRes;//Set to target resolution
	public Vector2 screenReciprocal;


	// Use this for initialization
	void Start () {
		myRecTransform = (RectTransform)transform;
		DefineScreenValues ();

	}
	
	// Update is called once per frame
	void Update () {


		horizontalMovement = Input.GetAxis (horizontalControl);
		verticalMovement = Input.GetAxis (verticalControl);
		//movement = new Vector3 (horizontalControl*speed*Time.unscaledDeltaTime, verticalMovement*speed*Time.unscaledDeltaTime, 0);

		transform.Translate (Input.GetAxis (horizontalControl) * speed * Time.deltaTime, 0, 0);
		transform.Translate (0,Input.GetAxis (verticalControl) * speed * Time.deltaTime,  0);
		//this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x+movement.x,this.gameObject.transform.position.y+movement.y,this.gameObject.transform.position.z+movement.z);

		if (Input.GetButtonDown (clickButton)) {
			PressButton ();
		}
		
	}

	void DefineScreenValues()
	{
		screenSize = new Vector2 (Screen.width, Screen.height);
		screenReciprocal = new Vector2 (1 / screenSize.x, 1 / screenSize.y);
		targetRes = new Vector2 (1920, 1080);
		guiSizehalf = new Vector2 (myRecTransform.rect.width * 0.5f, myRecTransform.rect.height * 0.5f);
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
			if (selectedTag == "SkinName1") {
				buttonController.ChangeSkinPlayer1 (selectedSkin);
			}
			if (selectedTag == "FinishScene") {
				buttonController.FinishScreen ();
			}
			if (selectedTag == "NextRound") {
				buttonController.Rematch ();
			}
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Tourtament" || other.tag == "Quickplay" || other.tag == "Exit" || other.tag == "2" || other.tag == "3" || other.tag == "4"|| other.tag == "MainMenu"|| other.tag == "Setting"|| other.tag == "Continue"||other.tag == "Scene"||other.tag == "SkinName1"||other.tag == "SkinName2"||other.tag == "SkinName3"||other.tag == "SkinName4"||other.tag == "FinishScene"|| other.tag == "NextRound") {
			buttonSelected = true;
			selectedSkin = other.gameObject.name;
		}
		selectedTag = other.tag;
		if (other.tag == "Scene") {
			sceneStore = other.gameObject.GetComponent<SceneStore> ();
			buttonController.sceneNumber = sceneStore.sceneNumber;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Tourtament" || other.tag == "Quickplay" || other.tag == "Exit" || other.tag == "2" || other.tag == "3" || other.tag == "4"|| other.tag == "MainMenu"|| other.tag == "Setting"|| other.tag == "Continue"||other.tag == "Scene"||other.tag == "SkinName1"||other.tag == "SkinName2"||other.tag == "SkinName3"||other.tag == "SkinName4"||other.tag == "FinishScene"|| other.tag == "NextRound")
		{
			buttonSelected = false;
		}
	}
}
