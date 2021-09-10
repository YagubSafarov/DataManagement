namespace DataManagement
{
    using UnityEngine;

    public class PPStringDataValue : PPDataValue<string>
    {
        public PPStringDataValue(string key, string eventName, string defaultValue = null) : base(key, eventName)
        {
            m_key = key;
            Value = PlayerPrefs.GetString(m_key, defaultValue);
        }

        protected override void SetValue(string value)
        {
            base.SetValue(value);
            PlayerPrefs.SetString(m_key, value);
            PlayerPrefs.Save();
        }
    }
}