using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbApi.Api.Contracts
{
    public interface ITransaction
    {
        public Guid UserId { get; set; }
        public string IMDbId { get; set; }
        public DateTime DateId { get; set; }
    }
}
