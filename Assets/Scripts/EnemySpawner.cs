using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnRate = 1f;
    public float stageTime = 30f;

    float nextSpawn = 0f;
    float timer = 0f;
    bool stageEnd = false;

    void Update()
    {
        if (stageEnd) return;

        timer += Time.deltaTime;
        if (timer >= stageTime)
        {
            stageEnd = true;
            GameManager.Instance.OnStageClear();
            return;
        }

        if (Time.time > nextSpawn)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            nextSpawn = Time.time + spawnRate;
            float x = Random.Range(-6.5f, 6.5f);
            Instantiate(enemyPrefab[index], new Vector3(x, 6f, 0), Quaternion.identity);
        }
    }
}
