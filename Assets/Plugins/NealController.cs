using UnityEngine;
using System.Collections;

public class NealController : MonoBehaviour {

    public GameObject Neil = null;
    private string strHorizontalAxis = "Horizontal";
    private string strVerticalAxis = "Vertical";
    private string strFireButton;
    private float fltRotate = 0;
    private float fltMove = 0;
    private float fltNealDirection = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fltRotate = Input.GetAxis(strHorizontalAxis);
        fltMove = Input.GetAxis(strVerticalAxis);

        fltNealDirection += fltRotate * Time.deltaTime;
        Neil.transform.rotation = Quaternion.EulerAngles(0.0f, fltNealDirection, 0.0f);
        Neil.transform.position += Neil.transform.forward * fltMove * Time.deltaTime;
	}
}
