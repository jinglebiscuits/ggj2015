using UnityEngine;
using System.Collections;

public class ShipSection : MonoBehaviour {

	public bool isHookedUp = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsHookedUp {
		get {
			return this.isHookedUp;
		}
		set {
			isHookedUp = value;
			if(isHookedUp)
				Destroy(this.gameObject);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("found " + gameObject.name);
        if (other.gameObject.transform.tag == "Player")
        {
            GameDirector.instance.FoundShipPart(gameObject.name);
        }
    }


   
}
