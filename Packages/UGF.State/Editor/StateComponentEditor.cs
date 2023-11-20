using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.State.Runtime;
using UnityEditor;

namespace UGF.State.Editor
{
    [CustomEditor(typeof(StateComponent), true)]
    internal class StateComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyDefaultStateIndex;
        private ReorderableListDrawer m_listStates;

        private void OnEnable()
        {
            m_propertyDefaultStateIndex = serializedObject.FindProperty("m_defaultStateIndex");
            m_listStates = new ReorderableListDrawer(serializedObject.FindProperty("m_states"));
            m_listStates.Enable();
        }

        private void OnDisable()
        {
            m_listStates.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyDefaultStateIndex);

                m_listStates.DrawGUILayout();
            }
        }
    }
}
