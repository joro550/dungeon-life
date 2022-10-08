using Event.Events;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(IntEvent), editorForChildClasses: true)]
    public class IntGameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            var myTarget = (IntEvent)target;
            
            DrawDefaultInspector();
            
            var buttonPressed = GUILayout.Button("Raise");
            if (buttonPressed)
                myTarget.Raise(myTarget.Value);
        }
    }
}