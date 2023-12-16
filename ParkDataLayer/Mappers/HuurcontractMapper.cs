using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurcontractMapper
    {
        public static Huurcontract ToDomain(this HuurcontractEntity entity)
        {
            if (entity == null) return null;

            var huurperiode = HuurperiodeMapper.ToDomain(entity.Huurperiode);
            var huurder = HuurderMapper.ToDomain(entity.Huurder);
            var huis = HuisMapper.ToDomain(entity.Huis);

            return new Huurcontract(entity.Id, huurperiode, huurder, huis);
        }

        public static HuurcontractEntity ToEntity(this Huurcontract domainModel)
        {
            if (domainModel == null) return null;

            var huurperiodeEntity = HuurperiodeMapper.ToEntity(domainModel.Huurperiode);
            var huurderEntity = HuurderMapper.ToEntity(domainModel.Huurder);
            var huisEntity = HuisMapper.ToEntity(domainModel.Huis);

            return new HuurcontractEntity
            {
                Id = domainModel.Id,
                Huurperiode = huurperiodeEntity,
                Huurder = huurderEntity,
                Huis = huisEntity
            };
        }
    }

}
