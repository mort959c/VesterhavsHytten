using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using VesterhavsHyttenBIZ;


namespace VesterhavsHyttenDB
{
    public class DBGrund
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source = CV-PC-T-41\SQLEXPRESS; Initial Catalog = VesterhavsHytten; Integrated Security = True");//Connection string for the database
        SqlCommand myCommand = null;
        SqlDataReader myReader = null;

        public List<Grund> getGrundList()
        {
            List<Grund> Grunde = new List<Grund>();

            string sql = @"SELECT g.Addresse gAdresse, g.Tillæg gTillæg, g.Areal gAreal, g.Id gId,
                            gp.Postnr gpPostnr, gp.Navn gpNavn,
                            f.navn fNavn, f.Adresse fAdresse, f.Telefon fTelefon,
                            f.FirmaId fFirmaId, fp.Postnr fpPostnr, fp.Navn fpNavn, b.mail bMail  
                            FROM Grund g
                            JOIN PostDistrikt gp
                            ON g.Postnr = gp.Postnr
                            JOIN Filial f
                            ON g.FilialNavn = f.Navn
                            JOIN PostDistrikt fp
                            ON f.postnr = fp.Postnr
                            JOIN ByggeFirma b
                            ON f.FirmaId = b.id";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //postnr filial
                    Postnr fp = new Postnr(Convert.ToInt32(myReader["fpPostnr"]), myReader["fpNavn"].ToString());
                    //postnr grund
                    Postnr gp = new Postnr(Convert.ToInt32(myReader["gpPostnr"]), myReader["gpNavn"].ToString());

                    Filial f = new Filial(myReader["fNavn"].ToString(),
                                          myReader["fAdresse"].ToString(),
                                          fp,
                                          myReader["fTelefon"].ToString(),
                                          myReader["bMail"].ToString(),
                                          Convert.ToInt32(myReader["fFirmaId"]));
                    Grund g = new Grund(myReader["gAdresse"].ToString(),
                                        gp,
                                        Convert.ToDouble(myReader["gTillæg"]),
                                        Convert.ToInt32(myReader["gAreal"]),
                                        Convert.ToInt32(myReader["gId"]),
                                        f);

                    Grunde.Add(g);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { myConnection.Close(); }

            return Grunde;
        }

        public List<Grund> getNotSoldGrundList()
        {
            List<Grund> Grunde = new List<Grund>();

            string sql = @"SELECT g.Addresse gAdresse, g.Tillæg gTillæg, g.Areal gAreal, g.Id gId,
                            gp.Postnr gpPostnr, gp.Navn gpNavn,
                            f.navn fNavn, f.Adresse fAdresse, f.Telefon fTelefon,
                            f.FirmaId fFirmaId, fp.Postnr fpPostnr, fp.Navn fpNavn, b.mail bMail  
                            FROM Grund g
                            JOIN PostDistrikt gp
                            ON g.Postnr = gp.Postnr
                            JOIN Filial f
                            ON g.FilialNavn = f.Navn
                            JOIN PostDistrikt fp
                            ON f.postnr = fp.Postnr
                            JOIN ByggeFirma b
                            ON f.FirmaId = b.id
                            LEFT JOIN Solgt s ON s.GId = g.Id WHERE s.GId IS NULL";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //postnr filial
                    Postnr fp = new Postnr(Convert.ToInt32(myReader["fpPostnr"]), myReader["fpNavn"].ToString());
                    //postnr grund
                    Postnr gp = new Postnr(Convert.ToInt32(myReader["gpPostnr"]), myReader["gpNavn"].ToString());

                    Filial f = new Filial(myReader["fNavn"].ToString(),
                                          myReader["fAdresse"].ToString(),
                                          fp,
                                          myReader["fTelefon"].ToString(),
                                          myReader["bMail"].ToString(),
                                          Convert.ToInt32(myReader["fFirmaId"]));
                    Grund g = new Grund(myReader["gAdresse"].ToString(),
                                        gp,
                                        Convert.ToDouble(myReader["gTillæg"]),
                                        Convert.ToInt32(myReader["gAreal"]),
                                        Convert.ToInt32(myReader["gId"]),
                                        f);

                    Grunde.Add(g);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { myConnection.Close(); }

            return Grunde;
        }

