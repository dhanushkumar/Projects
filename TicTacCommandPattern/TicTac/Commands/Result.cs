
namespace TicTac.Calculator
{
    /// <summary>
    /// Returns processed result
    /// </summary>
    public class Result: INumber
    {
        /// <summary>
        /// Alias based on the logic
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// value of left devisible number
        /// </summary>
        public int Value { get; set; }
    }
}
