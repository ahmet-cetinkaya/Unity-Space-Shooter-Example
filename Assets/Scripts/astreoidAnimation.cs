using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astreoidAnimation : MonoBehaviour
{
    private Rigidbody fizik;
    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.angularVelocity = Random.insideUnitSphere * speed; // açısal hızı // rotasyonda değişiklik
    }
}