using Event.Events;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FloatEvent), editorForChildClasses: true)]
    public class FloatGameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            var myTarget = (FloatEvent)target;
            DrawDefaultInspector();
            
            var buttonPressed = GUILayout.Button("Raise");
            if (buttonPressed)
                myTarget.Raise(myTarget.Value);
        }
    }
}