using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject stageClearText;

    void Awake()
    {
        Instance = this;
    }

    public void OnStageClear()
    {
        stageClearText.SetActive(true);
        // 게임 정지 등 추가 연출 가능
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
