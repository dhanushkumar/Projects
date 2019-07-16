
namespace TicTac.Calculator
{
    public interface ICommand: IIterationJob
    {
        void Execute();
    }
}
