using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Float Event", menuName = "Game Event/Float")]
    public class FloatEvent : BaseGameEvent<float>
    {
        public float Value;

        public void Raise() => Raise(Value);
    }
}