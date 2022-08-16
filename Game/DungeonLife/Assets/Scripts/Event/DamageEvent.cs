using UnityEngine;

namespace Event
{
    [CreateAssetMenu(menuName = "events/item pickup")]
    public class DamageDoneEvent : GameEvent
    {
        [SerializeField] public float Value;
    }
}