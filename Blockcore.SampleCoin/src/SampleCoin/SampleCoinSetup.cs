using System;
using System.Collections.Generic;
using Blockcore.Consensus.Checkpoints;
using Blockcore.SampleCoin.Networks;
using Blockcore.SampleCoin.Networks.Setup;
using NBitcoin;

namespace Blockcore.SampleCoin
{
   internal class SampleCoinSetup
   {
      internal static SampleCoinSetup Instance = new SampleCoinSetup();

      internal CoinSetup Setup = new CoinSetup
      {
         FileNamePrefix = "samplecoin",
         ConfigFileName = "samplecoin.conf",
         Magic = "02-4B-4C-42",
         CoinType = 1981, // SLIP-0044: https://github.com/satoshilabs/slips/blob/master/slip-0044.md,
         PremineReward = 5000000,
         PoWBlockReward = 4545,
         PoSBlockReward = 5555,
         LastPowBlock = 12500,
         GenesisText = "SALES AT U.S. STORES HIT CATASTROPHIC DEPTHS", // The New York Times, 2020-04-16
         TargetSpacing = TimeSpan.FromSeconds(10 * 60),
         ProofOfStakeTimestampMask = 0x0000000F, // 0x0000003F // 64 sec
         PoSVersion = 4444
      };

      internal NetworkSetup Main = new NetworkSetup
      {
         Name = "SampleCoinMain",
         RootFolderName = "samplecoin",
         CoinTicker = "BLC",
         DefaultPort = 10003,
         DefaultRPCPort = 10001,
         DefaultAPIPort = 10002,
         PubKeyAddress = 222, // B https://en.bitcoin.it/wiki/List_of_address_prefixes
         ScriptAddress = 223, // b
         SecretAddress = 224,
         GenesisTime = 1587118902,
         GenesisNonce = 631024,
         GenesisBits = 0x1E0FFFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "00000e8a284c34a684bde165d213f45b4a945a6c15118341d10f9616444dd140",
         HashMerkleRoot = "55e4f7372f1be36fa85860ccb7eb7623c28c0ec8dd348125bba20681b3cb0249",
         DNS = new[] { "seed1.blc.blockcore.net", "seed2.blc.blockcore.net", "blc.seed.blockcore.net" },
         Nodes = new[] { "89.10.227.34", "::1" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      internal NetworkSetup RegTest = new NetworkSetup
      {
         Name = "SampleCoinRegTest",
         RootFolderName = "samplecoinregtest",
         CoinTicker = "TBLC",
         DefaultPort = 20000,
         DefaultRPCPort = 20001,
         DefaultAPIPort = 20002,
         PubKeyAddress = 111,
         ScriptAddress = 196,
         SecretAddress = 239,
         GenesisTime = 1587118950,
         GenesisNonce = 41450,
         GenesisBits = 0x1F00FFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "00008af47a491ddf7251cc05cd48f0272a9cfad8540de9400ea0506850f5ed93",
         HashMerkleRoot = "344960deee772f2b6f8cdc5f6fe86e0fe3146f43430849d8ca5b9b851bdcc58c",
         DNS = new[] { "seedregtest1.blc.blockcore.net", "seedregtest2.blc.blockcore.net", "seedregtest.blc.blockcore.net" },
         Nodes = new[] { "89.10.227.34", "::1" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      internal NetworkSetup Test = new NetworkSetup
      {
         Name = "SampleCoinTest",
         RootFolderName = "samplecointest",
         CoinTicker = "TBLC",
         DefaultPort = 30000,
         DefaultRPCPort = 30001,
         DefaultAPIPort = 30002,
         PubKeyAddress = 111,
         ScriptAddress = 196,
         SecretAddress = 239,
         GenesisTime = 1587118953,
         GenesisNonce = 4834,
         GenesisBits = 0x1F0FFFFF,
         GenesisVersion = 1,
         GenesisReward = Money.Zero,
         HashGenesisBlock = "0009066a2c5b01b1b5ecb41267ce79a94954b75a5906a83221c587428f1e0bcd",
         HashMerkleRoot = "7d197d7cf32b63e01b1cf0279b5d3c8ed733770284554881038d253b6c34b3a8",
         DNS = new[] { "seedtest1.blc.blockcore.net", "seedtest2.blc.blockcore.net", "seedtest.blc.blockcore.net" },
         Nodes = new[] { "89.10.227.34", "::1" },
         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
            // TODO: Add checkpoints as the network progresses.
         }
      };

      public bool IsPoSv3()
      {
         return Setup.PoSVersion == 3;
      }

      public bool IsPoSv4()
      {
         return Setup.PoSVersion == 4;
      }
   }
}
