using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 7f;

    Vector2 direction = Vector2.down;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < -6f || transform.position.y > 6f ||
            Mathf.Abs(transform.position.x) > 6f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
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
