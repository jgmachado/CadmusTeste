using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadmus.Entities.Config
{
    /// <summary>
    /// Classe de configurações gerais
    /// </summary>
    public class Config
    {
        #if Debug

        public const string DbConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Cadmus;Persist Security Info=True;User ID=sa;Password=teste1234";
        public const string WebServicesCadmusUrl = @"http://localhost:36000/WcfService.svc";

        #endif
    }
}
