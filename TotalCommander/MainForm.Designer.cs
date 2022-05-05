
namespace TotalCommander
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.btnWorkPlace = new System.Windows.Forms.Button();
            this.btnColorWindow = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.TwoPanelsSplitConteiner = new System.Windows.Forms.SplitContainer();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TwoPanelsSplitConteiner)).BeginInit();
            this.TwoPanelsSplitConteiner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
            this.panel.Controls.Add(this.btnWorkPlace);
            this.panel.Controls.Add(this.btnColorWindow);
            this.panel.Controls.Add(this.btnColor);
            this.panel.Controls.Add(this.btnFont);
            this.panel.Controls.Add(this.btnCopy);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1020, 61);
            this.panel.TabIndex = 0;
            // 
            // btnWorkPlace
            // 
            this.btnWorkPlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnWorkPlace.FlatAppearance.BorderSize = 0;
            this.btnWorkPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkPlace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(96)))));
            this.btnWorkPlace.Location = new System.Drawing.Point(145, 2);
            this.btnWorkPlace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWorkPlace.Name = "btnWorkPlace";
            this.btnWorkPlace.Size = new System.Drawing.Size(163, 58);
            this.btnWorkPlace.TabIndex = 4;
            this.btnWorkPlace.Text = "Сделать рабочим пространством";
            this.btnWorkPlace.UseVisualStyleBackColor = false;
            this.btnWorkPlace.Click += new System.EventHandler(this.CreateWorkPlace_Click);
            // 
            // btnColorWindow
            // 
            this.btnColorWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColorWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnColorWindow.FlatAppearance.BorderSize = 0;
            this.btnColorWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnColorWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(96)))));
            this.btnColorWindow.Location = new System.Drawing.Point(889, 3);
            this.btnColorWindow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColorWindow.Name = "btnColorWindow";
            this.btnColorWindow.Size = new System.Drawing.Size(127, 54);
            this.btnColorWindow.TabIndex = 3;
            this.btnColorWindow.Text = "Цвет окон";
            this.btnColorWindow.UseVisualStyleBackColor = false;
            this.btnColorWindow.Click += new System.EventHandler(this.ColorForFileCard_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(96)))));
            this.btnColor.Location = new System.Drawing.Point(761, 3);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(120, 55);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Цвет панелей";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnFont.FlatAppearance.BorderSize = 0;
            this.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(96)))));
            this.btnFont.Location = new System.Drawing.Point(629, 2);
            this.btnFont.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(124, 55);
            this.btnFont.TabIndex = 1;
            this.btnFont.Text = "Шрифт";
            this.btnFont.UseVisualStyleBackColor = false;
            this.btnFont.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(232)))), ((int)(((byte)(230)))));
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(92)))), ((int)(((byte)(96)))));
            this.btnCopy.Location = new System.Drawing.Point(4, 2);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(133, 57);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Копировать";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // TwoPanelsSplitConteiner
            // 
            this.TwoPanelsSplitConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TwoPanelsSplitConteiner.Location = new System.Drawing.Point(0, 61);
            this.TwoPanelsSplitConteiner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TwoPanelsSplitConteiner.MinimumSize = new System.Drawing.Size(0, 615);
            this.TwoPanelsSplitConteiner.Name = "TwoPanelsSplitConteiner";
            this.TwoPanelsSplitConteiner.Panel1MinSize = 300;
            this.TwoPanelsSplitConteiner.Panel2MinSize = 300;
            this.TwoPanelsSplitConteiner.Size = new System.Drawing.Size(1020, 654);
            this.TwoPanelsSplitConteiner.SplitterDistance = 400;
            this.TwoPanelsSplitConteiner.TabIndex = 1;
            // 
            // TotalCommanderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 715);
            this.Controls.Add(this.TwoPanelsSplitConteiner);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1035, 752);
            this.Name = "TotalCommanderForm";
            this.Text = " TotalCommander";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TwoPanelsSplitConteiner)).EndInit();
            this.TwoPanelsSplitConteiner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.SplitContainer TwoPanelsSplitConteiner;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnColorWindow;
        private System.Windows.Forms.Button btnWorkPlace;
    }
}