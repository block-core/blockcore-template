using System;
using System.Collections.Generic;
using System.Net;
using Blockcore.SampleCoin.Networks.Deployments;
using Blockcore.SampleCoin.Networks.Policies;
using NBitcoin;
using NBitcoin.BouncyCastle.Math;
using NBitcoin.DataEncoders;
using NBitcoin.Protocol;

namespace Blockcore.SampleCoin.Networks
{
   public class SampleCoinTest : SampleCoinMain
   {
      public SampleCoinTest()
      {
         NetworkType = NetworkType.Testnet;

         Name = SampleCoinSetup.Test.Name;
         CoinTicker = SampleCoinSetup.Test.CoinTicker;
         Magic = ConversionTools.ConvertToUInt32(SampleCoinSetup.Magic, true);
         RootFolderName = SampleCoinSetup.Test.RootFolderName;
         DefaultPort = SampleCoinSetup.Test.DefaultPort;
         DefaultRPCPort = SampleCoinSetup.Test.DefaultRPCPort;
         DefaultAPIPort = SampleCoinSetup.Test.DefaultAPIPort;
         DefaultSignalRPort = SampleCoinSetup.Test.DefaultSignalRPort;

         var consensusFactory = new PosConsensusFactory();

         Block genesisBlock = CreateGenesisBlock(consensusFactory,
            SampleCoinSetup.Test.GenesisTime,
            SampleCoinSetup.Test.GenesisNonce,
            SampleCoinSetup.Test.GenesisBits,
            SampleCoinSetup.Test.GenesisVersion,
            SampleCoinSetup.Test.GenesisReward,
            SampleCoinSetup.GenesisText);

         Genesis = genesisBlock;

         // Taken from StratisX.
         var consensusOptions = new PosConsensusOptions(
             maxBlockBaseSize: 1_000_000,
             maxStandardVersion: 2,
             maxStandardTxWeight: 100_000,
             maxBlockSigopsCost: 20_000,
             maxStandardTxSigopsCost: 20_000 / 5,
             witnessScaleFactor: 4
         );

         var buriedDeployments = new BuriedDeploymentsArray
         {
            [BuriedDeployments.BIP34] = 0,
            [BuriedDeployments.BIP65] = 0,
            [BuriedDeployments.BIP66] = 0
         };

         var bip9Deployments = new SampleCoinBIP9Deployments()
         {
            [SampleCoinBIP9Deployments.TestDummy] = new BIP9DeploymentsParameters("TestDummy", 28,
                 new DateTime(2019, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultTestnetThreshold),

            [SampleCoinBIP9Deployments.CSV] = new BIP9DeploymentsParameters("CSV", 0,
                 new DateTime(2019, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultTestnetThreshold),

            [SampleCoinBIP9Deployments.Segwit] = new BIP9DeploymentsParameters("Segwit", 1,
                 new DateTime(2019, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultTestnetThreshold),

            [SampleCoinBIP9Deployments.ColdStaking] = new BIP9DeploymentsParameters("ColdStaking", 2,
                 new DateTime(2018, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2019, 6, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultTestnetThreshold)
         };

         Consensus = new NBitcoin.Consensus(
             consensusFactory: consensusFactory,
             consensusOptions: consensusOptions,
             coinType: SampleCoinSetup.CoinType,
             hashGenesisBlock: genesisBlock.GetHash(),
             subsidyHalvingInterval: 210000,
             majorityEnforceBlockUpgrade: 750,
             majorityRejectBlockOutdated: 950,
             majorityWindow: 1000,
             buriedDeployments: buriedDeployments,
             bip9Deployments: bip9Deployments,
             bip34Hash: null, // new uint256("0x000000000000024b89b42a942fe0d9fea3bb44ab7bd1b19115dd6a759c0808b8"),
             minerConfirmationWindow: 2016, // nPowTargetTimespan / nPowTargetSpacing
             maxReorgLength: 500,
             defaultAssumeValid: null, // new uint256("0x690e7e30ae3fa6c10855db0f8bc10110a54f5c73019f5581ee038186154397d0"), // 1100000
             maxMoney: long.MaxValue,
             coinbaseMaturity: 10,
             premineHeight: 2,
             premineReward: Money.Coins(SampleCoinSetup.PremineReward),
             proofOfWorkReward: Money.Coins(SampleCoinSetup.PoWBlockReward),
             targetTimespan: TimeSpan.FromSeconds(14 * 24 * 60 * 60), // two weeks
             targetSpacing: SampleCoinSetup.TargetSpacing,
             powAllowMinDifficultyBlocks: false,
             posNoRetargeting: false,
             powNoRetargeting: false,
             powLimit: new Target(new uint256("000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
             minimumChainWork: null,
             isProofOfStake: true,
             lastPowBlock: SampleCoinSetup.LastPowBlock,
             proofOfStakeLimit: new BigInteger(uint256.Parse("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeLimitV2: new BigInteger(uint256.Parse("000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeReward: Money.Coins(SampleCoinSetup.PoSBlockReward),
             proofOfStakeTimestampMask: SampleCoinSetup.ProofOfStakeTimestampMask
         );

         Consensus.PosEmptyCoinbase = true;

         Base58Prefixes[(int)Base58Type.PUBKEY_ADDRESS] = new byte[] { (SampleCoinSetup.RegTest.PubKeyAddress) };
         Base58Prefixes[(int)Base58Type.SCRIPT_ADDRESS] = new byte[] { (SampleCoinSetup.RegTest.ScriptAddress) };
         Base58Prefixes[(int)Base58Type.SECRET_KEY] = new byte[] { (239) };
         Base58Prefixes[(int)Base58Type.EXT_PUBLIC_KEY] = new byte[] { (0x04), (0x35), (0x87), (0xCF) };
         Base58Prefixes[(int)Base58Type.EXT_SECRET_KEY] = new byte[] { (0x04), (0x35), (0x83), (0x94) };
         Base58Prefixes[(int)Base58Type.STEALTH_ADDRESS] = new byte[] { 0x2b };
         Base58Prefixes[(int)Base58Type.ASSET_ID] = new byte[] { 115 };

         Bech32Encoders = new Bech32Encoder[2];
         var encoder = new Bech32Encoder(SampleCoinSetup.RegTest.CoinTicker);
         Bech32Encoders[(int)Bech32Type.WITNESS_PUBKEY_ADDRESS] = encoder;
         Bech32Encoders[(int)Bech32Type.WITNESS_SCRIPT_ADDRESS] = encoder;

         Checkpoints = SampleCoinSetup.Test.Checkpoints;
         DNSSeeds = SampleCoinSetup.Test.DNS;
         SeedNodes = SampleCoinSetup.Test.Nodes;

         StandardScriptsRegistry = new SampleCoinStandardScriptsRegistry();

         // 64 below should be changed to TargetSpacingSeconds when we move that field.
         Assert(DefaultBanTimeSeconds <= Consensus.MaxReorgLength * 64 / 2);

         // TODO: update RHS to match HashGenesisBlock
         Assert(Consensus.HashGenesisBlock == uint256.Parse("0x00000e246d7b73b88c9ab55f2e5e94d9e22d471def3df5ea448f5576b1d156b9"));

         RegisterRules(Consensus);
         RegisterMempoolRules(Consensus);
      }
   }
}
