using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSelect : MonoBehaviour {
	public Vector3 OriginalPosition;
	public Vector3 NewPosition;
	public RectTransform canvas;
	public RectTransform button;
	public bool isSelected;
	public float speed;
	public float height;
	// Use this for initialization
	void Start () {
		OriginalPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed, speed, speed);
		if (isSelected) {
			this.gameObject.transform.position = NewPosition;
		}
		if (!isSelected) {
			this.gameObject.transform.position = OriginalPosition;
		}
	}
	void OnMouseOver ()
	{
		isSelected = true;
	}

	void OnMouseExit ()
	{
		isSelected = false;
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Mouse") {
			isSelected = true;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Mouse") {
			isSelected = false;
		}
	}
}
