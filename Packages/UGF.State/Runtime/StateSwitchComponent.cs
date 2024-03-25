using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    [AddComponentMenu("Unity Game Framework/States/State Switch", 2000)]
    public class StateSwitchComponent : StateSelectComponent<StateSelectComponent>
    {
        public StateSelectComponent Current { get { return m_current ? m_current : throw new ArgumentException("Value not specified."); } }

        private StateSelectComponent m_current;

        protected override void OnApply(int index)
        {
            if (m_current != null)
            {
                m_current.Apply(false);
            }

            m_current = States[index];
            m_current.Apply(true);
        }

        protected override async Task OnApplyAsync(int index)
        {
            if (m_current != null)
            {
                await m_current.ApplyAsync(false);
            }

            m_current = States[index];

            await m_current.ApplyAsync(true);
        }
    }
}
