using UnityEngine;

namespace SPD.Events
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Events/Game Event Vector3", fileName = "New Game Event Vector3")]
    public class GameEventVector3 : GameEvent<Vector3> { }
}