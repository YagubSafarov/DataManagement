namespace DataManagement
{
    public class CIntDataValue : DataValue<int>
    {
        private string m_eValue;

        public CIntDataValue(int value, string eventName) : base(-1, eventName)
        {
            EnctiptAndSetValue(value);
        }

        public CIntDataValue(int value) : base()
        {
            EnctiptAndSetValue(value);
        }

        public CIntDataValue() : base()
        {
            EnctiptAndSetValue(default);
        }

        public override int Value { get => GetDectiptedValue(); set => EnctiptAndSetValue(value); }

        protected virtual int GetDectiptedValue()
        {
            return int.Parse(B64X.Decode(m_eValue));
        }

        protected virtual void EnctiptAndSetValue(int value)
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