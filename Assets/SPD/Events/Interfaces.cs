namespace SPD.Events
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T param);
    }
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
}
