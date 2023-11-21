using UnityEngine;

namespace UGF.State.Runtime.Misc
{
    [AddComponentMenu("Unity Game Framework/States/Misc/Behaviour State", 2000)]
    public class BehaviourStateComponent : StateComponent<Behaviour>
    {
        [SerializeField] private bool m_enabled;

        public bool Enabled { get { return m_enabled; } set { m_enabled = value; } }

        protected override void OnApply()
        {
            Target.enabled = m_enabled;
        }
    }
}
