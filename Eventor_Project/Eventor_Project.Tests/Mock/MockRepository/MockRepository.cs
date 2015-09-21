using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventor_Project.Models.SqlRepository;
using Moq;

namespace Eventor_Project.Tests.Mock.MockRepository
{
    public partial class MockRepository : Mock<SqlRepository>
    {
        public MockRepository(MockBehavior mockBehavior = MockBehavior.Strict) 
            : base(mockBehavior)
        {

        }
    }
}

