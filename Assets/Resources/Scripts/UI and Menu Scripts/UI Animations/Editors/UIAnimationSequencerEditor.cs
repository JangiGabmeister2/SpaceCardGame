using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(UIAnimationSequencer))]
public class UIAnimationSequencerEditor : Editor
{
    SerializedProperty sequence;
    SerializedProperty uITransforms;

    private void OnEnable()
    {
        sequence = serializedObject.FindProperty("sequencer");
    }

    //public override void OnInspectorGUI()
    //{
    //    serializedObject.Update();

    //    EditorGUI.BeginChangeCheck();
    //    var sequencerArray = sequence;
    //    int indexer = 0;

    //    sequencerArray.GetArrayElementAtIndex(indexer).FindPropertyRelative("uITransform").objectReferenceValue =
    //        EditorGUILayout.ObjectField("uITransforms", sequencerArray.objectReferenceValue, typeof(Transform), true);

    //    if (EditorGUI.EndChangeCheck())
    //    {
    //        serializedObject.ApplyModifiedProperties();
    //    }
    //}
}
