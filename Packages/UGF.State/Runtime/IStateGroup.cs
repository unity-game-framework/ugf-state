using System.Collections.Generic;

namespace UGF.State.Runtime
{
    public interface IStateGroup : IState
    {
        IReadOnlyList<IState> States { get; }

        void Add(IState state);
        bool Remove(IState state);
        void Remove(int index);
        void Clear();
    }
}
