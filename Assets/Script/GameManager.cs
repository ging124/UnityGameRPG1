using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private GameObject player;

    static public GameManager instance;

    void Awake()
    {
        GameManager.instance = this;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player == null)
        {
            MenuIngame.instance.GameOverMenuOn();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
