using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int hp = 1;
    public GameObject explosionPrefab;

    public GameObject enemyBulletPrefab;
    float fireRate = 1.2f;    // ÃÑ ½î´Â °£°Ý
    float nextFire = 0f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6f) Destroy(gameObject);

        // ÃÑ¾Ë ¹ß»ç
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            hp--;
            if (hp <= 0)
            {
                GameObject explostion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explostion.gameObject, 1.0f);
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
