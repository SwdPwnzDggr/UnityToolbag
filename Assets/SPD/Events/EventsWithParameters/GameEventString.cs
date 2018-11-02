using UnityEngine;

namespace SPD.Events
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Events/Game Event String", fileName = "New Game Event String")]
    public class GameEventString : GameEvent<string> { }
}