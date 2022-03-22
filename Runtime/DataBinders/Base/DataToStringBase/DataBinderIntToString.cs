namespace DataManagement
{
    public abstract class DataBinderIntToString : DataBinderInt
    {
        protected override void OnChangeInt(int value)
        {
            OnChangeString(FormatString(value));
        }

        protected abstract void OnChangeString(string value);
    }
}