using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SPD.Events
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "SPD/Events/Game Event", fileName = "New Game Event")]
    public class GameEvent : ScriptableObject
    {
        public System.Type type;
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        private List<IGameEventListener> listeners =
            new List<IGameEventListener>();

        public void Raise()
        {
            //Loop through list backwards 
            //incase a listener removes itself from the list 
            //as a response to event being raised
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            listeners.Add(listener);
        }
         
        public void UnregisterListener(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}