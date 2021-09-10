namespace DataManagement
{
    using System;

    public class BoolDataListener : DataListenerBase<bool>
    {
        public const string TYPE_NAME = "BoolDataListener";

        public BoolDataListener(string enevtName, Action<string> action, string format = "") : base(enevtName, action, format)
        {
        }

        protected override void OnEvent(bool value)
        {
            CallEvent(value ? "1" : null);
        }

    }
}