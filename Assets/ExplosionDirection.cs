using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDirection : MonoBehaviour {
	public GameObject explosion;
	public bool explosionon;
	public float Time;
	public float Timer;
	public float Counter;
	// Use this for initialization
	void Start () {
		Timer = Time;
	}
	
	// Update is called once per frame
	void Update () {
		if (explosionon) {
			Timer = Timer - Counter;
			if (Timer <= 0) {
				explosion.SetActive (false);
				//explosionon = false;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		
		explosion.SetActive (true);
		explosionon = true;
		Timer = Time;
	}
}
