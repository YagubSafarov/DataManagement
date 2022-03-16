namespace DataManagement
{
    using UnityEngine.UI;

    public class DataBinderFloatSlider : DataBinderFloat
    {
        private Slider _slider;

        protected override void Awake()
        {
            base.Awake();
            _slider = GetComponent<Slider>();
        }

        protected override void OnChangeFloat(float value)
        {
            _slider.value = value;
        }
    }
}