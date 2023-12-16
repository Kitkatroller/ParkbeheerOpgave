using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurperiodeMapper
    {
        public static Huurperiode ToDomain(this HuurperiodeEntity entity)
        {
            if (entity == null) return null;
                        
            return new Huurperiode(entity.StartDatum, entity.Aantaldagen);
        }

        public static HuurperiodeEntity ToEntity(this Huurperiode domainModel)
        {
            if (domainModel == null) return null;

            return new HuurperiodeEntity
            {
                StartDatum = domainModel.StartDatum,
                EindDatum = domainModel.EindDatum,
                Aantaldagen = domainModel.Aantaldagen
            };
        }
    }

}
