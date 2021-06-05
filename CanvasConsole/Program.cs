using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Threading.Tasks;
using Contracts.Contracts.Canvas.ContractDefinition;
using Contracts.Contracts.Canvas;

namespace CanvasConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "http://testchain.nethereum.com:8545";
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            var deployment = new CanvasDeployment();
            var receipt = await CanvasService.DeployContractAndWaitForReceiptAsync(web3, deployment);
            var service = new CanvasService(web3, receipt.ContractAddress);

            Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");

            SetPixelFunction func = new()
            {
                RgbColor = 3,
                // RgbColor = 16777216,
                CanvasIndex = 0
            };

            await service.SetPixelRequestAndWaitForReceiptAsync(func);

            var result = await service.GetPixelQueryAsync(new GetPixelFunction { CanvasIndex = 0 });

            Console.WriteLine($"RGB: {result}");
        }
    }
}
