using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Int Event", menuName = "Game Event/Int")]
    public class IntEvent : BaseGameEvent<int>
    {
        [SerializeField] public int Value;
        public void Raise() => Raise(Value);
    }
}