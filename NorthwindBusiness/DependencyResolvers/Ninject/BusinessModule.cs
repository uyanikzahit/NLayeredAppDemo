using Ninject.Modules;
using NorthwindBusiness.Abstract;
using NorthwindBusiness.Concrete;
using NorthwindDataAccess.Abstract;
using NorthwindDataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.DependencyResolvers.Ninject
{
    public class BusinessModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

        }
    }
}
