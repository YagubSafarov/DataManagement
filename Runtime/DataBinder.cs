namespace DataManagement
{
    using UnityEngine;

    public class DataBinder : MonoBehaviour
    {
        [SerializeField]
        private string m_eventName;
        [SerializeField]
        private string m_format;
        [SerializeField]
        private string m_type;

        private UnityEngine.UI.Text m_text;
        private TMPro.TextMeshProUGUI m_tmp;
        private TMPro.TMP_InputField m_tmpInput;

        private void Awake()
        {
            m_tmp = GetComponent<TMPro.TextMeshProUGUI>();
            m_tmpInput = GetComponent<TMPro.TMP_InputField>();
            m_text = GetComponent<UnityEngine.UI.Text>();
            DataRepository.Get(m_type, m_eventName, OnChange, m_format);
        }

        private void OnChange(string value)
        {
            if (m_text)
                m_text.text = value;
            if (m_tmp)
                m_tmp.text = value;
            if (m_tmpInput)
                m_tmpInput.text = value;
        }

    }
}