
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Entities
{
    public class User : IdentityUser<int>
    {
        #region Properties
        public bool IsSeller { get; set; }


        #endregion Properties

        #region Navigation properties
        public Customer? Customer { get; set; }
        public Seller? Seller { get; set; }
        public Admin? Admin { get; set; }

        #endregion Navigation properties

    }
}
