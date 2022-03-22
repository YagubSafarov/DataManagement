namespace DataManagement
{
    public abstract class DataBinderLongToString : DataBinderLong
    {
        protected override void OnChangeLong(long value)
        {
            OnChangeString(FormatString(value));
        }

        protected abstract void OnChangeString(string value);
    }
}