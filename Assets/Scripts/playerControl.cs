using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Rigidbody fizik;
    private float horizontal = 0;
    private float vertical = 0;
    private Vector3 vec;
    public float speed;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float slope;
    private float attackTime;
    public float attackTimeout;
    public GameObject bullet;
    public Transform Gun;
    private AudioSource audio;

    // Start is called before the first frame update
    private void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > attackTime)
        {
            attackTime = Time.time + attackTimeout;
            // Instantiate (object, position, rotation) // game object oluşturma
            Instantiate(bullet, Gun.position, Quaternion.identity); // Quaternion.identity = (0.0, 0.0, 0.0, 1.0)
            audio.Play();
        }
    }

    // Update is called once per frame
    private void FixedUpdate() // fizik olayları için FixedUpdate
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);
        fizik.velocity = vec * speed;
        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)
        );
        fizik.rotation = Quaternion.Euler(fizik.velocity.z * slope, 0, -fizik.velocity.x * slope);
    }
}