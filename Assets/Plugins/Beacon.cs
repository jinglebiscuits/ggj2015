using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour, ITargetable {

	private float health;

	private bool lightOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float Health {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public bool LightOn {
		get {
			return this.lightOn;
		}
		set {
			lightOn = value;
		}
	}

	public void TakeHit (float damage)
	{
		throw new System.NotImplementedException ();
	}
}
