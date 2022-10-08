using Event.Events;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(VoidEvent), editorForChildClasses: true)]
    public class VoidGameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            var myTarget = (VoidEvent)target;
            
            DrawDefaultInspector();
            
            var buttonPressed = GUILayout.Button("Raise");
            if (buttonPressed)
                myTarget.Raise();
        }
    }
}