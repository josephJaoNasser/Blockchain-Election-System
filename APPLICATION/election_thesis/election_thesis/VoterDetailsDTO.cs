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
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;

namespace election_thesis
{
    class VoterDetailsDTO
    {
        [FunctionOutput]
        public class VoterDetailsOutputDTO : IFunctionOutputDTO
        {
            [Parameter("uint8", 1)]
            public virtual BigInteger Exists { get; set; }

            [Parameter("bytes32", 2)]
            public virtual byte[] precinctID { get; set; }

        }
        
    }
}
