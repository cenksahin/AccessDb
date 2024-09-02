using AccessDb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

#pragma warning disable 
namespace AccessDb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/Database.mdb");
            string mdbBaglanti = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + fullPath + ";";

            Table1 tablo = new();

            OleDbConnection OlDbCnctn = new(mdbBaglanti);
            OlDbCnctn.Open();

            OleDbCommand OlDbCmnd = new("select Adi from Table1", OlDbCnctn);

            OleDbDataReader OlDbDtRdr = OlDbCmnd.ExecuteReader();
            if (OlDbDtRdr.HasRows)
            {
                OlDbDtRdr.Read();

                tablo.Adi = OlDbDtRdr["Adi"].ToString().Trim();
            }

            OlDbDtRdr.Close();
            OlDbCnctn.Close();

            return View(tablo);
        }
    }
}