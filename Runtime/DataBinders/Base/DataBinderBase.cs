namespace DataManagement
{
    using UnityEngine;

    public class DataBinderBase : MonoBehaviour
    {
        [SerializeField]
        protected string m_eventName;
        [SerializeField]
        private string m_format;

        protected string FormatString(string value)
        {
            if (string.IsNullOrEmpty(m_format))
            {
                return value;
            }
            return string.Format(m_format, value);
        }

    }
}