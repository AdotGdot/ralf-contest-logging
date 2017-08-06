using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;
using System.Linq;

namespace Ralf.ContestLogging.Common.Services
{
    public class DxResolutionService : IDxResolutionService
    {
        private IDxResolutionRepository repository;

        public DxResolutionService(IDxResolutionRepository repository)
        {
            this.repository = repository;
        }

        public IList<DxccEntity> Resolve(string callsign)
        {
            return repository.Resolve(callsign);
        }

        public DxccEntity Resolve(int adifId)
        {
            return repository.Resolve(adifId);
        }

        public IList<ContinentDetail> ResolveContinentDetail(string callsign)
        {
            return repository.ResolveContinentDetail(callsign);
        }

        public IList<ItuZoneDetail> ResolveItuZoneDetail(string callsign)
        {
            return repository.ResolveItuZoneDetail(callsign);
        }

        public IList<CqZoneDetail> ResolveCqZoneDetail(string callsign)
        {
            return repository.ResolveCqZoneDetail(callsign);
        }

        public IList<DxccEntitySelection> ResolveAsCqEntitySelections(string callsign)
        {
            IList<DxccEntitySelection> selections = new List<DxccEntitySelection>();
            DxccEntitySelection selection;
            foreach (DxccEntity dxccEntity in Resolve(callsign))
            {
                foreach (string continent in dxccEntity.Continents)
                {
                    foreach (int cqZone in dxccEntity.CqZones)
                    {
                        int ituZone = 0;
                        if (dxccEntity.ItuZones.Count() == 1)
                        {
                            ituZone = dxccEntity.ItuZones[0];
                        }
                        selection = new DxccEntitySelection()
                        {
                            Continent = continent,
                            Name = dxccEntity.Name,
                            AdifId = dxccEntity.AdifId,
                            CqZone = cqZone,
                            ItuZone = ituZone,
                            Prefix = dxccEntity.Prefix
                        };
                        selections.Add(selection);
                    }
                }
            }
            return selections.Distinct().ToList();
        }
        public IList<DxccEntitySelection> ResolveAsItuEntitySelections(string callsign)
        {
            IList<DxccEntitySelection> selections = new List<DxccEntitySelection>();
            DxccEntitySelection selection;
            foreach (DxccEntity dxccEntity in Resolve(callsign))
            {
                foreach (string continent in dxccEntity.Continents)
                {
                    foreach (int ituZone in dxccEntity.ItuZones)
                    {
                        int cqZone = 0;
                        if (dxccEntity.CqZones.Count() == 1)
                        {
                            cqZone = dxccEntity.CqZones[0];
                        }
                        selection = new DxccEntitySelection()
                        {
                            Continent = continent,
                            Name = dxccEntity.Name,
                            AdifId = dxccEntity.AdifId,
                            CqZone = cqZone,
                            ItuZone = ituZone,
                            Prefix = dxccEntity.Prefix
                        };
                        selections.Add(selection);
                    }
                }
            }
            return selections.Distinct().ToList();
        }
        public IList<DxccEntitySelection> ResolveAsEntitySelections(string callsign)
        {
            IList<DxccEntitySelection> selections = new List<DxccEntitySelection>();
            DxccEntitySelection selection;
            foreach (DxccEntity dxccEntity in Resolve(callsign))
            {
                foreach (string continent in dxccEntity.Continents)
                {
                    int ituZone = 0;
                    if (dxccEntity.ItuZones.Count() == 1)
                    {
                        ituZone = dxccEntity.ItuZones[0];
                    }

                    int cqZone = 0;
                    if (dxccEntity.CqZones.Count() == 1)
                    {
                        cqZone = dxccEntity.CqZones[0];
                    }

                    selection = new DxccEntitySelection()
                    {
                        Continent = continent,
                        Name = dxccEntity.Name,
                        AdifId = dxccEntity.AdifId,
                        ItuZone = ituZone,
                        CqZone = cqZone,
                        Prefix = dxccEntity.Prefix
                    };
                    selections.Add(selection);
                }
            }
            return selections.Distinct().ToList();
        }
    }
}