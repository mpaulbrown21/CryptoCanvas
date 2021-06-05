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

namespace Contracts.Contracts.Canvas.ContractDefinition
{


    public partial class CanvasDeployment : CanvasDeploymentBase
    {
        public CanvasDeployment() : base(BYTECODE) { }
        public CanvasDeployment(string byteCode) : base(byteCode) { }
    }

    public class CanvasDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610197806100206000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c80636129dd111461003b578063e4da700b14610050575b600080fd5b61004e610049366004610104565b61007b565b005b61006361005e366004610149565b6100d3565b60405162ffffff909116815260200160405180910390f35b8061ffff1660008362ffffff166201000081106100a857634e487b7160e01b600052603260045260246000fd5b600a91828204019190066003026101000a81548162ffffff021916908362ffffff1602179055505050565b6000816201000081106100e557600080fd5b600a9182820401919006600302915054906101000a900462ffffff1681565b60008060408385031215610116578182fd5b823562ffffff81168114610128578283fd5b9150602083013561ffff8116811461013e578182fd5b809150509250929050565b60006020828403121561015a578081fd5b503591905056fea264697066735822122077591ce8bb87e7164faa808bb13ba704fc7ce5e30749b1a9f1ae52072b6547bd64736f6c63430008040033";
        public CanvasDeploymentBase() : base(BYTECODE) { }
        public CanvasDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CanvasPixelsFunction : CanvasPixelsFunctionBase { }

    [Function("canvasPixels", "uint24")]
    public class CanvasPixelsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SetPixelFunction : SetPixelFunctionBase { }

    [Function("setPixel")]
    public class SetPixelFunctionBase : FunctionMessage
    {
        [Parameter("uint24", "canvasIndex", 1)]
        public virtual  CanvasIndex { get; set; }
        [Parameter("uint16", "rgbColor", 2)]
        public virtual ushort RgbColor { get; set; }
    }

    public partial class CanvasPixelsOutputDTO : CanvasPixelsOutputDTOBase { }

    [FunctionOutput]
    public class CanvasPixelsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint24", "", 1)]
        public virtual  ReturnValue1 { get; set; }
    }


}
