using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int hp = 1;
    public GameObject explosionPrefab;

    public GameObject enemyBulletPrefab;
    float fireRate = 3.0f;    // �� ��� ����
    float nextFire = 0f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6f) Destroy(gameObject);

        // �Ѿ� �߻�
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            // ���������� �߻�.
            //Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            //AudioManager.Instance.PlayBullet();

            // �÷��̾� ã��
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                Vector2 dir = (playerObj.transform.position - transform.position).normalized;
                GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<EnemyBullet>().SetDirection(dir);
                AudioManager.Instance.PlayBullet();
            }
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
