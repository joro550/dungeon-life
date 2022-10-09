using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Transform Event", menuName = "Game Event/Transform")]
    public class TransformEvent : BaseGameEvent<Transform>
    {
        public Transform Value;

        public void Raise() => Raise(Value);
    }
}