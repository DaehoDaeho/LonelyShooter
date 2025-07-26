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

    void Update()
    {
        // 이동
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(h, v).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        // 화면 경계 제한
        Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        //pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;

        // 발사
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

