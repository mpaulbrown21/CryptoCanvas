using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Contracts.Contracts.Party.ContractDefinition;

namespace Contracts.Contracts.Party
{
    public partial class PartyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PartyDeployment partyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PartyDeployment>().SendRequestAndWaitForReceiptAsync(partyDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PartyDeployment partyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PartyDeployment>().SendRequestAsync(partyDeployment);
        }

        public static async Task<PartyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PartyDeployment partyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, partyDeployment, cancellationTokenSource);
            return new PartyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PartyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte> InitialRewardQueryAsync(InitialRewardFunction initialRewardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<InitialRewardFunction, byte>(initialRewardFunction, blockParameter);
        }

        
        public Task<byte> InitialRewardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<InitialRewardFunction, byte>(null, blockParameter);
        }

        public Task<byte> LongTermRewardQueryAsync(LongTermRewardFunction longTermRewardFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LongTermRewardFunction, byte>(longTermRewardFunction, blockParameter);
        }

        
        public Task<byte> LongTermRewardQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LongTermRewardFunction, byte>(null, blockParameter);
        }

        public Task<string> RewardAddressQueryAsync(RewardAddressFunction rewardAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardAddressFunction, string>(rewardAddressFunction, blockParameter);
        }

        
        public Task<string> RewardAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardAddressFunction, string>(null, blockParameter);
        }
    }
}
