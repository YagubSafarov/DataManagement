namespace DataManagement
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(DataBinder))]
    public class DataBinderInspector : Editor
    {
        private SerializedProperty t_eventName;
        private SerializedProperty t_format;
        private SerializedProperty t_type;
        private List<string[]> m_pathList;


        private void OnEnable()
        {
            t_eventName = serializedObject.FindProperty("m_eventName");
            t_format = serializedObject.FindProperty("m_format");
            t_type = serializedObject.FindProperty("m_type");

            m_pathList = new List<string[]>();

            foreach (var annotation in DataValueResource.Instance.DataAnnotations)
            {
                m_pathList.Add(new string[] { annotation.menuPath, annotation.eventName });
            }
        }

        private string GetDataAnnotationTypeByEventName(string eventName)
        {
            foreach(var data in DataValueResource.Instance.DataAnnotations)
            {
                if (data.eventName == eventName)
                    return data.type;
            }
            return null;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DataBinder m_Target = (DataBinder)target;

            EditorGUI.BeginChangeCheck();


            EditorGUILayout.PropertyField(t_type);
            EditorGUILayout.PropertyField(t_format);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(t_eventName);
            if (m_pathList.Count > 0)
            {
                if (GUILayout.Button("Select Event", GUILayout.Width(100)))
                {
                    GenericMenu menu = new GenericMenu();
                    foreach (var pair in m_pathList)
                    {
                        AddMenuItemForEvent(menu, pair[0], pair[1]);
                    }
                    menu.ShowAsContext();
                }
            }
            EditorGUILayout.EndHorizontal();
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void AddMenuItemForEvent(GenericMenu menu, string menuPath, string eventName)
        {
            menu.AddItem(new GUIContent(menuPath), t_eventName.stringValue.Equals(eventName), OnEventNameSelected, eventName);
        }

        void OnEventNameSelected(object eventName)
        {
            t_eventName.stringValue = (string)eventName;
            t_type.stringValue = GetDataAnnotationTypeByEventName((string)eventName);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
