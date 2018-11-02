using UnityEngine;

namespace SPD.Events
{
    [AddComponentMenu("SPD/Events/GameEventListenerFloat")]
    public class GameEventListenerFloat : GameEventListener<float>
    {
        public new GameEventFloat Event;
    }
}