using Event.Events;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    [SerializeField] private int minEnemiesToSpawn;
    [SerializeField] private int maxEnemiesToSpawn;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private IntEvent OnEnemiesSpawned;

    public void Spawn()
    {
        var worldPosition = transform.TransformPoint(transform.position);
        var enemiesToSpawn = Random.Range(minEnemiesToSpawn, maxEnemiesToSpawn + 1);

        var (minX, maxX) = (worldPosition.x - radius, worldPosition.x + radius);
        var (minY, maxY) = (worldPosition.y - radius, worldPosition.y + radius);
        
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);
            
            var random = new Vector3(x, y);
            Instantiate(enemyPrefab, random, Quaternion.identity);
        }

        OnEnemiesSpawned?.Raise(enemiesToSpawn);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, new Vector3(0, 0, 1), radius);
    }
#endif
}