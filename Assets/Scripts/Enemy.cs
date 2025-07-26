using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int hp = 1;
    public GameObject explosionPrefab;


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6f) Destroy(gameObject);
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
