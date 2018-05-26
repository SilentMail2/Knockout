using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour {
	public GameObject[] playerList;
	public float[] points;
	public int dead;
	// Use this for initialization
	void Start () {
		playerList = GameObject.FindGameObjectsWithTag ("Player");
		//point list size = playerlistsize;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
