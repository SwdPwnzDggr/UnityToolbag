using UnityEngine;

namespace SPD.Events
{
    [AddComponentMenu("SPD/Events/GameEventListenerString")]
    public class GameEventListenerString : GameEventListener<string>
    {
        public new GameEventString Event;
    }
}