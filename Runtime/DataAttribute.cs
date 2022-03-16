namespace DataManagement
{
    using System;

    [System.Serializable]
    public sealed class DataAnnotation : Attribute
    {
        public string menuPath;
        public string eventName;
    }
}