using NBitcoin;

namespace BlockcoreSampleCoin.Networks
{
    public static class Networks
    {
        public static NetworksSelector Bsc
        {
            get
            {
                return new NetworksSelector(() => new BscMain(), () => new BscTest(), () => new BscRegTest());
            }
        }
    }
}
