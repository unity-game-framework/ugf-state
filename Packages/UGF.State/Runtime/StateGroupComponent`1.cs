using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    public abstract class StateGroupComponent<TState> : StateComponent, IStateGroup where TState : StateComponent
    {
        [SerializeField] private List<TState> m_states = new List<TState>();

        public List<TState> States { get { return m_states; } }

        IReadOnlyList<IState> IStateGroup.States { get { return States; } }

        protected override void OnApply()
        {
            for (int i = 0; i < m_states.Count; i++)
            {
                StateComponent state = m_states[i];

                state.Apply();
            }
        }

        protected override async Task OnApplyAsync()
        {
            for (int i = 0; i < m_states.Count; i++)
            {
                StateComponent state = m_states[i];

                await state.ApplyAsync();
            }
        }

        public void Add(TState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            m_states.Add(state);
        }

        public bool Remove(TState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            return m_states.Remove(state);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= m_states.Count) throw new ArgumentOutOfRangeException(nameof(index));

            m_states.RemoveAt(index);
        }

        public void Clear()
        {
            m_states.Clear();
        }

        void IStateGroup.Add(IState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (state is not StateComponent stateComponent) throw new ArgumentException($"State must be type of '{nameof(StateComponent)}'.");

            m_states.Add((TState)stateComponent);
        }

        bool IStateGroup.Remove(IState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (state is not StateComponent stateComponent) throw new ArgumentException($"State must be type of '{nameof(StateComponent)}'.");

            return m_states.Remove((TState)stateComponent);
        }
    }
}
