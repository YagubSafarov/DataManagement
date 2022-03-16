namespace DataManagement
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(DataBinderBase), true)]
    public class DataBinderInspector : Editor
    {
        private SerializedProperty t_eventName;
        private List<string[]> m_pathList;


        private void OnEnable()
        {
            t_eventName = serializedObject.FindProperty("m_eventName");
            Reinit();
        }

        private void Reinit()
        {
            m_pathList = new List<string[]>();

            foreach (var annotation in DataValueResource.Instance.DataAnnotations)
            {
                m_pathList.Add(new string[] { annotation.menuPath, annotation.eventName });
            }
        }

        public override void OnInspectorGUI()
        {
            //serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, "m_eventName");
            serializedObject.ApplyModifiedProperties();
            DataBinderBase m_Target = (DataBinderBase)target;

            EditorGUI.BeginChangeCheck();


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
            if(GUILayout.Button("Update events"))
            {
                DataValueResource.Scan();
                Reinit();
            }
        }

        void AddMenuItemForEvent(GenericMenu menu, string menuPath, string eventName)
        {
            menu.AddItem(new GUIContent(menuPath), t_eventName.stringValue.Equals(eventName), OnEventNameSelected, eventName);
        }

        void OnEventNameSelected(object eventName)
        {
            t_eventName.stringValue = (string)eventName;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
