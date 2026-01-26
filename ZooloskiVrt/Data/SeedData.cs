using System;
using System.Collections.Generic;
using System.Linq;
using ZooloskiVrt.Data;
using ZooloskiVrt.Models;

namespace ZooloskiVrt
{
    public static class SeedData
    {
        public static void Initialize(ZooloskiVrtContext context)
        {
            
            if (context.Radnici.Any() ||
                context.Nastambe.Any() ||
                context.Zivotinje.Any() ||
                context.Obaveze.Any() ||
                context.Incidenti.Any() ||
                context.Posjetitelji.Any())
            {
                return;
            }

            var danas = DateTime.Today;

           
            var radnici = new List<Radnik>
            {
                new Radnik { Ime="Ivan",  Prezime="Marić",   Kontakt="091-111-111", Email="ivan.maric@zoo.hr",  Obrazovanje="Biolog" },
                new Radnik { Ime="Ana",   Prezime="Kovač",   Kontakt="091-222-222", Email="ana.kovac@zoo.hr",   Obrazovanje="Veterinar" },
                new Radnik { Ime="Marko", Prezime="Perić",   Kontakt="091-333-333", Email="marko.peric@zoo.hr", Obrazovanje="Tehničar" },
                new Radnik { Ime="Petra", Prezime="Babić",   Kontakt="091-444-444", Email="petra.babic@zoo.hr", Obrazovanje="Zoolog" }
            };
            context.Radnici.AddRange(radnici);
            context.SaveChanges();

           
           
            var nastambe = new List<Nastamba>
            {
                new Nastamba { Naziv="Lavovi",   Tip="Vanjska",   RazinaOsuncanosti="Visoka" },
                new Nastamba { Naziv="Ptice",    Tip="Unutarnja", RazinaOsuncanosti="Srednja" },
                new Nastamba { Naziv="Akvarij",  Tip="Unutarnja", RazinaOsuncanosti="Niska" },
                new Nastamba { Naziv="Majmuni",  Tip="Vanjska",   RazinaOsuncanosti="Visoka" }
            };
            context.Nastambe.AddRange(nastambe);
            context.SaveChanges();

            
            var zivotinje = new List<Zivotinja>
            {
                
                new Zivotinja { Ime="Leo",  HrvatskiNaziv="Lav",   LatinskiNaziv="Panthera leo", NacinNabave="Kupnja", DatumNabave=danas.AddYears(-4), Aktivna=true, NastambaID=nastambe[0].ID },
                new Zivotinja { Ime="Nala", HrvatskiNaziv="Lav",   LatinskiNaziv="Panthera leo", NacinNabave="Donacija", DatumNabave=danas.AddYears(-2), Aktivna=true, NastambaID=nastambe[0].ID },

                
                new Zivotinja { Ime="Kiki", HrvatskiNaziv="Papiga", LatinskiNaziv="Ara ararauna", NacinNabave="Kupnja", DatumNabave=danas.AddYears(-1), Aktivna=true, NastambaID=nastambe[1].ID },

                
                new Zivotinja { Ime="Nemo", HrvatskiNaziv="Klaun riba", LatinskiNaziv="Amphiprion ocellaris", NacinNabave="Kupnja", DatumNabave=danas.AddMonths(-6), Aktivna=true, NastambaID=nastambe[2].ID },

                
                new Zivotinja { Ime="Koko", HrvatskiNaziv="Majmun", LatinskiNaziv="Macaca fascicularis", NacinNabave="Rođena", DatumNabave=danas.AddYears(-3), Aktivna=true, NastambaID=nastambe[3].ID }
            };
            context.Zivotinje.AddRange(zivotinje);
            context.SaveChanges();

            
            var obaveze = new List<Obaveza>
            {
                new Obaveza { Opis="Hranjenje lavova", Datum=danas.AddHours(9), Status="Planirano", RadnikID=radnici[0].ID, NastambaID=nastambe[0].ID },
                new Obaveza { Opis="Čišćenje lavlje nastambe", Datum=danas.AddHours(11), Status="U tijeku", RadnikID=radnici[2].ID, NastambaID=nastambe[0].ID },

                new Obaveza { Opis="Hranjenje ptica", Datum=danas.AddHours(10), Status="Planirano", RadnikID=radnici[3].ID, NastambaID=nastambe[1].ID },

                new Obaveza { Opis="Čišćenje akvarija", Datum=danas.AddHours(14), Status="Planirano", RadnikID=radnici[2].ID, NastambaID=nastambe[2].ID },

                new Obaveza { Opis="Hranjenje majmuna", Datum=danas.AddHours(12), Status="Obavljeno", RadnikID=radnici[1].ID, NastambaID=nastambe[3].ID }
            };
            context.Obaveze.AddRange(obaveze);
            context.SaveChanges();

         
            var incidenti = new List<Incident>
            {
                new Incident { Opis="Oštećenje ograde kod lavova", Datum=danas.AddDays(-5), Ozbiljnost="Srednja" },
                new Incident { Opis="Kvar na filteru u akvariju", Datum=danas.AddDays(-2), Ozbiljnost="Niska" }
            };
            context.Incidenti.AddRange(incidenti);
            context.SaveChanges();

            
            var posjetitelji = new List<Posjetitelj>
            {
                new Posjetitelj { ImeGrupe="Osnovna škola Mostar", TerminPosjete=danas.AddDays(1).AddHours(10), VodicID=radnici[0].ID },
                new Posjetitelj { ImeGrupe="Gimnazija Mostar",    TerminPosjete=danas.AddDays(3).AddHours(11), VodicID=radnici[3].ID },
                new Posjetitelj { ImeGrupe="Vrtić Pčelice",      TerminPosjete=danas.AddDays(5).AddHours(9),  VodicID=radnici[1].ID }
            };
            context.Posjetitelji.AddRange(posjetitelji);
            context.SaveChanges();
        }
    }
}
