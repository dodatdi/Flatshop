﻿using FlatShop.Models.EF.MoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace FlatShop.Models.Security
{
    public class CustomPrincipal:IPrincipal
    {
        private Account Account;

        public IIdentity Identity { get; set; }
        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Email);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.Account.Roles.Contains(r));
            return kq;
        }



    }
}