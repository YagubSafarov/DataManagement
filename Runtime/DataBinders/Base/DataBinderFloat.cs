using System;

namespace DataManagement
{

    public abstract class DataBinderFloat : DataBinder<float>
    {
        protected override string m_type => FloatDataListener.TYPE_NAME;

        protected override void OnChange(object value)
        {
            float f = Convert.ToSingle(value);
            OnChangeFloat(f);
            Notify(f);
        }

        protected abstract void OnChangeFloat(float value);
    }
}