
namespace TicTac.Calculator
{
    public interface ICommand
    {
        void Set(int leftInput); 
        void Execute();
    }
}
