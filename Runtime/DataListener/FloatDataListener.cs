namespace DataManagement
{
    using System;

    public class FloatDataListener : DataListenerBase<float>
    {
        public const string TYPE_NAME = "FloatDataListener";

        public FloatDataListener(string enevtName, Action<object> action) : base(enevtName, action)
        {
        }
    }
}