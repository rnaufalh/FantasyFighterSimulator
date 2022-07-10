using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FantasyFighterSimulator
{
    public partial class CharacterSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                // To show all data when the page is first loaded
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();

                string query = "SELECT * FROM [Characters];";
                SqlCommand cmd = new SqlCommand(query, conn);

                DataTable allData = new DataTable();
                allData.Load(cmd.ExecuteReader());

                CharGridView.DataSource = allData;
                CharGridView.DataBind();

                conn.Close();
            }
            
        }

        protected void CharGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey primaryKey = CharGridView.SelectedDataKey;

            string id = primaryKey.Value.ToString();
            
            Response.Redirect("CharacterDetails.aspx" + "?ID=" + id);

        }

        protected void ApplyFilters_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            string selectedName = SearchTextBox.Text;
            string selectedJobType = JobTypeList.SelectedValue;

            string query =
                "SELECT * " +
                "FROM [Characters] " +
                "WHERE Name LIKE ISNULL('" + selectedName + "%', '')" +
                "AND JobType LIKE ISNULL('%" + selectedJobType + "%', '');";

            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable allData = new DataTable();
            allData.Load(cmd.ExecuteReader());

            CharGridView.DataSource = allData;
            CharGridView.DataBind();

            conn.Close();
        }
    }
}