using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PCODSurveyApp;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
namespace PCODSurvey.Models
{
    public class SurveyForm : Form
    {        // Database connection string (update YOUR_SERVER_NAME)        private string connectionString = "Server=YOUR_SERVER_NAME;Database=PCODSurveyDB;Trusted_Connection=True;";
        // Declare controls        private Label lblName, lblWeight, lblHeight, lblBloodGroup, lblAge, lblGender;        private TextBox txtName, txtWeight, txtHeight;        private ComboBox cmbBloodGroup, cmbAge, cmbGender;        private Button btnSubmit;
        public SurveyForm()
        {            // Form properties            this.Text = "PCOD Survey";            this.Size = new Size(800, 600);            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize controls            InitializeControls();        }
        private void InitializeControls()
        {            // Labels            lblName = new Label { Text = "What is your name?", Location = new Point(50, 30), AutoSize = true };            lblWeight = new Label { Text = "What is your weight (in kg)?", Location = new Point(50, 80), AutoSize = true };            lblHeight = new Label { Text = "What is your height (in cm)?", Location = new Point(50, 130), AutoSize = true };            lblBloodGroup = new Label { Text = "What is your blood group?", Location = new Point(50, 180), AutoSize = true };            lblAge = new Label { Text = "What is your age?", Location = new Point(50, 230), AutoSize = true };            lblGender = new Label { Text = "What is your gender?", Location = new Point(50, 280), AutoSize = true };
            // TextBoxes            txtName = new TextBox { Location = new Point(300, 30), Width = 200 };            txtWeight = new TextBox { Location = new Point(300, 80), Width = 200 };            txtHeight = new TextBox { Location = new Point(300, 130), Width = 200 };
            // ComboBoxes            cmbBloodGroup = new ComboBox { Location = new Point(300, 180), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };            cmbBloodGroup.Items.AddRange(new string[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-", "I don't know" });
            cmbAge = new ComboBox { Location = new Point(300, 230), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList }; cmbAge.Items.AddRange(new string[] { "Under 18", "18–24", "25–34", "35–44", "45 and above" });
            cmbGender = new ComboBox { Location = new Point(300, 280), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList }; cmbGender.Items.AddRange(new string[] { "Female", "Male", "Non-binary", "Prefer not to say" });
            // Submit Button            btnSubmit = new Button            {                Text = "Submit",                Location = new Point(300, 350),                BackColor = Color.LightBlue,                Width = 100,            };            btnSubmit.Click += BtnSubmit_Click;
            // Add controls to the form            this.Controls.Add(lblName);            this.Controls.Add(txtName);            this.Controls.Add(lblWeight);            this.Controls.Add(txtWeight);            this.Controls.Add(lblHeight);            this.Controls.Add(txtHeight);            this.Controls.Add(lblBloodGroup);            this.Controls.Add(cmbBloodGroup);            this.Controls.Add(lblAge);            this.Controls.Add(cmbAge);            this.Controls.Add(lblGender);            this.Controls.Add(cmbGender);            this.Controls.Add(btnSubmit);        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {                // Retrieve data from controls                string name = txtName.Text;                double weight = double.Parse(txtWeight.Text);                double height = double.Parse(txtHeight.Text);                string bloodGroup = cmbBloodGroup.Text;                string age = cmbAge.Text;                string gender = cmbGender.Text;
                             // Insert into the database                using (SqlConnection connection = new SqlConnection(connectionString))                {                    string query = @"                        INSERT INTO SurveyResponses (Name, Weight, Height, BloodGroup, Age, Gender)                        VALUES (@Name, @Weight, @Height, @BloodGroup, @Age, @Gender);";
                SqlCommand command = new SqlCommand(query, connection); command.Parameters.AddWithValue("@Name", name); command.Parameters.AddWithValue("@Weight", weight); command.Parameters.AddWithValue("@Height", height); command.Parameters.AddWithValue("@BloodGroup", bloodGroup); command.Parameters.AddWithValue("@Age", age); command.Parameters.AddWithValue("@Gender", gender);
                connection.Open(); command.ExecuteNonQuery();
            }

        MessageBox.Show("Survey submitted successfully!");
        }            catch (Exception ex)            {                MessageBox.Show("Error: " + ex.Message);            }
}
[STAThread] public static void Main() { Application.EnableVisualStyles(); Application.Run(new SurveyForm()); }    }}