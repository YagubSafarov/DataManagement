namespace DataManagement
{
    using UnityEngine;
    using System.Collections;

    public class PPDataValue<T> : DataValue<T>
    {
        protected string m_key;

        public PPDataValue(string key, string eventName) : base(eventName)
        {
            m_key = key;
        }

        public string GetKey()
        {
            return m_key;
        }
    }
}