using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static SequenceItem;

#if UNITY_EDITOR
using UnityEditor;
#endif
[CanEditMultipleObjects]
public class UIAnimationSequencer : MonoBehaviour
{
    [SerializeField, Tooltip("Order each item from starting first to last.")]
    public SequenceItem[] sequencer;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (SequenceItem item in sequencer)
        {
            sequence.Append(item.uITransform.tweener);
        }
    }

#if UNITY_EDITOR
    #region Editor
    [CustomEditor(typeof(UIAnimationSequencer))]
    [ExecuteInEditMode]
    public class UIAnimationSequencerEditor : Editor
    {
        private SerializedProperty sequencer;
        //private SerializedProperty uITransform;
        //private SerializedProperty animationType;
        //private SerializedProperty moveAnimationType;
        bool boolea = true;

        private void OnEnable()
        {
            sequencer = serializedObject.FindProperty("sequencer");
            //uITransform = serializedObject.FindProperty("uITransform");
            //animationType = serializedObject.FindProperty("animationType");
            //moveAnimationType = serializedObject.FindProperty("moveAnimationType");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            UIAnimationSequencer sequenceItem = (UIAnimationSequencer)target;

            sequenceItem.sequencer = SequenceArray("Sequence Items", ref boolea, sequenceItem.sequencer, 1);
            serializedObject.ApplyModifiedProperties();
        }

        private SequenceItem[] SequenceArray(string label, ref bool open, SequenceItem[] array, int size)
        {
            open = EditorGUILayout.Foldout(open, label);
            array = new SequenceItem[size];

            if (open)
            {
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        //serializes a public field with type TrasformTween
                        array[i].uITransform = (TransformTween)EditorGUILayout.ObjectField("UI Transform", array[i].uITransform, typeof(TransformTween), true);

                        EditorGUI.BeginChangeCheck();
                        //if this field is null, the below contents will not show up.
                        if (array[i].uITransform != null)
                        {
                            //serializes a public enum
                            array[i].animationType = (AnimationType)EditorGUILayout.EnumPopup("Animation Type", array[i].animationType);

                            //if the enum is of this type, shows unique content based on selected choice
                            if (array[i].animationType == AnimationType.Move)
                            {
                                array[i].moveAnimationType = (MoveAnimationType)EditorGUILayout.EnumPopup("Move Type", array[i].moveAnimationType);

                                if (array[i].moveAnimationType == MoveAnimationType.World_Move)
                                {
                                    EditorGUILayout.HelpBox("This only shows if moving in World Space!", MessageType.None);
                                }
                                else if (array[i].moveAnimationType == MoveAnimationType.Local_Move)
                                {
                                    EditorGUILayout.HelpBox("This only shows if moving in Local Space!", MessageType.None);
                                }
                            }
                        }
                        EditorGUI.EndChangeCheck();
                    }
                }
            }

            return array;
        }

        //private static T[] ResizeArray<T>(T[] array, int size)
        //{
        //    T[] newArray = new T[size];
        //
        //    for (var i = 0; i < size; i++)
        //    {
        //        if (i < array.Length)
        //        {
        //            newArray[i] = array[i];
        //        }
        //    }
        //
        //    return newArray;
        //}
    }
    #endregion
#endif
}
