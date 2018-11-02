using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPD.Events
{
    [System.Serializable]
    public class UnityEventBool : UnityEngine.Events.UnityEvent<bool> { }
    [System.Serializable]
    public class UnityEventFloat: UnityEngine.Events.UnityEvent<float> { }
    [System.Serializable]
    public class UnityEventString : UnityEngine.Events.UnityEvent<string> { }
    [System.Serializable]
    public class UnityEventInt : UnityEngine.Events.UnityEvent<int> { }
    [System.Serializable]
    public class UnityEventVector3 : UnityEngine.Events.UnityEvent<Vector3> { }

}