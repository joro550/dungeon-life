using System;
using Event.Events;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private int enemies;
    [SerializeField] private VoidEvent allEnemiesDead;

    private void Start()
    {
        var findObjectOfType = FindObjectsOfType<EnemyHealth>();
        enemies = findObjectOfType.Length;
    }

    public void RemoveEnemy()
    {
        enemies -= 1;
        if(enemies  <= 0)
            allEnemiesDead?.Raise();
    }
}