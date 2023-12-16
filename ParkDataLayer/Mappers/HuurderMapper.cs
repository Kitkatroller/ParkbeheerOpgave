using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurderMapper
    {
        public static Huurder ToDomain(this HuurderEntity entity)
        {
            if (entity == null) return null;

            var contactgegevens = ContactgegevensMapper.ToDomain(entity.Contactgegevens);
            return new Huurder(entity.Id, entity.Naam, contactgegevens);
        }

        public static HuurderEntity ToEntity(this Huurder domainModel)
        {
            if (domainModel == null) return null;

            var contactgegevensEntity = ContactgegevensMapper.ToEntity(domainModel.Contactgegevens);
            return new HuurderEntity
            {
                Id = domainModel.Id,
                Naam = domainModel.Naam,
                Contactgegevens = contactgegevensEntity
            };
        }
    }

}
