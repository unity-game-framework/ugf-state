using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.EditorTools.Runtime.IMGUI.References;
using UnityEngine;

namespace UGF.State.Runtime
{
    [AddComponentMenu("Unity Game Framework/States/State")]
    public class StateComponent : MonoBehaviour
    {
        [Min(0F)]
        [SerializeField] private int m_defaultStateIndex;
        [ManagedReference]
        [SerializeReference] private List<IState> m_states = new List<IState>();

        public int DefaultStateIndex { get { return m_defaultStateIndex; } set { m_defaultStateIndex = value; } }
        public List<IState> States { get { return m_states; } }

        public void Apply()
        {
            Apply(m_defaultStateIndex);
        }

        public void Apply(bool state)
        {
            Apply(state ? 1 : 0);
        }

        public void Apply(int index)
        {
            if (index < 0 || index >= m_states.Count) throw new ArgumentOutOfRangeException(nameof(index));

            IState state = m_states[index];

            state.Apply();
        }

        public Task ApplyAsync()
        {
            return ApplyAsync(m_defaultStateIndex);
        }

        public Task ApplyAsync(bool state)
        {
            return ApplyAsync(state ? 1 : 0);
        }

        public async Task ApplyAsync(int index)
        {
            if (index < 0 || index >= m_states.Count) throw new ArgumentOutOfRangeException(nameof(index));

            IState state = m_states[index];

            await state.ApplyAsync();
        }
    }
}
