namespace DataManagement
{
    using System;

    public class BoolDataListener : DataListenerBase<bool>
    {
        public const string TYPE_NAME = "BoolDataListener";

        public BoolDataListener(string enevtName, Action<object> action) : base(enevtName, action)
        {
        }
    }
}