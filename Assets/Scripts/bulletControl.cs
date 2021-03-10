using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    private Rigidbody fizik;
    public float bulletSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * bulletSpeed;
    }
}