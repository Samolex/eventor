using Ninject;

namespace Eventor_Project.Models.SqlRepository
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public CurrentContext Db { get; set; }
    }
}