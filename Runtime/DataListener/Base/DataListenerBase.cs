namespace DataManagement
{
    using EventManagement;

    public class DataListenerBase<T> : System.IDisposable
    {
        private System.Action<string> m_onEventString;
        protected string m_enevtName;

        protected DataListenerBase(string enevtName, System.Action<string> action)
        {
            m_enevtName = enevtName;
            m_onEventString = action;

            EventHandler.RegisterEvent<T>(m_enevtName, OnEvent);
            OnEvent((T)DataRepository.GetDataValue(enevtName));
        }

        public virtual void Dispose()
        {
            EventHandler.UnregisterEvent<T>(m_enevtName, OnEvent);
        }

        protected virtual void OnEvent(T value)
        {
            CallEventString(value.ToString());
        }

        protected virtual void CallEventString(string value)
        {
            m_onEventString?.Invoke(value);
        }

    }

}
