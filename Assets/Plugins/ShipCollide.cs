using UnityEngine;
using System.Collections;

public class ShipCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.transform.tag == "Player")
		{
			GameObject neil = other.gameObject.transform.parent.gameObject;
			Neil neilScript = neil.GetComponent<Neil>();
			neilScript.neilState = NeilStates.InShip;
			neilScript.neilControlState = NeilControlStates.InShip;
			neil.transform.position = this.transform.position;
		}
	}
}
