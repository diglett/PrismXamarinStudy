using Microsoft.Practices.Unity;
using Modules.Views;
using Prism.Modularity;
using Prism.Unity;

namespace Modules
{
    public class ModuleA : IModule
    {
        readonly IUnityContainer _container;

        public ModuleA(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<Sample1View>();
        }
    }
}
