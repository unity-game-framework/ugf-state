using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.State.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.State.Editor
{
    [CustomEditor(typeof(StateSelectComponent), true)]
    internal class StateSelectComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyDefaultState;
        private ReorderableListDrawer m_listStates;
        private ReorderableListSelectionDrawerByElement m_listStatesSelection;

        private void OnEnable()
        {
            m_propertyDefaultState = serializedObject.FindProperty("m_defaultState");
            m_listStates = new ReorderableListDrawer(serializedObject.FindProperty("m_states"));

            m_listStatesSelection = new ReorderableListSelectionDrawerByElement(m_listStates)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listStates.Enable();
            m_listStatesSelection.Enable();
        }

        private void OnDisable()
        {
            m_listStates.Disable();
            m_listStatesSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyDefaultState);

                m_listStates.DrawGUILayout();
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                using (new EditorGUI.DisabledScope(!OnCanRevert()))
                {
                    if (GUILayout.Button("Revert", GUILayout.Width(75F)))
                    {
                        OnRevert();
                    }
                }

                using (new EditorGUI.DisabledScope(!OnCanApply()))
                {
                    if (GUILayout.Button("Apply", GUILayout.Width(75F)))
                    {
                        OnApply();
                    }
                }
            }

            m_listStatesSelection.DrawGUILayout();
        }

        private bool OnCanRevert()
        {
            return m_propertyDefaultState.intValue >= 0
                   && m_propertyDefaultState.intValue < m_listStates.SerializedProperty.arraySize
                   && m_listStates.SerializedProperty.GetArrayElementAtIndex(m_propertyDefaultState.intValue).objectReferenceValue != null;
        }

        private void OnRevert()
        {
            var component = (StateSelectComponent)target;

            serializedObject.ApplyModifiedProperties();

            Undo.RegisterFullObjectHierarchyUndo(component.gameObject, "State Select Revert");

            component.Revert();
        }

        private bool OnCanApply()
        {
            return m_listStates.List.selectedIndices.Count > 0
                   && m_listStates.List.selectedIndices[0] >= 0
                   && m_listStates.List.selectedIndices[0] < m_listStates.SerializedProperty.arraySize
                   && m_listStates.SerializedProperty.GetArrayElementAtIndex(m_listStates.List.selectedIndices[0]).objectReferenceValue != null;
        }

        private void OnApply()
        {
            var component = (StateSelectComponent)target;

            serializedObject.ApplyModifiedProperties();

            Undo.RegisterFullObjectHierarchyUndo(component.gameObject, "State Select Apply");

            component.Apply(m_listStates.List.selectedIndices[0]);
        }
    }
}
