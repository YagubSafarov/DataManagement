namespace DataManagement
{
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public class ExecutionOrderValidator
    {

        const int BinderExecOrder = 1000;

        static ExecutionOrderValidator()
        {
            var temp = new GameObject();

            var binder = temp.AddComponent<DataBinderBase>();
            
            MonoScript readerScript = MonoScript.FromMonoBehaviour(binder);
            if (MonoImporter.GetExecutionOrder(readerScript) != BinderExecOrder)
            {
                MonoImporter.SetExecutionOrder(readerScript, BinderExecOrder);
                Debug.Log("Fixing exec order for " + readerScript.name);
            }

            Object.DestroyImmediate(temp);
        }

    }
}
