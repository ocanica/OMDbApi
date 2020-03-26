using OMDbApi.Api.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMDbApi.Api.Models
{
    public class Transaction : ITransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string Username { get; set; }
        [Required]
        [ForeignKey("Movie")]
        public string IMDbId { get; set; }
        public DateTime DateId { get; set; }
    }
}
