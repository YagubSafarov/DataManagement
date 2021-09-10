namespace DataManagement
{
    using UnityEngine;

    public class PPFloatDataValue : PPDataValue<float>
    {
        public PPFloatDataValue(string key, string eventName, float defaultValue = 0f) : base(key, eventName)
        {
            m_key = key;
            Value = PlayerPrefs.GetFloat(m_key, defaultValue);
        }

        protected override void SetValue(float value)
        {
            base.SetValue(value);
            PlayerPrefs.SetFloat(m_key, value);
            PlayerPrefs.Save();
        }
    }
}