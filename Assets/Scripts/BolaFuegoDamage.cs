using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuegoDamage : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public int damage = 1;
    void Start()
    {
        
    }

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.SendMessageUpwards("AddDamage", damage);
        }
    }
}
