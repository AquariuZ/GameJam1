namespace _Scripts.SaveLoad
{
    public interface ISaveable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}