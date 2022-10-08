using Event;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(BaseGameEvent<>), editorForChildClasses: true)]
    public class GameEventEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            // var myTarget = (GameEvent)target;
            //
            // DrawDefaultInspector();
            //
            // var buttonPressed = GUILayout.Button("Raise");
            // if(buttonPressed)
            //     myTarget.Raise();
        }
    }
}