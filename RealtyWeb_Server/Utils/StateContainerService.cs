namespace RealtyWeb_Server.Utils
{
    public class StateContainerService
    {
        public int Value { get; set; } = 0;
        public event Action OnStateChange = null!;
        public void SetValue(int value) 
        {
            Value = value;
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
