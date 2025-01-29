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
    public int Lives;

    [Header("References")]
    [SerializeField] private GameObject IntroUI;
    [SerializeField] private GameObject EnemySpawner;
    [SerializeField] private GameObject FoodSpawner;
    [SerializeField] private GameObject GoldenSpawner;
    [SerializeField] private Player PlayerScript;

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

    // Update is called once per frame
    void Update()
    {
        if(State == GameState.Intro && Input.GetKeyDown(KeyCode.Space)){
            State = GameState.Playing;
            Lives = 3;

            IntroUI.SetActive(false);
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldenSpawner.SetActive(true);
        }
        else if(State == GameState.Playing && Lives == 0)
        {
            State = GameState.Dead;
            PlayerScript.KillPlayer();

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
