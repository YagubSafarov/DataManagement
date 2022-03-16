namespace DataManagement
{
    using UnityEngine.UI;

    public class DataBinderStringText : DataBinderString
    {
        private Text _text;

        protected override void Awake()
        {
            base.Awake();
            _text = GetComponent<Text>();
        }

        protected override void OnChangeString(string value)
        {
            _text.text = FormatString(value);
        }
    }
}