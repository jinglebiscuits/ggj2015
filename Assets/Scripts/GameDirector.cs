using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {

    public static GameDirector instance = null;

    public GameObject Neil = null;
   

    void Awake()
    {
        instance = this;
    }

}
