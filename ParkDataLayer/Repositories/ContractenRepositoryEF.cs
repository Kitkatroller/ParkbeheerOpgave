using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private readonly ParkContext _context;

        public ContractenRepositoryEF(ParkContext context)
        {
            _context = context;
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            var contractEntity = _context.Huurcontracten.Find(contract.Id);
            if (contractEntity != null)
            {
                _context.Huurcontracten.Remove(contractEntity);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Contract not found");
            }
        }

        public Huurcontract GeefContract(string id)
        {
            var contractEntity = _context.Huurcontracten
                                         .Include(c => c.Huurperiode)
                                         .Include(c => c.Huurder)
                                         .Include(c => c.Huis)
                                         .FirstOrDefault(c => c.Id == id);
            return contractEntity == null ? null : HuurcontractMapper.ToDomain(contractEntity);
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            var query = _context.Huurcontracten
                                .Include(c => c.Huurperiode)
                                .Include(c => c.Huurder)
                                .Include(c => c.Huis)
                                .AsQueryable();

            if (dtEinde.HasValue)
            {
                query = query.Where(c => c.Huurperiode.StartDatum >= dtBegin &&
                                         c.Huurperiode.EindDatum <= dtEinde.Value);
            }
            else
            {
                query = query.Where(c => c.Huurperiode.StartDatum >= dtBegin);
            }

            var contractEntities = query.ToList();
            return contractEntities.Select(HuurcontractMapper.ToDomain).ToList();
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            return _context.Huurcontracten.Any(c => c.Huurperiode.StartDatum == startDatum &&
                                                    c.Huurder.Id == huurderid &&
                                                    c.Huis.Id == huisid);
        }

        public bool HeeftContract(string id)
        {
            return _context.Huurcontracten.Any(c => c.Id == id);
        }

        public void UpdateContract(Huurcontract contract)
        {
            var contractEntity = _context.Huurcontracten.Find(contract.Id);
            if (contractEntity != null)
            {
                _context.Entry(contractEntity).CurrentValues.SetValues(HuurcontractMapper.ToEntity(contract));
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Contract not found");
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            var contractEntity = HuurcontractMapper.ToEntity(contract);
            _context.Huurcontracten.Add(contractEntity);
            _context.SaveChanges();
                        
            contract.ZetId(contractEntity.Id);
        }
    }

}
