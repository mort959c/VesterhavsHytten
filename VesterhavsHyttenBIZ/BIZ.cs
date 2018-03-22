using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesterhavsHyttenBIZ
{
    public class Filial
    {
        public string Navn { get; set; }
        private string Adresse { get; set; }
        private Postnr Postnr { get; set; }
        public string Telefon { get; set; }
        private string Mail { get; set; }
        private int Id { get; set; }

        /// <summary>
        /// With Id
        /// </summary>
        public Filial(string navn, string adresse, Postnr postnr, string telefon, string mail, int id)
        {
            this.Navn = navn;
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Telefon = telefon;
            this.Mail = mail;
            this.Id = id;
        }
        
        /// <summary>
        /// Without Id
        /// </summary>
        public Filial(string navn, string adresse, Postnr postnr, string telefon, string mail)
        {
            this.Navn = navn;
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Telefon = telefon;
            this.Mail = mail;
        }

        //public string getNavn() { return this.Navn; }
        //public string getAdresse() { return this.Adresse; }
        //public Postnr getPostnr() { return this.Postnr; }
        //public string getTelefon() { return this.Telefon; }
        //public string getMail() { return this.Mail; }
        public int getId() { return this.Id; }
        public string getAdresse() { return this.Adresse; }
        public string getBy() { return this.Postnr.Navn; }
        public string getMail() { return this.Mail; }
        public string getNavn() { return this.Navn; }
        public int getPostnr() { return this.Postnr.postnr; }
        public string getTelefon() { return this.Telefon; }

        public override string ToString()
        {
            return this.Id + " - " + this.Navn + " - " + this.Adresse + " - " + this.Postnr.ToString() + " - " + this.Mail + " - " + this.Telefon;
        }
    }

    public class Udbyder
    {
        public Filial Filial { get; set; }
        private List<HusType> HusTyper { get; set; }
        public double Pris { get; set; }

        public double getPris() { return this.Pris; }

        public void addHusTypeToUdbyder(HusType hustype) { this.HusTyper.Add(hustype); }

        public List<HusType> getHustyper() { return this.HusTyper; }

        public Udbyder(Filial filial, List<HusType> hustyper, double pris)
        {
            this.Filial = filial;
            this.HusTyper = hustyper;
            this.Pris = pris;
        }

        public override string ToString()
        {
            return this.Filial.ToString() + " : " + this.Pris;
        }
    }

    public class HusType
    {
        public int Id { get; set; }
        public int Etager { get; set; }
        public int Areal { get; set; }
        public string Navn { get; set; }

        /// <summary>
        /// with id
        /// </summary>
        public HusType(int id, int etager, int areal, string navn)
        {
            this.Id = id;
            this.Etager = etager;
            this.Areal = areal;
            this.Navn = navn;
        }

        /// <summary>
        /// Without id
        /// </summary>
        public HusType(int etager, int areal, string navn)
        {
            this.Etager = etager;
            this.Areal = areal;
            this.Navn = navn;
        }

        public override string ToString()
        {
            return this.Id + " - " + this.Navn + " - " + this.Etager + " - " + this.Areal;
        }
    }

    public class Postnr
    {
        public int postnr { get; set; }
        public string Navn { get; set; }

        public Postnr(int postnr, string navn)
        {
            this.postnr = postnr;
            this.Navn = navn;
        }

        public override string ToString()
        {
            return this.postnr + " - " + this.Navn;
        }
    }

    public class Grund
    {
        public string Adresse { get; set; }
        public Postnr Postnr { get; set; }
        public double Tillæg { get; set; }
        public int Areal { get; set; }
        public int Id { get; set; }
        public Filial Filial { get; set; }
        
        public double getTillæg() { return this.Tillæg; }
        public int getAreal() { return this.Areal; }
        public Filial getFilial() { return this.Filial; }

        public Grund(string adresse, Postnr postnr, double tillæg, int areal, int id, Filial filial)
        {
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Tillæg = tillæg;
            this.Areal = areal;
            this.Id = id;
            this.Filial = filial;
        }

        public Grund(string adresse, Postnr postnr, double tillæg, int areal, Filial filial)
        {
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Tillæg = tillæg;
            this.Areal = areal;
            this.Filial = filial;
        }

        public override string ToString()
        {
            return this.Id + " - " + this.Adresse + " - " + this.Postnr.ToString() + " - " + this.Tillæg + " - " + this.Areal;
        }
    }

    public class Salg
    {
        public HusType HusType { get; set; }
        public Grund Grund { get; set; }
        public Kunde Kunde { get; set; }
        private string Status { get; set; }
        public double Beløb { get; set; }

        //public double getBeløb() { return this.Grund.getTillæg() + this.HusType.}

        public Salg(HusType hustype, Grund grund, Kunde kunde, double beløb)
        {
            this.HusType = hustype;
            this.Grund = grund;
            this.Kunde = kunde;
            this.Beløb = beløb;
        }

        public override string ToString()
        {
            return this.HusType.ToString() + " - " + this.Grund.ToString() + " - " + this.Kunde.ToString() + " - " + this.Status + " - " + this.Beløb;
        }
    }

    public class Kunde
    {
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public Postnr Postnr { get; set; }
        public string Telefon { get; set; }
        private string Mail { get; set; }
        public int Id { get; set; }

        public int getId() { return this.Id; }

        public Kunde(string navn, string adresse, Postnr postnr, string telefon, string mail, int id)
        {
            this.Navn = navn;
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Telefon = telefon;
            this.Mail = mail;
            this.Id = id;
        }

        public Kunde(string navn, string adresse, Postnr postnr, string telefon, string mail)
        {
            this.Navn = navn;
            this.Adresse = adresse;
            this.Postnr = postnr;
            this.Telefon = telefon;
            this.Mail = mail;
        }

        public override string ToString()
        {
            return this.Id + " - " + this.Navn + " - " + this.Adresse + " - " + this.Postnr.ToString() + " - " + this.Telefon + " - " + this.Mail;
        }
    }
}
