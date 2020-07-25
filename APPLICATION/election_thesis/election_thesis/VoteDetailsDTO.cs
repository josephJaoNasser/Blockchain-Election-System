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
using System.Threading;

namespace election_thesis
{
    public class VoteDetailsDTO
    {
        [FunctionOutput]
        public class VoteDetailsOutputDTO : IFunctionOutputDTO
        {
            
            [Parameter("bytes32", 1)]
            public virtual byte[] VoterID { get; set; }


            [Parameter("bytes32", 2)]
            public virtual byte[] voteStringA { get; set; }

            [Parameter("bytes32", 3)]
            public virtual byte[] voteStringB { get; set; }           


            [Parameter("bytes32", 4)]
            public virtual byte[] VoteTime { get; set; }
                       
        }

    }
}
