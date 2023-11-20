using System;
using UnityEngine;

namespace UGF.State.Runtime.Misc
{
    [Serializable]
    public class GameObjectState : State<GameObject>
    {
        [SerializeField] private bool m_active;

        public bool Active { get { return m_active; } set { m_active = value; } }

        protected override void OnApply()
        {
            Target.SetActive(m_active);
        }
    }
}
