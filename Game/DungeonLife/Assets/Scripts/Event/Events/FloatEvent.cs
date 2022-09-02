using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Int Event", menuName = "Game Event/Int")]
    public class FloatEvent : BaseGameEvent<float>
    {
        public float Value { get; set; }

        public void Raise() => Raise(Value);
    }
}