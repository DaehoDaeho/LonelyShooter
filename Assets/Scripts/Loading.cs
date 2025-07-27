using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float maxLoading = 3.0f;
    private float currentTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxLoading)
        {
            SceneManager.LoadScene("MainScene");
        }

        gameObject.transform.Rotate(0.0f, 0.0f, -0.5f);
    }
}
