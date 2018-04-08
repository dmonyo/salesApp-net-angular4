using System;

namespace MVCSalesAPI.ViewModels
{
    public class SalesViewModel
    {
        public string FOLIO_NUMBER { get; set; }
        public string SALE_DATE { get; set; }
        public string SALE_AMOUNT { get; set; }

        public System.DateTime GET_SALE_DATE()

        {
            return Convert.ToDateTime(SALE_DATE);
        }
    }
}