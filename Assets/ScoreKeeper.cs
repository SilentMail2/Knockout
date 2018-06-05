using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ScoreKeeper : MonoBehaviour {
	public GameObject[] playerList;
	 
	//public List <playerList> Players;
	public GameObject VariableHolder;
	public MatchVariables Variables;
	public int[] points;
	public int dead;
	public int playerMode;
	public int pointsIncrement = 5;
	public int firstDeathPoints = 5;
	public int deathPoints;


	public bool roundEnd;

	// Use this for initialization
	void Start () {
		VariableHolder = GameObject.FindGameObjectWithTag ("VariableHolder");
		Variables = VariableHolder.GetComponent <MatchVariables> ();

		//MatchVariables Variables = VariableHolder.GetComponents <MatchVariables> ();
		playerList = GameObject.FindGameObjectsWithTag ("Player");
		//point list size = playerlistsize;
		deathPoints = firstDeathPoints;    
		//dead = 0;
		playerMode = Variables.PlayerNos;
		points [0] = Variables.Player1Score;
		points [1] = Variables.Player2Score;
		points [2] = Variables.Player3Score;
		points [3] = Variables.Player4Score;
	}
	void Update ()
	{
		//checkplacement

		if (dead >= playerMode && !roundEnd) {
			EndRound ();
			roundEnd = true;

		}
//		List<player> players = playerList
	}
	public void LogDeath(int playerNum)
	{
		Debug.Log ("Scorekeeper acknowledges player " + playerNum + " has died.");
		dead = dead + 1;
		points [playerNum] = deathPoints;
		if (playerNum == 0) {
			Variables.Player1Score += points [playerNum];
		}
		if (playerNum == 1) {
			Variables.Player2Score += points [playerNum];
		}
		if (playerNum == 2) {
			Variables.Player3Score += points [playerNum];
		}
		if (playerNum == 3) {
			Variables.Player4Score += points [playerNum];
		}
		CheckScore ();
		deathPoints += pointsIncrement;
		Debug.Log ("LogDeath Completed");
		
	}
	public void CheckScore ()
	{
		Debug.Log (Mathf.Max (points[0],points[1],points[2],points[3]));
	}
	public void EndRound()
	{
		//Variables.RoundMenu.SetActive (true);
		if (Variables.MaxRound > Variables.Round) {
			Debug.Log ("ScoreShown");
			Variables.Round++;
			Variables.RoundMenu.SetActive (true);

		}
		if (Variables.MaxRound == Variables.Round) {
			Variables.Winner ();
		}
	}

}
