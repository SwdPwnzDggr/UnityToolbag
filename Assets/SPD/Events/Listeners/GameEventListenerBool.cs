using UnityEngine;

namespace SPD.Events
{
    [AddComponentMenu("SPD/Events/GameEventListenerBool")]
    public class GameEventListenerBool :GameEventListener<bool>
    {
        public new GameEventBool Event;
    }
}