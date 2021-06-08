using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Users.
	/// </summary>
	public class Users : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.DateTimePicker dtUserBirthDate;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblFirstName;
		private System.Windows.Forms.Label lblLastName;
		private System.Windows.Forms.Label lblDateOfBirth;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Button btnStartInsert;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnStartFind;
		private System.Windows.Forms.Label lblRegionCenter;
		private System.Windows.Forms.ComboBox cmbRegionCenter;
		private System.Windows.Forms.Label lblSupervisorRegCent;
		private System.Windows.Forms.ComboBox cmbSupervisorRegCent;
		private System.Windows.Forms.Label lblSalesmanRegCent;
		private System.Windows.Forms.ComboBox cmbSalesmanRegCent;
		private System.Windows.Forms.ComboBox cmbSupervisorCashOffice;
		private System.Windows.Forms.Label lblSupervisorCashOffice;
		private System.Windows.Forms.ComboBox cmbSalesmanCashOffice;
		private System.Windows.Forms.Label lblSalesmanCashOffice;

		private SqlDataAdapter daUser;
		private SqlDataAdapter daRegion;
		private SqlDataAdapter daRegionSupervisor;
		private SqlDataAdapter daRegionSalesman;
		private SqlDataAdapter daSupervisorPostalOffice;
		private SqlDataAdapter daSalesmanPostalOffice;
		private SqlDataAdapter daUserDesc0;
		private SqlDataAdapter daUserDesc1;
		private SqlDataAdapter daUserDesc2;
		private SqlDataAdapter daUserDesc3;
		private SqlDataAdapter daUserDesc4;
		
		private DataSet dsSupervisorPostalOffice;
		private DataSet dsSalesmanPostalOffice;
		private DataSet dsUser;
		private DataSet dsRegion;
		private DataSet dsRegionSupervisor;
		private DataSet dsRegionSalesman;

		private BindingManagerBase bindingManager;
		private DataView dv;
		private DataView dvComboSalesman;
		private DataView dvComboSupervisor;
		private int nCheckForCombo;
		private const string error = "Error!";
		private const String ErrorRecExist		=	"This record exists!!";
		private const String ErrorEmptyRec		= "You cannot add an empty record!!";
		private const string Confirm				= "Are you sure you want to update records?";
		private const string ConfirmTitle			= "Confirm";

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public Users()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblRegionCenter = new System.Windows.Forms.Label();
            this.cmbRegionCenter = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbSupervisorCashOffice = new System.Windows.Forms.ComboBox();
            this.lblSupervisorCashOffice = new System.Windows.Forms.Label();
            this.lblSupervisorRegCent = new System.Windows.Forms.Label();
            this.cmbSupervisorRegCent = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cmbSalesmanCashOffice = new System.Windows.Forms.ComboBox();
            this.lblSalesmanCashOffice = new System.Windows.Forms.Label();
            this.lblSalesmanRegCent = new System.Windows.Forms.Label();
            this.cmbSalesmanRegCent = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.dtUserBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnStartInsert = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnStartFind = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(40, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 120);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(448, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Admin";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(448, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Distributor";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblRegionCenter);
            this.tabPage3.Controls.Add(this.cmbRegionCenter);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(448, 91);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Region Center";
            // 
            // lblRegionCenter
            // 
            this.lblRegionCenter.Location = new System.Drawing.Point(116, 18);
            this.lblRegionCenter.Name = "lblRegionCenter";
            this.lblRegionCenter.Size = new System.Drawing.Size(80, 16);
            this.lblRegionCenter.TabIndex = 8;
            this.lblRegionCenter.Text = "Region Center";
            this.lblRegionCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRegionCenter
            // 
            this.cmbRegionCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionCenter.Location = new System.Drawing.Point(211, 18);
            this.cmbRegionCenter.Name = "cmbRegionCenter";
            this.cmbRegionCenter.Size = new System.Drawing.Size(173, 21);
            this.cmbRegionCenter.TabIndex = 9;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cmbSupervisorCashOffice);
            this.tabPage4.Controls.Add(this.lblSupervisorCashOffice);
            this.tabPage4.Controls.Add(this.lblSupervisorRegCent);
            this.tabPage4.Controls.Add(this.cmbSupervisorRegCent);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(448, 91);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Supervisor";
            // 
            // cmbSupervisorCashOffice
            // 
            this.cmbSupervisorCashOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisorCashOffice.Location = new System.Drawing.Point(211, 48);
            this.cmbSupervisorCashOffice.Name = "cmbSupervisorCashOffice";
            this.cmbSupervisorCashOffice.Size = new System.Drawing.Size(173, 21);
            this.cmbSupervisorCashOffice.TabIndex = 16;
            // 
            // lblSupervisorCashOffice
            // 
            this.lblSupervisorCashOffice.Location = new System.Drawing.Point(116, 48);
            this.lblSupervisorCashOffice.Name = "lblSupervisorCashOffice";
            this.lblSupervisorCashOffice.Size = new System.Drawing.Size(80, 16);
            this.lblSupervisorCashOffice.TabIndex = 15;
            this.lblSupervisorCashOffice.Text = "Cash Office";
            this.lblSupervisorCashOffice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSupervisorRegCent
            // 
            this.lblSupervisorRegCent.Location = new System.Drawing.Point(116, 18);
            this.lblSupervisorRegCent.Name = "lblSupervisorRegCent";
            this.lblSupervisorRegCent.Size = new System.Drawing.Size(80, 16);
            this.lblSupervisorRegCent.TabIndex = 8;
            this.lblSupervisorRegCent.Text = "Region Center";
            this.lblSupervisorRegCent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSupervisorRegCent
            // 
            this.cmbSupervisorRegCent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisorRegCent.Location = new System.Drawing.Point(211, 18);
            this.cmbSupervisorRegCent.Name = "cmbSupervisorRegCent";
            this.cmbSupervisorRegCent.Size = new System.Drawing.Size(173, 21);
            this.cmbSupervisorRegCent.TabIndex = 9;
            this.cmbSupervisorRegCent.SelectedIndexChanged += new System.EventHandler(this.cmbSupervisorRegCent_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cmbSalesmanCashOffice);
            this.tabPage5.Controls.Add(this.lblSalesmanCashOffice);
            this.tabPage5.Controls.Add(this.lblSalesmanRegCent);
            this.tabPage5.Controls.Add(this.cmbSalesmanRegCent);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(448, 91);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Salesman";
            // 
            // cmbSalesmanCashOffice
            // 
            this.cmbSalesmanCashOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesmanCashOffice.Location = new System.Drawing.Point(211, 48);
            this.cmbSalesmanCashOffice.Name = "cmbSalesmanCashOffice";
            this.cmbSalesmanCashOffice.Size = new System.Drawing.Size(173, 21);
            this.cmbSalesmanCashOffice.TabIndex = 16;
            // 
            // lblSalesmanCashOffice
            // 
            this.lblSalesmanCashOffice.Location = new System.Drawing.Point(116, 48);
            this.lblSalesmanCashOffice.Name = "lblSalesmanCashOffice";
            this.lblSalesmanCashOffice.Size = new System.Drawing.Size(80, 16);
            this.lblSalesmanCashOffice.TabIndex = 15;
            this.lblSalesmanCashOffice.Text = "Cash Office";
            this.lblSalesmanCashOffice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSalesmanRegCent
            // 
            this.lblSalesmanRegCent.Location = new System.Drawing.Point(116, 18);
            this.lblSalesmanRegCent.Name = "lblSalesmanRegCent";
            this.lblSalesmanRegCent.Size = new System.Drawing.Size(80, 16);
            this.lblSalesmanRegCent.TabIndex = 8;
            this.lblSalesmanRegCent.Text = "Region Center";
            this.lblSalesmanRegCent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSalesmanRegCent
            // 
            this.cmbSalesmanRegCent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesmanRegCent.Location = new System.Drawing.Point(211, 18);
            this.cmbSalesmanRegCent.Name = "cmbSalesmanRegCent";
            this.cmbSalesmanRegCent.Size = new System.Drawing.Size(173, 21);
            this.cmbSalesmanRegCent.TabIndex = 9;
            this.cmbSalesmanRegCent.SelectedIndexChanged += new System.EventHandler(this.cmbSalesmanRegCent_SelectedIndexChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(160, 192);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(400, 160);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(160, 160);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // dtUserBirthDate
            // 
            this.dtUserBirthDate.CustomFormat = "dd.MM.yyyy";
            this.dtUserBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUserBirthDate.Location = new System.Drawing.Point(400, 192);
            this.dtUserBirthDate.Name = "dtUserBirthDate";
            this.dtUserBirthDate.Size = new System.Drawing.Size(112, 20);
            this.dtUserBirthDate.TabIndex = 8;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(24, 160);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(24, 192);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(100, 23);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(312, 160);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(72, 23);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Location = new System.Drawing.Point(304, 192);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(80, 23);
            this.lblDateOfBirth.TabIndex = 7;
            this.lblDateOfBirth.Text = "Date Of Birth";
            this.lblDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateOfBirth);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.dtUserBirthDate);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(80, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " User Group";
            // 
            // DataGrid
            // 
            this.DataGrid.CaptionText = "Users";
            this.DataGrid.DataMember = "";
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(40, 288);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(664, 288);
            this.DataGrid.TabIndex = 6;
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(568, 256);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnStartInsert
            // 
            this.btnStartInsert.Location = new System.Drawing.Point(96, 256);
            this.btnStartInsert.Name = "btnStartInsert";
            this.btnStartInsert.Size = new System.Drawing.Size(75, 23);
            this.btnStartInsert.TabIndex = 1;
            this.btnStartInsert.Text = "Start Insert";
            this.btnStartInsert.Click += new System.EventHandler(this.btnStartInsert_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(216, 256);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(336, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnStartFind
            // 
            this.btnStartFind.Location = new System.Drawing.Point(456, 256);
            this.btnStartFind.Name = "btnStartFind";
            this.btnStartFind.Size = new System.Drawing.Size(75, 23);
            this.btnStartFind.TabIndex = 4;
            this.btnStartFind.Text = "Start Find";
            this.btnStartFind.Click += new System.EventHandler(this.btnStartFind_Click);
            // 
            // Users
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 606);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnStartInsert);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnStartFind);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(744, 620);
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Users_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered the Users form at {0}", LogIn.FormatedDate(1));

			nCheckForCombo = 0;
			LoadUser();
			dsUser = new DataSet();
			daUser.Fill(dsUser, "User");

			LoadUserDesc0();
			daUserDesc0.Fill(dsUser, "UserDesc0");
			LoadUserDesc1();
			daUserDesc1.Fill(dsUser, "UserDesc1");
			LoadUserDesc2();
			daUserDesc2.Fill(dsUser, "UserDesc2");
			LoadUserDesc3();
			daUserDesc3.Fill(dsUser, "UserDesc3");
			LoadUserDesc4();
			daUserDesc4.Fill(dsUser, "UserDesc4");

			dv = new DataView(dsUser.Tables["User"]);
			dv.AllowNew = false;
			dv.AllowEdit = false;
			dv.AllowDelete = false;
			dv.RowFilter = "RoleID = 0";
			DataGrid.DataSource = dv;

			LoadRegion();
			dsRegion = new DataSet();
			daRegion.Fill(dsRegion, "Region");
            
			LoadRegionSupervisor();
			dsRegionSupervisor = new DataSet();
			daRegionSupervisor.Fill(dsRegionSupervisor, "RegionSupervisor");

			LoadRegionSalesman();
			dsRegionSalesman = new DataSet();
			daRegionSalesman.Fill(dsRegionSalesman, "RegionSalesman");

			LoadSupervisorPostalOffice();
			dsSupervisorPostalOffice = new DataSet();
			daSupervisorPostalOffice.Fill(dsSupervisorPostalOffice, "SupervisorPostalOffice");

			LoadSalesmanPostalOffice();
			dsSalesmanPostalOffice = new DataSet();
			daSalesmanPostalOffice.Fill(dsSalesmanPostalOffice, "SalesmanPostalOffice");

			dvComboSupervisor = new DataView(dsSupervisorPostalOffice.Tables["SupervisorPostalOffice"]);
			dvComboSalesman = new DataView(dsSalesmanPostalOffice.Tables["SalesmanPostalOffice"]);

			cmbRegionCenter.DataSource = dsRegion.Tables["Region"];
			cmbRegionCenter.DisplayMember = "RegionDescription";
			cmbRegionCenter.ValueMember = "RegionID";

			cmbSupervisorRegCent.DataSource = dsRegionSupervisor.Tables["RegionSupervisor"];
			cmbSupervisorRegCent.DisplayMember = "RegionDescription";
			cmbSupervisorRegCent.ValueMember = "RegionID";

			cmbSupervisorCashOffice.DataSource = dsSupervisorPostalOffice.Tables["SupervisorPostalOffice"];
			cmbSupervisorCashOffice.DisplayMember = "PostalDesc";
			cmbSupervisorCashOffice.ValueMember = "PostalID";

			cmbSalesmanRegCent.DataSource = dsRegionSalesman.Tables["RegionSalesman"];
			cmbSalesmanRegCent.DisplayMember = "RegionDescription";
			cmbSalesmanRegCent.ValueMember = "RegionID";

			cmbSalesmanCashOffice.DataSource = dsSalesmanPostalOffice.Tables["SalesmanPostalOffice"];
			cmbSalesmanCashOffice.DisplayMember = "PostalDesc";
			cmbSalesmanCashOffice.ValueMember = "PostalID";

			tabControl1_SelectedIndexChanged(sender, e);
			nCheckForCombo = 1;
		}

		private void btnStartInsert_Click(object sender, System.EventArgs e)
		{
			if (btnStartInsert.Text == "Start Insert")
			{
				btnStartInsert.Text = "Cancel";
				btnUpdate.Enabled = false;
				btnFind.Enabled = false;
				btnStartFind.Enabled = false;
				btnInsert.Enabled = true;
				DataGrid.Enabled = false;
				txtUserName.DataBindings.Clear();
				txtFirstName.DataBindings.Clear();
				txtLastName.DataBindings.Clear();
				txtUserName.Text = "";
				txtFirstName.Text = "";
				txtLastName.Text = "";
			}
			else
			{
				btnStartInsert.Text = "Start Insert";
				btnUpdate.Enabled = true;
				btnFind.Enabled = true;
				btnStartFind.Enabled = true;
				btnInsert.Enabled = false;
				DataGrid.Enabled = true;
			}
		}

		private void btnInsert_Click(object sender, System.EventArgs e)
		{
			try
			{
				string UserName = "", FirstName = "", LastName = "";
				DateTime DateOfBirth;
				DateTime LastEndOfDayDate = new DateTime();
				int RoleID = 0, RegionID = 0, PostalID = 0, FirstTimeEntrance = 0;
				UserName = txtUserName.Text;
				FirstName = txtFirstName.Text;
				LastName = txtLastName.Text;
				DateOfBirth = dtUserBirthDate.Value;
				String SelectedPage = tabControl1.SelectedTab.Text;
				switch (SelectedPage)
				{
					case "Admin":
						RoleID = 0;
						RegionID = 0;
						PostalID = 0;
						FirstTimeEntrance = 0;
						break;
					case "Distributor":
						RoleID = 1;
						RegionID = 0;
						PostalID = 0;
						FirstTimeEntrance = 0;
						break;
					case "Region Center":
						RoleID = 2;
						RegionID = Convert.ToInt32(cmbRegionCenter.SelectedValue);
						PostalID = 0;
						FirstTimeEntrance = 0;
						break;
					case "Supervisor":
						RoleID = 3;
						RegionID = Convert.ToInt32(cmbSupervisorRegCent.SelectedValue);
						PostalID = Convert.ToInt32(cmbSupervisorCashOffice.SelectedValue);
						if (PostalID == 0 || cmbSupervisorCashOffice.Enabled == false)
							throw new Exception("Error!! The User could not be entered into system, check CashOffice comboBox!!");
						FirstTimeEntrance = 0;
						break;
					case "Salesman":
						RoleID = 4;
						RegionID = Convert.ToInt32(cmbSalesmanRegCent.SelectedValue);
						PostalID = Convert.ToInt32(cmbSalesmanCashOffice.SelectedValue);
						if (PostalID == 0)
							throw new Exception("Error!! The User could not be entered into system, check CashOffice comboBox!!");
						FirstTimeEntrance = 0;
						break;
				}
				InsertRecord(UserName, FirstName, LastName, DateOfBirth, RoleID, RegionID, PostalID, LastEndOfDayDate, FirstTimeEntrance);
				btnStartInsert_Click(sender, e);
				tabControl1_SelectedIndexChanged(sender, e);

			}
			catch (Exception ex)
			{
				
				LogIn.foutLogFile.WriteLine("{0}", ex);
				MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void InsertRecord(string UserName, string FirstName,  string LastName, DateTime DateOfBirth, int RoleID, int RegionID, int PostalID, DateTime LastEndOfDayDate, int FirstTimeEntrance)
		{
			LogIn.foutLogFile.WriteLine("User entered the Insert button at {0}", LogIn.FormatedDate(1));
			SqlConnection cn = LogIn.conn;
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cn.Open();
			cmd.CommandText = "select max(usertableid) from usertable";
			String szMaxRecord = cmd.ExecuteScalar().ToString();
			cn.Close();
			int nMaxRecord = szMaxRecord == "" ? 0: Convert.ToInt32(szMaxRecord);
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			try
			{
				nMaxRecord++;
				dsUser = new DataSet();
				daUser.Fill(dsUser, "User");
				daUserDesc0.Fill(dsUser, "UserDesc0");
				daUserDesc1.Fill(dsUser, "UserDesc1");
				daUserDesc2.Fill(dsUser, "UserDesc2");
				daUserDesc3.Fill(dsUser, "UserDesc3");
				daUserDesc4.Fill(dsUser, "UserDesc4");

				sqlConnection = LogIn.conn;
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction();
				daUser.InsertCommand.Transaction = sqlTransaction;
				daUser.UpdateCommand.Transaction = sqlTransaction;
				daUser.SelectCommand.Transaction = sqlTransaction;
				daUserDesc0.SelectCommand.Transaction = sqlTransaction;
				daUserDesc1.SelectCommand.Transaction = sqlTransaction;
				daUserDesc2.SelectCommand.Transaction = sqlTransaction;
				daUserDesc3.SelectCommand.Transaction = sqlTransaction;
				daUserDesc4.SelectCommand.Transaction = sqlTransaction;
				if (UserName == "")
					throw new Exception(ErrorEmptyRec);
				if (FirstName == "")
					throw new Exception(ErrorEmptyRec);
				if (LastName == "")
					throw new Exception(ErrorEmptyRec);

				String szProposedPassword = "123456";
				MD5 md5 = new MD5CryptoServiceProvider();
				UnicodeEncoding unicode = new UnicodeEncoding();
				byte [] btPassword = ASCIIEncoding.ASCII.GetBytes(szProposedPassword);
				md5 = new MD5CryptoServiceProvider();
				String szPassword = unicode.GetString(md5.ComputeHash(btPassword));

				DataRow dr = dsUser.Tables["User"].NewRow();
				DataRow [] drRowExist = dsUser.Tables["User"].Select("UserName = '" + UserName + "'");
				if (drRowExist.Length != 0)
					throw new Exception(ErrorRecExist);

				dr["UserTableID"] = nMaxRecord;
				dr["UserName"] = UserName;
				dr["Password"] = szPassword;
				dr["FirstName"] = FirstName;
				dr["LastName"] = LastName;
				dr["DateOfBirth"] = DateOfBirth.Date;
				dr["RoleID"] = RoleID;
				if (RegionID == 0)
					dr["RegionID"] = DBNull.Value;
				else
					dr["RegionID"] = RegionID;
				if (PostalID == 0)
					dr["PostalID"] = DBNull.Value;
				else
					dr["PostalID"] = PostalID;
				dr["LastEndOfDayDate"] = DBNull.Value;
				dr["FirstTimeEntrance"] = 0;
				dsUser.Tables["User"].Rows.Add(dr);

				DataSet tempDS = dsUser.GetChanges(DataRowState.Added);
				daUser.Update(tempDS, "User");
				dsUser.AcceptChanges();
				switch (tabControl1.SelectedTab.Text)
				{
					case "Admin":
						dsUser.Tables["UserDesc0"].Clear();
						daUserDesc0.Fill(dsUser, "UserDesc0");
						break;
					case "Distributor":
						dsUser.Tables["UserDesc1"].Clear();
						daUserDesc1.Fill(dsUser, "UserDesc1");
						break;
					case "Region Center":
						dsUser.Tables["UserDesc2"].Clear();
						daUserDesc2.Fill(dsUser, "UserDesc2");
						break;
					case "Supervisor":
						dsUser.Tables["UserDesc3"].Clear();
						daUserDesc3.Fill(dsUser, "UserDesc3");
						break;
					case "Salesman":
						dsUser.Tables["UserDesc4"].Clear();
						daUserDesc4.Fill(dsUser, "UserDesc4");
						break;
				}
				LogIn.foutLogFile.WriteLine("UserName {0} entered into DB at {1}", txtUserName.Text, LogIn.FormatedDate(1));
				sqlTransaction.Commit();
			}

			catch (SqlException sqlEx)
			{
				LogIn.foutLogFile.WriteLine("UserName {0} COULD NOT BE entered at {1}", txtUserName.Text, LogIn.FormatedDate(1));
				dsUser.RejectChanges();
				sqlTransaction.Rollback();
				MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception Ex)
			{
				LogIn.foutLogFile.WriteLine("UserName {0} COULD NOT BE entered at {1}", txtUserName.Text, LogIn.FormatedDate(1));
				dsUser.RejectChanges();
				sqlTransaction.Rollback();
				MessageBox.Show(Ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (sqlConnection != null)
					sqlConnection.Close();
			}
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered the Update button at {0}", LogIn.FormatedDate(1));
			if (bindingManager.Position == bindingManager.Count - 1)
			{
				bindingManager.Position -= 1;
				bindingManager.Position	+= 1;
			}
			else 
			{
				bindingManager.Position += 1;
				bindingManager.Position	-= 1;
			}
			DataSet tempDS = dsUser.GetChanges(DataRowState.Modified);
			DialogResult result = MessageBox.Show(Confirm, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			String szNothingChanged = "No records to change!";
			String szRecordExists = "This UserName exist, so you cannot change the record!!";
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Update') at {0}", LogIn.FormatedDate(1));
				try 
				{
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daUser.UpdateCommand.Transaction = sqlTransaction;
					daUser.SelectCommand.Transaction = sqlTransaction;
					daUserDesc0.SelectCommand.Transaction = sqlTransaction;
					daUserDesc1.SelectCommand.Transaction = sqlTransaction;
					daUserDesc2.SelectCommand.Transaction = sqlTransaction;
					daUserDesc3.SelectCommand.Transaction = sqlTransaction;
					daUserDesc4.SelectCommand.Transaction = sqlTransaction;
					if (tempDS == null)
						throw new Exception(szNothingChanged);
					int OldPosition;

					switch (tabControl1.SelectedTab.Text)
					{
						case "Admin":
							for (int i = 0; i < tempDS.Tables["UserDesc0"].Rows.Count; i++)
							{
								int OldID = Convert.ToInt32(tempDS.Tables["UserDesc0"].Rows[i]["UserTableID"].ToString());
								string OldUserName = tempDS.Tables["UserDesc0"].Rows[i]["UserName"].ToString();
								DataRow [] drNewID = dsUser.Tables["User"].Select("UserName = '" + OldUserName + "' AND UserTableID <> " + OldID);
								int NewID = drNewID.Length == 0 ? 0 : Convert.ToInt32(drNewID[0]["UserTableID"].ToString());
								DataRow [] drNewUserName = dsUser.Tables["User"].Select("UserTableID = '" + NewID + "'");
								string NewUserName = drNewUserName.Length == 0 ? "": drNewUserName[0]["UserName"].ToString();
								if (OldID != NewID && OldUserName == NewUserName)
									throw new Exception(szRecordExists);
							}
							OldPosition = bindingManager.Position;
							daUser.Update(tempDS, "UserDesc0");
							dsUser.Tables["UserDesc0"].Clear();
							daUserDesc0.Fill(dsUser, "UserDesc0");
							dsUser.Tables["User"].Clear();
							daUserDesc0.Fill(dsUser, "User");
							daUser.Fill(dsUser, "User");
							bindingManager.Position = OldPosition;
							break;
						case "Distributor":
							for (int i = 0; i < tempDS.Tables["UserDesc1"].Rows.Count; i++)
							{
								int OldID = Convert.ToInt32(tempDS.Tables["UserDesc1"].Rows[i]["UserTableID"].ToString());
								string OldUserName = tempDS.Tables["UserDesc1"].Rows[i]["UserName"].ToString();
								DataRow [] drNewID = dsUser.Tables["User"].Select("UserName = '" + OldUserName + "' AND UserTableID <> " + OldID);
								int NewID = drNewID.Length == 0 ? 0 : Convert.ToInt32(drNewID[0]["UserTableID"].ToString());
								DataRow [] drNewUserName = dsUser.Tables["User"].Select("UserTableID = '" + NewID + "'");
								string NewUserName = drNewUserName.Length == 0 ? "": drNewUserName[0]["UserName"].ToString();
								if (OldID != NewID && OldUserName == NewUserName)
									throw new Exception(szRecordExists);
							}
							OldPosition = bindingManager.Position;
							daUser.Update(tempDS, "UserDesc1");
							dsUser.Tables["UserDesc1"].Clear();
							daUserDesc1.Fill(dsUser, "UserDesc1");
							dsUser.Tables["User"].Clear();
							daUserDesc1.Fill(dsUser, "User");
							daUser.Fill(dsUser, "User");
							bindingManager.Position = OldPosition;
							break;
						case "Region Center":
							for (int i = 0; i < tempDS.Tables["UserDesc2"].Rows.Count; i++)
							{
								int OldID = Convert.ToInt32(tempDS.Tables["UserDesc2"].Rows[i]["UserTableID"].ToString());
								string OldUserName = tempDS.Tables["UserDesc2"].Rows[i]["UserName"].ToString();
								DataRow [] drNewID = dsUser.Tables["User"].Select("UserName = '" + OldUserName + "' AND UserTableID <> " + OldID);
								int NewID = drNewID.Length == 0 ? 0 : Convert.ToInt32(drNewID[0]["UserTableID"].ToString());
								DataRow [] drNewUserName = dsUser.Tables["User"].Select("UserTableID = '" + NewID + "'");
								string NewUserName = drNewUserName.Length == 0 ? "": drNewUserName[0]["UserName"].ToString();
								if (OldID != NewID && OldUserName == NewUserName)
									throw new Exception(szRecordExists);
							}
							OldPosition = bindingManager.Position;
							daUser.Update(tempDS, "UserDesc2");
							dsUser.Tables["UserDesc2"].Clear();
							daUserDesc2.Fill(dsUser, "UserDesc2");
							dsUser.Tables["User"].Clear();
							daUserDesc2.Fill(dsUser, "User");
							daUser.Fill(dsUser, "User");
							bindingManager.Position = OldPosition;
							break;
						case "Supervisor":
							for (int i = 0; i < tempDS.Tables["UserDesc3"].Rows.Count; i++)
							{
								int OldID = Convert.ToInt32(tempDS.Tables["UserDesc3"].Rows[i]["UserTableID"].ToString());
								string OldUserName = tempDS.Tables["UserDesc3"].Rows[i]["UserName"].ToString();
								DataRow [] drNewID = dsUser.Tables["User"].Select("UserName = '" + OldUserName + "' AND UserTableID <> " + OldID);
								int NewID = drNewID.Length == 0 ? 0 : Convert.ToInt32(drNewID[0]["UserTableID"].ToString());
								DataRow [] drNewUserName = dsUser.Tables["User"].Select("UserTableID = '" + NewID + "'");
								string NewUserName = drNewUserName.Length == 0 ? "": drNewUserName[0]["UserName"].ToString();
								if (OldID != NewID && OldUserName == NewUserName)
									throw new Exception(szRecordExists);
								int nRegionID =	Convert.ToInt32(tempDS.Tables["UserDesc3"].Rows[i]["RegionID"].ToString());
								DataRow [] dr = dsRegion.Tables[0].Select("RegionID = " + nRegionID);
								
								tempDS.Tables["UserDesc3"].Rows[i]["RegionDescription"] = dr[0]["RegionDescription"].ToString();
							}
							nCheckForCombo = 2;
							OldPosition = bindingManager.Position;
							daUser.Update(tempDS, "UserDesc3");
							dsUser.Tables["UserDesc3"].Clear();
							daUserDesc3.Fill(dsUser, "UserDesc3");
							dsUser.Tables["User"].Clear();
							daUserDesc3.Fill(dsUser, "User");
							daUser.Fill(dsUser, "User");
							bindingManager.Position = OldPosition;
							nCheckForCombo = 1;
							break;
						case "Salesman":
							for (int i = 0; i < tempDS.Tables["UserDesc4"].Rows.Count; i++)
							{
								int OldID = Convert.ToInt32(tempDS.Tables["UserDesc4"].Rows[i]["UserTableID"].ToString());
								string OldUserName = tempDS.Tables["UserDesc4"].Rows[i]["UserName"].ToString();
								DataRow [] drNewID = dsUser.Tables["User"].Select("UserName = '" + OldUserName + "' AND UserTableID <> " + OldID);
								int NewID = drNewID.Length == 0 ? 0 : Convert.ToInt32(drNewID[0]["UserTableID"].ToString());
								DataRow [] drNewUserName = dsUser.Tables["User"].Select("UserTableID = '" + NewID + "'");
								string NewUserName = drNewUserName.Length == 0 ? "": drNewUserName[0]["UserName"].ToString();
								if (OldID != NewID && OldUserName == NewUserName)
									throw new Exception(szRecordExists);
								int nRegionID =	Convert.ToInt32(tempDS.Tables["UserDesc4"].Rows[i]["RegionID"].ToString());
								DataRow [] dr = dsRegion.Tables[0].Select("RegionID = " + nRegionID);
								
								tempDS.Tables["UserDesc4"].Rows[i]["RegionDescription"] = dr[0]["RegionDescription"].ToString();
							}
							nCheckForCombo = 2;
							OldPosition = bindingManager.Position;
							daUser.Update(tempDS, "UserDesc4");
							dsUser.Tables["UserDesc4"].Clear();
							daUserDesc4.Fill(dsUser, "UserDesc4");
							dsUser.Tables["User"].Clear();
							daUserDesc4.Fill(dsUser, "User");
							daUser.Fill(dsUser, "User");
							bindingManager.Position = OldPosition;
							nCheckForCombo = 1;
							break;
					}
					LogIn.foutLogFile.WriteLine("User update was successfull at {0}", LogIn.FormatedDate(1));
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("User update was NOT successfull at {0}", LogIn.FormatedDate(1));
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					dsUser.RejectChanges();
					sqlTransaction.Rollback();
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("User update was NOT successfull at {0}", LogIn.FormatedDate(1));
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					dsUser.RejectChanges();
					sqlTransaction.Rollback();
				}
				finally
				{
					if (sqlConnection != null)
						sqlConnection.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Update') at {0}", LogIn.FormatedDate(1));
				dsUser.RejectChanges();
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (btnStartInsert.Text == "Cancel")
				btnStartInsert_Click(sender, e);
			if (btnStartFind.Text == "Cancel")
				btnStartFind_Click(sender, e);
			dsUser = new DataSet();
			daUser.Fill(dsUser, "User");
			daUserDesc0.Fill(dsUser, "UserDesc0");
			daUserDesc1.Fill(dsUser, "UserDesc1");
			daUserDesc2.Fill(dsUser, "UserDesc2");
			daUserDesc3.Fill(dsUser, "UserDesc3");
			daUserDesc4.Fill(dsUser, "UserDesc4");

			DataGridTableStyle ts1 = new DataGridTableStyle();
			DataGridTextBoxColumn txtBoxCol0, txtBoxCol1, txtBoxCol2, txtBoxCol3, txtBoxCol4, txtBoxCol5, txtBoxCol6, txtBoxCol7;
			txtBoxCol0 = new DataGridTextBoxColumn();
			txtBoxCol1 = new DataGridTextBoxColumn();
			txtBoxCol2 = new DataGridTextBoxColumn();
			txtBoxCol3 = new DataGridTextBoxColumn();
			txtBoxCol4 = new DataGridTextBoxColumn();
			txtBoxCol5 = new DataGridTextBoxColumn();
			txtBoxCol6 = new DataGridTextBoxColumn();
			txtBoxCol7 = new DataGridTextBoxColumn();
			switch (tabControl1.SelectedTab.Text)
			{
				case "Admin":
					dv = new DataView(dsUser.Tables["UserDesc0"]);
					dv.AllowNew = false;
					dv.AllowEdit = false;
					dv.AllowDelete = false;
					DataGrid.DataSource = dv;
					ts1.MappingName = "UserDesc0";
					txtBoxCol0.HeaderText = "User ID";
					txtBoxCol0.MappingName = "UserTableID";
					txtBoxCol0.Width = 50;
					txtBoxCol1.HeaderText = "User Name";
					txtBoxCol1.MappingName = "UserName";
					txtBoxCol1.Width = 90;
					txtBoxCol2.HeaderText = "First Name";
					txtBoxCol2.MappingName = "FirstName";
					txtBoxCol2.Width = 90;
					txtBoxCol3.HeaderText = "Last Name";
					txtBoxCol3.MappingName = "LastName";
					txtBoxCol3.Width = 90;
					txtBoxCol4.HeaderText = "Date Of Birth";
					txtBoxCol4.MappingName = "DateOfBirth";
					ts1.GridColumnStyles.Add(txtBoxCol0);
					ts1.GridColumnStyles.Add(txtBoxCol1);
					ts1.GridColumnStyles.Add(txtBoxCol2);
					ts1.GridColumnStyles.Add(txtBoxCol3);
					ts1.GridColumnStyles.Add(txtBoxCol4);
					DataGrid.TableStyles.Clear();
					DataGrid.TableStyles.Add(ts1);
					break;
				case "Distributor":
					dv = new DataView(dsUser.Tables["UserDesc1"]);
					dv.AllowNew = false;
					dv.AllowEdit = false;
					dv.AllowDelete = false;
					DataGrid.DataSource = dv;
					ts1.MappingName = "UserDesc1";
					txtBoxCol0.HeaderText = "User ID";
					txtBoxCol0.MappingName = "UserTableID";
					txtBoxCol0.Width = 50;
					txtBoxCol1.HeaderText = "User Name";
					txtBoxCol1.MappingName = "UserName";
					txtBoxCol1.Width = 90;
					txtBoxCol2.HeaderText = "First Name";
					txtBoxCol2.MappingName = "FirstName";
					txtBoxCol2.Width = 90;
					txtBoxCol3.HeaderText = "Last Name";
					txtBoxCol3.MappingName = "LastName";
					txtBoxCol3.Width = 90;
					txtBoxCol4.HeaderText = "Date Of Birth";
					txtBoxCol4.MappingName = "DateOfBirth";
					ts1.GridColumnStyles.Add(txtBoxCol0);
					ts1.GridColumnStyles.Add(txtBoxCol1);
					ts1.GridColumnStyles.Add(txtBoxCol2);
					ts1.GridColumnStyles.Add(txtBoxCol3);
					ts1.GridColumnStyles.Add(txtBoxCol4);
					DataGrid.TableStyles.Clear();
					DataGrid.TableStyles.Add(ts1);
					break;
				case "Region Center":
					dv = new DataView(dsUser.Tables["UserDesc2"]);
					dv.AllowNew = false;
					dv.AllowEdit = false;
					dv.AllowDelete = false;
					DataGrid.DataSource = dv;
					ts1.MappingName = "UserDesc2";
					txtBoxCol0.HeaderText = "User ID";
					txtBoxCol0.MappingName = "UserTableID";
					txtBoxCol0.Width = 50;
					txtBoxCol1.HeaderText = "User Name";
					txtBoxCol1.MappingName = "UserName";
					txtBoxCol1.Width = 90;
					txtBoxCol2.HeaderText = "First Name";
					txtBoxCol2.MappingName = "FirstName";
					txtBoxCol2.Width = 90;
					txtBoxCol3.HeaderText = "Last Name";
					txtBoxCol3.MappingName = "LastName";
					txtBoxCol3.Width = 90;
					txtBoxCol4.HeaderText = "Date Of Birth";
					txtBoxCol4.MappingName = "DateOfBirth";
					txtBoxCol4.Width = 90;
					txtBoxCol5.HeaderText = "Region";
					txtBoxCol5.MappingName = "RegionDescription";
					txtBoxCol5.Width = 90;
					ts1.GridColumnStyles.Add(txtBoxCol0);
					ts1.GridColumnStyles.Add(txtBoxCol1);
					ts1.GridColumnStyles.Add(txtBoxCol2);
					ts1.GridColumnStyles.Add(txtBoxCol3);
					ts1.GridColumnStyles.Add(txtBoxCol4);
					ts1.GridColumnStyles.Add(txtBoxCol5);
					DataGrid.TableStyles.Clear();
					DataGrid.TableStyles.Add(ts1);
					break;
				case "Supervisor":
					dv = new DataView(dsUser.Tables["UserDesc3"]);
					dv.AllowNew = false;
					dv.AllowEdit = false;
					dv.AllowDelete = false;
					DataGrid.DataSource = dv;
					ts1.MappingName = "UserDesc3";
					txtBoxCol0.HeaderText = "User ID";
					txtBoxCol0.MappingName = "UserTableID";
					txtBoxCol0.Width = 50;
					txtBoxCol1.HeaderText = "User Name";
					txtBoxCol1.MappingName = "UserName";
					txtBoxCol1.Width = 90;
					txtBoxCol2.HeaderText = "First Name";
					txtBoxCol2.MappingName = "FirstName";
					txtBoxCol2.Width = 90;
					txtBoxCol3.HeaderText = "Last Name";
					txtBoxCol3.MappingName = "LastName";
					txtBoxCol3.Width = 90;
					txtBoxCol4.HeaderText = "Date Of Birth";
					txtBoxCol4.MappingName = "DateOfBirth";
					txtBoxCol4.Width = 90;
					txtBoxCol5.HeaderText = "Region";
					txtBoxCol5.MappingName = "RegionDescription";
					txtBoxCol5.Width = 60;
					txtBoxCol6.HeaderText = "Postal Office";
					txtBoxCol6.MappingName = "PostalDesc";
					txtBoxCol6.Width = 135;
					ts1.GridColumnStyles.Add(txtBoxCol0);
					ts1.GridColumnStyles.Add(txtBoxCol1);
					ts1.GridColumnStyles.Add(txtBoxCol2);
					ts1.GridColumnStyles.Add(txtBoxCol3);
					ts1.GridColumnStyles.Add(txtBoxCol4);
					ts1.GridColumnStyles.Add(txtBoxCol5);
					ts1.GridColumnStyles.Add(txtBoxCol6);
					DataGrid.TableStyles.Clear();
					DataGrid.TableStyles.Add(ts1);
					break;
				case "Salesman":
					dv = new DataView(dsUser.Tables["UserDesc4"]);
					dv.AllowNew = false;
					dv.AllowEdit = false;
					dv.AllowDelete = false;
					DataGrid.DataSource = dv;
					ts1.MappingName = "UserDesc4";
					txtBoxCol0.HeaderText = "User ID";
					txtBoxCol0.MappingName = "UserTableID";
					txtBoxCol0.Width = 50;
					txtBoxCol1.HeaderText = "User Name";
					txtBoxCol1.MappingName = "UserName";
					txtBoxCol1.Width = 90;
					txtBoxCol2.HeaderText = "First Name";
					txtBoxCol2.MappingName = "FirstName";
					txtBoxCol2.Width = 90;
					txtBoxCol3.HeaderText = "Last Name";
					txtBoxCol3.MappingName = "LastName";
					txtBoxCol3.Width = 90;
					txtBoxCol4.HeaderText = "Date Of Birth";
					txtBoxCol4.MappingName = "DateOfBirth";
					txtBoxCol4.Width = 90;
					txtBoxCol5.HeaderText = "Region";
					txtBoxCol5.MappingName = "RegionDescription";
					txtBoxCol5.Width = 60;
					txtBoxCol6.HeaderText = "Postal Office";
					txtBoxCol6.MappingName = "PostalDesc";
					txtBoxCol6.Width = 140;
					ts1.GridColumnStyles.Add(txtBoxCol0);
					ts1.GridColumnStyles.Add(txtBoxCol1);
					ts1.GridColumnStyles.Add(txtBoxCol2);
					ts1.GridColumnStyles.Add(txtBoxCol3);
					ts1.GridColumnStyles.Add(txtBoxCol4);
					ts1.GridColumnStyles.Add(txtBoxCol5);
					ts1.GridColumnStyles.Add(txtBoxCol6);
					DataGrid.TableStyles.Clear();
					DataGrid.TableStyles.Add(ts1);
					break;
			}
			bindingManager = this.BindingContext[dv];
			bindingManager.PositionChanged += new EventHandler(Position_Changed);
			Position_Changed(sender, e);
		}

		private void cmbSalesmanRegCent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nCheckForCombo == 0)
			{
				cmbSalesmanCashOffice.Enabled = false;
			}
			else if (nCheckForCombo == 1)
			{
				cmbSalesmanCashOffice.Enabled = true;
				dvComboSalesman.RowFilter = "RegionID = " + cmbSalesmanRegCent.SelectedValue;
				cmbSalesmanCashOffice.DataSource = dvComboSalesman;
				cmbSalesmanCashOffice.SelectedIndex = -1;
			}
		}

		private void cmbSupervisorRegCent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nCheckForCombo == 0)
			{
				cmbSupervisorCashOffice.Enabled = false;
			}
			else if (nCheckForCombo == 1)
			{
				cmbSupervisorCashOffice.Enabled = true;
				dvComboSupervisor.RowFilter = "RegionID = " + cmbSupervisorRegCent.SelectedValue;
				cmbSupervisorCashOffice.DataSource = dvComboSupervisor;
				cmbSupervisorCashOffice.SelectedIndex = -1;
			}
		}

		private void Position_Changed(object sender, System.EventArgs e) 
		{ 
			txtUserName.DataBindings.Clear();
			txtFirstName.DataBindings.Clear();
			txtLastName.DataBindings.Clear();
			dtUserBirthDate.DataBindings.Clear();
			cmbRegionCenter.DataBindings.Clear();
			cmbSupervisorRegCent.DataBindings.Clear();
			cmbSupervisorCashOffice.DataBindings.Clear();
			cmbSalesmanRegCent.DataBindings.Clear();
			cmbSalesmanCashOffice.DataBindings.Clear();

			if (btnStartFind.Text == "Cancel")
				return;
			txtUserName.DataBindings.Add("Text", dv, "UserName");
			txtFirstName.DataBindings.Add("Text", dv, "FirstName");
			txtLastName.DataBindings.Add("Text", dv, "LastName");
			dtUserBirthDate.DataBindings.Add("Text", dv, "DateOfBirth");

			switch (tabControl1.SelectedTab.Text)
			{
				case "Region Center":
					cmbRegionCenter.DataBindings.Add("SelectedValue", dv, "RegionID");
					break;
				case "Supervisor":
					if (cmbSupervisorCashOffice.Enabled == false)
						cmbSupervisorRegCent_SelectedIndexChanged(sender, e);
					cmbSupervisorRegCent.DataBindings.Add("SelectedValue", dv, "RegionID");
					cmbSupervisorCashOffice.DataBindings.Add("SelectedValue", dv, "PostalID");
					break;
				case "Salesman":
					if (cmbSalesmanCashOffice.Enabled == false)
						cmbSalesmanRegCent_SelectedIndexChanged(sender, e);
					cmbSalesmanRegCent.DataBindings.Add("SelectedValue", dv, "RegionID");
					cmbSalesmanCashOffice.DataBindings.Add("SelectedValue", dv, "PostalID");
					break;
			}
		}

		private void btnStartFind_Click(object sender, System.EventArgs e)
		{
			if (btnStartFind.Text == "Start Find")
			{
				txtUserName.DataBindings.Clear();
				txtFirstName.DataBindings.Clear();
				txtLastName.DataBindings.Clear();
				txtUserName.Text = "";
				txtFirstName.Text = "";
				txtLastName.Text = "";
				btnStartFind.Text = "Cancel";
				btnStartInsert.Enabled = false;
				btnInsert.Enabled = false;
				btnUpdate.Enabled = false;
				btnFind.Enabled = true;
			}
			else
			{
				btnStartFind.Text = "Start Find";
				btnStartInsert.Enabled = true;
				btnUpdate.Enabled = true;
				btnInsert.Enabled = false;
				btnFind.Enabled = false;
				dv.RowFilter = "";
			}
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			StringBuilder Filter = new StringBuilder();
			if (txtUserName.Text.Trim() != "")
				Filter.AppendFormat("UserName LIKE  '%{0}%'", txtUserName.Text.Trim());

			if (txtFirstName.Text.Trim() != "")
			{
				if (Filter.Length == 0)
				{
					Filter.AppendFormat("FirstName LIKE '%{0}%'", txtFirstName.Text.Trim());
				}
				else
				{
					Filter.AppendFormat(" AND FirstName LIKE '%{0}%'", txtFirstName.Text.Trim());
				}
			}
			if (txtLastName.Text.Trim() != "")
			{
				if (Filter.Length == 0)
				{
					Filter.AppendFormat("LastName LIKE '%{0}%'", txtLastName.Text.Trim());
				}
				else
				{
					Filter.AppendFormat(" AND LastName LIKE '%{0}%'", txtLastName.Text.Trim());
				}
			}
			dv.RowFilter = Filter.ToString();
			dv.AllowDelete = false;
			dv.AllowEdit = false;
			dv.AllowNew = false;
		}

		private void LoadUser()
		{
			daUser = new SqlDataAdapter();

			SqlCommand cmdUserSelect = LogIn.conn.CreateCommand();
			cmdUserSelect.CommandType = CommandType.Text;
			cmdUserSelect.CommandText = "SELECT * from usertable";

			SqlCommand cmdUserInsert = LogIn.conn.CreateCommand();
			cmdUserInsert.CommandType = CommandType.Text;
			cmdUserInsert.CommandText = "insert into UserTable (UserTableID, UserName, Password, FirstName, LastName, DateOfBirth, RoleID, RegionID, PostalID, LastEndOfDayDate, FirstTimeEntrance) VALUES (@UserTableID, @UserName, @Password, @FirstName, @LastName, @DateOfBirth, @RoleID, @RegionID, @PostalID, @LastEndOfDayDate, @FirstTimeEntrance)";
			cmdUserInsert.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserInsert.Parameters.Add("@UserName", SqlDbType.NVarChar, 30, "UserName");
			cmdUserInsert.Parameters.Add("@Password", SqlDbType.NVarChar, 30, "Password");
			cmdUserInsert.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
			cmdUserInsert.Parameters.Add("@LastName", SqlDbType.NVarChar, 30, "LastName");
			cmdUserInsert.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 8, "DateOfBirth");
			cmdUserInsert.Parameters.Add("@RoleID", SqlDbType.Int, 4, "RoleID");
			cmdUserInsert.Parameters.Add("@RegionID", SqlDbType.Int, 4, "RegionID");
			cmdUserInsert.Parameters.Add("@PostalID", SqlDbType.Int, 4, "PostalID");
			cmdUserInsert.Parameters.Add("@LastEndOfDayDate", SqlDbType.DateTime, 8, "LastEndOfDayDate");
			cmdUserInsert.Parameters.Add("@FirstTimeEntrance", SqlDbType.Int, 4, "FirstTimeEntrance");
			cmdUserInsert.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdUserUpdate = LogIn.conn.CreateCommand();
			cmdUserUpdate.CommandType = CommandType.Text;
			cmdUserUpdate.CommandText = "update UserTable SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, RegionID = @RegionID, PostalID = @PostalID WHERE UserTableID = @UserTableID";
			cmdUserUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserUpdate.Parameters.Add("@UserName", SqlDbType.NVarChar, 30, "UserName");
			cmdUserUpdate.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
			cmdUserUpdate.Parameters.Add("@LastName", SqlDbType.NVarChar, 30, "LastName");
			cmdUserUpdate.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 8, "DateOfBirth");
			cmdUserUpdate.Parameters.Add("@RegionID", SqlDbType.Int, 4, "RegionID");
			cmdUserUpdate.Parameters.Add("@PostalID", SqlDbType.Int, 4, "PostalID");
			cmdUserUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daUser.SelectCommand = cmdUserSelect;
			daUser.UpdateCommand = cmdUserUpdate;
			daUser.InsertCommand = cmdUserInsert;
		}

		private void LoadSupervisorPostalOffice()
		{
			daSupervisorPostalOffice = new SqlDataAdapter();

			SqlCommand cmdPostalOffice = LogIn.conn.CreateCommand();
			cmdPostalOffice.CommandType = CommandType.Text;
			cmdPostalOffice.CommandText = "select * from PostalOffice";
			daSupervisorPostalOffice.SelectCommand = cmdPostalOffice;
		}

		private void LoadSalesmanPostalOffice()
		{
			daSalesmanPostalOffice = new SqlDataAdapter();

			SqlCommand cmdPostalOffice = LogIn.conn.CreateCommand();
			cmdPostalOffice.CommandType = CommandType.Text;
			cmdPostalOffice.CommandText = "select * from PostalOffice";
			daSalesmanPostalOffice.SelectCommand = cmdPostalOffice;
		}

		private void LoadRegion()
		{
			daRegion = new SqlDataAdapter();
			SqlCommand cmdRegion = LogIn.conn.CreateCommand();
			cmdRegion.CommandType = CommandType.Text;
			cmdRegion.CommandText = "select * from Region";
			daRegion.SelectCommand = cmdRegion;
		}

		private void LoadRegionSupervisor()
		{
			daRegionSupervisor = new SqlDataAdapter();
			SqlCommand cmdRegion = LogIn.conn.CreateCommand();
			cmdRegion.CommandType = CommandType.Text;
			cmdRegion.CommandText = "select * from Region";
			daRegionSupervisor.SelectCommand = cmdRegion;
		}

		private void LoadRegionSalesman()
		{
			daRegionSalesman = new SqlDataAdapter();
			SqlCommand cmdRegion = LogIn.conn.CreateCommand();
			cmdRegion.CommandType = CommandType.Text;
			cmdRegion.CommandText = "select * from Region";
			daRegionSalesman.SelectCommand = cmdRegion;
		}

		private void LoadUserDesc0()
		{
			daUserDesc0 = new SqlDataAdapter();
			SqlCommand cmdUserDesc0 = LogIn.conn.CreateCommand();
			cmdUserDesc0.CommandType = CommandType.Text;
			cmdUserDesc0.CommandText = "select UserTableID, UserName, FirstName, LastName, DateOfBirth, RegionID = null, PostalID = null from Usertable where RoleID = 0";

			daUserDesc0.SelectCommand = cmdUserDesc0;
		}

		private void LoadUserDesc1()
		{
			daUserDesc1 = new SqlDataAdapter();
			SqlCommand cmdUserDesc1 = LogIn.conn.CreateCommand();
			cmdUserDesc1.CommandType = CommandType.Text;
			cmdUserDesc1.CommandText = "select UserTableID, UserName, FirstName, LastName, DateOfBirth, RegionID = null, PostalID = null from Usertable where RoleID = 1";

			daUserDesc1.SelectCommand = cmdUserDesc1;
		}

		private void LoadUserDesc2()
		{
			daUserDesc2 = new SqlDataAdapter();
			SqlCommand cmdUserDesc2 = LogIn.conn.CreateCommand();
			cmdUserDesc2.CommandType = CommandType.Text;
			cmdUserDesc2.CommandText = "select UserTableID, UserName, FirstName, LastName, DateOfBirth, Region.RegionID as RegionID, RegionDescription, PostalID = null from Usertable INNER JOIN Region ON UserTable.RegionID = Region.RegionID WHERE RoleID = 2";

			daUserDesc2.SelectCommand = cmdUserDesc2;
		}

		private void LoadUserDesc3()
		{
			daUserDesc3 = new SqlDataAdapter();
			SqlCommand cmdUserDesc3 = LogIn.conn.CreateCommand();
			cmdUserDesc3.CommandType = CommandType.Text;
			cmdUserDesc3.CommandText = "select UserTableID, UserName, FirstName, LastName, DateOfBirth, Region.RegionID as RegionID, RegionDescription, PostalOffice.PostalID as PostalID, PostalOffice.PostalDesc from Usertable INNER JOIN Region ON UserTable.RegionID = Region.RegionID INNER JOIN PostalOffice ON UserTable.PostalID = PostalOffice.PostalID WHERE RoleID = 3";

			daUserDesc3.SelectCommand = cmdUserDesc3;
		}

		private void LoadUserDesc4()
		{
			daUserDesc4 = new SqlDataAdapter();
			SqlCommand cmdUserDesc4 = LogIn.conn.CreateCommand();
			cmdUserDesc4.CommandType = CommandType.Text;
			cmdUserDesc4.CommandText = "select UserTableID, UserName, FirstName, LastName, DateOfBirth, Region.RegionID as RegionID, RegionDescription, PostalOffice.PostalID as PostalID, PostalOffice.PostalDesc from Usertable INNER JOIN Region ON UserTable.RegionID = Region.RegionID INNER JOIN PostalOffice ON UserTable.PostalID = PostalOffice.PostalID WHERE RoleID = 4";

			daUserDesc4.SelectCommand = cmdUserDesc4;
		}
	}
}
