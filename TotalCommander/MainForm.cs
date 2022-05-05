using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace TotalCommander
{
    public partial class MainForm : Form
    {

        private List<string> copy_paths;
        private string path_to_copy;
        private Thread thread;
        public MainForm(string leftpath,string rightpath)
        {
            InitializeComponent();
            LeftSmallPanel = new SmallPanel(leftpath);
            RightSmallPanel = new SmallPanel(rightpath);

            LeftSmallPanel.DeleteAction = Reload;
            RightSmallPanel.DeleteAction = Reload;

            TwoPanelsSplitConteiner.Panel1.Controls.Add(LeftSmallPanel);
            TwoPanelsSplitConteiner.Panel2.Controls.Add(RightSmallPanel);
        }
        public MainForm()
        { 
            InitializeComponent();
            LeftSmallPanel = new SmallPanel();
            RightSmallPanel = new SmallPanel();

            LeftSmallPanel.DeleteAction = Reload;
            RightSmallPanel.DeleteAction = Reload;

            TwoPanelsSplitConteiner.Panel1.Controls.Add(LeftSmallPanel);
            TwoPanelsSplitConteiner.Panel2.Controls.Add(RightSmallPanel);
        }
        static private SmallPanel LeftSmallPanel = new SmallPanel();
        static private SmallPanel RightSmallPanel = new SmallPanel();
        private void TotalCommanderForm_Load(object sender, EventArgs e)
        {

        }

        private void FontButton_Click(object sender, EventArgs e)
        {


            FontDialog dialog = new FontDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CardForFile.StartFont = dialog.Font;
                SmallPanel.StartFont = new Font(dialog.Font.FontFamily, 8.25F);
                
                LeftSmallPanel.Reload_this_Panel();
                RightSmallPanel.Reload_this_Panel();
            }
        }
        private void Reload()
        {
            LeftSmallPanel.Reload_this_Panel();
            RightSmallPanel.Reload_this_Panel();
        }
        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LeftSmallPanel.ReColor_Form(dialog.Color);
                RightSmallPanel.ReColor_Form(dialog.Color);
            }

        }

        private void ColorForFileCard_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CardForFile.StartColor = dialog.Color;
                LeftSmallPanel.Reload_this_Panel();
                RightSmallPanel.Reload_this_Panel();
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            copy_paths = LeftSmallPanel.GetSelectedDirectory();
            path_to_copy = RightSmallPanel.GetOpenedDirectory();
            if (Directory.Exists(path_to_copy) && !path_to_copy.Equals("") && copy_paths.Count > 0)
            {
                thread = new Thread(Startcopy);
                thread.Start();
            }
        }
        private void Startcopy()
        {
            string[] copy_paths = this.copy_paths.ToArray();
            string newdirectory = path_to_copy;
            foreach (string path in copy_paths)
            {
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(newdirectory + '\\' + new DirectoryInfo(path).Name);
                    RecuryCopy(path, newdirectory + '\\' + new DirectoryInfo(path).Name);

                }
                else if (new FileInfo(path).Exists)
                {
                    FileInfo file = new FileInfo(path);
                    try
                    {
                        file.CopyTo(newdirectory + '\\' + new FileInfo(path).Name);
                    }
                    catch
                    {

                    }


                }
            }
            Action act = () =>
            {
                Reload();
            };
            Invoke(act);



        }
        private void RecuryCopy(string whichcopy, string wherecopy)
        {
            try
            {
                foreach (string directory_path in Directory.GetDirectories(whichcopy))
                {
                    Directory.CreateDirectory(wherecopy + '\\' + new DirectoryInfo(directory_path).Name);
                    RecuryCopy(directory_path, wherecopy + '\\' + new DirectoryInfo(directory_path).Name);
                }
            }
            catch
            {

            }
            try
            {
                foreach (FileInfo file in new DirectoryInfo(whichcopy).GetFiles())
                {
                    try
                    {
                        file.CopyTo(wherecopy + '\\' + file.Name);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }


        }

        private void CreateWorkPlace_Click(object sender, EventArgs e)
        {
            using (StreamWriter text = new StreamWriter("Work.txt"))
            {
                text.WriteLine(LeftSmallPanel.GetOpenedDirectory());
                text.WriteLine(RightSmallPanel.GetOpenedDirectory());
                
            }
        }
    }
}
