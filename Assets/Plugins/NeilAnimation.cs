using UnityEngine;
using System.Collections;

public class NeilAnimation : MonoBehaviour {

	public Animator animator;
	private float speed = 0;

	// Use this for initialization
	void Start () {
		animator = this.transform.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Vertical");
		animator.SetFloat("Speed", move);
	}

	public float Speed {
		get {
			return this.speed;
		}
		set {
			speed = value;
			animator.SetFloat("Speed", value);
		}
	}
}
