using UnityEngine;

namespace Event
{
    [CreateAssetMenu(menuName = "events/item pickup")]
    public class ItemPickupEvent : GameEvent
    {
        [SerializeField] public float Value;
    }
}