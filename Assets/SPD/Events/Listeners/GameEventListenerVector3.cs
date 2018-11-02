using UnityEngine;

namespace SPD.Events
{
    [AddComponentMenu("SPD/Events/GameEventListenerVector3")]
    public class GameEventListenerVector3 : GameEventListener<Vector3>
    {
        public new GameEventVector3 Event;
    }
}