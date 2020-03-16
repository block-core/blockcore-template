using NBitcoin;

namespace Blockcore.SampleCoin.Networks
{
    public static class Networks
    {
        public static NetworksSelector SampleCoin
        {
            get
            {
                return new NetworksSelector(() => new SampleCoinMain(), () => new SampleCoinTest(), () => new SampleCoinRegTest());
            }
        }
    }
}
