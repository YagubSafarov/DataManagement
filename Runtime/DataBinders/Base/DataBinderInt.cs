namespace DataManagement
{

    public abstract class DataBinderInt : DataBinder<int>
    {
        protected override string m_type => IntDataListener.TYPE_NAME;

        protected override void OnChange(object value)
        {
            int i = (int)value;
            OnChangeInt(i);
            Notify(i);
        }

        protected abstract void OnChangeInt(int value);
    }
}