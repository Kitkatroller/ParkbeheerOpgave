using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System;

namespace ConsoleAppModelTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string connectionString= @"Data Source=RAZER-LAPTOP-EP\SQLEXPRESS;Initial Catalog=Parkbeheer;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<ParkContext>();
            optionsBuilder.UseSqlServer(connectionString);

            ParkContext ctx = new ParkContext(optionsBuilder.Options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            IHuizenRepository hrepo = new HuizenRepositoryEF(ctx);
            BeheerHuizen bh = new BeheerHuizen(hrepo);
            Park p = new Park("p2", "Binnenhoeve", "Gent");
            bh.VoegNieuwHuisToe("parklaan", 1, p);
            bh.VoegNieuwHuisToe("parklaan", 2, p);
            bh.VoegNieuwHuisToe("parklaan", 3, p);
            var x = bh.GeefHuis(1);
            x.ZetStraat("Kerkstraat");
            x.ZetNr(11);
            bh.UpdateHuis(x);
            bh.ArchiveerHuis(x);
            //Huis h1 = new Huis();
            ParkEntity pdb = new ParkEntity("p1","naam", "locatie");
            HuisEntity hdb = new HuisEntity("straat", 5, true);
            hdb.Park = pdb;
            ctx.Huizen.Add(hdb);
            ctx.SaveChanges();
            ////huurder
            IHuurderRepository rhuur = new HuurderRepositoryEF(ctx);
            BeheerHuurders bhuur = new BeheerHuurders(rhuur);
            bhuur.VoegNieuweHuurderToe("jos", new Contactgegevens("email1", "tel", "adres"));
            bhuur.VoegNieuweHuurderToe("jef", new Contactgegevens("email2", "tel", "adres"));

            IContractenRepository crepo = new ContractenRepositoryEF(ctx);
            BeheerContracten bc = new BeheerContracten(crepo);
            Huurperiode hp = new Huurperiode(DateTime.Now, 10);
            Huurder h = new Huurder(3, "Jos", new Contactgegevens("email1", "tel", "adres"));
            Park p2 = new Park("p3", "Buitenhoeve", "Deinze");
            Huis huis = new Huis(1, "Kerkstraat", 5, true, p2);
            bc.MaakContract("c2", hp, h, huis);

            var y = bc.GeefContract("c2");
            var t = bh.GeefHuis(1);
            Console.WriteLine(t);
        }
    }
}
