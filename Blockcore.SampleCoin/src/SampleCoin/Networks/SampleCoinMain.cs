using System;
using System.Collections.Generic;
using System.Net;
using Blockcore.Features.Consensus.Rules.CommonRules;
using Blockcore.Features.Consensus.Rules.ProvenHeaderRules;
using Blockcore.Features.Consensus.Rules.UtxosetRules;
using Blockcore.Features.MemoryPool.Rules;
using Blockcore.SampleCoin.Networks.Deployments;
using Blockcore.SampleCoin.Networks.Policies;
using Blockcore.SampleCoin.Networks.Rules;
using NBitcoin;
using NBitcoin.BouncyCastle.Math;
using NBitcoin.DataEncoders;
using NBitcoin.Protocol;

namespace Blockcore.SampleCoin.Networks
{
   public class SampleCoinMain : Network
   {
      public SampleCoinMain()
      {
         NetworkType = NetworkType.Mainnet;
         DefaultConfigFilename = SampleCoinSetup.ConfigFileName; // The default name used for the Blockcore.SampleCoin configuration file.

         Name = SampleCoinSetup.Main.Name;
         CoinTicker = SampleCoinSetup.Main.CoinTicker;
         Magic = ConversionTools.ConvertToUInt32(SampleCoinSetup.Magic);
         RootFolderName = SampleCoinSetup.Main.RootFolderName;
         DefaultPort = SampleCoinSetup.Main.DefaultPort;
         DefaultRPCPort = SampleCoinSetup.Main.DefaultRPCPort;
         DefaultAPIPort = SampleCoinSetup.Main.DefaultAPIPort;
         DefaultSignalRPort = SampleCoinSetup.Main.DefaultSignalRPort;

         DefaultMaxOutboundConnections = 16;
         DefaultMaxInboundConnections = 109;
         MaxTipAge = 2 * 60 * 60;
         MinTxFee = 10000;
         FallbackFee = 10000;
         MinRelayTxFee = 10000;
         MaxTimeOffsetSeconds = 25 * 60;
         DefaultBanTimeSeconds = 16000; // 500 (MaxReorg) * 64 (TargetSpacing) / 2 = 4 hours, 26 minutes and 40 seconds

         var consensusFactory = new PosConsensusFactory();

         Block genesisBlock = CreateGenesisBlock(consensusFactory,
            SampleCoinSetup.Main.GenesisTime,
            SampleCoinSetup.Main.GenesisNonce,
            SampleCoinSetup.Main.GenesisBits,
            SampleCoinSetup.Main.GenesisVersion,
            SampleCoinSetup.Main.GenesisReward,
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
                 new DateTime(2019, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultMainnetThreshold),

            [SampleCoinBIP9Deployments.CSV] = new BIP9DeploymentsParameters("CSV", 0,
                 new DateTime(2019, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultMainnetThreshold),

            [SampleCoinBIP9Deployments.Segwit] = new BIP9DeploymentsParameters("Segwit", 1,
                 new DateTime(2019, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultMainnetThreshold),

            [SampleCoinBIP9Deployments.ColdStaking] = new BIP9DeploymentsParameters("ColdStaking", 2,
                 new DateTime(2019, 12, 2, 0, 0, 0, DateTimeKind.Utc),
                 new DateTime(2020, 12, 2, 0, 0, 0, DateTimeKind.Utc),
                 BIP9DeploymentsParameters.DefaultMainnetThreshold)
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
             bip34Hash: null,
             minerConfirmationWindow: 2016, // nPowTargetTimespan / nPowTargetSpacing
             maxReorgLength: 500,
             defaultAssumeValid: null,
             maxMoney: long.MaxValue,
             coinbaseMaturity: 50,
             premineHeight: 2,
             premineReward: Money.Coins(SampleCoinSetup.PremineReward),
             proofOfWorkReward: Money.Coins(SampleCoinSetup.PoWBlockReward),
             targetTimespan: TimeSpan.FromSeconds(14 * 24 * 60 * 60), // two weeks
             targetSpacing: SampleCoinSetup.TargetSpacing,
             powAllowMinDifficultyBlocks: false,
             posNoRetargeting: false,
             powNoRetargeting: false,
             powLimit: new Target(new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
             minimumChainWork: null,
             isProofOfStake: true,
             lastPowBlock: SampleCoinSetup.LastPowBlock,
             proofOfStakeLimit: new BigInteger(uint256.Parse("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeLimitV2: new BigInteger(uint256.Parse("000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeReward: Money.Coins(SampleCoinSetup.PoSBlockReward),
             proofOfStakeTimestampMask: 0x0000003F // 64 sec
         );

         Consensus.PosEmptyCoinbase = true;

         // TODO: Set your Base58Prefixes
         Base58Prefixes = new byte[12][];
         Base58Prefixes[(int)Base58Type.PUBKEY_ADDRESS] = new byte[] { (SampleCoinSetup.Main.PubKeyAddress) };
         Base58Prefixes[(int)Base58Type.SCRIPT_ADDRESS] = new byte[] { (SampleCoinSetup.Main.ScriptAddress) };
         Base58Prefixes[(int)Base58Type.SECRET_KEY] = new byte[] { (SampleCoinSetup.Main.SecretAddress) };

         Base58Prefixes[(int)Base58Type.ENCRYPTED_SECRET_KEY_NO_EC] = new byte[] { 0x01, 0x42 };
         Base58Prefixes[(int)Base58Type.ENCRYPTED_SECRET_KEY_EC] = new byte[] { 0x01, 0x43 };
         Base58Prefixes[(int)Base58Type.EXT_PUBLIC_KEY] = new byte[] { (0x04), (0x88), (0xB2), (0x1E) };
         Base58Prefixes[(int)Base58Type.EXT_SECRET_KEY] = new byte[] { (0x04), (0x88), (0xAD), (0xE4) };
         Base58Prefixes[(int)Base58Type.PASSPHRASE_CODE] = new byte[] { 0x2C, 0xE9, 0xB3, 0xE1, 0xFF, 0x39, 0xE2 };
         Base58Prefixes[(int)Base58Type.CONFIRMATION_CODE] = new byte[] { 0x64, 0x3B, 0xF6, 0xA8, 0x9A };
         Base58Prefixes[(int)Base58Type.STEALTH_ADDRESS] = new byte[] { 0x2a };
         Base58Prefixes[(int)Base58Type.ASSET_ID] = new byte[] { 23 };
         Base58Prefixes[(int)Base58Type.COLORED_ADDRESS] = new byte[] { 0x13 };

         Bech32Encoders = new Bech32Encoder[2];
         var encoder = new Bech32Encoder(SampleCoinSetup.Main.CoinTicker);
         Bech32Encoders[(int)Bech32Type.WITNESS_PUBKEY_ADDRESS] = encoder;
         Bech32Encoders[(int)Bech32Type.WITNESS_SCRIPT_ADDRESS] = encoder;

         Checkpoints = SampleCoinSetup.Main.Checkpoints;
         DNSSeeds = SampleCoinSetup.Main.DNS;
         SeedNodes = SampleCoinSetup.Main.Nodes;

         StandardScriptsRegistry = new SampleCoinStandardScriptsRegistry();

         // 64 below should be changed to TargetSpacingSeconds when we move that field.
         Assert(DefaultBanTimeSeconds <= Consensus.MaxReorgLength * 64 / 2);

         // TODO: update RHS to match HashGenesisBlock & HashMerkleRoot
         Assert(Consensus.HashGenesisBlock == uint256.Parse(SampleCoinSetup.Main.HashGenesisBlock));
         Assert(Genesis.Header.HashMerkleRoot == uint256.Parse(SampleCoinSetup.Main.HashMerkleRoot));

         RegisterRules(Consensus);
         RegisterMempoolRules(Consensus);
      }

      protected void RegisterRules(IConsensus consensus)
      {
         consensus.ConsensusRules
             .Register<HeaderTimeChecksRule>()
             .Register<HeaderTimeChecksPosRule>()
             .Register<SampleCoinPosFutureDriftRule>()
             .Register<CheckDifficultyPosRule>()
             .Register<SampleCoinHeaderVersionRule>()
             .Register<ProvenHeaderSizeRule>()
             .Register<ProvenHeaderCoinstakeRule>();

         consensus.ConsensusRules
             .Register<BlockMerkleRootRule>()
             .Register<PosBlockSignatureRepresentationRule>()
             .Register<PosBlockSignatureRule>();

         consensus.ConsensusRules
             .Register<SetActivationDeploymentsPartialValidationRule>()
             .Register<PosTimeMaskRule>()

             // rules that are inside the method ContextualCheckBlock
             .Register<TransactionLocktimeActivationRule>()
             .Register<CoinbaseHeightActivationRule>()
             .Register<WitnessCommitmentsRule>()
             .Register<BlockSizeRule>()

             // rules that are inside the method CheckBlock
             .Register<EnsureCoinbaseRule>()
             .Register<CheckPowTransactionRule>()
             .Register<CheckPosTransactionRule>()
             .Register<CheckSigOpsRule>()
             .Register<PosCoinstakeRule>();

         consensus.ConsensusRules
             .Register<SetActivationDeploymentsFullValidationRule>()

             .Register<CheckDifficultyHybridRule>()

             // rules that require the store to be loaded (coinview)
             .Register<FetchUtxosetRule>()
             .Register<TransactionDuplicationActivationRule>()
             .Register<CheckPosUtxosetRule>() // implements BIP68, MaxSigOps and BlockReward calculation
                                              // Place the PosColdStakingRule after the PosCoinviewRule to ensure that all input scripts have been evaluated
                                              // and that the "IsColdCoinStake" flag would have been set by the OP_CHECKCOLDSTAKEVERIFY opcode if applicable.
             .Register<PosColdStakingRule>()
             .Register<PushUtxosetRule>();
      }

      protected void RegisterMempoolRules(IConsensus consensus)
      {
         consensus.MempoolRules = new List<Type>()
            {
                typeof(CheckConflictsMempoolRule),
                typeof(CheckCoinViewMempoolRule),
                typeof(CreateMempoolEntryMempoolRule),
                typeof(CheckSigOpsMempoolRule),
                typeof(CheckFeeMempoolRule),
                typeof(CheckRateLimitMempoolRule),
                typeof(CheckAncestorsMempoolRule),
                typeof(CheckReplacementMempoolRule),
                typeof(CheckAllInputsMempoolRule),
                typeof(CheckTxOutDustRule)
            };
      }

      protected static Block CreateGenesisBlock(ConsensusFactory consensusFactory, uint nTime, uint nNonce, uint nBits, int nVersion, Money genesisReward, string genesisText)
      {
         Transaction txNew = consensusFactory.CreateTransaction();
         txNew.Version = 1;

         if (txNew is IPosTransactionWithTime posTx)
         {
            posTx.Time = nTime;
         }

         txNew.AddInput(new TxIn()
         {
            ScriptSig = new Script(Op.GetPushOp(0), new Op()
            {
               Code = (OpcodeType)0x1,
               PushData = new[] { (byte)42 }
            }, Op.GetPushOp(Encoders.ASCII.DecodeData(genesisText)))
         });

         txNew.AddOutput(new TxOut()
         {
            Value = genesisReward,
         });

         Block genesis = consensusFactory.CreateBlock();
         genesis.Header.BlockTime = Utils.UnixTimeToDateTime(nTime);
         genesis.Header.Bits = nBits;
         genesis.Header.Nonce = nNonce;
         genesis.Header.Version = nVersion;
         genesis.Transactions.Add(txNew);
         genesis.Header.HashPrevBlock = uint256.Zero;
         genesis.UpdateMerkleRoot();

         return genesis;
      }
   }
}
