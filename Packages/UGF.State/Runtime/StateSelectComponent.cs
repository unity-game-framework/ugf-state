using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    [AddComponentMenu("Unity Game Framework/States/State Select", 2000)]
    public class StateSelectComponent : StateGroupComponent
    {
        [Min(0F)]
        [SerializeField] private int m_defaultState;

        public int DefaultState { get { return m_defaultState; } set { m_defaultState = value; } }

        protected override void OnApply()
        {
            Apply(m_defaultState);
        }

        protected override Task OnApplyAsync()
        {
            return ApplyAsync(m_defaultState);
        }

        public void Apply(bool state)
        {
            Apply(state ? 1 : 0);
        }

        public void Apply(int index)
        {
            if (index < 0 || index >= States.Count) throw new ArgumentOutOfRangeException(nameof(index));

            StateComponent state = States[index];

            state.Apply();
        }

        public Task ApplyAsync(bool state)
        {
            return ApplyAsync(state ? 1 : 0);
        }

        public async Task ApplyAsync(int index)
        {
            if (index < 0 || index >= States.Count) throw new ArgumentOutOfRangeException(nameof(index));

            StateComponent state = States[index];

            await state.ApplyAsync();
        }

        public void Revert()
        {
            Apply();
        }

        public Task RevertAsync()
        {
            return ApplyAsync();
        }
    }
}
