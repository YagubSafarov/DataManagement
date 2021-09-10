namespace DataManagement
{
    using UnityEngine;

    public class PPIntDataValue : PPDataValue<int>
    {
        public PPIntDataValue(string key, string eventName, int defaultValue = 0) : base(key, eventName)
        {
            m_key = key;
            Value = PlayerPrefs.GetInt(m_key, defaultValue);
        }

        protected override void SetValue(int value)
        {
            base.SetValue(value);
            PlayerPrefs.SetInt(m_key, value);
            PlayerPrefs.Save();
        }
    }
}