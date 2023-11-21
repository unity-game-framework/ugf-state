using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.State.Runtime;
using UnityEditor;

namespace UGF.State.Editor
{
    [CustomEditor(typeof(StateGroupComponent), true)]
    internal class StateGroupComponentEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listStates;
        private ReorderableListSelectionDrawerByElement m_listStatesSelection;

        private void OnEnable()
        {
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

                m_listStates.DrawGUILayout();
                m_listStatesSelection.DrawGUILayout();
            }
        }
    }
}
