using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    private GameObject[] spawnPoints;

    private GameObject enemyPrefab;

    [SerializeField] private AnimationCurve spawnCurve;

    [SerializeField] [Range(0.01f, 0.1f)] private float spawnSpeedIncreaseFactor;
    private float spawnSpeedFactor = 0;

    [SerializeField] private float spawnIntervalTimerSet = 2f;
    private float spawnIntervalTimer;


    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        enemyPrefab = Resources.Load<GameObject>("Enemy");
    }

    private void Start()
    {
        spawnIntervalTimer = spawnIntervalTimerSet;
    }

    void Update()
    {
        if(spawnIntervalTimer > 0)
        {
            spawnIntervalTimer -= Time.deltaTime;

            if(spawnIntervalTimer <= 0)
            {
                SpawnEnemy();

                HandleDifficultyIncrease();
            }
        }
    }

    private void HandleDifficultyIncrease()
    {
        spawnSpeedFactor += spawnSpeedIncreaseFactor;
        spawnSpeedFactor = Mathf.Min(spawnSpeedFactor, 1f); //Curve only goes to 1

        float curveValue = spawnCurve.Evaluate(spawnSpeedFactor);

        spawnIntervalTimer = spawnIntervalTimerSet * curveValue;
    }


    private void SpawnEnemy()
    {
        Vector3 spawnPos = FindRandomSpawnPoint();

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    private Vector3 FindRandomSpawnPoint()
    {
        if (spawnPoints == null || spawnPoints.Length == 0) return Vector3.zero;

        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        Transform selectedSpawnPoint = spawnPoints[randomSpawnPointIndex].transform;

        return selectedSpawnPoint.position;
    }
}
