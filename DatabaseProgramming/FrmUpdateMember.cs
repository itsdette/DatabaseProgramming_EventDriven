using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProgramming
{
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int Age;
        private string Program;
        private long StudentId;
        private int count = 0;
        private string FirstName, MiddleName, LastName, Gender;

        public FrmUpdateMember()
        {
            InitializeComponent();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            this.clubMembersTableAdapter.Fill(this.clubDBDataSet.ClubMembers);
            this.clubMembersTableAdapter.Fill(this.clubDBDataSet.ClubMembers);
            clubRegistrationQuery = new ClubRegistrationQuery();
            clubRegistrationQuery.DisplayID(comboBoxStudentID);

        }

        private void comboBoxStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxStudentID.SelectedItem != null)
            {
                long selectedStudentID = Convert.ToInt64(comboBoxStudentID.SelectedItem);
                clubRegistrationQuery.GetStudentData(selectedStudentID);
                TextFill();
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StudentId = Convert.ToInt64(comboBoxStudentID.Text);
            Age = Convert.ToInt32(txtBoxAge.Text);
            Program = comboBoxProgram.Text;
            FirstName = txtBoxFirst.Text;
            MiddleName = txtBoxMiddle.Text;
            LastName = txtBoxLast.Text;
            Gender = comboBoxGender.Text;
            clubRegistrationQuery.UpdateStudent(StudentId, Age, Program, FirstName, LastName, MiddleName, Gender);
        }

        public void Fill()
        {
            string ClubDBConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\deane\source\repos\ClubRegistration\ClubDB.mdf; Integrated Security = True";
            SqlConnection sqlConnect = new SqlConnection(ClubDBConnectionString);
            string getId = "SELECT * FROM ClubMembers";
            SqlCommand sqlCommand = new SqlCommand(getId, sqlConnect);
            sqlConnect.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBoxStudentID.Items.Add(sqlReader["StudentId"]);
            }
            sqlConnect.Close();
        }
        public void TextFill()
        {
            txtBoxLast.Text = clubRegistrationQuery._LastName;
            txtBoxFirst.Text = clubRegistrationQuery._FirstName;
            txtBoxMiddle.Text = clubRegistrationQuery._MiddleName;
            txtBoxAge.Text = clubRegistrationQuery._Age.ToString();
            comboBoxGender.Text = clubRegistrationQuery._Gender;
            comboBoxProgram.Text = clubRegistrationQuery._Program;
        }
        public void cbFill()
        {
            clubRegistrationQuery.DisplayID(comboBoxStudentID);
        }

    }
}
