namespace DataManagement
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;
    using System;
    using System.Reflection;

    public class DataValueResource : ScriptableObject
    {
        private const string DIRECTORY_PATH = "Assets/Editor/Resources/DataValue";
        private const string FILE_PATH = DIRECTORY_PATH + "/DataValueResource.asset";
        private const string RESOURCE = "DataValue/DataValueResource";

        public static DataValueResource Instance
        {
            get
            {
                if (!System.IO.Directory.Exists(DIRECTORY_PATH))
                {
                    System.IO.Directory.CreateDirectory(DIRECTORY_PATH);
                    AssetDatabase.Refresh();
                }

                if (!System.IO.File.Exists(FILE_PATH))
                {
                    DataValueResource res = CreateInstance<DataValueResource>();
                    AssetDatabase.CreateAsset(res, FILE_PATH);
                    AssetDatabase.Refresh();
                }
                return Resources.Load<DataValueResource>(RESOURCE);
            }
        }

        public List<DataAnnotation> DataAnnotations = new List<DataAnnotation>();


        [MenuItem("Tools/DataValue/Scan")]
        private static void Scan()
        {
            Instance.DataAnnotations.Clear();

            foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (ass.GetName().Name == "DataManagementEditor")
                    continue;

                if (ass.GetName().Name != "Assembly-CSharp")
                {
                    var refs = ass.GetReferencedAssemblies();
                    bool isDependensy = false;
                    foreach (var r in refs)
                    {
                        if (r.Name == "DataManagementRuntime")
                        {
                            isDependensy = true;
                            break;
                        }
                    }

                    if (!isDependensy)
                        continue;
                }

                foreach (var type in ass.GetTypes())
                {
                    var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                    foreach (var field in fields)
                    {
                        try
                        {
                            DataAnnotation dataAnnotation = field.GetCustomAttribute<DataAnnotation>();
                            if (dataAnnotation != null)
                            {
                                Instance.DataAnnotations.Add(dataAnnotation);
                            }
                        }
                        catch { }
                    }

                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        try
                        {
                            DataAnnotation dataAnnotation = property.GetCustomAttribute<DataAnnotation>();
                            if (dataAnnotation != null)
                            {
                                Instance.DataAnnotations.Add(dataAnnotation);
                            }
                        }
                        catch { }
                    }
                }
            }


            EditorUtility.SetDirty(Instance);

            Debug.Log("End Scan");
        }
    }
}
