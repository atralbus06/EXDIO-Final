using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //프리팹은 instance로 불러올 수 없음 할거면 소환하고 하이어라이키에 있는 오브젝트를 들고와야함
    public ObjectManager objectManager;
    public Player player;

    public string[] playerBulletType;
    public string curPlayerBulletType;

    int curScore;
    int finalScore;
    public float time;

    public Text scoreText;
    public Text timeText;
    public GameObject gameoverUI;
    public Text finalScoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        curPlayerBulletType = "A";
    }

    void Start()
    {
        GameObject p = objectManager.Get(0);
        player = p.GetComponent<Player>();

        curScore = 0;

        gameoverUI.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + time.ToString("F2");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemySemple = objectManager.Get(2);
            enemySemple.transform.position = new Vector2(0, 3);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeBullet();
        }
        
    }

    void ChangeBullet()
    {
        for (int i = 0; i < playerBulletType.Length; i++)
        {
            if (playerBulletType[i] == curPlayerBulletType)
            {
                if (i == playerBulletType.Length - 1)
                    curPlayerBulletType = playerBulletType[0];
                else
                    curPlayerBulletType = playerBulletType[i + 1];

                player.ChangeInterval(curPlayerBulletType);
                break;
            }
        }
    }

    public void Score(int score)
    {
        curScore += score;
        scoreText.text = "score: " + curScore;
    }

    public void GameOver()
    {
        finalScore = curScore + Mathf.FloorToInt(time);
        gameoverUI.SetActive(true);
        finalScoreText.text = "Score: " + finalScore;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void MainMeun()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
