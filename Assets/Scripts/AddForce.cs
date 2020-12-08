using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
	public Vector2 force;
	public ForceMode2D forceMode;
	public Transform point;

	private Rigidbody2D _rigidbody;



	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		
		if (point.position.y >= 20) {
			force.y = 100;
		} else {
			force.y = 210;
		}
		_rigidbody.AddForce(force, forceMode);
	}
}
