using UnityEngine;

namespace SPD.Variables
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Variables/Bool Variable", fileName = "New Bool Variable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public bool Value;

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(bool value)
        {
            Value = value;
        }
    }
}