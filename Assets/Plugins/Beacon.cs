using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour, ITargetable {

    public Light light;
    public float Health {get; set;}

	private bool lightOn;

	// Use this for initialization
	void Start () {
        InitBeacon();
	}
    public void InitBeacon()
    {
        Health = 100f;
    }
	
	// Update is called once per frame
	void Update () {
        float fltIntsty = Health / 100.0f;
        light.intensity = fltIntsty;
	}

	public bool LightOn {
		get {
			return this.lightOn;
		}
		set {
			lightOn = value;
		}
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
	public void TakeHit (float damage)
	{
		this.Health -= damage;
	}
}
