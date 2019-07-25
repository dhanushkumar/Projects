
namespace TicTac.Calculator
{
    public interface ICommand: IIterationJob
    {
        void Execute();
        void Accept(INumber input);
    }
}
