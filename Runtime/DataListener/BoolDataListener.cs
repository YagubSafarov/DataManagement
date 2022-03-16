namespace DataManagement
{
    using System;

    public class BoolDataListener : DataListenerBase<bool>
    {
        public const string TYPE_NAME = "BoolDataListener";

        public BoolDataListener(string enevtName, Action<string> action) : base(enevtName, action)
        {
        }

        protected override void OnEvent(bool value)
        {
            CallEventString(value ? "1" : null);
        }

    }
}