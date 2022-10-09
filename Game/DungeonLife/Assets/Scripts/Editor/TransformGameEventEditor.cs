using Event.Events;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(TransformEvent), editorForChildClasses: true)]
    public class TransformGameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            var myTarget = (TransformEvent)target;
            
            DrawDefaultInspector();
            
            var buttonPressed = GUILayout.Button("Raise");
            if (buttonPressed)
                myTarget.Raise(myTarget.Value);
        }
    }
}