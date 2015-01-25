using UnityEngine;
using System.Collections;

public class ConnectSection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		print (other.transform.name);
		if(other.transform.tag == "Selection")
		{
			other.transform.GetComponent<ShipSection>().IsHookedUp = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		print (other.transform.name + "stay");
	}
}
