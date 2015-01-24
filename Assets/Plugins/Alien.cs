using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

    public enum enAlienBehaviors
    { 
        Attack,
        RunAway
    }

    public enAlienBehaviors Behavior = enAlienBehaviors.RunAway;

    private Neil neil = null;
    private Ship ship = null;
    private float fltLightSafeDistance = 5.0f;
    private float fltHealth = 100.0f;
    private float fltSunburn = 0.0f;


    private GameObject closestBeacon = null;

	/// <summary>
	/// 
	/// </summary>
	void Start () {
        Behavior = enAlienBehaviors.RunAway;
        neil = GameDirector.instance.neil;
        ship = GameDirector.instance.ship;
	}
	
	/// <summary>
	/// 
	/// </summary>
	void Update () {
	
	}

    /// <summary>
    /// 
    /// </summary>
    private void Behave()
    {
        if (Behavior == enAlienBehaviors.Attack)
        {
            FindClosestBeacon();
            MoveTowardBeacon();
        }
        else if (Behavior == enAlienBehaviors.RunAway)
        {
            FindClosestBeacon();
            RunAwayFromBeacon();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void FindClosestBeacon()
    {
        float fltBestDistance = float.MaxValue;
        float fltThisDistance = 0.0f;
        foreach (GameObject thisBeacon in GameDirector.instance.beacons)
        {
            fltThisDistance = (thisBeacon.transform.position - gameObject.transform.position).magnitude;
            if (fltThisDistance < fltBestDistance)
            {
                fltBestDistance = fltThisDistance;
                closestBeacon = thisBeacon;
            }
        }
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveTowardBeacon()
    { 
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void RunAwayFromBeacon()
    { 
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetDamageFromLight()
    { 
        //iterate through each light source
        float fltThisDistance = 0.0f;
        foreach (GameObject thisBeacon in GameDirector.instance.beacons)
        {
            fltThisDistance = (thisBeacon.transform.position - gameObject.transform.position).magnitude;

        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="beacon"></param>
    /// <returns></returns>
    private float GetLightIntensity(GameObject beacon)
    {
        return 0.5f;
    }

}
