namespace DataManagement
{
    using System;

    public class StringDataListener : DataListenerBase<string>
    {
        public const string TYPE_NAME = "StringDataListener";

        public StringDataListener(string enevtName, Action<string> action, string format = "") : base(enevtName, action, format)
        {
        }
    }
}