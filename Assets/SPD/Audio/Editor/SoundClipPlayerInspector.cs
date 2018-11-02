using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundClipPlayer))]
public class SoundClipPlayerInspector : Editor {

    public override void OnInspectorGUI()
    {
        SPD.EditorTools.Tools.DrawHeader(Color.black,Color.gray, "Sound Clip Player");
    }
}
