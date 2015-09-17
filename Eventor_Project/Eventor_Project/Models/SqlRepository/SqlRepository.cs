using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public CurrentContext Db { get; set; }

    }
}