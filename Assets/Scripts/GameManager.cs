using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro = 1,
    Playing,
    Dead
};

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;
    public GameState State;
    public float PlayStartTime;
    public int Lives;

    [Header("References")]
    [SerializeField] private GameObject IntroUI;
    [SerializeField] private GameObject DeadUI;
    [SerializeField] private GameObject EnemySpawner;
    [SerializeField] private GameObject FoodSpawner;
    [SerializeField] private GameObject GoldenSpawner;
    [SerializeField] private Player PlayerScript;
    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        IntroUI.SetActive(true);
        Lives = 3;
        State = GameState.Intro;
    }

    int CalculateScore()
    {
        return Mathf.FloorToInt(Time.time - PlayStartTime);
    }

    void SaveHighScore()
    {
        int score = CalculateScore();
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    int GetHighScore() {
        return PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(State == GameState.Playing)
        {
            scoreText.text = "Score : " + CalculateScore();
        }else if(State == GameState.Dead)
        {
            scoreText.text = "High Score : " + GetHighScore();
        }

        if(State == GameState.Intro && Input.GetKeyDown(KeyCode.Space)){
            State = GameState.Playing;
            Lives = 3;

            IntroUI.SetActive(false);
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldenSpawner.SetActive(true);
            PlayStartTime = Time.time;
        }
        else if(State == GameState.Playing && Lives == 0)
        {
            State = GameState.Dead;
            PlayerScript.KillPlayer();
            SaveHighScore();

            DeadUI.SetActive(true);
            EnemySpawner.SetActive(false);
            FoodSpawner.SetActive(false);
            GoldenSpawner.SetActive(false);
        }
        else if (State == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            State = GameState.Intro;
            SceneManager.LoadScene("main");
            //Debug.Log("Re Run");
        }
    }
}
