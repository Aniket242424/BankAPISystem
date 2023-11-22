using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowAssesment.Models
{
  public  class AccountModel
    {
        public int InitialBalance { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public int NewBalance { get; set; }
    }
}
