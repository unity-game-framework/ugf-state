using UnityEngine;

namespace UGF.State.Runtime.Misc
{
    [AddComponentMenu("Unity Game Framework/States/Misc/GameObject State", 2000)]
    public class GameObjectStateComponent : StateComponent<GameObject>
    {
        [SerializeField] private bool m_active;

        public bool Active { get { return m_active; } set { m_active = value; } }

        protected override void OnApply()
        {
            Target.SetActive(m_active);
        }
    }
}
