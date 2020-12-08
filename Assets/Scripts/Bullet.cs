using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage = 1;
	public float speed = 2f;
	public Vector2 direction;
	public GameObject prefab;


	public float livingTime = 3f;
	public Color initialColor = Color.white;
	public Color finalColor;

	private SpriteRenderer _renderer;
	private Rigidbody2D _rigidbody;
	private float _startingTime;

	private bool _returning;

	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
		//  Save initial time
		_startingTime = Time.time;

		// Destroy the bullet after some time
		Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
		// Change bullet's color over time
		float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }

	private void FixedUpdate()
	{
		//  Move object
		Vector2 movement = direction.normalized * speed;
		_rigidbody.velocity = movement;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_returning == false && collision.CompareTag("Player")) {
			// Tell player to get hurt
			collision.SendMessageUpwards("AddDamage", damage);
			GameObject explosion = Instantiate(prefab, this.transform.position, Quaternion.identity) as GameObject;
			Destroy(explosion, 2f);
			Destroy(gameObject);
			/* Destroy(explosion, 0.6666667f); */
		}

		if (_returning == true && collision.CompareTag("Enemy")) {
			collision.SendMessageUpwards("AddDamage");
			Destroy(gameObject);
		}
	}

	public void AddDamage()
	{
		_returning = true;
		direction = direction * -1f;
	}

	
}


