using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameControl gameControl;

    public int scoreValue;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameControl");

        gameControl = gameControllerObject.GetComponent<GameControl>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("mapLimit") || col.CompareTag("Enemy")) return;

        if (explosion != null) Instantiate(explosion, transform.position, transform.rotation);

        if (col.CompareTag("Player"))
        {
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
            gameControl.GameOver();
        }
        else gameControl.ScoreUp(scoreValue);

        Destroy(col.gameObject); // bullet
        Destroy(gameObject); // astreoid
    }
}