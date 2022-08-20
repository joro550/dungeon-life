using Event.Types;
using UnityEngine;

namespace Event.Events
{
    [CreateAssetMenu(fileName = "Void Event", menuName = "Game Event/Void")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}