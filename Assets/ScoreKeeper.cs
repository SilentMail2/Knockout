﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour {
	public GameObject[] playerList;
	public GameObject VariableHolder;
	public MatchVariables Variables;
	public int[] points;
	public int dead;
	public int playerMode;
	public int pointsIncrement = 5;
	public int firstDeathPoints = 5;
	public int deathPoints;

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

	}
	void Update ()
	{
		if (dead >= playerMode) {
			Variables.Winner ();
		}
	}
	public void LogDeath(int playerNum)
	{
		Debug.Log ("Scorekeeper acknowledges player " + playerNum + " has died.");
		dead = dead + 1;
		points [playerNum] = deathPoints;
		deathPoints += pointsIncrement;
		Debug.Log ("LogDeath Completed");
	}
}
