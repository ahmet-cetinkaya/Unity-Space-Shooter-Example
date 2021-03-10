using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float speed;
    public float[] range;
    private Rigidbody physics;
    private float rangeValue;
    private enemyMovement enemyMovement;

    private void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward * -speed;
        rangeValue = Random.Range(range[0], range[1]);

        enemyMovement = GetComponent<enemyMovement>();
    }

    private void FixedUpdate()
    {
        if (transform.position.z < rangeValue)
        {
            physics.velocity = Vector3.zero;
            enemyMovement.enabled = true;
        }
    }
}