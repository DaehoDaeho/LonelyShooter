using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject stageClearText;
    public GameObject gameOverText;

    void Awake()
    {
        Instance = this;
    }

    public void OnStageClear()
    {
        stageClearText.SetActive(true);
        // 게임 정지 등 추가 연출 가능
    }

    public void OnGameOver()
    {
        gameOverText.SetActive(true);
        // 필요하면 Time.timeScale = 0; // 일시정지 등
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
