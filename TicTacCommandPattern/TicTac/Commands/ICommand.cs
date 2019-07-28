
namespace TicTac.Calculator
{
    public interface ICommand: IIterationJob
    {
        void Execute();
        ICommand Accept(INumber input);
    }
}
