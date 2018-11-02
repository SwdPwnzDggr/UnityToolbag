using UnityEngine;

namespace SPD.Events
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Events/Game Event Bool", fileName = "New Game Event Bool")]
    public class GameEventBool : GameEvent<bool> { }
}