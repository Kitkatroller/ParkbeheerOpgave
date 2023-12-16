using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Mappers;
using System;
using System.Linq;
using ParkBusinessLayer.Interfaces;
using ParkDataLayer;
using Microsoft.EntityFrameworkCore;

public class HuizenRepositoryEF : IHuizenRepository
{
    private readonly ParkContext _context;

    public HuizenRepositoryEF(ParkContext context)
    {
        _context = context;
    }

    public Huis GeefHuis(int id)
    {
        var huisEntity = _context.Huizen.Include(h => h.Park).FirstOrDefault(h => h.Id == id);
        if (huisEntity == null) return null;

        Huis huis = HuisMapper.ToDomain(huisEntity);
        huis.ZetId(huisEntity.Id);

        return huis;
    }

    public bool HeeftHuis(string straat, int nummer, Park park)
    {
        return _context.Huizen.Any(h => h.Straat == straat && h.Nr == nummer && h.ParkId == park.Id);
    }

    public bool HeeftHuis(int id)
    {
        return _context.Huizen.Any(h => h.Id == id);
    }

    public void UpdateHuis(Huis huis)
    {
        var huisEntity = _context.Huizen.Find(huis.Id);
        if (huisEntity == null) throw new InvalidOperationException("Huis not found");

        HuisEntity huisEntityChanges = HuisMapper.ToEntity(huis);
        huisEntityChanges.Id = huis.Id;

        _context.Entry(huisEntity).CurrentValues.SetValues(huisEntityChanges);
        _context.SaveChanges();
    }

    public Huis VoegHuisToe(Huis huis)
    {
        var huisEntity = HuisMapper.ToEntity(huis);

        if (_context.Parken.Find(huisEntity.Park.Id) != null)//Search if park is already created, if so use that park instead of creating a new one
        {
            huisEntity.Park = _context.Parken.Find(huisEntity.Park.Id);
        }

        _context.Huizen.Add(huisEntity);
        _context.SaveChanges();

        huis.ZetId(huisEntity.Id);
        return huis;
    }
}
