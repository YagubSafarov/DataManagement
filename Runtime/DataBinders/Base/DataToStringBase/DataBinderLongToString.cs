namespace DataManagement
{
    public abstract class DataBinderLongToString : DataBinderLong
    {
        protected override void OnChangeLong(long value)
        {
            OnChangeString(value.ToString());
        }

        protected abstract void OnChangeString(string value);
    }
}