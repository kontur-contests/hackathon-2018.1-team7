namespace GameLogic.Strategies
{
    using System.Collections;
    using System.Collections.Generic;

    internal sealed class StrategySet : IEnumerable<IStrategy>
    {
        private readonly IStrategy[] _strategies;

        public StrategySet(params IStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public IEnumerator<IStrategy> GetEnumerator()
        {
            return (_strategies as IList<IStrategy>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
