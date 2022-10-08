using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class DropTable : MonoBehaviour
{
    [SerializeField] private List<DropType> dropType;
    
    public void GetDrop()
    {
        var item = GetItem();
        Instantiate(item, transform.position, Quaternion.identity);
    }

    private Transform GetItem()
    {
        var ratio = dropType.Sum(x => x.GetChance());
        var numericValue = Random.value * ratio;

        foreach (var parameter in dropType)
        {
            numericValue -= parameter.GetChance();

            if (!(numericValue <= 0))
                continue;

            return parameter.GetItem();
        }

        return null;
    }
}

[Serializable]
public class DropType
{
    [SerializeField] private int chance;
    [SerializeField] private Transform item;

    public int GetChance() => chance;
    public Transform GetItem() => item;
}