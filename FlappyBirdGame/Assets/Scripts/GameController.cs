
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panelStartGame;
    public GameObject panelEndGame;
    public Text endScore;
    public Button btnRestart;
    public bool isFirstStart = true;
    bool isEndGame;
    int gameScore;
    public Text txtScore;

    public Sprite btnClick;
    public Sprite btnHover;
    public Sprite btnIdle;

    // Start is called before the first frame update
    void Start()
    {
        isFirstStart = true;
        Time.timeScale = 0;     // timeline is stopped
        isEndGame = false;
        gameScore = 0;
        panelEndGame.SetActive(false);
        panelStartGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButton(0) && isFirstStart)
            {
                StartGame();
            }
        } else
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
            }
        }
        panelStartGame.SetActive(false);
    }

    public void ButtonRestartClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    public void ButtonRestartHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    public void ButtonRestartIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(0);      // scene 0
    }
    public void Restart()
    {
        StartGame();
    }

    public void GetScore()
    {
        gameScore++;
        txtScore.text = "Score: " + gameScore.ToString();
    }

    public void EndGame()
    {
        isFirstStart = false;
        isEndGame = true;
        Time.timeScale = 0;
        panelEndGame.SetActive(true);
        endScore.text = "Your Score\n" + gameScore.ToString();
    }
}
