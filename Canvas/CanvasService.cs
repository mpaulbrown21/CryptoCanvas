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
using Contracts.Contracts.Canvas.ContractDefinition;

namespace Contracts.Contracts.Canvas
{
    public partial class CanvasService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CanvasDeployment canvasDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CanvasDeployment>().SendRequestAndWaitForReceiptAsync(canvasDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CanvasDeployment canvasDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CanvasDeployment>().SendRequestAsync(canvasDeployment);
        }

        public static async Task<CanvasService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CanvasDeployment canvasDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, canvasDeployment, cancellationTokenSource);
            return new CanvasService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CanvasService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<> CanvasPixelsQueryAsync(CanvasPixelsFunction canvasPixelsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanvasPixelsFunction, >(canvasPixelsFunction, blockParameter);
        }

        
        public Task<> CanvasPixelsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var canvasPixelsFunction = new CanvasPixelsFunction();
                canvasPixelsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<CanvasPixelsFunction, >(canvasPixelsFunction, blockParameter);
        }

        public Task<string> SetPixelRequestAsync(SetPixelFunction setPixelFunction)
        {
             return ContractHandler.SendRequestAsync(setPixelFunction);
        }

        public Task<TransactionReceipt> SetPixelRequestAndWaitForReceiptAsync(SetPixelFunction setPixelFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPixelFunction, cancellationToken);
        }

        public Task<string> SetPixelRequestAsync( canvasIndex, ushort rgbColor)
        {
            var setPixelFunction = new SetPixelFunction();
                setPixelFunction.CanvasIndex = canvasIndex;
                setPixelFunction.RgbColor = rgbColor;
            
             return ContractHandler.SendRequestAsync(setPixelFunction);
        }

        public Task<TransactionReceipt> SetPixelRequestAndWaitForReceiptAsync( canvasIndex, ushort rgbColor, CancellationTokenSource cancellationToken = null)
        {
            var setPixelFunction = new SetPixelFunction();
                setPixelFunction.CanvasIndex = canvasIndex;
                setPixelFunction.RgbColor = rgbColor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPixelFunction, cancellationToken);
        }
    }
}
