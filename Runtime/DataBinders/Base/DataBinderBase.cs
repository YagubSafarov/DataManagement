namespace DataManagement
{
    using UnityEngine;

    public class DataBinderBase : MonoBehaviour
    {
        [SerializeField]
        protected string m_eventName;
        [SerializeField, TextArea]
        private string m_format;

        protected string FormatString(object value)
        {
            if (string.IsNullOrEmpty(m_format))
            {
                return value.ToString();
            }
            return string.Format(m_format, value);
        }

    }
}