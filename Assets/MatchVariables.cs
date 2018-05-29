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
	public string Scene;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		/*DontDestroyOnLoad (Playerno);
		DontDestroyOnLoad (PlayerSkins);
		DontDestroyOnLoad (StartMenu);*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void QuickPlay ()
	{
		matchtypes [0] = true;
		StartMenu.SetActive (false);
		Playerno.SetActive (true);
	}
	public void Tournament()
	{
		StartMenu.SetActive (false);
		matchtypes [1] = true;
		Playerno.SetActive (true);
	}
	public void TwoPlayer ()
	{
		PlayerNos = 2;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		SceneManager.LoadScene (Scene);
	}
	public void ThreePlayer ()
	{
		PlayerNos = 3;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		SceneManager.LoadScene (Scene);
	}
	public void FourPlayer ()
	{
		PlayerNos = 4;
		Debug.Log (PlayerNos + " Players");
		Playerno.SetActive (false);
		SceneManager.LoadScene (Scene);
	}
}
