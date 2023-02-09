using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] gameObjects;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject player;
    public int SpawnerHealth;
    public int scoreToGive;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            if ((Mathf.Abs(player.transform.position.x - transform.position.x) < 5) || (Mathf.Abs(player.transform.position.z - transform.position.z) < 3))
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length < 15)
                {
                    InvokeRepeating(nameof(SpawnObj), spawnTime, spawnDelay);
                    SpawnerHealth--;
                    if (SpawnerHealth <= 0)
                    {
                        Destroy(gameObject, 5);
                    }
                }
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void TakeDamage(int damage)
    {
        SpawnerHealth -= damage;
        if (SpawnerHealth <= 0)
            Die();
    }

    void Die()
    {
        GameManager.instance.AddScore(scoreToGive);

        Destroy(gameObject);
    }

    void SpawnObj()
        {
            int randomindex = Random.Range(0, gameObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(transform.position.x + Random.Range(-3, 4), 70.7f, transform.position.z + Random.Range(-3, 4));
            Instantiate(gameObjects[randomindex], randomSpawnPosition, Quaternion.identity);
            if (stopSpawning)
            {
                CancelInvoke(nameof(SpawnObj));
            }
        }
    }