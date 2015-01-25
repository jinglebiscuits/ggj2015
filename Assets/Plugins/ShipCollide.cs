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
		print (other.gameObject.transform.name);
	}
}
