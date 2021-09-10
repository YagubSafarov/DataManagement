namespace DataManagement
{
    public class CFloatDataValue : DataValue<float>
    {
        private string m_eValue;

        public CFloatDataValue(float value, string eventName) : base(eventName)
        {
            EnctiptAndSetValue(value);
        }

        public override float Value { get => GetDectiptedValue(); set => EnctiptAndSetValue(value); }

        protected virtual float GetDectiptedValue()
        {
            return float.Parse(B64X.Decode(m_eValue));
        }

        protected virtual void EnctiptAndSetValue(float value)
        {
            string newValue = B64X.Encode(value.ToString());
            if ((m_eValue != null && m_value.Equals(newValue)))
                return;

            m_eValue = newValue;
            if (!string.IsNullOrWhiteSpace(m_eventName))
                Broadcast();
        }
    }
}