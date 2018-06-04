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
	public GameObject StartMenu;
	public GameObject PauseMenu;
	public GameObject EveryMenu;
	public GameObject WinnerMenu;
	public bool InGame = false;
	public bool paused = false;
	public string Scene;
	public string startMenu;
	public string pauseGame;
	public bool winnerMenu = false;
	public Scene currentScene;
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
		if (Input.GetButtonDown (pauseGame)) {
			if (!paused) {
				PauseGame ();
			}
			if (paused) {
				UnPauseGame ();
			}
		}
		if (winnerMenu) {
			WinnerMenu.SetActive (true);
		}
		if (!winnerMenu) {
			WinnerMenu.SetActive (false);
		}
	}
	public void QuickPlay ()
	{
		matchtypes [0] = true;
		matchtypes [1] = false;
		StartMenu.SetActive (false);
		Playerno.SetActive (true);
	}
	public void Tournament()
	{
		StartMenu.SetActive (false);
		matchtypes [1] = true;
		matchtypes [0] = false;
		Playerno.SetActive (true);
	}
	public void TwoPlayer ()
	{
		PlayerNos = 2;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		EveryMenu.SetActive (false);
		SceneManager.LoadScene (Scene);
		InGame = true;
	}
	public void ThreePlayer ()
	{
		PlayerNos = 3;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		EveryMenu.SetActive (false);
		SceneManager.LoadScene (Scene);
		InGame = true;
	}
	public void FourPlayer ()
	{
		PlayerNos = 4;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		EveryMenu.SetActive (false);
		SceneManager.LoadScene (Scene);
		InGame = true;

	}
	public void PauseGame()
	{
		if (InGame) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		}
	}
	public void UnPauseGame ()
	{
		
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		
	}
	public void MainMenu ()
	{
		
		SceneManager.LoadScene (startMenu);
		EveryMenu.SetActive (true);
		InGame = false;
		PauseMenu.SetActive (false);
		StartMenu.SetActive (true);
		WinnerMenu.SetActive (false);
		Time.timeScale = 1;

	}
	public void ExitApp ()
	{
		Application.Quit();
	}
	public void Rematch()
	{
		WinnerMenu.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		winnerMenu = false;

	}
	public void Winner()
	{
		winnerMenu = true;
		WinnerMenu.SetActive (true);
	}


}
