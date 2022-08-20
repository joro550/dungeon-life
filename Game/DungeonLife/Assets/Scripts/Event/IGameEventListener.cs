namespace Event
{
    public interface IGameEventListener<in T>
    {
        void OnEventRaised(T value);
    }
}