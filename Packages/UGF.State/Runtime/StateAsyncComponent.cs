﻿using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UGF.State.Runtime
{
    public abstract class StateAsyncComponent : MonoBehaviour, IState
    {
        public bool IsValid()
        {
            return OnIsValid();
        }

        public async void Apply()
        {
            if (!IsValid()) throw new InvalidOperationException("State is invalid and can not be applied.");

            await OnApplyAsync();
        }

        public Task ApplyAsync()
        {
            if (!IsValid()) throw new InvalidOperationException("State is invalid and can not be applied.");

            return OnApplyAsync();
        }

        protected abstract bool OnIsValid();
        protected abstract Task OnApplyAsync();
    }
}
