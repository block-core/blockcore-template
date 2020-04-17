using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NBitcoin;
using NBitcoin.Protocol;

namespace Blockcore.SampleCoin
{
   public class SampleCoinSetup
   {
      public const string FileNamePrefix = "samplecoin";
      public const string ConfigFileName = "samplecoin.conf";
      public const string Magic = "02-4B-4C-42";
      public const int CoinType = 1981; // SLIP-0044: https://github.com/satoshilabs/slips/blob/master/slip-0044.md
      public const decimal PremineReward = 5000000;
      public const decimal PoWBlockReward = 4545;
      public const decimal PoSBlockReward = 5555;
      public const int LastPowBlock = 12500;
      public const string GenesisText = "SALES AT U.S. STORES HIT CATASTROPHIC DEPTHS"; // The New York Times, 2020-04-16
      public static TimeSpan TargetSpacing = TimeSpan.FromSeconds(10 * 60);
      public const uint ProofOfStakeTimestampMask = 0x0000000F; // 0x0000003F // 64 sec
      public const int PoSVersion = 4444;

      public class Main
      {
         public const string Name = "SampleCoinMain";
         public const string RootFolderName = "SampleCoin";
         public const string CoinTicker = "BLC";
         public const int DefaultPort = 9333;
         public const int DefaultRPCPort = 9332;
         public const int DefaultAPIPort = 9331;
         public const int DefaultSignalRPort = 9330;
         public const int PubKeyAddress = 222; // B https://en.bitcoin.it/wiki/List_of_address_prefixes
         public const int ScriptAddress = 223; // b
         public const int SecretAddress = 224;

         public const uint GenesisTime = 1587118902;
         public const uint GenesisNonce = 631024;
         public const uint GenesisBits = 0x1E0FFFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "00000e8a284c34a684bde165d213f45b4a945a6c15118341d10f9616444dd140";
         public const string HashMerkleRoot = "55e4f7372f1be36fa85860ccb7eb7623c28c0ec8dd348125bba20681b3cb0249";

         public static List<DNSSeedData> DNS = new List<DNSSeedData>
         {
            // TODO: Add additional DNS seeds here
            new DNSSeedData("seed1.blc.blockcore.net", "seed1.blc.blockcore.net"),
            new DNSSeedData("seed2.blc.blockcore.net", "seed2.blc.blockcore.net"),
            new DNSSeedData("seed.blc.blockcore.net", "seed.blc.blockcore.net"),
         };

         public static List<NetworkAddress> Nodes = new List<NetworkAddress>
         {
            // TODO: Add additional seed nodes here
            new NetworkAddress(IPAddress.Parse("89.10.227.34"), SampleCoinSetup.Test.DefaultPort),
            new NetworkAddress(IPAddress.Parse("::1"), SampleCoinSetup.Test.DefaultPort),
         };

         public static Dictionary<int, CheckpointInfo> Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         };
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
         public const int SecretAddress = 239;

         public const uint GenesisTime = 1587118950;
         public const uint GenesisNonce = 41450;
         public const uint GenesisBits = 0x1F00FFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "00008af47a491ddf7251cc05cd48f0272a9cfad8540de9400ea0506850f5ed93";
         public const string HashMerkleRoot = "344960deee772f2b6f8cdc5f6fe86e0fe3146f43430849d8ca5b9b851bdcc58c";

         public static List<DNSSeedData> DNS = new List<DNSSeedData>
         {
            // TODO: Add additional DNS seeds here
            new DNSSeedData("seedregtest1.blc.blockcore.net", "seedregtest1.blc.blockcore.net"),
            new DNSSeedData("seedregtest2.blc.blockcore.net", "seedregtest2.blc.blockcore.net"),
            new DNSSeedData("seedregtest.blc.blockcore.net", "seedregtest.blc.blockcore.net"),
         };

         public static List<NetworkAddress> Nodes = new List<NetworkAddress>
         {
            // TODO: Add additional seed nodes here
            new NetworkAddress(IPAddress.Parse("89.10.227.34"), SampleCoinSetup.Test.DefaultPort),
            new NetworkAddress(IPAddress.Parse("::1"), SampleCoinSetup.Test.DefaultPort),
         };

         public static Dictionary<int, CheckpointInfo> Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         };
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
         public const int SecretAddress = 239;

         public const uint GenesisTime = 1587118953;
         public const uint GenesisNonce = 4834;
         public const uint GenesisBits = 0x1F0FFFFF;
         public const int GenesisVersion = 1;
         public static Money GenesisReward = Money.Zero;
         public const string HashGenesisBlock = "0009066a2c5b01b1b5ecb41267ce79a94954b75a5906a83221c587428f1e0bcd";
         public const string HashMerkleRoot = "7d197d7cf32b63e01b1cf0279b5d3c8ed733770284554881038d253b6c34b3a8";

         public static List<DNSSeedData> DNS = new List<DNSSeedData>
         {
            // TODO: Add additional DNS seeds here
            new DNSSeedData("seedtest1.blc.blockcore.net", "seedtest1.blc.blockcore.net"),
            new DNSSeedData("seedtest2.blc.blockcore.net", "seedtest2.blc.blockcore.net"),
            new DNSSeedData("seedtest.blc.blockcore.net", "seedtest.blc.blockcore.net"),
         };

         public static List<NetworkAddress> Nodes = new List<NetworkAddress>
         {
            // TODO: Add additional seed nodes here
            new NetworkAddress(IPAddress.Parse("89.10.227.34"), SampleCoinSetup.Test.DefaultPort),
            new NetworkAddress(IPAddress.Parse("::1"), SampleCoinSetup.Test.DefaultPort),
         };

         public static Dictionary<int, CheckpointInfo> Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         };
      }

      public static bool IsPoSv3()
      {
         return PoSVersion == 3;
      }

      public static bool IsPoSv4()
      {
         return PoSVersion == 4;
      }
   }
}
