using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour, ITargetable {

    public Light light;
    public float Health {get; set;}
	private Ship ship;

	private bool lightOn = true;

	// Use this for initialization
	void Start () {
        InitBeacon();
		ship = GameObject.Find("Ship").GetComponent<Ship>();
		ship.energyUsePerSecond += 5;
	}
    public void InitBeacon()
    {
        Health = 100f;
    }
	
	// Update is called once per frame
	void Update () {
		if(LightOn)
		{
			float fltIntsty = Health / 100.0f;
			light.intensity = fltIntsty;
		}
		else
		{
			light.intensity = 0;
		}
	}

	public bool LightOn {
		get {
			return this.lightOn;
		}
		set {
			lightOn = value;
			if(lightOn)
				ship.energyUsePerSecond += 5;
			else
				ship.energyUsePerSecond -= 5;
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
