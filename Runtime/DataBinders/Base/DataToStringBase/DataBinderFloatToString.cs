namespace DataManagement
{
    public abstract class DataBinderFloatToString : DataBinderFloat
    {
        protected override void OnChangeFloat(float value)
        {
            OnChangeString(value.ToString());
        }

        protected abstract void OnChangeString(string value);
    }
}