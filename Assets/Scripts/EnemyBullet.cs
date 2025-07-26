using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 7f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ �Ѿ˸� ����(�÷��̾� ó�� ����)
            Destroy(gameObject);
        }
    }
}
