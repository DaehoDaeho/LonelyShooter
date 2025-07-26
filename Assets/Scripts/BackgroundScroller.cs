using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // 배경이 일정 위치 아래로 내려가면, 다시 위로 올려서 반복
        if (transform.position.y < -10.0f)
        {
            transform.position = new Vector3(0, 10.0f, transform.position.z);
        }
    }
}
