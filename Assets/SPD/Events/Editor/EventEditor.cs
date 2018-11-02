using UnityEditor;
using UnityEngine;

namespace SPD.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }

    public class EventEditor<T> : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent<T> e = target as GameEvent<T>;
            if (GUILayout.Button("Raise"))
                e.Raise(e.testParam);
        }
    }

    [CustomEditor(typeof(GameEventString))]
    public class EventStringEditor : EventEditor<string> { }

    [CustomEditor(typeof(GameEventInt))]
    public class EventIntEditor : EventEditor<int> { }

    [CustomEditor(typeof(GameEventFloat))]
    public class EventFloatEditor : EventEditor<float> { }

    [CustomEditor(typeof(GameEventBool))]
    public class EventBoolEditor : EventEditor<bool> { }

    [CustomEditor(typeof(GameEventVector3))]
    public class EventVector3Editor : EventEditor<Vector3> { }
}