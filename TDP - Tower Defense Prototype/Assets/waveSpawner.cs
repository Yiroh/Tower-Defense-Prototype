using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 15.5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update () 
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0;i < waveIndex * waveIndex + 1; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
