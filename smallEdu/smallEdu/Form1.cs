
namespace smallEdu
{
    public partial class smallEdu : Form
    {
        const String notAllowed = "[0-9 \\[\\]{ \"}~`!@#$%\\^&\\*()\\-_+=|\\':;/><]+";
        public smallEdu()
        {
            InitializeComponent();
        }

       

        private void BT_logIn_Click(object sender, EventArgs e)
        {

        }

        private void CAL_dateOfBirth_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.TB_dateOfBirth.Text = this.CAL_dateOfBirth.SelectionRange.Start.ToShortDateString();
        }

        private void CAL_newStudentDateOfBirth_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.TB_newStudentDateOfBirth.Text = this.CAL_newStudentDateOfBirth.SelectionRange.Start.ToShortDateString();

        }

        private void BT_newStudentBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                
                FileDialog fd = new OpenFileDialog();
                fd.Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(fd.FileName);
                    Image img = Image.FromFile(fd.FileName);
                  
                        /*resize the image according to picture box*/
                        img = img.GetThumbnailImage(PB_newStudentPicture.Width, PB_newStudentPicture.Height, null, IntPtr.Zero);
                        PB_newStudentPicture.Image = img;
                        PB_newStudentPicture.BackgroundImageLayout = ImageLayout.Center;
                       
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               // File.AppendAllLines();
            }
            
        }

       

        private void TB_newStudentFatherName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TB_newStudentFatherName.Text, notAllowed))
            {
                LB_newStudentFatherName.ForeColor = Color.Red;
            }
            else
            {

                LB_newStudentFatherName.ForeColor = Color.Black;
            }

        }

        private void TB_newStudentMotherName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TB_newStudentMotherName.Text, notAllowed))
            {
                LB_newStudentMotherName.ForeColor = Color.Red;
            }
            else
            {

                LB_newStudentMotherName.ForeColor = Color.Black;
            }

        }

        private void TB_newStudentFullName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TB_newStudentFullName.Text, notAllowed))
            {
                LB_newStudent.ForeColor = Color.Red;
            }
            else
            {

                LB_newStudent.ForeColor = Color.Black;
            }
        }

    }
}