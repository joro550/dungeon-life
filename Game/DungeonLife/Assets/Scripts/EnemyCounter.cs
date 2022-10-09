using System;
using Event.Events;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int enemies;
    [SerializeField] private VoidEvent allEnemiesDead;

    private void Start()
    {
        var findObjectOfType = FindObjectsOfType<DropTable>();
        enemies = findObjectOfType.Length;
    }

    public void RemoveEnemy()
    {
        enemies -= 1;
        if(enemies  <= 0)
            allEnemiesDead?.Raise();
    }
}