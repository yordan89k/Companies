using System;
using System.ComponentModel.DataAnnotations;

namespace CompaniesYK.Core.Models
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Base()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }
    }
}