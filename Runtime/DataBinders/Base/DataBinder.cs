namespace DataManagement
{
    public abstract class DataBinder<T> : DataBinderBase
    {
        public System.Action<T> OnChangeValue;
        protected abstract string m_type { get; }

        private System.IDisposable m_listener;

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
            m_listener = DataRepository.Get(m_type, m_eventName, OnChange);
        }

        protected virtual void OnDestroy()
        {
            if (m_listener != null)
                m_listener.Dispose();
        }

        protected void Notify(T value)
        {
            OnChangeValue?.Invoke(value);
        }

        protected abstract void OnChange(object value);
    }
}