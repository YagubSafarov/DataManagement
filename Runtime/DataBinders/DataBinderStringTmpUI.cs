using TMPro;

namespace DataManagement
{
    public class DataBinderStringTmpUI : DataBinderString
    {
        private TextMeshProUGUI _text;

        protected override void Awake()
        {
            base.Awake();
            _text = GetComponent<TextMeshProUGUI>();
        }

        protected override void OnChangeString(string value)
        {
            _text.text = FormatString(value);
        }
    }
}