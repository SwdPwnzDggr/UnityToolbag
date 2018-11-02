using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
[CreateAssetMenu(menuName = "SPD/Audio/Sound Clip Player", fileName = "Sound Clip Player")]
public class SoundClipPlayer : ScriptableObject
{
    [SerializeField]
    protected AudioMixer _mixer;

    [SerializeField]
    protected AudioMixerGroup[] _groups;

    void OnValidate()
    {
        if (_mixer == null) return;
        _groups = _mixer.FindMatchingGroups(string.Empty);

    }
}


