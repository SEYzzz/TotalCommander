using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace TotalCommander
{
    class SmallPanel : Panel
    {
        private Panel PanelForDirectory = new Panel();
        private Panel PanelForButtons = new Panel();
        private TextBox PathTextbox = new TextBox();
        private Button btnUp = new Button();
        private Button btnDown = new Button();
        private Button btnBack = new Button();
        private Button btnDelete = new Button();
        private Button btnCreateDirect = new Button();
        public Action DeleteAction;

        public static Color StartColor= Color.FromArgb(241, 208, 213);
        public static Font StartFont= new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        public SmallPanel()
        {
            Inicalization();
        }
        private void Inicalization()
        {
            BackColor = Color.FromArgb(255, 192, 255);
            MinimumSize = new Size(300, 500);
            Size = new Size(300, 500);
            Controls.Add(PanelForDirectory);
            Controls.Add(PanelForButtons);
            Dock = DockStyle.Fill;

            PanelForDirectory.Controls.Add(btnUp);
            PanelForDirectory.Controls.Add(btnDown);

            //btnUp
            #region UpButton
            btnUp.FlatStyle = FlatStyle.Flat;
            btnUp.Text = "˄";
            btnUp.Size = new Size(80, 20);
            btnUp.Location = new Point(PanelForDirectory.Width - 90, PanelForDirectory.Height - 30);
            btnUp.BackColor = Color.FromArgb(162, 124, 130);
            btnUp.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnUp.Click += btnUp_Click;
            #endregion

            //btnDown
            #region DownButton
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.FlatAppearance.BorderSize = 0;
            btnDown.Text = "˅";
            btnDown.Size = new Size(80, 20);
            btnDown.Location = new Point(PanelForDirectory.Width - 180, PanelForDirectory.Height - 30);
            btnDown.BackColor = Color.FromArgb(162, 124, 130);
            btnDown.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnDown.Click += btnDown_Click;
            #endregion
            PanelForButtons.Controls.Add(PathTextbox);
            PanelForButtons.Controls.Add(btnBack);
            PanelForButtons.Controls.Add(btnCreateDirect);
            PanelForButtons.Controls.Add(btnDelete);

            PathTextbox.ReadOnly = true;
            //btnBack
            #region BackButton
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Text = "˂";
            btnBack.Size = new Size(80, 30);
            btnBack.Location = new Point(5, 5);
            btnBack.BackColor = Color.FromArgb(162, 124, 130);
            btnBack.Click += btnBack_Click;
            #endregion

            //btnCreateDirect
            #region CreateDirectory
            btnCreateDirect.FlatStyle = FlatStyle.Flat;
            btnCreateDirect.FlatAppearance.BorderSize = 0;
            btnCreateDirect.Text = "Создать";
            btnCreateDirect.Size = new Size(80, 30);
            btnCreateDirect.Location = new Point(90, 5);
            btnCreateDirect.BackColor = Color.FromArgb(162, 124, 130);
            btnCreateDirect.Click += btnCreateDirect_Click;
            #endregion

            //btnDelete
            #region DeleteButton
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Text = "Удалить";
            btnDelete.Size = new Size(80, 30);
            btnDelete.Location = new Point(175, 5);
            btnDelete.BackColor = Color.FromArgb(162, 124, 130);
            btnDelete.Click += btnDelete_Click;

            PanelForButtons.BackColor = StartColor;
            PanelForDirectory.BackColor = StartColor;
            PanelForButtons.Dock = DockStyle.Top;
            PanelForDirectory.Dock = DockStyle.Fill;
            PathTextbox.Dock = DockStyle.Bottom;
            PanelForDirectory.Resize += SmallPanel_Resize;
            #endregion
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                AllFiles.Add(new CardForFile(drive.Name));
            }
            CountofShowingFileCard = (PanelForDirectory.Height - 50) / (CardForFile.StartFont.Height + 10 + LengthBetweenFileCards);

            ShowFiles();
        }
        public SmallPanel(string path)
        {
            Inicalization();
            if (!path.Equals("") && !path.Equals(null))
            {
                ShowIndirectory(new CardForFile(path));
            }
        }
        public string GetOpenedDirectory()
        {
            return PathTextbox.Text;
        }
        public List<string> GetSelectedDirectory()
        {
            List<string> paths = new List<String>();
            foreach(CardForFile file in AllFiles)
            {
                if (file.IsClicked)
                {
                    paths.Add(file.Path);
                }
            }
            return paths;
        }
        public string[] SelectedFilesPaths { get; set; }

        List<string> PathForDelete = new List<string>();

        List<CardForFile> AllFiles = new List<CardForFile>();
        List<CardForFile> ShowingFiles = new List<CardForFile>();
        private int FirstActiveFileCard = 0;
        private int CountofShowingFileCard;

        private int hieghtFileCards = 30;
        private int LengthBetweenFileCards = 5;

        private void SmallPanel_Resize(object sender, EventArgs e)
        {
            ClearFiles();
            CountofShowingFileCard = (PanelForDirectory.Height - 45) / (CardForFile.StartFont.Height + 10 + LengthBetweenFileCards); ;
            ShowFiles();

        }
        public void ReColor_Form(Color color)
        {
            PanelForButtons.BackColor = color;
            PanelForDirectory.BackColor = color;
        }
        public void Reload_this_Panel()
        {
            PathTextbox.Font = StartFont;
            if (PathTextbox.Text.Equals(""))
            {
                ClearFiles();
                AllFiles.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    AllFiles.Add(new CardForFile(drive.Name));
                }
                ShowFiles();
            }
            else
            {
                ShowIndirectory(new CardForFile(PathTextbox.Text));
            }
            
        }
       
        private void DeleteReload()
        {
            DeleteAction.Invoke();
        }
        private void directory_DoubleClick(object sender, EventArgs e)
        {
            if(sender is CardForFile)
            {
                ShowIndirectory(sender as CardForFile);
            }
            else if(sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
                ShowIndirectory((CardForFile)pic.Tag);
            }
            else if(sender is Label)
            {
                Label text = sender as Label;
                ShowIndirectory((CardForFile)text.Tag);
               
            }
            
        }
        
        private void ShowIndirectory(CardForFile cardp)
        {
            ClearFiles();
            if (Directory.Exists(cardp.Path))
            {
                PathTextbox.Text = cardp.Path;
                AllFiles.Clear();
                cardp.GetDirectories();
                if (!(cardp.GetDirectories() == null))
                {
                    foreach (string path in cardp.GetDirectories())
                    {
                        AllFiles.Add(new CardForFile(path));
                    }
                }
                if (!(cardp.GetFiles() == null))
                {
                    foreach (FileInfo file in cardp.GetFiles())
                    {
                        AllFiles.Add(new CardForFile(file.FullName));
                    }
                }

            }
            else if (File.Exists(cardp.Path))
            {
                try
                {
                    System.Diagnostics.Process.Start(cardp.Path);

                }
                catch
                {
                    MessageBox.Show("Простите, нельзя открыть этот файл");
                }
               
            }
            ShowFiles();
        }

        private void TotalCommanderForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {

                CardForFile File = new CardForFile( drive.Name);
                File.Location = new Point(5, LengthBetweenFileCards + i * (hieghtFileCards + LengthBetweenFileCards));
                File.DoubleClick += directory_DoubleClick;
                File.PictureFile.DoubleClick += directory_DoubleClick;
                File.NameFile.DoubleClick += directory_DoubleClick;

                File.Click +=Selecte_Click;
                File.PictureFile.Click += Selecte_Click;
                File.NameFile.Click += Selecte_Click;
                ShowingFiles.Add(File);
            }
        }

        private void ClearFiles()
        {
            foreach (CardForFile File in ShowingFiles)
            {
                PanelForDirectory.Controls.Remove(File);
            }
            ShowingFiles.Clear();
        }
        private void ShowFiles()
        {
            CountofShowingFileCard=(PanelForDirectory.Height - 50) / (CardForFile.StartFont.Height + 10+ LengthBetweenFileCards);
            for (int i = FirstActiveFileCard, j = 0; i < FirstActiveFileCard + CountofShowingFileCard&&i<AllFiles.Count; i++, j++)
            {
                hieghtFileCards = CardForFile.StartFont.Height + 10;

                AllFiles[i].Size = new Size(Width - 25, hieghtFileCards);
                AllFiles[i].Location = new Point(5, LengthBetweenFileCards + j * (hieghtFileCards + LengthBetweenFileCards));
                AllFiles[i].PictureFile.Size = new Size(hieghtFileCards-10, hieghtFileCards-10);
                AllFiles[i].NameFile.Location = new Point(hieghtFileCards, 5);
                AllFiles[i].NameFile.Size = new Size(Width - 50, hieghtFileCards - 10);
                AllFiles[i].BackColor = CardForFile.StartColor;
                AllFiles[i].NameFile.BackColor = CardForFile.StartColor;

                ShowingFiles.Add(AllFiles[i]);
                PanelForDirectory.Controls.Add(AllFiles[i]);
            }
            for (int i = FirstActiveFileCard, j = 0; i < FirstActiveFileCard + CountofShowingFileCard && i < AllFiles.Count; i++, j++)
            {
                AllFiles[i].DoubleClick += directory_DoubleClick;
                AllFiles[i].PictureFile.DoubleClick += directory_DoubleClick;
                AllFiles[i].NameFile.DoubleClick += directory_DoubleClick;

                AllFiles[i].Click += Selecte_Click;
                AllFiles[i].PictureFile.Click += Selecte_Click;
                AllFiles[i].NameFile.Click += Selecte_Click;

            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard--;
            FirstActiveFileCard = FirstActiveFileCard <0 ? 0 : FirstActiveFileCard;
            ClearFiles();
            ShowFiles();
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard++;
            FirstActiveFileCard = FirstActiveFileCard > AllFiles.Count - 1 ? --FirstActiveFileCard : FirstActiveFileCard;
            ClearFiles();
            ShowFiles();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard = 0;
            if (!PathTextbox.Text.Equals("") && PathTextbox.Text.LastIndexOf('\\').Equals(PathTextbox.Text.Length - 1))
            {
                ClearFiles();
                AllFiles.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    AllFiles.Add(new CardForFile(drive.Name));
                }
                PathTextbox.Text = "";
                ShowFiles();
            }
            else if (!PathTextbox.Text.Equals("") && PathTextbox.Text.LastIndexOf('\\') != PathTextbox.Text.IndexOf('\\'))
            {
                ShowIndirectory(new CardForFile(PathTextbox.Text.Substring(0, PathTextbox.Text.LastIndexOf('\\'))));
            }
            else if (!PathTextbox.Text.Equals(""))
            {
                ShowIndirectory(new CardForFile(PathTextbox.Text.Substring(0, 1 + PathTextbox.Text.LastIndexOf('\\'))));
            }
        }
        private void btnCreateDirect_Click(object sender, EventArgs e)
        {
            new CreateDirectory(PathTextbox.Text).ShowDialog();
            ShowIndirectory(new CardForFile(PathTextbox.Text));
            DeleteAction.Invoke();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удаление файлов", "Вы точно хотите удалить данные файлы", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                foreach(CardForFile card in AllFiles)
                {
                    if (card.IsClicked)
                    {
                        PanelForDirectory.Controls.Remove(card);
                        PathForDelete.Add(card.Path);
                    }
                    
                }
                
                Thread DeleteThread = new Thread(new ThreadStart(deleteDirectories));
                DeleteThread.Start();
                
            }

            
        }
        private void deleteDirectories()
        {
            List<string> pathfordelete = PathForDelete;
     
            foreach(string deletepath in pathfordelete)
            {
                if (Directory.Exists(deletepath))
                {
                    try
                    {
                        Directory.Delete(deletepath, true);
                    }
                    catch
                    {

                    }
                    
                }
                else if(new FileInfo(deletepath).Exists)
                {
                    new FileInfo(deletepath).Delete();
                }
            }
            Action act= ()=>{ DeleteReload(); };
            Invoke(act);

        }
        private void Selecte_Click(object sender, EventArgs e)
        {
            if (sender is CardForFile)
            {
                (sender as CardForFile).Oneclick();
            }
            else if (sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
             ((CardForFile)pic.Tag).Oneclick();
            }
            else if (sender is Label)
            {
                Label text = sender as Label;
                ((CardForFile)text.Tag).Oneclick();

            }
        }
        private void LeftDirectoryPanel_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < ShowingFiles.Count; i++)
            {
                ShowingFiles[i].Size = new Size(Width, hieghtFileCards);

            }
        }

    }
}
