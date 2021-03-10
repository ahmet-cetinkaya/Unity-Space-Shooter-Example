using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteVFX : MonoBehaviour
{
    public float time;

    private void Start()
    {
        Destroy(gameObject, time);
    }
}