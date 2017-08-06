using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ralf.ContestLogging.Common.Types
{
    public class AggregateModuleCatalog : IModuleCatalog
    {
        private List<IModuleCatalog> catalogs = new List<IModuleCatalog>();

        public AggregateModuleCatalog()
        {
            this.catalogs.Add(new ModuleCatalog());
        }

        public ReadOnlyCollection<IModuleCatalog> Catalogs
        {
            get
            {
                return this.catalogs.AsReadOnly();
            }
        }

        public void AddCatalog(IModuleCatalog catalog)
        {
            if (catalog == null)
            {
                throw new ArgumentNullException("catalog");
            }

            this.catalogs.Add(catalog);
        }

        public IEnumerable<ModuleInfo> Modules
        {
            get
            {
                return this.Catalogs.SelectMany(x => x.Modules);
            }
        }

        public IEnumerable<ModuleInfo> GetDependentModules(ModuleInfo moduleInfo)
        {
            var catalog = this.catalogs.Single(x => x.Modules.Contains(moduleInfo));
            return catalog.GetDependentModules(moduleInfo);
        }

        public IEnumerable<ModuleInfo> CompleteListWithDependencies(IEnumerable<ModuleInfo> modules)
        {
            var modulesGroupedByCatalog = modules.GroupBy<ModuleInfo, IModuleCatalog>(module => this.catalogs.Single(catalog => catalog.Modules.Contains(module)));
            return modulesGroupedByCatalog.SelectMany(x => x.Key.CompleteListWithDependencies(x));
        }

        public void Initialize()
        {
            foreach (var catalog in this.Catalogs)
            {
                Console.WriteLine(catalog);
                catalog.Initialize();
            }
        }

        public void AddModule(ModuleInfo moduleInfo)
        {
            this.catalogs[0].AddModule(moduleInfo);
        }
    }
}