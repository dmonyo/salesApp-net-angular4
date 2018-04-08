using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesAPI.Models
{
    public class Sales
    {
        [Key, StringLength(12)]
        public string FOLIO_NUMBER { get; set; }

        public DateTime SALE_DATE { get; set; }

        public double SALE_AMOUNT { get; set; }

    }
}