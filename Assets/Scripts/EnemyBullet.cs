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
            // 플레이어에 맞으면 총알만 삭제(플레이어 처리 별도)
            Destroy(gameObject);
        }
    }
}
