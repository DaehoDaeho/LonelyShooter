using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // ����� ���� ��ġ �Ʒ��� ��������, �ٽ� ���� �÷��� �ݺ�
        if (transform.position.y < -10.0f)
        {
            transform.position = new Vector3(0, 10.0f, transform.position.z);
        }
    }
}
