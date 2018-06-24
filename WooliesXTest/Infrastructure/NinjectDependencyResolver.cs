using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WooliesXTest.Abstract;
using WooliesXTest.Services;

namespace WooliesXTest.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IApiHelper>().To<ApiHelper>();
            _kernel.Bind<IProductsService>().To<ProductsService>();
            _kernel.Bind<IProductsSorter>().To<ProductsSorter>();
        }
    }
}
