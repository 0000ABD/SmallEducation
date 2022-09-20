
namespace smallEdu
{
    public partial class smallEdu : Form
    {
        const String notAllowed = "[0-9 \\[\\]{ \"}~`!@#$%\\^&\\*()\\-_+=|\\':;/><]+";
        public LocalDatabase lbDataBase;
        public static st_Standards st_StdCount;
        private DebugLogger log;
        public smallEdu()
        {
            InitializeComponent();
            log = new DebugLogger();
            if(File.Exists(Mislaneous.s_debugStatementFile))
            {
                File.Delete(Mislaneous.s_debugStatementFile);
            }
            st_StdCount = new st_Standards(this.CB_newStudentStanderd.Items.Count - 1, this.CB_newStudentStanderd.Items );
            log.logDebugStatement("Standard Counts : " + st_StdCount.int_Standards.ToString()+System.Environment.NewLine);

              lbDataBase = new LocalDatabase();
            lbDataBase.initDataBase();
            
            

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

        private void CB_newStudentStanderd_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.logDebugStatement(CB_newStudentStanderd.SelectedIndex.ToString());
            switch ((Mislaneous.e_streem)CB_newStudentStanderd.SelectedIndex)  
            {
                case Mislaneous.e_streem.XI:
                case Mislaneous.e_streem.XII:
                case Mislaneous.e_streem.Bachelor:
                case Mislaneous.e_streem.Master:
                    CB_newStudentStreem.Enabled = true;     /*Enable streem selection combobox*/
                    break;
                default:
                    CB_newStudentStreem.Enabled = false;  /*Enable streem selection combobox*/
                    CB_newStudentStreem.Items.Clear();
                    break;
            }

            try
            {
                string s_file = Mislaneous.s_streemPath + Enum.GetName((Enum)Mislaneous.e_streem,(Mislaneous.e_streem)CB_newStudentStanderd.SelectedIndex) + Mislaneous.s_streemFileExtn)
                switch ((Mislaneous.e_streem)CB_newStudentStanderd.SelectedIndex)
                {
                    case Mislaneous.e_streem.XI:
                        CB_newStudentStreem.Items.Add
                        break;
                    case Mislaneous.e_streem.XII:
                        break;
                    case Mislaneous.e_streem.Bachelor:
                        break;
                    case Mislaneous.e_streem.Master:
                        break;
                }
            }
            catch(Exception ex)
            {
                log.logDebugStatement(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class DebugLogger
    {
        public void logDebugStatement(string statement)
        {
            File.AppendAllText(Mislaneous.s_debugStatementFile,statement);
        }
    }
}