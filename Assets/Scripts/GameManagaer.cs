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
        // ���� ���� �� �߰� ���� ����
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
