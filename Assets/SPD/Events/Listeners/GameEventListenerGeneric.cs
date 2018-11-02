using UnityEngine;

namespace SPD.Events
{
   [AddComponentMenu("SPD/Events/GameEventListener")]
   public abstract class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
   {
       public GameEvent<T> Event;
#if UNITY_EDITOR
        [Multiline]
       public string DeveloperDescription = "";
#endif
        public UnityEngine.Events.UnityEvent<T> Response;

       private void OnEnable()
       {
           Event.RegisterListener(this);
       }

       private void OnDisable()
       {
           Event.UnregisterListener(this);
       }

       public void OnEventRaised(T myParam)
       {
           Response.Invoke(myParam);
       }
   }
}