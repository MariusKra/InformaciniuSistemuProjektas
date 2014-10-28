namespace eShopas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.užsakymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pardavimųStatistikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vartotojaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prekėsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserEnabledComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UserPermissionsComboBox = new System.Windows.Forms.ComboBox();
            this.labelUserPermissionsLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užsakymaiToolStripMenuItem,
            this.pardavimųStatistikaToolStripMenuItem,
            this.vartotojaiToolStripMenuItem,
            this.prekėsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // užsakymaiToolStripMenuItem
            // 
            this.užsakymaiToolStripMenuItem.Name = "užsakymaiToolStripMenuItem";
            this.užsakymaiToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.užsakymaiToolStripMenuItem.Text = "Užsakymai";
            this.užsakymaiToolStripMenuItem.Click += new System.EventHandler(this.užsakymaiToolStripMenuItem_Click);
            // 
            // pardavimųStatistikaToolStripMenuItem
            // 
            this.pardavimųStatistikaToolStripMenuItem.Name = "pardavimųStatistikaToolStripMenuItem";
            this.pardavimųStatistikaToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.pardavimųStatistikaToolStripMenuItem.Text = "Pardavimų statistika";
            this.pardavimųStatistikaToolStripMenuItem.Click += new System.EventHandler(this.pardavimųStatistikaToolStripMenuItem_Click);
            // 
            // vartotojaiToolStripMenuItem
            // 
            this.vartotojaiToolStripMenuItem.Name = "vartotojaiToolStripMenuItem";
            this.vartotojaiToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.vartotojaiToolStripMenuItem.Text = "Vartotojai";
            this.vartotojaiToolStripMenuItem.Click += new System.EventHandler(this.vartotojaiToolStripMenuItem_Click);
            // 
            // prekėsToolStripMenuItem
            // 
            this.prekėsToolStripMenuItem.Name = "prekėsToolStripMenuItem";
            this.prekėsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.prekėsToolStripMenuItem.Text = "Prekės";
            this.prekėsToolStripMenuItem.Click += new System.EventHandler(this.prekėsToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 338);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.37093F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.62906F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.11765F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.88235F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 465);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UserEnabledComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.UserPermissionsComboBox);
            this.panel1.Controls.Add(this.labelUserPermissionsLabel);
            this.panel1.Controls.Add(this.emailTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.usernameTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(760, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 338);
            this.panel1.TabIndex = 5;
            // 
            // UserEnabledComboBox
            // 
            this.UserEnabledComboBox.FormattingEnabled = true;
            this.UserEnabledComboBox.Location = new System.Drawing.Point(33, 165);
            this.UserEnabledComboBox.Name = "UserEnabledComboBox";
            this.UserEnabledComboBox.Size = new System.Drawing.Size(141, 21);
            this.UserEnabledComboBox.TabIndex = 7;
            this.UserEnabledComboBox.SelectedIndexChanged += new System.EventHandler(this.UserEnabledComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vartotojo būsena";
            // 
            // UserPermissionsComboBox
            // 
            this.UserPermissionsComboBox.FormattingEnabled = true;
            this.UserPermissionsComboBox.Location = new System.Drawing.Point(33, 216);
            this.UserPermissionsComboBox.Name = "UserPermissionsComboBox";
            this.UserPermissionsComboBox.Size = new System.Drawing.Size(141, 21);
            this.UserPermissionsComboBox.TabIndex = 5;
            this.UserPermissionsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelUserPermissionsLabel
            // 
            this.labelUserPermissionsLabel.AutoSize = true;
            this.labelUserPermissionsLabel.Location = new System.Drawing.Point(30, 200);
            this.labelUserPermissionsLabel.Name = "labelUserPermissionsLabel";
            this.labelUserPermissionsLabel.Size = new System.Drawing.Size(79, 13);
            this.labelUserPermissionsLabel.TabIndex = 4;
            this.labelUserPermissionsLabel.Text = "Vartotojo teisės";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(33, 112);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(141, 20);
            this.emailTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Elektroninis paštas";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(33, 60);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(141, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vartotojo vardas";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1046, 462);
            this.tableLayoutPanel2.TabIndex = 6;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Viskas su preki7 ivedimu ir panasiai eina cia";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 27);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1043, 465);
            this.tableLayoutPanel3.TabIndex = 7;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cia viskas apie uzsakymus";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1120, 492);
            this.tableLayoutPanel4.TabIndex = 8;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cia viskas apie pardavimus eina";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Išsaugoti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1180, 540);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem užsakymaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pardavimųStatistikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vartotojaiToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem prekėsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUserPermissionsLabel;
        private System.Windows.Forms.ComboBox UserPermissionsComboBox;
        private System.Windows.Forms.ComboBox UserEnabledComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}