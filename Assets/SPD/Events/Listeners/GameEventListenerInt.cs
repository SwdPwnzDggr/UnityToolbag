using UnityEngine;

namespace SPD.Events
{
    [AddComponentMenu("SPD/Events/GameEventListenerInt")]
    public class GameEventListenerInt : GameEventListener<int>
    {
        public new GameEventInt Event;
    }
}