        public List<Filial> getFilialList()
        {
            List<Filial> filialer = new List<Filial>();

            string sql = @"SELECT f.Navn fNavn, f.Adresse fAdresse, p.Navn pNavn, p.Postnr pPostnr, f.Telefon fTelefon, b.Mail bMail, f.FirmaId fFirmaId
                        FROM Filial f
                        JOIN PostDistrikt p
                        ON f.Postnr = p.Postnr
                        JOIN ByggeFirma b
                        ON f.FirmaId = b.Id";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Postnr pn = new Postnr(Convert.ToInt32(myReader["pPostnr"]), myReader["pNavn"].ToString());
                    Filial f = new Filial(myReader["fNavn"].ToString(),
                                          myReader["fAdresse"].ToString(),
                                          pn,
                                          myReader["fTelefon"].ToString(),
                                          myReader["bMail"].ToString(),
                                          Convert.ToInt32(myReader["fFirmaId"]));

                    filialer.Add(f);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return filialer;
        }

        public void InsertNewGrund(Grund newGrund)
        {
            string sql = @"INSERT INTO Grund(Postnr, Tillæg, Addresse, Areal, FilialNavn) 
                         VALUES(@Postnr, @tillæg, @Adresse, @Areal, @FilialNavn)";
            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myCommand.Parameters.AddWithValue("@Postnr", newGrund.Postnr.postnr);
                myCommand.Parameters.AddWithValue("@Tillæg", newGrund.getTillæg());
                myCommand.Parameters.AddWithValue("@Adresse", newGrund.Adresse);
                myCommand.Parameters.AddWithValue("@Areal", newGrund.getAreal());
                myCommand.Parameters.AddWithValue("@FilialNavn", newGrund.Filial.getNavn());

                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }
        }

        public void UpdateGrund(Grund updatedGrund)
        {
            string sql = "UPDATE Grund SET Postnr = @postnr, Tillæg = @tillæg, Addresse = @adresse, Areal = @areal WHERE Id = @Id";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myCommand.Parameters.AddWithValue("@postnr", updatedGrund.Postnr.postnr);
                myCommand.Parameters.AddWithValue("@tillæg", updatedGrund.getTillæg());
                myCommand.Parameters.AddWithValue("@adresse", updatedGrund.Adresse);
                myCommand.Parameters.AddWithValue("@areal", updatedGrund.getAreal());
                myCommand.Parameters.AddWithValue("@Id", updatedGrund.Id);

                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }
        }

        public void deleteGrund(int id)
        {
            string sql = "DELETE FROM Grund WHERE Id = @id";
            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myCommand.Parameters.AddWithValue("@Id", id);

                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }
        }
    }

    public class DBHustype
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source = CV-PC-T-41\SQLEXPRESS; Initial Catalog = VesterhavsHytten; Integrated Security = True");//Connection string for the database
        SqlCommand myCommand = null;
        SqlDataReader myReader = null;

        public List<HusType> getHustypeList()
        {
            List<HusType> hustyper = new List<HusType>();

            string sql = "SELECT * FROM HusType";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    HusType ht = new HusType(Convert.ToInt32(myReader["Id"]),
                                             Convert.ToInt32(myReader["Etager"]),
                                             Convert.ToInt32(myReader["Areal"]),
                                             myReader["Navn"].ToString());

                    hustyper.Add(ht);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return hustyper;
        }

        public void insertNewHustype(HusType ht)
        {
            string sql = "INSERT INTO HusType(Etager, Areal, Navn) VALUES(@Etager, @Areal, @Navn)";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myCommand.Parameters.AddWithValue("@Etager", ht.Etager);
                myCommand.Parameters.AddWithValue("@Areal", ht.Areal);
                myCommand.Parameters.AddWithValue("@Navn", ht.Navn);

                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { myConnection.Close(); }
        }

        public void deleteHusType(int id)
        {
            string sql = "DELETE FROM HusType WHERE Id = @Id";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myCommand.Parameters.AddWithValue("@Id", id);

                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { myConnection.Close(); }
        }
    }

    public class DBSaelgHus
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source = CV-PC-T-41\SQLEXPRESS; Initial Catalog = VesterhavsHytten; Integrated Security = True");//Connection string for the database
        SqlCommand myCommand = null;
        SqlDataReader myReader = null;

        public List<HusType> getHustyperList()
        {
            List<HusType> hustyper = new List<HusType>();
            DBHustype dbh = new DBHustype();

            hustyper = dbh.getHustypeList();

            return hustyper;
        }

        public List<Grund> getGrundeList()
        {
            List<Grund> grunde = new List<Grund>();
            DBGrund dbg = new DBGrund();

            grunde = dbg.getNotSoldGrundList();

            return grunde;
        }

        public List<Kunde> getKundeList()
        {
            List<Kunde> kunder = new List<Kunde>();

            string sql = @"SELECT k.Id Kid, k.Addresse Kadresse, k.Mail Kmail, k.Navn Knavn, k.Telefon Ktelefon, p.Postnr Ppostnr, p.Navn Pnavn
                            FROM Kunde k
                            JOIN PostDistrikt p
                            ON k.Postnr = p.Postnr";
            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Postnr pn = new Postnr(Convert.ToInt32(myReader["Ppostnr"]), myReader["Pnavn"].ToString());
                    Kunde k = new Kunde(myReader["Knavn"].ToString(),
                                        myReader["Kadresse"].ToString(),
                                        pn,
                                        myReader["Ktelefon"].ToString(),
                                        myReader["Kmail"].ToString(),
                                        Convert.ToInt32(myReader["Kid"]));

                    kunder.Add(k);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return kunder;
        }

        public List<Udbyder> getUdbyderList()
        {
            List<Udbyder> udbyder = new List<Udbyder>();

            string sql = @"Select u.FNavn uFNavn, u.Pris uPris, u.HId uHId, f.Adresse fAdresse, p.Navn pNavn, p.Postnr pPostnr, f.Telefon fTelefon,
                            b.Mail bMail, f.FirmaId fFirmaId, h.Areal hAreal, h.Etager hEtager, h.Navn hNavn FROM Udbyder u
                            JOIN Filial f on u.FNavn = f.Navn
                            JOIN PostDistrikt p ON f.Postnr = p.Postnr
                            JOIN ByggeFirma b ON f.FirmaId = b.Id
                            JOIN HusType h ON u.HId = h.Id";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    HusType h = new HusType(Convert.ToInt32(myReader["uHId"]),
                                            Convert.ToInt32(myReader["hEtager"]),
                                            Convert.ToInt32(myReader["hAreal"]),
                                            myReader["hNavn"].ToString());

                    Postnr p = new Postnr(Convert.ToInt32(myReader["pPostnr"]),
                                          myReader["pNavn"].ToString());

                    Filial f = new Filial(myReader["uFNavn"].ToString(),
                                          myReader["fAdresse"].ToString(),
                                          p,
                                          myReader["fTelefon"].ToString(),
                                          myReader["bMail"].ToString(),
                                          Convert.ToInt32(myReader["fFirmaId"]));

                    bool filialExists = false;
                    // checks if the filial allready exist, if it does it adds the hustype to the list
                    foreach (Udbyder u in udbyder)
                    {
                        if (u.Filial.getNavn() == f.getNavn())
                        {
                            u.addHusTypeToUdbyder(h);
                            filialExists = true;
                            break;
                        }
                    }
                    // if the filial doesn't exist a new udbyder will be created
                    if (filialExists == false)
                    {
                        List<HusType> hustyper = new List<HusType>();
                        hustyper.Add(h);

                        Udbyder u = new Udbyder(f, hustyper, Convert.ToDouble(myReader["uPris"]));
                        udbyder.Add(u);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return udbyder;
        }

        public List<Salg> getSalgList()
        {
            List<Salg> salg = new List<Salg>();

            string sql = @"SELECT s.GId sGId, s.HtId sHtId, s.KId sKId,

                            g.Addresse gAdresse, g.Areal gAreal, g.FilialNavn gFilialNavn, g.Postnr gPostnr, gp.Navn gpNavn,
                            g.Tillæg gTillæg, fg.Adresse fgAdresse, fg.FirmaId fgFirmaId, fg.Navn fgNavn, fg.Postnr fgPostnr, fp.Navn fpNavn, fg.Telefon fgTelefon, b.Mail bMail,

                            h.Areal hAreal, h.Etager hEtager, h.Navn hNavn,

                            k.Addresse kAdresse, k.Mail kMail, k.Navn kNavn, k.Postnr kPostnr, kp.Navn kpNavn, k.Telefon kTelefon, u.Pris uPris FROM Solgt s

                            JOIN Grund g ON s.GId = g.Id
                            JOIN HusType h ON s.HtId = h.Id
                            JOIN Kunde k ON s.KId = k.Id
                            JOIN PostDistrikt gp ON g.Postnr = gp.Postnr
                            JOIN PostDistrikt kp ON k.Postnr = kp.Postnr
                            JOIN Filial fg ON g.FilialNavn = fg.Navn
                            JOIN PostDistrikt fp ON fg.Postnr = fp.Postnr
                            JOIN ByggeFirma b ON fg.FirmaId = b.Id
                            JOIN Udbyder u ON fg.Navn = u.FNavn AND s.HtId = u.HId";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //kunde
                    Postnr kp = new Postnr(Convert.ToInt32(myReader["kPostnr"]),
                                           myReader["kpNavn"].ToString());

                    Kunde k = new Kunde(myReader["kNavn"].ToString(),
                                        myReader["kAdresse"].ToString(),
                                        kp,
                                        myReader["kTelefon"].ToString(),
                                        myReader["kMail"].ToString(),
                                        Convert.ToInt32(myReader["sKId"]));

                    //grund
                    Postnr gp = new Postnr(Convert.ToInt32(myReader["gPostnr"]),
                                           myReader["gpNavn"].ToString());

                    Postnr fp = new Postnr(Convert.ToInt32(myReader["fgPostnr"]),
                                           myReader["fpNavn"].ToString());

                    Filial gf = new Filial(myReader["fgNavn"].ToString(),
                                           myReader["fgAdresse"].ToString(),
                                           fp,
                                           myReader["fgTelefon"].ToString(),
                                           myReader["bMail"].ToString(),
                                           Convert.ToInt32(myReader["fgFirmaId"]));

                    Grund g = new Grund(myReader["gAdresse"].ToString(),
                                        gp, Convert.ToDouble(myReader["gTillæg"]),
                                        Convert.ToInt32(myReader["gAreal"]),
                                        Convert.ToInt32(myReader["sGId"]),
                                        gf);

                    //hustype
                    HusType h = new HusType(Convert.ToInt32(myReader["sHtId"]), Convert.ToInt32(myReader["hEtager"]), Convert.ToInt32(myReader["hAreal"]), myReader["hNavn"].ToString());

                    Salg s = new Salg(h, g, k, Convert.ToDouble(myReader["uPris"]) + Convert.ToDouble(myReader["gTillæg"]));

                    salg.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return salg;
        }

        public void createSalg(Salg salg)
        {
            string sql = "INSERT INTO Solgt(HtId, KId, GId) VALUES (@HtId, @KId, @GId)";

            myCommand = new SqlCommand(sql, myConnection);

            myCommand.Parameters.AddWithValue("@HtId", salg.HusType.Id);
            myCommand.Parameters.AddWithValue("@KId", salg.Kunde.Id);
            myCommand.Parameters.AddWithValue("@GId", salg.Grund.Id);

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }
        }
    }

    public class dbForspøgelser
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source = CV-PC-T-41\SQLEXPRESS; Initial Catalog = VesterhavsHytten; Integrated Security = True");//Connection string for the database
        SqlCommand myCommand = null;
        SqlDataReader myReader = null;

        public bool A7Exist()
        {
            bool exists = false;
            string sql = @"Select FNavn FROM Udbyder u
                            JOIN HusType h ON h.Id = u.HId
                            WHERE h.Etager = 1
                            AND NOT EXISTS(SELECT * FROM udbyder uu JOIN HusType hh ON hh.id = uu.HId WHERE hh.Etager > 1 AND uu.FNavn = u.FNavn)";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader["FNavn"] != null)
                    {
                        exists = true;
                        return exists;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }
            return exists;
        }

        public List<Filial> B7FilialList()
        {
            DBGrund dbg = new DBGrund();
            List<Filial> filialer = dbg.getFilialList();

            return filialer;
        }

        public List<string> B7Answer(string filial)
        {
            List<string> answers = new List<string>();

            string sql = @"SELECT u.FNavn uFNavn, u.HId uHId, u.Pris uPris FROM Udbyder u
                         JOIN HusType h ON u.HId = h.Id
                         WHERE h.Areal > 180
                         AND h.Etager = 1 AND
                         u.FNavn = @filial";

            myCommand = new SqlCommand(sql, myConnection);
            myCommand.Parameters.AddWithValue("@filial", filial);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["uFNavn"].ToString() + " - " + myReader["uHId"].ToString() + " - " + myReader["uPris"].ToString();

                    answers.Add(s);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return answers;
        }

        public List<string> C7Answer(string filial)
        {
            List<string> huse = new List<string>();

            string sql = @"SELECT h.Id hId, h.Navn hNavn, h.Etager hEtager, h.Areal hAreal FROM HusType h
                         JOIN Udbyder u ON h.Id = u.HId
                         WHERE u.FNavn = @filial";
            myCommand = new SqlCommand(sql, myConnection);
            myCommand.Parameters.AddWithValue("@filial", filial);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["hId"].ToString() + " - " + myReader["hNavn"].ToString() + " - " + myReader["hEtager"].ToString() + " - " + myReader["hAreal"].ToString();

                    huse.Add(s);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return huse;
        }

        public List<string> D7Answer()
        {
            List<string> huse = new List<string>();

            string sql = @"SELECT h.Id hId, h.Navn hNavn, h.Etager hEtager, h.Areal hAreal FROM HusType h
                         WHERE NOT EXISTS (SELECT * FROM Udbyder u WHERE h.Id = u.hid)";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["hId"].ToString() + " - " + myReader["hNavn"].ToString() + " - " + myReader["hEtager"].ToString() + " - " + myReader["hAreal"].ToString();

                    huse.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return huse;
        }

        public List<string> E7()
        {
            List<string> huse = new List<string>();

            string sql = @"SELECT u.HId, h.Id hId, h.Navn hNavn, h.Etager hEtager, h.Areal hAreal FROM HusType h
                            JOIN Udbyder u ON h.Id = u.HId
                            GROUP BY u.HId, h.Id, h.Navn, h.Etager, h.Areal
                            HAVING COUNT(u.FNavn) = 1";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["hId"].ToString() + " - " + myReader["hNavn"].ToString() + " - " + myReader["hEtager"].ToString() + " - " + myReader["hAreal"].ToString();

                    huse.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return huse;
        }

        public List<string> F7(string filial)
        {
            List<string> huse = new List<string>();

            string sql = @"SELECT h.Areal hAreal, h.Id hId, h.Navn hNavn, h.Etager hEtager FROM HusType h
                        JOIN udbyder u ON u.HId = h.Id
                        WHERE u.FNavn = @filial
                        AND h.Areal = (SELECT MAX(hh.Areal)
                        FROM HusType hh JOIN Udbyder uu ON uu.HId = hh.id 
                        WHERE uu.FNavn = @filial)";

            myCommand = new SqlCommand(sql, myConnection);
            myCommand.Parameters.AddWithValue("@filial", filial);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["hId"].ToString() + " - " + myReader["hNavn"].ToString() + " - " + myReader["hEtager"].ToString() + " - " + myReader["hAreal"].ToString();

                    huse.Add(s);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { myConnection.Close(); }

            return huse;
        }

        public List<string> G7()
        {
            List<string> filialer = new List<string>();

            string sql = @"SELECT u.FNavn uFNavn, COUNT(u.HId) FROM udbyder u GROUP BY u.FNavn
                         HAVING COUNT(u.Hid)=(SELECT Count(*) FROM HusType)";
            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["uFNavn"].ToString();

                    filialer.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return filialer;
        }

        public List<string> H7()
        {
            List<string> filialInfo = new List<string>();

            string sql = @"SELECT f.Navn fNavn, MAX(u.Pris ) maksimum, MIN(u.Pris ) minimum, AVG(u.Pris) gennemsnit
                            FROM Filial f
                            JOIN Udbyder u ON f.Navn = u.FNavn
                            GROUP BY f.Navn";
            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["fNavn"].ToString() + " - " + myReader["maksimum"].ToString() + " - " + myReader["minimum"].ToString() + " - " + myReader["gennemsnit"].ToString();

                    filialInfo.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return filialInfo;
        }

        public List<string> I7()
        {
            List<string> filialInfo = new List<string>();

            string sql = @"SELECT f.navn fNavn, SUM(g.Tillæg) total FROM Filial f
                            JOIN Grund g ON f.Navn = g.FilialNavn
                            GROUP BY f.Navn ORDER BY total";

            myCommand = new SqlCommand(sql, myConnection);

            try
            {
                myConnection.Open();
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string s = myReader["fNavn"].ToString() + " - " + myReader["total"].ToString();
                    filialInfo.Add(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { myConnection.Close(); }

            return filialInfo;
        }
    }
}
