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
        // ���� ���� �� �߰� ���� ����
    }

    public void OnGameOver()
    {
        gameOverText.SetActive(true);
        // �ʿ��ϸ� Time.timeScale = 0; // �Ͻ����� ��
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
