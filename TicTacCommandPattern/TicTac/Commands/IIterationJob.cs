
namespace TicTac.Calculator
{
    public interface IIterationJob
    {
        void SetIterations(int iterations);
        int Iterations { get; }
        int CurrentIteration {  set; }
     
    }
}
