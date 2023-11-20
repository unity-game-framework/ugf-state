using System;
using UnityEngine;

namespace UGF.State.Runtime
{
    [Serializable]
    public class StateSelect : State<StateComponent>
    {
        [SerializeField] private int m_stateIndex;

        public int StateIndex { get { return m_stateIndex; } set { m_stateIndex = value; } }

        protected override void OnApply()
        {
            Target.Apply(m_stateIndex);
        }
    }
}
