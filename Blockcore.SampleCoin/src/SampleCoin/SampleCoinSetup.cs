using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBitcoin;

namespace Blockcore.SampleCoin
{
   public class SampleCoinSetup
   {
      public const string FileNamePrefix = "samplecoin";
      public const string ConfigFileName = "samplecoin.conf";
      public const string Magic = "02-4B-4C-42";
      public const int CoinType = 1981; // SLIP-0044: https://github.com/satoshilabs/slips/blob/master/slip-0044.md
      public const decimal PremineReward = 5000000;
      public const decimal BlockReward = 45;
      public const int LastPowBlock = 12500;
      public const string GenesisText = "SALES AT U.S. STORES HIT CATASTROPHIC DEPTHS"; // The New York Times, 2020-04-16

      public class Main {
         public const string Name = "SampleCoinMain";
         public const string RootFolderName = "SampleCoin";
         public const string CoinTicker = "BLC";
         public const int DefaultPort = 9333;
         public const int DefaultRPCPort = 9332;
         public const int DefaultAPIPort = 9331;
         public const int DefaultSignalRPort = 9330;
         public const int PubKeyAddress = 26; // B https://en.bitcoin.it/wiki/List_of_address_prefixes
         public const int ScriptAddress = 85; // b

         public const uint GenesisTime = 1587084684;
         public const uint GenesisNonce = 796685;
         public const uint GenesisBits = 0x1E0FFFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "00000bfa445930bb5628f2b84bb31acd4ec689e1b6b8fb998c0ab6c32819feb8";
         public const string HashMerkleRoot = "6e0a689b55dd9b1acffefb2ff8fcae065b7212858c7353be8cb43654ccd01629";
      }

      public class RegTest
      {
         public const string Name = "SampleCoinRegTest";
         public const string RootFolderName = "SampleCoinRegTest";
         public const string CoinTicker = "TBLC";
         public const int DefaultPort = 19333;
         public const int DefaultRPCPort = 19332;
         public const int DefaultAPIPort = 19331;
         public const int DefaultSignalRPort = 19330;
         public const int PubKeyAddress = 111;
         public const int ScriptAddress = 196;

         public const uint GenesisTime = 1587084814;
         public const uint GenesisNonce = 45048;
         public const uint GenesisBits = 0x1F00FFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "000001c15a6605c287f21cf1d071bfc7d5924601885712317259ecd28b85b845";
         public const string HashMerkleRoot = "2bc0ebbc2c3065e2a9864b5bcf49ec6c4e20d84fbd10c70c044453e19395f500";
      }

      public class Test
      {
         public const string Name = "SampleCoinTest";
         public const string RootFolderName = "SampleCoinTest";
         public const string CoinTicker = "TBLC";
         public const int DefaultPort = 29333;
         public const int DefaultRPCPort = 29332;
         public const int DefaultAPIPort = 29331;
         public const int DefaultSignalRPort = 29330;
         public const int PubKeyAddress = 111;
         public const int ScriptAddress = 196;

         public const uint GenesisTime = 1587084821;
         public const uint GenesisNonce = 455;
         public const uint GenesisBits = 0x1F0FFFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "00000bfa445930bb5628f2b84bb31acd4ec689e1b6b8fb998c0ab6c32819feb8";
         public const string HashMerkleRoot = "6e0a689b55dd9b1acffefb2ff8fcae065b7212858c7353be8cb43654ccd01629";
      }
   }
}
