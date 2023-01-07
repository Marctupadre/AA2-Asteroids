using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroiide asteroidPrefab;

    public float trajectoryVariance = 15.0f;

    public float spawnRate = 2.0f;

    public float spawnDistance = 15.0f;

    public int spawnAmount = 1;

    public float size = 1.0f;


    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }


    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroiide asteroiide = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroiide.size = Random.Range(asteroiide.minSize, asteroiide.maxSize);
            asteroiide.SetTrajectory(rotation * -spawnDirection);
        }


    }

}
