using System.Threading.Tasks;

namespace UGF.State.Runtime
{
    public interface IStateSelect : IStateGroup
    {
        int DefaultStateIndex { get; }

        IState GetDefaultState();
        void Apply(bool state);
        void Apply(int index);
        Task ApplyAsync(bool state);
        Task ApplyAsync(int index);
        void Revert();
        Task RevertAsync();
    }
}
