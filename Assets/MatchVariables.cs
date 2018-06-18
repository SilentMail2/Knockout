using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchVariables : MonoBehaviour {
	public int PlayerNos;
	public int noPlayer;
	public bool[] matchtypes;
	public GameObject Playerno;
	public GameObject PlayerSkins;
	public GameObject[] PlayerSelect;
	public GameObject StartMenu;
	public GameObject PauseMenu;
	public GameObject EveryMenu;
	public GameObject WinnerMenu;
	public GameObject LevelMenu;
	public GameObject mouse1;
	public GameObject mouse2;
	public GameObject mouse3;
	public GameObject mouse4;


	public string player1Skin;
	public string player2Skin;
	public string player3Skin;
	public string player4Skin;

	public bool PlayerSkinsActive;
	public bool[] players;

	public GameObject[] playerScreen;

	public bool InGame = false;
	public bool paused = false;
	public string Scene;
	public string startMenu;
	public string pauseGame;
	public bool winnerMenu = false;
	public Scene currentScene;
	public Scene[] newScene;
	public int sceneNumber;
	public int MaxRound;
	public int Round;
	public GameObject RoundMenu;

	public float TimeVariable = 1;

	public int Player1Score;
	public int Player2Score;
	public int Player3Score;
	public int Player4Score;

	public Text Player1ScTx;
	public Text Player2ScTx;
	public Text Player3ScTx;
	public Text Player4ScTx;

	public Text WinnerText;

	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		currentScene = SceneManager.GetActiveScene();
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
		/*DontDestroyOnLoad (Playerno);
		DontDestroyOnLoad (PlayerSkins);
		DontDestroyOnLoad (StartMenu);*/
	}
	
	// Update is called once per frame
	void Update () {
		if (!InGame || paused) {
			if (PlayerNos == 2) {
				mouse1.SetActive (true);
				mouse2.SetActive (true);
				mouse3.SetActive (false);
				mouse4.SetActive (false);
			}
			if (PlayerNos == 3) {
				mouse1.SetActive (true);
				mouse2.SetActive (true);
				mouse3.SetActive (true);
				mouse4.SetActive (false);
			}
			if (PlayerNos == 4) {
				mouse1.SetActive (true);
				mouse2.SetActive (true);
				mouse3.SetActive (true);
				mouse4.SetActive (true);
			}
		}
		if (InGame && !paused) {
			mouse1.SetActive (false);
			mouse2.SetActive (false);
			mouse3.SetActive (false);
			mouse4.SetActive (false);
		}
		if (PlayerNos == 0) {
			mouse1.SetActive (true);
			mouse2.SetActive (false);
			mouse3.SetActive (false);
			mouse4.SetActive (false);
		}
			
		if (Input.GetButtonDown (pauseGame)) {
			Debug.Log ("Escaped Pressed");
			if (!paused) {
				PauseGame ();
				Debug.Log ("GamePaused");
			}
			/*if (paused) {
				UnPauseGame ();
				Debug.Log ("GameUnPaused");
			}*/
		}
		if (winnerMenu) {
			WinnerMenu.SetActive (true);
		}
		if (!winnerMenu) {
			WinnerMenu.SetActive (false);
		}
		Player1ScTx.text = Player1Score.ToString();
		Player2ScTx.text = Player2Score.ToString();
		Player3ScTx.text = Player3Score.ToString();
		Player4ScTx.text = Player4Score.ToString();

		if (Input.GetButtonDown ("MousePress1") || Input.GetButtonDown ("MousePress2") || Input.GetButtonDown ("MousePress3") || Input.GetButtonDown ("MousePress4")) {
			if (PlayerSkinsActive == true) {
				AddPlayer ();
			}
		}
		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2") || Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire4")) {
			if (PlayerSkinsActive == true) {
				TakePlayer ();
			}
		}

	}
	public void QuickPlay ()
	{
		matchtypes [0] = true;
		matchtypes [1] = false;
		StartMenu.SetActive (false);
		PlayerSkinsActive = true;
		PlayerSkins.SetActive (true);
		MaxRound = 0;
	}
	public void Tournament()
	{
		StartMenu.SetActive (false);
		matchtypes [1] = true;
		matchtypes [0] = false;
		PlayerSkinsActive = true;
		PlayerSkins.SetActive (true);
		MaxRound = 3;
	}


	public void AddPlayer ()
	{

		if (Input.GetButtonDown ("MousePress1") && !players [0]) 
		{
			//player1 down
			PlayerNos++;
			players [0] = true;
			PlayerSelect [0].SetActive (true);
		}
		if (Input.GetButtonDown ("MousePress2") && !players [1]) 
		{
			//player2 down
			PlayerNos++;
			players [1] = true;
			PlayerSelect [1].SetActive (true);
		}
		if (Input.GetButtonDown ("MousePress3") && !players [2]) 
		{
			//player3 down
			PlayerNos++;
			players [2] = true;
			PlayerSelect [2].SetActive (true);
		}
		if (Input.GetButtonDown ("MousePress4") && !players [3]) 
		{
			//player4 down
			PlayerNos++;
			players [3] = true;
			PlayerSelect [3].SetActive (true);
		}
	}
	public void TakePlayer ()
	{
		if (Input.GetButtonDown ("Fire1") && players [0]) 
		{
			PlayerNos--;
			players [0] = false;
			PlayerSelect [0].SetActive (false);
		}
		if (Input.GetButtonDown ("Fire2") && players [1]) 
		{
			PlayerNos--;
			players [1] = false;
			PlayerSelect [0].SetActive (false);
		}
		if (Input.GetButtonDown ("Fire3") && players [2]) 
		{
			PlayerNos--;
			players [2] = false;
			PlayerSelect [1].SetActive (false);
		}
		if (Input.GetButtonDown ("Fire4") && players [3]) 
		{
			PlayerNos--;
			players [3] = false;
			PlayerSelect [3].SetActive (false);
		}
	}
	public void FinishScreen ()
	{
		if (PlayerNos >= 2) {
			PlayerSkins.SetActive (false);
			LevelMenu.SetActive (true);
			PlayerSkinsActive = false;
		}
	}

	public void TwoPlayer ()
	{
		PlayerNos = 2;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);

		//SceneManager.LoadScene (Scene);
		LevelMenu.SetActive (true);
		InGame = true;
	}
	public void ThreePlayer ()
	{
		PlayerNos = 3;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);

		//SceneManager.LoadScene (Scene);
		LevelMenu.SetActive (true);
		InGame = true;
	}
	public void FourPlayer ()
	{
		PlayerNos = 4;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);

		LevelMenu.SetActive (true);
		//SceneManager.LoadScene (Scene);
		InGame = true;

	}

	public void ChangeLevel ()
	{
		SceneManager.LoadScene ("Scene"+sceneNumber.ToString());
		EveryMenu.SetActive (false);
		LevelMenu.SetActive (false);
		InGame = true;
		paused = false;
	}

	public void PauseGame()
	{
		if (InGame) {
			PauseMenu.SetActive (true);
			TimeVariable = 0;
			paused = true;
		}
	}
	public void UnPauseGame ()
	{
		
		PauseMenu.SetActive (false);
		TimeVariable = 1;
		paused = false;
		
	}
	public void MainMenu ()
	{
		RoundMenu.SetActive (false);

		EveryMenu.SetActive (true);
		InGame = false;
		PauseMenu.SetActive (false);
		StartMenu.SetActive (true);
		WinnerMenu.SetActive (false);
		winnerMenu = false;
		if (!winnerMenu) {
			SceneManager.LoadScene (startMenu);
		}
		Time.timeScale = 1;
		Player1Score = 0;
		Player2Score = 0;
		Player3Score = 0;
		Player4Score = 0;
		TimeVariable = 1;
		PlayerNos = 0;
		players [0] = false;
		players [1] = false;
		players [2] = false;
		players [3] = false;
		PlayerSelect [0].SetActive (false);
		PlayerSelect [1].SetActive (false);
		PlayerSelect [2].SetActive (false);
		PlayerSelect [3].SetActive (false);

	}
	public void ExitApp ()
	{
		Application.Quit();
	}
	public void Rematch()
	{
		
		WinnerMenu.SetActive (false);
		RoundMenu.SetActive (false);
		winnerMenu = false;
		if (!winnerMenu) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
		if (MaxRound == Round) {
			Player1Score = 0;
			Player2Score = 0;
			Player3Score = 0;
			Player4Score = 0;
		}
		TimeVariable = 1;
	}
	public void Winner()
	{
		if (Player1Score > Player2Score && Player1Score > Player3Score && Player1Score > Player4Score) {
			WinnerText.text = "Player 1 Wins!";
		}
		if (Player2Score > Player1Score && Player2Score > Player3Score && Player2Score > Player4Score) {
			WinnerText.text = "Player 2 Wins!";
		}
		if (Player3Score > Player2Score && Player3Score > Player1Score && Player3Score > Player4Score) {
			WinnerText.text = "Player 3 Wins!";
		}
		if (Player4Score > Player2Score && Player4Score > Player3Score && Player4Score>Player1Score) {
			WinnerText.text = "Player 4 Wins!";
		}
		winnerMenu = true;
		WinnerMenu.SetActive (true);
		TimeVariable = 0;


	}

	public void ChangeSkinPlayer1(string newname)
	{
		player1Skin = newname;
	}
	public void ChangeSkinPlayer2(string newname, Collider2D other)
	{
		
	}
	public void ChangeSkinPlayer3(string newname, Collider2D other)
	{
		player3Skin = other.gameObject.name;
		newname = player3Skin;
	}
	public void ChangeSkinPlayer4(string newname, Collider2D other)
	{
		player4Skin = other.gameObject.name;
		newname = player4Skin;
	}


	public void EndRound()
	{
		RoundMenu.SetActive (true);
		TimeVariable = 0;
	}
	


}
