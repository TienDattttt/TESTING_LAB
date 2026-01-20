using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapApDung
{
    public partial class DirectorForm : Form
    {
        private readonly int _orgId;
        private readonly string _orgName;
        private readonly string _connectionString =
            @"Data Source=DESKTOP-ISSK39T;Initial Catalog=OrganizationDB;User ID=sa;Password=1224454";

        public DirectorForm(int orgId, string orgName)
        {
            _orgId = orgId;
            _orgName = orgName;
            InitializeComponent();
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            lblOrgNameValue.Text = _orgName;
            LoadDirectors();
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtDirectorName, "");
            errorProvider1.SetError(txtDirectorPhone, "");
            errorProvider1.SetError(txtDirectorEmail, "");
            lblStatusDirector.Text = "";
        }

        private bool ValidateDirectorInputs()
        {
            ClearErrors();
            bool isValid = true;

            string name = txtDirectorName.Text.Trim();
            string phone = txtDirectorPhone.Text.Trim();
            string email = txtDirectorEmail.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                errorProvider1.SetError(txtDirectorName, "Director name is required");
                isValid = false;
            }

            if (!string.IsNullOrEmpty(phone))
            {
                if (!Regex.IsMatch(phone, @"^\d{9,12}$"))
                {
                    errorProvider1.SetError(txtDirectorPhone, "Phone must be 9–12 digits");
                    isValid = false;
                }
            }

            if (!string.IsNullOrEmpty(email))
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    errorProvider1.SetError(txtDirectorEmail, "Invalid email format");
                    isValid = false;
                }
            }

            if (!isValid)
            {
                lblStatusDirector.Text = "Please correct highlighted fields.";
            }

            return isValid;
        }

        private void LoadDirectors()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT DirectorID, FullName, Phone, Email, CreatedDate
                  FROM DIRECTOR
                  WHERE OrgID = @OrgID
                  ORDER BY CreatedDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@OrgID", _orgId);
                DataTable dt = new DataTable();
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                dgvDirectors.DataSource = dt;
            }
        }

        private void InsertDirector(string name, string phone, string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO DIRECTOR (OrgID, FullName, Phone, Email, CreatedDate)
                  VALUES (@OrgID, @FullName, @Phone, @Email, GETDATE());", conn))
            {
                cmd.Parameters.AddWithValue("@OrgID", _orgId);
                cmd.Parameters.AddWithValue("@FullName", name);
                cmd.Parameters.AddWithValue("@Phone",
                    string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnAddDirector_Click(object sender, EventArgs e)
        {
            if (!ValidateDirectorInputs())
                return;

            try
            {
                string name = txtDirectorName.Text.Trim();
                string phone = txtDirectorPhone.Text.Trim();
                string email = txtDirectorEmail.Text.Trim();

                InsertDirector(name, phone, email);

                lblStatusDirector.ForeColor = System.Drawing.Color.Green;
                lblStatusDirector.Text = "Director saved successfully.";

                // Clear input & reload grid
                txtDirectorName.Clear();
                txtDirectorPhone.Clear();
                txtDirectorEmail.Clear();
                LoadDirectors();
            }
            catch (Exception ex)
            {
                lblStatusDirector.ForeColor = System.Drawing.Color.Red;
                lblStatusDirector.Text = "Error while saving director: " + ex.Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
