namespace DataManagement
{
    using UnityEngine;

    public class PPBoolDataValue : PPDataValue<bool>
    {
        public PPBoolDataValue(string key, string eventName, bool defaultValue = false) : base(key, eventName)
        {
            m_key = key;
            Value = PlayerPrefs.GetInt(m_key, defaultValue ? 1 : 0) == 1;
        }

        protected override void SetValue(bool value)
        {
            base.SetValue(value);
            PlayerPrefs.SetInt(m_key, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}