using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Eventor_Project.Models.SqlRepository;
using Eventor_Project.Tests.Mock.MockRepository;
using Eventor_Project.Tests.Tools;
using Ninject;
using NUnit.Framework;

namespace Eventor_Project.Tests.Setup
{

    [TestFixture]
    public class UnitTestSetupFixture
    {
        [SetUp]
        public virtual void Init()
        {
            InitKernel();
        }

        protected virtual StandardKernel InitKernel()
        {
            var kernel = new StandardKernel();
            DependencyResolver.SetResolver(new NinjectDepedencyResolver(kernel));
            InitRepository(kernel);
            return kernel;
        }

        private void InitRepository(StandardKernel kernel)
        {
            kernel.Bind<MockRepository>().To<MockRepository>().InThreadScope();
            kernel.Bind<IRepository>().ToMethod(p => kernel.Get<MockRepository>().Object);
        }
    }
}
