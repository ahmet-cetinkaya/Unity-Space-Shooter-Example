using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;
    public float tileSizeZ;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * -speed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}