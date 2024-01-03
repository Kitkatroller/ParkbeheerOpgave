using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class ContactgegevensMapper
    {
        public static Contactgegevens ToDomain(this ContactgegevensEntity entity)
        {
            if (entity == null) return null;

            return new Contactgegevens(entity.Email, entity.Tel, entity.Adres);
        }

        public static ContactgegevensEntity ToEntity(this Contactgegevens domainModel)
        {
            if (domainModel == null) return null;

            return new ContactgegevensEntity
            {
                Email = domainModel.Email,
                Tel = domainModel.Tel,
                Adres = domainModel.Adres
            };
        }
    }

}
