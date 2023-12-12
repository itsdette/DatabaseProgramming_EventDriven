using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProgramming
{
    public partial class FrmClubRegistration : Form
    {

        private ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();
        private int ID, Age ;
        private int count = 0 ;
        private string FirstName, LastName, MiddleName, Gender, Program;
        private long StudentID;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember update = new FrmUpdateMember();
            update.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentID = Convert.ToInt64(txtboxStudentID.Text);
            FirstName = txtBoxFirst.Text;
            MiddleName = txtBoxMiddle.Text;
            LastName = txtBoxLast.Text;
            Age = Convert.ToInt32(txtBoxAge.Text);
            Gender = comboBoxGender.Text;
            Program = comboBoxProgram.Text;

            clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName,
            MiddleName, LastName, Age, Gender, Program);
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
           // clubRegistrationQuery = new ClubRegistrationQuery();
           // RefreshListOfClubMembers();
        }

        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        public int RegistrationID()
        {
            
            return ++count;
        }
    }
}
