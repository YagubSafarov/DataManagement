namespace DataManagement
{
    using EventManagement;

    public class DataListenerBase<T> : System.IDisposable
    {
        private System.Action<string> m_onEvent;
        protected string m_format;
        protected string m_enevtName;

        protected DataListenerBase(string enevtName, System.Action<string> action, string format = "")
        {
            m_enevtName = enevtName;
            m_format = format;
            m_onEvent = action;

            EventHandler.RegisterEvent<T>(m_enevtName, OnEvent);
            OnEvent((T)DataRepository.GetDataValue(enevtName));
        }

        public virtual void Dispose()
        {
            EventHandler.UnregisterEvent<T>(m_enevtName, OnEvent);
        }

        protected virtual void OnEvent(T value)
        {
            CallEvent(value.ToString());
        }

        protected virtual void CallEvent(string value)
        {
            m_onEvent?.Invoke(value);
        }

    }

}
