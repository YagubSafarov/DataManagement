namespace DataManagement
{
    using System.Collections.Generic;

    public static class DataRepository
    {
        private static Dictionary<string, System.Func<string, System.Action<object>, System.IDisposable>> ListenerEntity;
        private static Dictionary<string, IData> DataEntity;


        static DataRepository()
        {
            ListenerEntity = new Dictionary<string, System.Func<string, System.Action<object>, System.IDisposable>>();
            DataEntity = new Dictionary<string, IData>();

            ListenerEntity.Add(StringDataListener.TYPE_NAME, (enevtName, action) =>
            {
                return new StringDataListener(enevtName, action);
            });

            ListenerEntity.Add(IntDataListener.TYPE_NAME, (enevtName, action) =>
            {
                return new IntDataListener(enevtName, action);
            });

            ListenerEntity.Add(LongDataListener.TYPE_NAME, (enevtName, action) =>
            {
                return new LongDataListener(enevtName, action);
            });

            ListenerEntity.Add(FloatDataListener.TYPE_NAME, (enevtName, action) =>
            {
                return new FloatDataListener(enevtName, action);
            });
        }

        public static void Add(string type, System.Func<string, System.Action<string>, System.IDisposable> func)
        {
            ListenerEntity.Add(type, func);
        }

        public static System.IDisposable Get(string type, string enevtName, System.Action<object> action)
        {
            return ListenerEntity[type].Invoke(enevtName, action);
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