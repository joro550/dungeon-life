using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Float Event", menuName = "Game Event/Float")]
    public class TransformEvent : BaseGameEvent<Transform>
    {
        public Transform Value;

        public void Raise() => Raise(Value);
    }
}