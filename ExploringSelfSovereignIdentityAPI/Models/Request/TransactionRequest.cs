﻿using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public partial class TransactionRequest : TransactionRequestBase { }

    public class TransactionRequestBase
    {
        [Parameter("string[]", "attributes", 1)]
        public virtual List<string> Attributes { get; set; }
        [Parameter("tuple", "stamp", 2)]
        public virtual TransactionStamp Stamp { get; set; }
    }
}