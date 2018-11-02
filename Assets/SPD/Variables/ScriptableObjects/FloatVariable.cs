using UnityEngine;

namespace SPD.Variables
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Variables/Float Variable", fileName = "New Float Variable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(double value)
        {
            Value = (float)value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(int value)
        {
            Value = (float)value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(double amount)
        {
            Value += (float) amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(int amount)
        {
            Value += (float)amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}