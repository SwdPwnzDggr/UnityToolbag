using UnityEngine;

namespace SPD.Variables
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Variables/Vector3 Variable", fileName = "New Vector3 Variable")]
    public class Vector3Variable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public Vector3 Value;

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(Vector3 value)
        {
            Value = value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(Vector2 value)
        {
            Value = value;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(int x, int y, int z)
        {
            Value.x = x;
            Value.y = y;
            Value.z = z;
        }

        /// <summary>
        /// Overwrites the current Value
        /// </summary>
        public void SetValue(Vector3Variable value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(Vector3 amount)
        {
            Value += amount;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(Vector2 amount)
        {
            Value.x += amount.x;
            Value.y += amount.y;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(int x, int y, int z)
        {
            Value.x += x;
            Value.y += y;
            Value.z += z;
        }

        /// <summary>
        /// Adds to the Value
        /// </summary>
        public void ApplyChange(Vector3Variable amount)
        {
            Value += amount.Value;
        }
    }
}