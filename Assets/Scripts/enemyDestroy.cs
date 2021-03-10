using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameControl gameControl;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameControl");
        if (gameControllerObject != null) gameControl = gameControllerObject.GetComponent<GameControl>();
        else Debug.Log("Cannot Find GameControl Script");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (explosion != null) Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameControl.GameOver();
        }
        else gameControl.ScoreUp(scoreValue); // dodge enemy hit

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}