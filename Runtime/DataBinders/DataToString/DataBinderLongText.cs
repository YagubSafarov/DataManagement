namespace DataManagement
{
    using UnityEngine.UI;

    [UnityEngine.RequireComponent(typeof(Text))]
    public class DataBinderLongText : DataBinderLongToString
    {
        private Text _text;

        protected override void Awake()
        {
            base.Awake();
            _text = GetComponent<Text>();
        }

        protected override void OnChangeString(string value)
        {
            _text.text = value;
        }
    }
}