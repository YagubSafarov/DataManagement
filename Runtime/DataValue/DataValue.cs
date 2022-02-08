namespace DataManagement
{
    using EventManagement;
    using Unity.Plastic.Newtonsoft.Json;

    [System.Serializable]
    public class DataValue<T>: IData, System.IDisposable
    {
        [JsonProperty]
        protected T m_value;
        [JsonProperty]
        protected string m_eventName;

        public DataValue(string eventName)
        {
            m_eventName = eventName;
            if (!string.IsNullOrEmpty(m_eventName))
            {
                DataRepository.Register(this);
            }
        }

        public DataValue(T value, string eventName)
        {
            m_eventName = eventName;
            SetValue(value);
            if (!string.IsNullOrEmpty(m_eventName))
            {
                DataRepository.Register(this);
            }
        }

        public DataValue(T value)
        {
            SetValue(value);
        }

        public DataValue()
        {
            SetValue(default);
        }

        public virtual T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        protected virtual T GetValue()
        {
            return m_value;
        }

        protected virtual void SetValue(T value)
        {
            if ((m_value != null && m_value.Equals(value)) || (m_value == null && value == null))
                return;
            m_value = value;
            if (!string.IsNullOrWhiteSpace(m_eventName))
                Broadcast();
        }

        protected virtual void Broadcast()
        {
            EventHandler.ExecuteEvent(m_eventName, Value);
        }

        public string GetEventName()
        {
            return m_eventName;
        }

        public object GetValueObject()
        {
            return Value;
        }

        public void Dispose()
        {
            if (!string.IsNullOrEmpty(m_eventName))
            {
                DataRepository.Unregister(this);
            }
        }

        public void Subscribe(System.Action<T> func)
        {
            if (!string.IsNullOrEmpty(m_eventName))
                EventHandler.RegisterEvent<T>(m_eventName, func);
        }

        public void Unsubscribe(System.Action<T> func)
        {
            if (!string.IsNullOrEmpty(m_eventName))
                EventHandler.UnregisterEvent<T>(m_eventName, func);
        }
    }
}