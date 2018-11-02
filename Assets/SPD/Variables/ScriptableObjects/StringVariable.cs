using UnityEngine;

namespace SPD.Variables
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Variables/String Variable", fileName = "New String Variable")]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string Value;

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(StringVariable value)
        {
            Value = value.Value;
        }
    }
}