using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FootTargetUpdater))]
[CanEditMultipleObjects]
public class FootTargetEditor : Editor
{
    private void OnSceneGUI()
    {
        Handles.matrix = Matrix4x4.identity;
        Handles.color = Color.green;
        EditorGUI.BeginChangeCheck();

        foreach (Object currentTarget in targets)
        {
            FootTargetUpdater targetScript = (FootTargetUpdater)target;

            float newRadius = Handles.RadiusHandle(
                 targetScript.transform.rotation,
                 targetScript.transform.position,
                 targetScript.moveDistanceThreshold
             );


            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(targetScript, "Change move distance threshold");
                targetScript.moveDistanceThreshold = newRadius;
            }
        }


    }
}
