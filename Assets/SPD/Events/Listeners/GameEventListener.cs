using UnityEngine;

namespace SPD.Events
{
   [AddComponentMenu("SPD/Events/GameEventListener")]
   public class GameEventListener : MonoBehaviour, IGameEventListener
   {
       public GameEvent Event;
#if UNITY_EDITOR
        [Multiline]
       public string DeveloperDescription = "";
#endif
        public UnityEngine.Events.UnityEvent Response;

       private void OnEnable()
       {
           Event.RegisterListener(this);
       }

       private void OnDisable()
       {
           Event.UnregisterListener(this);
       }

       public void OnEventRaised()
       {
           Response.Invoke();
       }
   }
}