using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Test", menuName = "Test", order = 0)]
    public class Test : ScriptableObject
    {
        [SerializeField] private int Thing;
    }
}