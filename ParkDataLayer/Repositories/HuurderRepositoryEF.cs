using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private readonly ParkContext _context;

        public HuurderRepositoryEF(ParkContext context)
        {
            _context = context;
        }

        public Huurder GeefHuurder(int id)
        {
            var huurderEntity = _context.Huurders
                                        .Include(h => h.Contactgegevens)
                                        .FirstOrDefault(h => h.Id == id);
            return huurderEntity == null ? null : HuurderMapper.ToDomain(huurderEntity);
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            var huurdersEntities = _context.Huurders
                                           .Where(h => h.Naam.Contains(naam))
                                           .Include(h => h.Contactgegevens)
                                           .ToList();
            return huurdersEntities.Select(HuurderMapper.ToDomain).ToList();
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {            
            return _context.Huurders.Any(h => h.Naam == naam &&
                                              h.Contactgegevens.Email == contact.Email &&
                                              h.Contactgegevens.Tel == contact.Tel &&
                                              h.Contactgegevens.Adres == contact.Adres);
        }

        public bool HeeftHuurder(int id)
        {
            return _context.Huurders.Any(h => h.Id == id);
        }

        public void UpdateHuurder(Huurder huurder)
        {
            var huurderEntity = _context.Huurders.Find(huurder.Id);
            if (huurderEntity != null)
            {
                _context.Entry(huurderEntity).CurrentValues.SetValues(HuurderMapper.ToEntity(huurder));
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Huurder not found");
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            var huurderEntity = HuurderMapper.ToEntity(h);
            _context.Huurders.Add(huurderEntity);
            _context.SaveChanges();
                        
            h.ZetId(huurderEntity.Id);
            return h;
        }
    }

}
