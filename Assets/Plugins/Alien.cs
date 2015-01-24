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

    private GameObject closestBeacon = null;

	/// <summary>
	/// 
	/// </summary>
	void Start () {
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

}
