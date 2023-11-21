using System.Threading.Tasks;

namespace UGF.State.Runtime
{
    public interface IState
    {
        bool IsValid();
        void Apply();
        Task ApplyAsync();
    }
}
