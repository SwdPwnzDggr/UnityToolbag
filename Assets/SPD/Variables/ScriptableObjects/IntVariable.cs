using UnityEngine;

namespace SPD.Variables
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Variables/Int Variable", fileName = "New Int Variable")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(float value)
        {
            Value = (int)value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(double value)
        {
            Value = (int)value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(FloatVariable value)
        {
            Value = (int)value.Value;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(float amount)
        {
            Value += (int)amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(double amount)
        {
            Value += (int)amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(FloatVariable amount)
        {
            Value += (int)amount.Value;
        }
    }
}