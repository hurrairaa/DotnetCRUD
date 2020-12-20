using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Interface;
using FirstProject.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace FirstProject.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly string _connectionString;

        public FamilyService(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("MysqlConnection");
        }
        public void AddFamily(Family fam)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(this._connectionString))
                {
                    con.Open();
                    string insertQuery = "Insert into family(members,mother,father,sisters,brothers) Values('" + fam.members + "','" + fam.mother + "','" + fam.father + "','" + fam.brothers + "','" + fam.sisters + "')";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, con)){ 

                        cmd.ExecuteNonQuery();
                    }   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Family> GetFamily()
        {
            List<Family> familyList = new List<Family>();
            using (MySqlConnection con = new MySqlConnection(this._connectionString))
            {
                con.Open();
                string insertQuery = "SELECT * FROM family";
                using (MySqlCommand cmd= new MySqlCommand(insertQuery, con))
                {
                    
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Family family = new Family {
                            id = Convert.ToInt32(rdr["id"]),
                            members = Convert.ToInt32(rdr["members"]),
                            father = rdr["father"].ToString(),
                            mother=rdr["mother"].ToString(),
                            brothers= Convert.ToInt32(rdr["brothers"]),
                            sisters= Convert.ToInt32(rdr["sisters"])
                        };
                        familyList.Add(family);
                    }
                }
            
  
                return familyList;
            }
        }
        public void EditFamily(Family fam)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(this._connectionString))
                {
                    con.Open();
                    string insertQuery = "Insert into family(members,mother,father,sisters,brothers) Values('" + fam.members + "','" + fam.mother + "','" + fam.father + "','" + fam.brothers + "','" + fam.sisters + "')";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                    {

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFamily(Family fam)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(this._connectionString))
                {
                    con.Open();
                    string insertQuery = "Delete from family Where id="+fam.id+"";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                    {

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Family GetFamilyById(int famid)
        {
            Family family= new Family();
            using (MySqlConnection con = new MySqlConnection(this._connectionString))
            {
                con.Open();
                string insertQuery = "SELECT * FROM family Where id="+famid+"";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        family.id = Convert.ToInt32(rdr["id"]);
                        family.members = Convert.ToInt32(rdr["members"]);
                        family.father = rdr["father"].ToString();
                        family.mother = rdr["mother"].ToString();
                        family.brothers = Convert.ToInt32(rdr["brothers"]);
                        family.sisters = Convert.ToInt32(rdr["sisters"]);
                    }
                }


                return family;
            }
        }
    }
}
