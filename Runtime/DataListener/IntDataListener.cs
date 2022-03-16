namespace DataManagement
{
    using System;

    public class IntDataListener : DataListenerBase<int>
    {
        public const string TYPE_NAME = "IntDataListener";

        public IntDataListener(string enevtName, Action<string> action) : base(enevtName, action)
        {
        }
    }
}