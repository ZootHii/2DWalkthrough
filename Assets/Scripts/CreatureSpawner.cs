using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject beetlePrefab;
    private Vector3 spawnerPosition;

    private void Start()
    {
        spawnerPosition = transform.position;
        StartCoroutine(SpawnCreature());
    }

    private IEnumerator SpawnCreature()
    {
        while (true)
        {
            int spawnTime = Random.Range(2, 4);
            int offsetPosition = Random.Range(-8, 9);
            int randomRotation = Random.Range(-60, 61);
            var spawnPosition = new Vector3(spawnerPosition.x + offsetPosition, spawnerPosition.y, spawnerPosition.z);
            Instantiate(beetlePrefab, spawnPosition, Quaternion.Euler(new Vector3(0,0,randomRotation)));
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
