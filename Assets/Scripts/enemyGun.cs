using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float timeout;
    public float fireRate;

    private AudioSource audioSource;

    private void Start()

    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", timeout, fireRate);
    }

    private void Fire()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        audioSource.Play();
    }
}