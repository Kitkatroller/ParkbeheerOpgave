using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class ParkMapper
    {
        public static Park ToDomain(this ParkEntity entity)
        {
            if (entity == null) return null;

            return new Park(entity.Id, entity.Naam, entity.Locatie);
        }

        public static ParkEntity ToEntity(this Park park)
        {
            if (park == null) return null;

            return new ParkEntity
            {
                Id = park.Id,
                Naam = park.Naam,
                Locatie = park.Locatie                
            };
        }
    }

}
