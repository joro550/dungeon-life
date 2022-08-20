using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Int Event", menuName = "Game Event/Int")]
    public class IntEvent : BaseGameEvent<int>
    {
        public int Value { get; set; }

        public void Raise() => Raise(Value);
    }
}