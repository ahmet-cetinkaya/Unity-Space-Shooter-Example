using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject[] Enemies;
    public Vector3 RandomPos;
    public float startTime;
    public float waveTime;
    public int countOfEnemies;
    private int score;
    public Text text;
    private bool GameOverControl = false;
    private bool RestartControl = false;
    public Text GameOverText;
    public Text pressRText;
    private Random random = new Random();

    private void Start()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(create());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && RestartControl)
        {
            SceneManager.LoadScene("level1");
        }
    }

    private IEnumerator create()
    {
        yield return new WaitForSeconds(startTime); // await first 2 seconds
        while (!GameOverControl)
        {
            for (int i = 0; i < countOfEnemies; i++)
            {
                GameObject Astreoid = Enemies[Random.Range(0, Enemies.Length)];
                Vector3 vec = new Vector3(Random.Range(-RandomPos.x, RandomPos.x), 0, RandomPos.z); // create random position
                Instantiate(Astreoid, vec, Quaternion.identity); // create astreoid random position
                yield return new WaitForSeconds(0.7f); // return setTimeOut to for
            }
            yield return new WaitForSeconds(waveTime); // return setTimeOut to while
        }
    }

    public void ScoreUp(int point)
    {
        score += point;
        text.text = "Score = " + score;
    }

    public void GameOver()
    {
        GameOverControl = true;
        RestartControl = true;
        GameOverText.enabled = true;
        pressRText.enabled = true;
    }
}