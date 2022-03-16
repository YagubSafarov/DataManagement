namespace DataManagement
{
    public abstract class DataBinderLong : DataBinder<long>
    {
        protected override string m_type => LongDataListener.TYPE_NAME;

        protected override void OnChange(object value)
        {
            long l = (long)value;
            OnChangeLong(l);
            Notify(l);
        }

        protected abstract void OnChangeLong(long value);
    }
}