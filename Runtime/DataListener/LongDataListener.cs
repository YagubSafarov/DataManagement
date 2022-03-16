namespace DataManagement
{
    using System;

    public class LongDataListener : DataListenerBase<long>
    {
        public const string TYPE_NAME = "LongDataListener";

        public LongDataListener(string enevtName, Action<string> action) : base(enevtName, action)
        {
        }
    }
}