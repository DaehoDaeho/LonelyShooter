using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.2f;
    float nextFire = 0f;

    public int hp = 1;
    public GameObject explosionPrefab;   // 플레이어 폭발 이펙트(같은 거 써도 됨)

    public float boundRadius = 0.5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(h, v).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        // 1. 카메라의 화면 경계 계산 (World 좌표)
        Camera cam = Camera.main;
        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // 좌하단
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // 우상단

        // 2. Clamp로 위치 제한 (플레이어 반지름 만큼 여유)
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + boundRadius, max.x - boundRadius);
        pos.y = Mathf.Clamp(pos.y, min.y + boundRadius, max.y - boundRadius);
        transform.position = pos;

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            AudioManager.Instance.PlayBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        AudioManager.Instance.PlayHit();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false); // 플레이어 비활성화
        GameManager.Instance.OnGameOver(); // 게임매니저에 알리기
    }
}

