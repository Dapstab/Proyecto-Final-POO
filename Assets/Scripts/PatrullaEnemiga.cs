using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaEnemiga : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTarget() {

        //If first time create target in the left
        if (_target == null) {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
        //If we are in the left change target to the right
        if (_target.transform.position.x == minX) {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        } else if (_target.transform.position.x == maxX) {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator PatrolToTarget() { // Es una función que nos permite meter tiempos de espera y otras acciones.
        //Courutine to move the enemy:
        while(Vector2.Distance(transform.position, _target.transform.position) > 0.05f) {
            Vector2 direction = _target.transform.position - transform.position; // Para saber en que dirección se va a mover el enemigo
            float xDirection = direction.x; // Solo cojo la componente en x.

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null; // Funciona como una recursión se llama a si misma hasta que no se cumpla el while.
        }

        //At this point I reached the target so let´s set the position to the target´s one.
        //Debug.Log("Target Reached");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);

        // And let´s wait for a moment
        //Debug.Log("Waiting for " + waitingTime + " seconds");
        yield return new WaitForSeconds(waitingTime);

        // Once waited let´s restore the patrol bahavior
        //Debug.Log("Waited enought, let´s update the target and move again");
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }
}
