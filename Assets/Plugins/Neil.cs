using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Neil : MonoBehaviour, ITargetable {

	private float health;
	private float movementSpeed;
	private string state;
	private List<ICarryable> inventory = new List<ICarryable>();

	public delegate void MyEventHandler();
	public event MyEventHandler radarEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region Accessor Methods
	public float Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}

	public float MovementSpeed {
		get {
			return this.movementSpeed;
		}
		set {
			movementSpeed = value;
		}
	}

	public string State {
		get {
			return this.state;
		}
		set {
			state = value;
		}
	}

	public List<ICarryable> Inventory {
		get {
			return this.inventory;
		}
		set {
			inventory = value;
		}
	}
	#endregion

	public void TakeHit(float damage)
	{
		//subtract damage from Neil's hp
	}

	public void PulseRadar()
	{
		if(radarEvent != null)
		{
			radarEvent();
		}
	}
}
