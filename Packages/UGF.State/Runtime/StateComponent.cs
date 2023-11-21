using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    public abstract class StateComponent : MonoBehaviour, IState
    {
        public bool IsValid()
        {
            return OnIsValid();
        }

        public void Apply()
        {
            if (!IsValid()) throw new InvalidOperationException("State is invalid and can not be applied.");

            OnApply();
        }

        public Task ApplyAsync()
        {
            if (!IsValid()) throw new InvalidOperationException("State is invalid and can not be applied.");

            return OnApplyAsync();
        }

        protected virtual bool OnIsValid()
        {
            return true;
        }

        protected abstract void OnApply();

        protected virtual Task OnApplyAsync()
        {
            OnApply();

            return Task.CompletedTask;
        }
    }
}
