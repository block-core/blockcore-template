using System;
using System.Collections.Generic;
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
         // The message start string is designed to be unlikely to occur in normal data.
         // The characters are rarely used upper ASCII, not valid as UTF-8, and produce
         // a large 4-byte int at any alignment.
         byte[] messageStart = new byte[4];
         messageStart[0] = 0x71;
         messageStart[1] = 0x31;
         messageStart[2] = 0x21;
         messageStart[3] = 0x11;
         uint magic = BitConverter.ToUInt32(messageStart, 0); // 0x11213171;

         Name = "SampleCoinTest";
         NetworkType = NetworkType.Testnet;
         Magic = magic;

         CoinTicker = "TXSC";

         // TODO: set your ports and defaults
         DefaultPort = 26178;
         DefaultMaxOutboundConnections = 16;
         DefaultMaxInboundConnections = 109;
         DefaultRPCPort = 26174;
         DefaultAPIPort = 38221;
         DefaultSignalRPort = 39824;
         DefaultBanTimeSeconds = 16000; // 500 (MaxReorg) * 64 (TargetSpacing) / 2 = 4 hours, 26 minutes and 40 seconds

         var powLimit = new Target(new uint256("0000ffff00000000000000000000000000000000000000000000000000000000"));

         var consensusFactory = new PosConsensusFactory();

         // Create the genesis block.
         GenesisTime = 1470467000;
         GenesisNonce = 1831645;
         GenesisBits = 0x1e0fffff;
         GenesisVersion = 1;
         GenesisReward = Money.Zero;

         Block genesisBlock = CreateGenesisBlock(consensusFactory, GenesisTime, GenesisNonce, GenesisBits, GenesisVersion, GenesisReward);

         genesisBlock.Header.Time = 1493909211;
         genesisBlock.Header.Nonce = 2433759;
         genesisBlock.Header.Bits = powLimit;

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
             coinType: 105,
             hashGenesisBlock: genesisBlock.GetHash(),
             subsidyHalvingInterval: 210000,
             majorityEnforceBlockUpgrade: 750,
             majorityRejectBlockOutdated: 950,
             majorityWindow: 1000,
             buriedDeployments: buriedDeployments,
             bip9Deployments: bip9Deployments,
             bip34Hash: new uint256("0x000000000000024b89b42a942fe0d9fea3bb44ab7bd1b19115dd6a759c0808b8"),
             minerConfirmationWindow: 2016, // nPowTargetTimespan / nPowTargetSpacing
             maxReorgLength: 500,
             defaultAssumeValid: new uint256("0x690e7e30ae3fa6c10855db0f8bc10110a54f5c73019f5581ee038186154397d0"), // 1100000
             maxMoney: long.MaxValue,
             coinbaseMaturity: 10,
             premineHeight: 2,
             premineReward: Money.Coins(98000000),
             proofOfWorkReward: Money.Coins(4),
             targetTimespan: TimeSpan.FromSeconds(14 * 24 * 60 * 60), // two weeks
             targetSpacing: TimeSpan.FromSeconds(64),
             powAllowMinDifficultyBlocks: false,
             posNoRetargeting: false,
             powNoRetargeting: false,
             powLimit: powLimit,
             minimumChainWork: null,
             isProofOfStake: true,
             lastPowBlock: 12500,
             proofOfStakeLimit: new BigInteger(uint256.Parse("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeLimitV2: new BigInteger(uint256.Parse("000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffff").ToBytes(false)),
             proofOfStakeReward: Money.COIN,
             proofOfStakeTimestampMask: 0x0000003F // 64 sec
         );

         Consensus.PosEmptyCoinbase = true;

         // TODO: Set your Base58Prefixes
         Base58Prefixes[(int)Base58Type.PUBKEY_ADDRESS] = new byte[] { (65) };
         Base58Prefixes[(int)Base58Type.SCRIPT_ADDRESS] = new byte[] { (196) };
         Base58Prefixes[(int)Base58Type.SECRET_KEY] = new byte[] { (65 + 128) };

         Bech32Encoders = new Bech32Encoder[2];
         var encoder = new Bech32Encoder("TXSC");
         Bech32Encoders[(int)Bech32Type.WITNESS_PUBKEY_ADDRESS] = encoder;
         Bech32Encoders[(int)Bech32Type.WITNESS_SCRIPT_ADDRESS] = encoder;

         Checkpoints = new Dictionary<int, CheckpointInfo>
         {
         };

         DNSSeeds = new List<DNSSeedData>
         {
            // TODO: Add DNS seeds here
            // new DNSSeedData("X.SampleCoin.com", "X.SampleCoin.com"),
         };

         SeedNodes = new List<NetworkAddress>
         {
            // TODO: Add seed nodes here
            // new NetworkAddress(IPAddress.Parse("X.X.X.X"), 16178), 
         };

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
