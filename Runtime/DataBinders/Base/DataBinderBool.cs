namespace DataManagement
{
    public abstract class DataBinderBool : DataBinder<bool>
    {
        protected override string m_type => BoolDataListener.TYPE_NAME;

        protected override void OnChange(object value)
        {
            bool b = (bool)value;
            OnChangeBool(b);
            Notify(b);
        }

        protected abstract void OnChangeBool(bool value);
    }
}