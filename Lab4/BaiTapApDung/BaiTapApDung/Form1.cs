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
    public partial class Form1 : Form
    {
        // TODO: chỉnh lại connection string cho đúng SQL Server của bạn
        private readonly string _connectionString =
            @"Data Source=DESKTOP-ISSK39T;Initial Catalog=OrganizationDB;User ID=sa;Password=1224454";

        private int _currentOrgId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearErrors()
        {
            errorProvider1.SetError(txtOrgName, "");
            errorProvider1.SetError(txtPhone, "");
            errorProvider1.SetError(txtEmail, "");
            lblStatus.Text = "";
        }

        private bool ValidateInputs()
        {
            ClearErrors();
            bool isValid = true;

            string orgName = txtOrgName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // OrgName: required, length 3..255
            if (string.IsNullOrEmpty(orgName))
            {
                errorProvider1.SetError(txtOrgName, "Organization Name is required");
                isValid = false;
            }
            else if (orgName.Length < 3 || orgName.Length > 255)
            {
                errorProvider1.SetError(txtOrgName, "Length must be from 3 to 255 characters");
                isValid = false;
            }

            // Phone: if not empty -> digits only, length 9..12
            if (!string.IsNullOrEmpty(phone))
            {
                if (!Regex.IsMatch(phone, @"^\d{9,12}$"))
                {
                    errorProvider1.SetError(txtPhone, "Phone must be 9-12 digits");
                    isValid = false;
                }
            }

            // Email: if not empty -> basic email pattern
            if (!string.IsNullOrEmpty(email))
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    errorProvider1.SetError(txtEmail, "Invalid email format");
                    isValid = false;
                }
            }

            if (!isValid)
            {
                lblStatus.Text = "Please correct the highlighted fields.";
            }

            return isValid;
        }

        private bool CheckOrgNameExists(string orgName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM ORGANIZATION WHERE LOWER(OrgName) = LOWER(@OrgName)", conn))
            {
                cmd.Parameters.AddWithValue("@OrgName", orgName);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private int InsertOrganization(string orgName, string address, string phone, string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO ORGANIZATION (OrgName, Address, Phone, Email, CreatedDate)
                  VALUES (@OrgName, @Address, @Phone, @Email, GETDATE());
                  SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
            {
                cmd.Parameters.AddWithValue("@OrgName", (object)orgName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address);
                cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);

                conn.Open();
                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
        }

        // ========== EVENT HANDLERS ==========

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;

            if (!ValidateInputs())
            {
                return; // không lưu nếu validate fail
            }

            string orgName = txtOrgName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            try
            {
                // Check trùng OrgName
                if (CheckOrgNameExists(orgName))
                {
                    lblStatus.Text = "Organization Name already exists";
                    errorProvider1.SetError(txtOrgName, "Organization Name already exists");
                    return;
                }

                // Lưu vào DB
                int newId = InsertOrganization(orgName, address, phone, email);
                _currentOrgId = newId;
                btnDirector.Enabled = true;

                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Save successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error while saving: " + ex.Message;
            }
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            if (_currentOrgId <= 0)
            {
                MessageBox.Show("Please save organization first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mở form Director Management và truyền Organization vừa tạo
            string orgName = txtOrgName.Text.Trim();
            var directorForm = new DirectorForm(_currentOrgId, orgName);
            directorForm.ShowDialog(); // hoặc Show() nếu bạn muốn không chặn
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            // Đóng form, quay lại màn hình trước (Main form / menu...)
            this.Close();
        }
    }
}
