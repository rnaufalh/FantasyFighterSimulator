using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FantasyFighterSimulator
{
    public partial class CharacterDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("ID");

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            string characterQuery = 
                "SELECT c.Name, c.JobType, c.HP, c.AP, c.Speed, w.Name, w.WeaponType, w.DamageDealt, a.Name, a.ArmorType, a.ArmorPoints " +
                "FROM [Characters] AS c " +
                "INNER JOIN [Weapons] AS w ON c.WeaponId=w.WeaponId " +
                "INNER JOIN [Armors] AS a ON c.ArmorId=a.ArmorId " +
                "WHERE CharacterId=" + id + ";";
            SqlCommand cmd = new SqlCommand(characterQuery, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int weaponRowCount = 1;
                int armorRowCount = 1;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i >= 0 && i <= 4)
                    {
                        CharacterDataTable.Rows[i+1].Cells[1].Text = "" + reader[i];
                    }
                    else if (i >= 5 && i <= 7)
                    {
                        WeaponDataTable.Rows[weaponRowCount].Cells[1].Text = "" + reader[i];
                        weaponRowCount++;
                    }
                    else if (i >= 8 && i <= 10)
                    {
                        ArmorDataTable.Rows[armorRowCount].Cells[1].Text = "" + reader[i];
                        armorRowCount++;
                    }
                }
            }

        }
    }
}