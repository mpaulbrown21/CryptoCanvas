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
        public static string BYTECODE = "608060405234801561001057600080fd5b50610119806100206000396000f3fe6080604052348015600f57600080fd5b5060043610603c5760003560e01c806312a20f9b1460415780638da7f232146060578063b4f80eb914608f575b600080fd5b605e604c36600460c3565b60009182526020829052604090912055565b005b607d606b36600460ac565b60006020819052908152604090205481565b60405190815260200160405180910390f35b607d609a36600460ac565b60009081526020819052604090205490565b60006020828403121560bc578081fd5b5035919050565b6000806040838503121560d4578081fd5b5050803592602090910135915056fea2646970667358221220a5c3d557d26db525ae5ab597a8819863f2cf30f683ecefc786b583ece02e983664736f6c63430008040033";
        public CanvasDeploymentBase() : base(BYTECODE) { }
        public CanvasDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetPixelFunction : GetPixelFunctionBase { }

    [Function("getPixel", "uint256")]
    public class GetPixelFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_canvasIndex", 1)]
        public virtual BigInteger CanvasIndex { get; set; }
    }

    public partial class PixelsFunction : PixelsFunctionBase { }

    [Function("pixels", "uint256")]
    public class PixelsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SetPixelFunction : SetPixelFunctionBase { }

    [Function("setPixel")]
    public class SetPixelFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_canvasIndex", 1)]
        public virtual BigInteger CanvasIndex { get; set; }
        [Parameter("uint256", "_rgbColor", 2)]
        public virtual BigInteger RgbColor { get; set; }
    }

    public partial class GetPixelOutputDTO : GetPixelOutputDTOBase { }

    [FunctionOutput]
    public class GetPixelOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_rgbColor", 1)]
        public virtual BigInteger RgbColor { get; set; }
    }

    public partial class PixelsOutputDTO : PixelsOutputDTOBase { }

    [FunctionOutput]
    public class PixelsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
