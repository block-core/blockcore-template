using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockcore.SampleCoin.Networks
{
   public class SampleCoinSetup
   {
      public const string FileNamePrefix = "samplecoin";
      public const string ConfigFileName = "samplecoin.conf";
      public const string Magic = "02-4B-4C-42";
      public const int CoinType = 1981; // SLIP-0044: https://github.com/satoshilabs/slips/blob/master/slip-0044.md
      public const int PubKeyAddress = 26; // B https://en.bitcoin.it/wiki/List_of_address_prefixes
      public const int ScriptAddress = 85; // b
      public const decimal PremineReward = 5000000;
      public const decimal BlockReward = 45;

      public class Main {
         public const string Name = "SampleCoinMain";
         public const string RootFolderName = "SampleCoin";
         public const string CoinTicker = "XSC";
         public const int DefaultPort = 9333;
         public const int DefaultRPCPort = 9332;
         public const int DefaultAPIPort = 9331;
         public const int DefaultSignalRPort = 9330;
      }

      public class RegTest
      {
         public const string Name = "SampleCoinRegTest";
         public const string RootFolderName = "SampleCoinRegTest";
         public const string CoinTicker = "TXSC";
         public const int DefaultPort = 19333;
         public const int DefaultRPCPort = 19332;
         public const int DefaultAPIPort = 19331;
         public const int DefaultSignalRPort = 19330;
      }

      public class Test
      {
         public const string Name = "SampleCoinTest";
         public const string RootFolderName = "SampleCoinTest";
         public const string CoinTicker = "TXSC";
         public const int DefaultPort = 29333;
         public const int DefaultRPCPort = 29332;
         public const int DefaultAPIPort = 29331;
         public const int DefaultSignalRPort = 29330;
      }
   }
}
