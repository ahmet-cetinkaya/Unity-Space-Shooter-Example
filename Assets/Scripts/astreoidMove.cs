using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astreoidMove : MonoBehaviour
{
    private Rigidbody fizik;
    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * -speed;
    }
}