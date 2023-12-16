using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuisMapper
    {
        public static Huis ToDomain(this HuisEntity entity)
        {
            if (entity == null) return null;

            var park = ParkMapper.ToDomain(entity.Park);
            return new Huis(entity.Straat, entity.Nr, park)
            {                
                Actief = entity.Actief
            };
        }

        public static HuisEntity ToEntity(this Huis domainModel)
        {
            if (domainModel == null) return null;

            var parkEntity = ParkMapper.ToEntity(domainModel.Park);
            return new HuisEntity
            {
                Straat = domainModel.Straat,
                Nr = domainModel.Nr,
                Actief = domainModel.Actief,
                Park = parkEntity
            };
        }
    }
}
