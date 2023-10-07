using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;

namespace WebApp6Aug
{
    public partial class EnrollmentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source= DESKTOP-2OLVHPJ; initial catalog=Sep_23; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if(!IsPostBack)
            {
                Display();
                showGender();
                showBoard();
                SClass();
                SStream();
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
             
        {
            if (btnSave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into enrollments(NAME,FATHER_NAME,MOTHER_NAME,GENDER,BOARD,CLASS,STREAM) values('" + txtname.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + rblgender.SelectedValue + "','" + rblboard.SelectedValue + "','" + ddclass.SelectedValue + "','" + ddstream.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                txtname.Text = "";
                txtfname.Text = "";
                rblgender.ClearSelection();
                rblboard.ClearSelection();
                ddclass.ClearSelection();
                ddstream.ClearSelection();

            }
            else if(btnSave.Text == "Update")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update enrollments set NAME='" + txtname.Text + "' , FATHER_NAME='" + txtfname.Text + "' , MOTHER_NAME='" + txtmname.Text + "',GENDER='" + rblgender.SelectedValue + "', BOARD= '" + rblboard.SelectedValue + "', CLASS='" + ddclass.SelectedValue + "',STREAM='" + ddstream.SelectedValue + "'  where EnrollNo = '" + ViewState["abc"] + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                txtname.Text = "";
                txtfname.Text = "";
                txtmname.Text = "";
                rblgender.ClearSelection();
                rblboard.ClearSelection();
                ddclass.ClearSelection();
                ddstream.ClearSelection();
                btnSave.Text = "Save";


            }


        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from enrollments join sgender on GENDER = genderid join board on BOARD = bid join class on CLASS= cid join stream on STREAM = sid", con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt; 
            grd.DataBind();
        }

        public void showGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select *from sgender", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "genderid";
            rblgender.DataTextField = "gendername";
            rblgender.DataSource = dt;
            rblgender.DataBind();
           

        }


        public void showBoard()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select *from board", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblboard.DataValueField = "bid";
            rblboard.DataTextField = "bvalue";
            rblboard.DataSource = dt;
            rblboard.DataBind();
        }

        public void SClass()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select *from class", con);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddclass.DataValueField = "cid";
            ddclass.DataTextField = "cname";
            ddclass.DataSource = dt;
            ddclass.DataBind();
            ddclass.Items.Insert(0, new ListItem("--select Class---"));
        }
        public void SStream()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select *from stream", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddstream.DataValueField = "sid";
            ddstream.DataTextField = "sname";
            ddstream.DataSource = dt;
            ddstream.DataBind();
            ddstream.Items.Insert(0, new ListItem("--select stream---"));
        }


        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from enrollments where EnrollNo='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }

            else if (e.CommandName == "edi")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from enrollments where EnrollNo= '" + e.CommandArgument + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);            
                con.Close(); 
                txtname.Text = dt.Rows[0][1].ToString();
                txtfname.Text = dt.Rows[0][2].ToString();
                txtmname.Text = dt.Rows[0][3].ToString();
                rblgender.SelectedValue = dt.Rows[0][4].ToString();
                rblboard.SelectedValue = dt.Rows[0][5].ToString();
                ddclass.SelectedValue = dt.Rows[0][6].ToString();
                ddstream.SelectedValue = dt.Rows[0][7].ToString();

                btnSave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;

            }
        }
    }
}