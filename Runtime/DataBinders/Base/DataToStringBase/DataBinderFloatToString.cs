namespace DataManagement
{
    public abstract class DataBinderFloatToString : DataBinderFloat
    {
        protected override void OnChangeFloat(float value)
        {
            OnChangeString(FormatString(value));
        }

        protected abstract void OnChangeString(string value);
    }
}