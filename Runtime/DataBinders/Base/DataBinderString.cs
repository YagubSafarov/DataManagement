namespace DataManagement
{
    public abstract class DataBinderString : DataBinder<string>
    {
        protected override string m_type => StringDataListener.TYPE_NAME;

        protected override void OnChange(object value)
        {
            string str = (string)value;
            OnChangeString(str);
            Notify(str);
        }

        protected abstract void OnChangeString(string value);
    }
}