using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPD.Debug
{
    [System.Serializable]
    public class Graph
    {
        [SerializeField] private AnimationCurve curve;

        public void UpdateCurve(float time, float value)
        {
            curve.AddKey(time, value);
        }
        
        public void UpdateCurve(float time, int value)
        {
            curve.AddKey(time, value);
        }
    }
}