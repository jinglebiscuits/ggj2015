using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour {

    public static GameDirector instance = null;

    public Neil neil = null;
    public Ship ship = null;
    public List<GameObject> beacons = null;
   

    void Awake()
    {
        instance = this;
    }

}
