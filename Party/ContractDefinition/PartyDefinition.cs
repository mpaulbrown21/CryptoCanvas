using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.Contracts.Party.ContractDefinition
{


    public partial class PartyDeployment : PartyDeploymentBase
    {
        public PartyDeployment() : base(BYTECODE) { }
        public PartyDeployment(string byteCode) : base(byteCode) { }
    }

    public class PartyDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506040516101c43803806101c483398101604081905261002f9161008a565b600080546001600160a01b03949094166001600160a81b031990941693909317600160a01b60ff938416021760ff60a81b1916600160a81b91909216021790556100d9565b805160ff8116811461008557600080fd5b919050565b60008060006060848603121561009e578283fd5b83516001600160a01b03811681146100b4578384fd5b92506100c260208501610074565b91506100d060408501610074565b90509250925092565b60dd806100e76000396000f3fe6080604052348015600f57600080fd5b5060043610603c5760003560e01c80638cf57cb9146041578063abee967c146070578063ba504c60146094575b600080fd5b6000546053906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b600054608390600160a01b900460ff1681565b60405160ff90911681526020016067565b600054608390600160a81b900460ff168156fea2646970667358221220c946650c06008269b5747680dfd1bf2cee1fdfa615ff5b6b98addb3af35d5fc564736f6c63430008040033";
        public PartyDeploymentBase() : base(BYTECODE) { }
        public PartyDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_rewardAddress", 1)]
        public virtual string RewardAddress { get; set; }
        [Parameter("uint8", "_initialReward", 2)]
        public virtual byte InitialReward { get; set; }
        [Parameter("uint8", "_longTermReward", 3)]
        public virtual byte LongTermReward { get; set; }
    }

    public partial class InitialRewardFunction : InitialRewardFunctionBase { }

    [Function("initialReward", "uint8")]
    public class InitialRewardFunctionBase : FunctionMessage
    {

    }

    public partial class LongTermRewardFunction : LongTermRewardFunctionBase { }

    [Function("longTermReward", "uint8")]
    public class LongTermRewardFunctionBase : FunctionMessage
    {

    }

    public partial class RewardAddressFunction : RewardAddressFunctionBase { }

    [Function("rewardAddress", "address")]
    public class RewardAddressFunctionBase : FunctionMessage
    {

    }

    public partial class InitialRewardOutputDTO : InitialRewardOutputDTOBase { }

    [FunctionOutput]
    public class InitialRewardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class LongTermRewardOutputDTO : LongTermRewardOutputDTOBase { }

    [FunctionOutput]
    public class LongTermRewardOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class RewardAddressOutputDTO : RewardAddressOutputDTOBase { }

    [FunctionOutput]
    public class RewardAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
