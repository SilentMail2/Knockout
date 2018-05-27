using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	public GameObject[] pickUps;
	public GameObject pickUp;
	// Use this for initialization
	void Start () {
		pickUp = pickUps [Random.Range (0, pickUps.Length)];
		Instantiate (pickUp, this.gameObject.transform.position, this.gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
