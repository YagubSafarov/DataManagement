namespace DataManagement
{
    using System.Collections.Generic;

    public static class DataRepository
    {
        private static Dictionary<string, System.Func<string, System.Action<string>, string, System.IDisposable>> ListenerEntity;
        private static Dictionary<string, IData> DataEntity;


        static DataRepository()
        {
            ListenerEntity = new Dictionary<string, System.Func<string, System.Action<string>, string, System.IDisposable>>();
            DataEntity = new Dictionary<string, IData>();

            ListenerEntity.Add(StringDataListener.TYPE_NAME, (enevtName, action, format) =>
            {
                return new StringDataListener(enevtName, action, format);
            });

            ListenerEntity.Add(IntDataListener.TYPE_NAME, (enevtName, action, format) =>
            {
                return new IntDataListener(enevtName, action, format);
            });

            ListenerEntity.Add(LongDataListener.TYPE_NAME, (enevtName, action, format) =>
            {
                return new LongDataListener(enevtName, action, format);
            });

            ListenerEntity.Add(FloatDataListener.TYPE_NAME, (enevtName, action, format) =>
            {
                return new FloatDataListener(enevtName, action, format);
            });
        }

        public static void Add(string type, System.Func<string, System.Action<string>, string, System.IDisposable> func)
        {
            ListenerEntity.Add(type, func);
        }

        public static System.IDisposable Get(string type, string enevtName, System.Action<string> action, string format = "")
        {
            return ListenerEntity[type].Invoke(enevtName, action, format);
        }

        public static void Register(IData data)
        {
            DataEntity.Add(data.GetEventName(), data);
        }

        public static void Unregister(IData data)
        {
            DataEntity.Remove(data.GetEventName());
        }

        public static object GetDataValue(string eventName)
        {
            return DataEntity[eventName].GetValueObject();
        }
    }


}