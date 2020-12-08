using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceFireBall : MonoBehaviour
{
    public Vector2 force;
	public ForceMode2D forceMode;
    public Transform point;

	private Rigidbody2D _rigidbody;

    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(point.position.y >= 3) {
            point.position = new Vector2(point.position.x, 3);
            force.y = -10;
        } else if (point.position.y <= -1.45) {
            force.y = 20;
        }

        if (point.position.y <= -2.25) {
            point.position = new Vector2(point.position.x, -2);
        }
        
        _rigidbody.AddForce(force, forceMode);
    }
}
