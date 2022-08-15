using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            var myTarget = (GameEvent)target;
        
            DrawDefaultInspector();
            
            var buttonPressed = GUILayout.Button("Raise");
            if(buttonPressed)
                myTarget.Raise();
        }
    }
}