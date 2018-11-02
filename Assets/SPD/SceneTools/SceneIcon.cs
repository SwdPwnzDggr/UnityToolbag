using UnityEngine;

namespace SPD.SceneTools
{
    [AddComponentMenu("SPD/Gizmos/SceneIcon")]
    public class SceneIcon : MonoBehaviour
    {
        [Tooltip("Name of file (including extension) found in Gizmos folders")]
        [SerializeField]
        private string iconName;

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(this.transform.position, iconName);
        }
    }

}
