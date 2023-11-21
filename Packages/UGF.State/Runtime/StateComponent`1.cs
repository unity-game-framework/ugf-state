using UnityEngine;

namespace UGF.State.Runtime
{
    public abstract class StateComponent<TTarget> : StateComponent where TTarget : Object
    {
        [SerializeField] private TTarget m_target;

        public TTarget Target { get { return m_target; } set { m_target = value; } }

        protected override bool OnIsValid()
        {
            return m_target != null;
        }
    }
}
