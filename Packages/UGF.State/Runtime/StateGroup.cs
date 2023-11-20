using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.EditorTools.Runtime.IMGUI.References;
using UnityEngine;

namespace UGF.State.Runtime
{
    [Serializable]
    public class StateGroup : State, IStateGroup
    {
        [ManagedReference]
        [SerializeReference] private List<IState> m_states = new List<IState>();

        public List<IState> States { get { return m_states; } }

        IReadOnlyList<IState> IStateGroup.States { get { return States; } }

        protected override void OnApply()
        {
            for (int i = 0; i < m_states.Count; i++)
            {
                IState state = m_states[i];

                state.Apply();
            }
        }

        protected override async Task OnApplyAsync()
        {
            for (int i = 0; i < m_states.Count; i++)
            {
                IState state = m_states[i];

                await state.ApplyAsync();
            }
        }

        public void Add(IState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            m_states.Add(state);
        }

        public bool Remove(IState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            return m_states.Remove(state);
        }

        public void Remove(int index)
        {
            m_states.RemoveAt(index);
        }

        public void Clear()
        {
            m_states.Clear();
        }
    }
}
