using UnityEngine;
using System.Collections;

public class NeilPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			float distanceToGround = hit.distance;
			this.transform.parent.position = new Vector3(this.transform.position.x, hit.point.y + 1.5f, this.transform.position.z);
		}
	}
}
