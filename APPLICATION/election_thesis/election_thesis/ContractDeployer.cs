using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;

namespace election_thesis
{
    class ContractDeployer:ContractDeploymentMessage
    {
        public static string bytecode = "";
        public ContractDeployer() : base(bytecode) { }
        public ContractDeployer(string byteCode) : base(byteCode) { }

        [Parameter("bytes32", "_key", 1)]
        public byte[] _key { get; set; }
    }
}
