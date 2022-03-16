namespace DataManagement
{
    public abstract class DataBinderIntToString : DataBinderInt
    {
        protected override void OnChangeInt(int value)
        {
            OnChangeString(value.ToString());
        }

        protected abstract void OnChangeString(string value);
    }
}