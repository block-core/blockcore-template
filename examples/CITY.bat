chcp 65001
dotnet new blockcorecoin ^
--output City ^
--cointicker CITY ^
--magic "01-59-54-43" ^
--cointype 1926 ^
--pubkeyaddress 28 ^
--scriptaddress 88 ^
--secretaddress 237 ^
--pow-reward 2 ^
--pos-reward 20 ^
--pos-timestamp-mask "0000000F" ^
--pos-version 3 ^
--premine-reward 13736000000 ^
--port 4333 ^
--rpcport 4334 ^
--apiport 4335 ^
--wsport 4336 ^
--target-spacing 60 ^
--lastpowblock 2500 ^
--seeddns1 "seed.city-chain.org" ^
--seeddns2 "seed.citychain.foundation" ^
--seednode1 "23.97.234.230" ^
--seednode2 "13.73.143.193" ^
--genesistext "July 27, 2018, New Scientiest, Bitcoin’s roots are in anarcho-capitalism" ^
--genesis-time-main 1538481600 ^
--genesis-nonce-main 1626464 ^
--genesis-bits-main "1E0FFFFF" ^
--genesis-block-hash-main "00000b0517068e602ed5279c20168cfa1e69884ee4e784909652da34c361bff2" ^
--genesis-merkle-hash-main "b3425d46594a954b141898c7eebe369c6e6a35d2dab393c1f495504d2147883b" ^
--genesis-time-regtest 1587115302 ^
--genesis-nonce-regtest 5917 ^
--genesis-bits-regtest "1F00FFFF" ^
--genesis-block-hash-regtest "000039df5f7c79084bf96c67ea24761e177d77c24f326eb5294860144301cb68" ^
--genesis-merkle-hash-regtest "d382311c9e4a1ec84be1b32eddb33f7f0420544a460754f573d7cb7054566d75" ^
--genesis-time-test 1587115303 ^
--genesis-nonce-test 3451 ^
--genesis-bits-test "1F0FFFFF" ^
--genesis-block-hash-test "00090058f8a37e4190aa341ab9605d74b282f0c80983a676ac44b0689be0fae1" ^
--genesis-merkle-hash-test "88cd7db112380c4d6d4609372b04cdd56c4f82979b7c3bf8c8a764f19859961f" ^
--force