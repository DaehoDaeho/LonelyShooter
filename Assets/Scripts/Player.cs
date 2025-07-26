using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.2f;
    float nextFire = 0f;

    void Update()
    {
        // �̵�
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(h, v).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        // ȭ�� ��� ����
        Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);
        //pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;

        // �߻�
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            AudioManager.Instance.PlayPlayerBullet();
        }
    }
}

