using OMDbApi.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMDbApi.Models
{
    public class Transaction : ITransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }
        public string Username { get; set; }
        public string IMDbId { get; set; }
        public DateTime DateId { get; set; }
    }
}
