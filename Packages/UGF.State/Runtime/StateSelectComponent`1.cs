using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    public abstract class StateSelectComponent<TState> : StateGroupComponent<TState>, IStateSelect where TState : StateComponent
    {
        [Min(0F)]
        [SerializeField] private int m_defaultState;

        public int DefaultState { get { return m_defaultState; } set { m_defaultState = value; } }

        int IStateSelect.DefaultStateIndex { get { return m_defaultState; } }

        protected override void OnApply()
        {
            Apply(m_defaultState);
        }

        protected override Task OnApplyAsync()
        {
            return ApplyAsync(m_defaultState);
        }

        public TState GetDefaultState()
        {
            return States[m_defaultState];
        }

        public void Apply(bool state)
        {
            Apply(state ? 1 : 0);
        }

        public void Apply(int index)
        {
            if (index < 0 || index >= States.Count) throw new ArgumentOutOfRangeException(nameof(index));

            OnApply(index);
        }

        public Task ApplyAsync(bool state)
        {
            return ApplyAsync(state ? 1 : 0);
        }

        public Task ApplyAsync(int index)
        {
            if (index < 0 || index >= States.Count) throw new ArgumentOutOfRangeException(nameof(index));

            return OnApplyAsync(index);
        }

        public void Revert()
        {
            OnRevert();
        }

        public Task RevertAsync()
        {
            return OnRevertAsync();
        }

        protected virtual void OnApply(int index)
        {
            StateComponent state = States[index];

            state.Apply();
        }

        protected virtual async Task OnApplyAsync(int index)
        {
            StateComponent state = States[index];

            await state.ApplyAsync();
        }

        protected virtual void OnRevert()
        {
            Apply();
        }

        protected virtual Task OnRevertAsync()
        {
            return ApplyAsync();
        }

        IState IStateSelect.GetDefaultState()
        {
            return GetDefaultState();
        }
    }
}
