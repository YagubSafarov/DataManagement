namespace DataManagement
{
    public abstract class DataBinderBoolToString : DataBinderBool
    {
        public string OffText = "Off";
        public string OnText = "On";

        protected override void OnChangeBool(bool value)
        {
            OnChangeString(value ? OnText : OffText);
        }

        protected abstract void OnChangeString(string value);
    }
}