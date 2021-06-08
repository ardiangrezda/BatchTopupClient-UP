using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Supervisor.
	/// </summary>
	public class Supervisor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Label lblNumberOf20Cards;
		private System.Windows.Forms.TextBox txtNumberOf20EuroCards;
		private System.Windows.Forms.Label lblNumberOf10Cards;
		private System.Windows.Forms.TextBox txtNumberOf10EuroCards;
		private System.Windows.Forms.Label lblNumberOf5Cards;
		private System.Windows.Forms.TextBox txtNumberOf5EuroCards;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnReceiveConfirm;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox grpResetPassword;
		private System.Windows.Forms.ComboBox cmbResetPassword;
		private System.Windows.Forms.Button btnResetPassword;
		private System.Windows.Forms.Button btnUploadNumbers;
		private System.Windows.Forms.Button btnDownloadReconciliation;
		private System.Windows.Forms.Button btnUploadUsers;

		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private SqlDataAdapter daUserTable;
		private SqlDataAdapter daUserTablePassword;
		private SqlDataAdapter daPostalOffice;
		private SqlDataAdapter daSupervisor;
		private SqlDataAdapter daSalesman;
		private SqlDataAdapter daEndOfDay;

		private DataSet dsSalesman;
		private DataSet dsCardInformation;
		private DataSet dsSupervisor;
		private DataSet dsUserTable;
		private DataSet dsEndOfDay;
		private DataView dvDataGrid;

		private int nRegionID;
		private string szRegion;
		private int nPostalID;
		private string szPostal;

		private const string ConfirmReceiveNumbers = "Are you sure you want to confirm receiving serial numbers ?";
		private const string ConfirmUploadSerialNumbers	= "Are you sure you want to upload serial numbers?";
		private const string ConfirmResetPassword = "Are you sure you want to reset password?";
		private const string ConfirmDownloadForReconiliation	= "Are you sure you want to do reconciliation?";
        private const string ConfirmUploadUser = "Are you sure you want to insert users?";

		private const string ConfirmTitle	= "Confirm";
		private const string error				= "Error!";
		private const char cFieldSeparator = '|';
		private System.Windows.Forms.ComboBox cmbSalesmanUser;
		private System.Windows.Forms.Label lblSalesman;
		private System.Windows.Forms.Button btnInsertNumberForSalesman;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Supervisor()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNumberOf20Cards = new System.Windows.Forms.Label();
            this.txtNumberOf20EuroCards = new System.Windows.Forms.TextBox();
            this.lblNumberOf10Cards = new System.Windows.Forms.Label();
            this.txtNumberOf10EuroCards = new System.Windows.Forms.TextBox();
            this.cmbSalesmanUser = new System.Windows.Forms.ComboBox();
            this.lblSalesman = new System.Windows.Forms.Label();
            this.lblNumberOf5Cards = new System.Windows.Forms.Label();
            this.txtNumberOf5EuroCards = new System.Windows.Forms.TextBox();
            this.btnInsertNumberForSalesman = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.btnReceiveConfirm = new System.Windows.Forms.Button();
            this.btnUploadNumbers = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpResetPassword = new System.Windows.Forms.GroupBox();
            this.cmbResetPassword = new System.Windows.Forms.ComboBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnDownloadReconciliation = new System.Windows.Forms.Button();
            this.btnUploadUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpResetPassword.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.btnReceiveConfirm);
            this.groupBox1.Controls.Add(this.btnUploadNumbers);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNumberOf20Cards);
            this.groupBox3.Controls.Add(this.txtNumberOf20EuroCards);
            this.groupBox3.Controls.Add(this.lblNumberOf10Cards);
            this.groupBox3.Controls.Add(this.txtNumberOf10EuroCards);
            this.groupBox3.Controls.Add(this.cmbSalesmanUser);
            this.groupBox3.Controls.Add(this.lblSalesman);
            this.groupBox3.Controls.Add(this.lblNumberOf5Cards);
            this.groupBox3.Controls.Add(this.txtNumberOf5EuroCards);
            this.groupBox3.Controls.Add(this.btnInsertNumberForSalesman);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(144, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 176);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Card insertion for salesman";
            // 
            // lblNumberOf20Cards
            // 
            this.lblNumberOf20Cards.Location = new System.Drawing.Point(16, 112);
            this.lblNumberOf20Cards.Name = "lblNumberOf20Cards";
            this.lblNumberOf20Cards.Size = new System.Drawing.Size(152, 23);
            this.lblNumberOf20Cards.TabIndex = 6;
            this.lblNumberOf20Cards.Text = "Number of 20 Euro Cards";
            this.lblNumberOf20Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberOf20EuroCards
            // 
            this.txtNumberOf20EuroCards.Location = new System.Drawing.Point(176, 112);
            this.txtNumberOf20EuroCards.Name = "txtNumberOf20EuroCards";
            this.txtNumberOf20EuroCards.Size = new System.Drawing.Size(104, 21);
            this.txtNumberOf20EuroCards.TabIndex = 7;
            this.txtNumberOf20EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf20EuroCards_TextChanged);
            // 
            // lblNumberOf10Cards
            // 
            this.lblNumberOf10Cards.Location = new System.Drawing.Point(14, 78);
            this.lblNumberOf10Cards.Name = "lblNumberOf10Cards";
            this.lblNumberOf10Cards.Size = new System.Drawing.Size(160, 23);
            this.lblNumberOf10Cards.TabIndex = 8;
            this.lblNumberOf10Cards.Text = "Number of 10 Euro Cards";
            // 
            // txtNumberOf10EuroCards
            // 
            this.txtNumberOf10EuroCards.Location = new System.Drawing.Point(176, 78);
            this.txtNumberOf10EuroCards.Name = "txtNumberOf10EuroCards";
            this.txtNumberOf10EuroCards.Size = new System.Drawing.Size(104, 21);
            this.txtNumberOf10EuroCards.TabIndex = 5;
            this.txtNumberOf10EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf10EuroCards_TextChanged);
            // 
            // cmbSalesmanUser
            // 
            this.cmbSalesmanUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesmanUser.Location = new System.Drawing.Point(176, 16);
            this.cmbSalesmanUser.Name = "cmbSalesmanUser";
            this.cmbSalesmanUser.Size = new System.Drawing.Size(104, 21);
            this.cmbSalesmanUser.TabIndex = 1;
            // 
            // lblSalesman
            // 
            this.lblSalesman.Location = new System.Drawing.Point(16, 16);
            this.lblSalesman.Name = "lblSalesman";
            this.lblSalesman.Size = new System.Drawing.Size(152, 23);
            this.lblSalesman.TabIndex = 0;
            this.lblSalesman.Text = "Sakesman";
            this.lblSalesman.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumberOf5Cards
            // 
            this.lblNumberOf5Cards.Location = new System.Drawing.Point(16, 48);
            this.lblNumberOf5Cards.Name = "lblNumberOf5Cards";
            this.lblNumberOf5Cards.Size = new System.Drawing.Size(152, 23);
            this.lblNumberOf5Cards.TabIndex = 2;
            this.lblNumberOf5Cards.Text = "Number of 5 Euro Cards";
            this.lblNumberOf5Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberOf5EuroCards
            // 
            this.txtNumberOf5EuroCards.Location = new System.Drawing.Point(176, 48);
            this.txtNumberOf5EuroCards.Name = "txtNumberOf5EuroCards";
            this.txtNumberOf5EuroCards.Size = new System.Drawing.Size(104, 21);
            this.txtNumberOf5EuroCards.TabIndex = 3;
            this.txtNumberOf5EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf5EuroCards_TextChanged);
            // 
            // btnInsertNumberForSalesman
            // 
            this.btnInsertNumberForSalesman.Location = new System.Drawing.Point(56, 144);
            this.btnInsertNumberForSalesman.Name = "btnInsertNumberForSalesman";
            this.btnInsertNumberForSalesman.Size = new System.Drawing.Size(176, 24);
            this.btnInsertNumberForSalesman.TabIndex = 8;
            this.btnInsertNumberForSalesman.Text = "Insert cards for salesman";
            this.btnInsertNumberForSalesman.Click += new System.EventHandler(this.btnInsertNumberForSalesman_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowNavigation = false;
            this.DataGrid.AllowSorting = false;
            this.DataGrid.CaptionFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGrid.CaptionText = "Info about cards";
            this.DataGrid.DataMember = "";
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(3, 213);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.Size = new System.Drawing.Size(488, 120);
            this.DataGrid.TabIndex = 3;
            // 
            // btnReceiveConfirm
            // 
            this.btnReceiveConfirm.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnReceiveConfirm.Location = new System.Drawing.Point(16, 112);
            this.btnReceiveConfirm.Name = "btnReceiveConfirm";
            this.btnReceiveConfirm.Size = new System.Drawing.Size(112, 48);
            this.btnReceiveConfirm.TabIndex = 1;
            this.btnReceiveConfirm.Text = "Confirm received serial numbers";
            this.btnReceiveConfirm.Click += new System.EventHandler(this.btnReceiveConfirm_Click);
            // 
            // btnUploadNumbers
            // 
            this.btnUploadNumbers.BackColor = System.Drawing.SystemColors.Control;
            this.btnUploadNumbers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadNumbers.Location = new System.Drawing.Point(16, 48);
            this.btnUploadNumbers.Name = "btnUploadNumbers";
            this.btnUploadNumbers.Size = new System.Drawing.Size(112, 48);
            this.btnUploadNumbers.TabIndex = 0;
            this.btnUploadNumbers.Text = "Upload serial numbers from file";
            this.btnUploadNumbers.UseVisualStyleBackColor = false;
            this.btnUploadNumbers.Click += new System.EventHandler(this.btnUploadNumbers_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 536);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(168, 480);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 24);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpResetPassword);
            this.groupBox2.Controls.Add(this.btnDownloadReconciliation);
            this.groupBox2.Controls.Add(this.btnUploadUsers);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CAREFULL WITH THESE BUTTONS";
            // 
            // grpResetPassword
            // 
            this.grpResetPassword.Controls.Add(this.cmbResetPassword);
            this.grpResetPassword.Controls.Add(this.btnResetPassword);
            this.grpResetPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResetPassword.Location = new System.Drawing.Point(248, 16);
            this.grpResetPassword.Name = "grpResetPassword";
            this.grpResetPassword.Size = new System.Drawing.Size(184, 80);
            this.grpResetPassword.TabIndex = 2;
            this.grpResetPassword.TabStop = false;
            this.grpResetPassword.Text = "Reset password";
            // 
            // cmbResetPassword
            // 
            this.cmbResetPassword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResetPassword.Location = new System.Drawing.Point(24, 48);
            this.cmbResetPassword.Name = "cmbResetPassword";
            this.cmbResetPassword.Size = new System.Drawing.Size(144, 21);
            this.cmbResetPassword.TabIndex = 1;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(40, 16);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(104, 23);
            this.btnResetPassword.TabIndex = 0;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnDownloadReconciliation
            // 
            this.btnDownloadReconciliation.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownloadReconciliation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadReconciliation.Location = new System.Drawing.Point(16, 32);
            this.btnDownloadReconciliation.Name = "btnDownloadReconciliation";
            this.btnDownloadReconciliation.Size = new System.Drawing.Size(100, 48);
            this.btnDownloadReconciliation.TabIndex = 0;
            this.btnDownloadReconciliation.Text = "Download for reconciliation";
            this.btnDownloadReconciliation.UseVisualStyleBackColor = false;
            this.btnDownloadReconciliation.Click += new System.EventHandler(this.btnDownloadReconciliation_Click);
            // 
            // btnUploadUsers
            // 
            this.btnUploadUsers.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnUploadUsers.Location = new System.Drawing.Point(144, 32);
            this.btnUploadUsers.Name = "btnUploadUsers";
            this.btnUploadUsers.Size = new System.Drawing.Size(100, 48);
            this.btnUploadUsers.TabIndex = 3;
            this.btnUploadUsers.Text = "Upload users";
            this.btnUploadUsers.Click += new System.EventHandler(this.btnUploadUsers_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(74, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 520);
            this.panel1.TabIndex = 4;
            // 
            // Supervisor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(613, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(520, 600);
            this.Name = "Supervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor";
            this.Load += new System.EventHandler(this.Supervisor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpResetPassword.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Supervisor_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User has entered the Superviser form at {0}", LogIn.FormatedDate(1));
			
			SqlConnection cn = LogIn.conn;
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cn.Open();
			cmd.CommandText = "select regionid from usertable where usertableid = " + LogIn.UserID;
			nRegionID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
			cmd.CommandText = "select regionDescription from region where regionid = " + nRegionID;
			szRegion = cmd.ExecuteScalar().ToString();
			cmd.CommandText = "select postalID from usertable where usertableid = " + LogIn.UserID;
			nPostalID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
			cmd.CommandText = "select PostalDesc from PostalOffice where postalid = " + nPostalID;
			szPostal = cmd.ExecuteScalar().ToString();
			cn.Close();

			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");

			LoadUserTable();
			LoadUserTablePassword();
			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");
			daUserTablePassword.Fill(dsUserTable, "UserTablePassword");

			cmbResetPassword.DataSource = dsUserTable.Tables["UserTablePassword"];
			cmbResetPassword.DisplayMember = "UserName";
			cmbResetPassword.ValueMember = "UserTableID";
			cmbResetPassword.SelectedIndex = -1;

			cmbSalesmanUser.DataSource = dsUserTable.Tables["UserTable"];
			cmbSalesmanUser.DisplayMember = "UserName";
			cmbSalesmanUser.ValueMember = "UserTableID";
			cmbSalesmanUser.SelectedIndex = -1;

			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
			LoadSupervisor();
			dsSupervisor = new DataSet();
			daSupervisor.Fill(dsSupervisor, "Supervisor");
			LoadSalesman();
			dsSalesman = new DataSet();
			daSalesman.Fill(dsSalesman, "Salesman");
			LoadEndOfDay();
			dsEndOfDay = new DataSet();
			daEndOfDay.Fill(dsEndOfDay, "EndOfDay");

			dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
			dvDataGrid.AllowNew = false;
			dvDataGrid.AllowEdit = false;
			DataGrid.DataSource = dvDataGrid;
		}

		private void btnUploadNumbers_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Upload Serial Numbers' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmUploadSerialNumbers, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Upload Serial Numbers') at {0}", LogIn.FormatedDate(1));
				string szUploadFile = "";
				FileStream fs = null;
				BinaryReader foutUpload = null;
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String ErrorInUPLFile = "Error in UPL File!";
					richTextBox1.Text = "";
					char [] delimiters = new char[] {cFieldSeparator};
					String [] tempStrings = new String[7];
					for (int x = 0; x < 7; x++)
						tempStrings[x] = "";
	
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = "upl files (*.upl)|*.upl" ;
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true ;
					if(openFileDialog.ShowDialog() == DialogResult.OK)
					{
						String szDirUploadtoSupervisor = "UploadToSupervisor";
						if (Directory.Exists(szDirUploadtoSupervisor) == false)
						{
							Directory.CreateDirectory(szDirUploadtoSupervisor);
						}

						szUploadFile = openFileDialog.FileName;
						dsCardInformation = new DataSet();
						daCardInformation.Fill(dsCardInformation, "CardInformation");
						dsSupervisor = new DataSet();
						daSupervisor.Fill(dsSupervisor, "Supervisor");

						sqlConnection = LogIn.conn;
						sqlConnection.Open();
						sqlTransaction = sqlConnection.BeginTransaction();
						daCardInformation.InsertCommand.Transaction = sqlTransaction;
						daSupervisor.InsertCommand.Transaction = sqlTransaction;
						daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
						fs = new FileStream(szUploadFile, FileMode.Open);
						if (fs.Length == 0)
							throw new Exception("Madhesia e file-it eshte 0 byte!");
						foutUpload = new BinaryReader(fs, Encoding.Unicode);

						int nNumberOf5EuroCards = 0, nNumberOf10EuroCards = 0, nNumberOf20EuroCards = 0;
						String szRTFSavedFile = String.Format("{0}\\UploadSerialNumbers_{1}.rtf", szDirUploadtoSupervisor, LogIn.FormatedDate(0));

						String szUserName = LogIn.UserName;
						String szOldBatch = "", szNewBatch = "";
						long nSerialNumber = 0, nMinSerialNumber = 0, nMaxSerialNumber = 0;
						int nNumberOfCurrentCards = 0;
						int nCardOldValue = 0, nCardNewValue = 0;
						string szSerial = "";
						int nCurrentRecord = 0;
						string sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
						while (foutUpload.PeekChar() != -1)
						{
							int nCardID = foutUpload.ReadInt32();
							DataRow [] drRepeat = dsCardInformation.Tables["CardInformation"].Select("CardID = " + nCardID);
							if (drRepeat.Length != 0)
								throw new Exception(ErrorInUPLFile);
							DataRow drCardInformation = dsCardInformation.Tables["CardInformation"].NewRow();
							drCardInformation["CardID"] = nCardID;
							drCardInformation["CardCode"] = foutUpload.ReadString();
							
							DataRow drSupervisor = dsSupervisor.Tables["Supervisor"].NewRow();
							drSupervisor["CardID"] = nCardID;
							drSupervisor["SentToSupervisorDate"] = foutUpload.ReadString();
							drSupervisor["ReceivedFromSupervisorDate"] = DBNull.Value;
							drSupervisor["SentToSupervisorFile"] = foutUpload.ReadString();
							drSupervisor["ReceivedFromSupervisorFile"] = DBNull.Value;
							drSupervisor["SentUserID"] = foutUpload.ReadInt32();
							if (Convert.ToInt32(drSupervisor["SentUserID"]) != LogIn.UserID)
								throw new Exception(ErrorInUPLFile);
							drSupervisor["ReceivedUserID"] =  DBNull.Value;
							drSupervisor["StatusCardID"] = 1;

							drCardInformation["UserTableID"] = drSupervisor["SentUserID"];
							drCardInformation["StatusCardID"] = 1;

							drCardInformation["CardValue"] = foutUpload.ReadString();
							nCardNewValue = Convert.ToInt32(drCardInformation["CardValue"]);
							drCardInformation["Batch"] = foutUpload.ReadString();
							szNewBatch = drCardInformation["Batch"].ToString();

							drCardInformation["UserTableID"] = foutUpload.ReadUInt32();
							drCardInformation["CardSerialNumber"] = foutUpload.ReadString();
							nSerialNumber = Convert.ToInt64(drCardInformation["CardSerialNumber"]);
							if (nCurrentRecord == 0)
							{
								nCardOldValue = nCardNewValue;
								szOldBatch = szNewBatch;
								nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation["CardSerialNumber"]);

							}
							if (nMinSerialNumber > nSerialNumber)
								nMinSerialNumber = nSerialNumber;
							if (nMaxSerialNumber < nSerialNumber)
								nMaxSerialNumber = nSerialNumber;
							
							if (nCardOldValue != nCardNewValue)
							{
								szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
								if (nCardOldValue == 5)
									sz5EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
								else if (nCardOldValue == 10)
                                    sz10EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
								else if (nCardOldValue == 20)
                                    sz20EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);

								nNumberOfCurrentCards = 0;
								szOldBatch = szNewBatch;
								nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation["CardSerialNumber"]);
								nCardOldValue = nCardNewValue;
							}
							else if (szOldBatch != szNewBatch)
							{
								szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
								if (nCardOldValue == 5)
                                    sz5EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
								else if (nCardOldValue == 10)
                                    sz10EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
								else if (nCardOldValue == 20)
                                    sz20EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
								nNumberOfCurrentCards = 0;
								szOldBatch = szNewBatch;
								nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation["CardSerialNumber"]);
							}
							nNumberOfCurrentCards++;
							if (Convert.ToInt32(drCardInformation["CardValue"]) == 5)
							{
								nNumberOf5EuroCards++;
							}
							else if (Convert.ToInt32(drCardInformation["CardValue"]) == 10)
							{
								nNumberOf10EuroCards++;
							}
							else if (Convert.ToInt32(drCardInformation["CardValue"]) == 20)
							{
								nNumberOf20EuroCards++;
							}

							dsCardInformation.Tables["CardInformation"].Rows.Add(drCardInformation);
							dsSupervisor.Tables["Supervisor"].Rows.Add(drSupervisor);
							nCurrentRecord++;
						}
						szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
						if (nCardOldValue == 5)
                            sz5EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
						else if (nCardOldValue == 10)
                            sz10EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
						else if (nCardOldValue == 20)
                            sz20EuroSerial += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
						if (sz5EuroSerial == "")
                            sz5EuroSerial = "Number of cards of 5 EURO: 0, TOTAL: 0 EURO";
						if (sz10EuroSerial == "")
                            sz10EuroSerial = "Number of cards of 10 EURO: 0, TOTAL: 0 EURO";
						if (sz20EuroSerial == "")
                            sz20EuroSerial = "Number of cards of 20 EURO: 0, TOTAL: 0 EURO";

						String szTextToPrint;
						DateTime CurrentTime = DateTime.Now;
						String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
						String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
						String szCurrentDateAndTime = LogIn.FormatedDate(1);
						szTextToPrint = String.Format("Number of uploaded cards for user: '{0}' on date: {1}", LogIn.UserID, szCurrentDate);
						richTextBox1.AppendText(szTextToPrint +  
							"\n\n---------------------------------------------------------------------------------------------\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
						szTextToPrint = sz5EuroSerial;
						richTextBox1.AppendText(szTextToPrint + "\n\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						szTextToPrint = sz10EuroSerial;
						richTextBox1.AppendText(szTextToPrint + "\n\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						szTextToPrint = sz20EuroSerial;
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						
						richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
						szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nNumberOf5EuroCards * 5 + nNumberOf10EuroCards * 10 + nNumberOf20EuroCards * 20);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
						richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n\n");
						szTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);
						richTextBox1.AppendText(szTextToPrint);
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);

						daCardInformation.Update(dsCardInformation, "CardInformation");
						dsCardInformation.AcceptChanges();
						daSupervisor.Update(dsSupervisor, "Supervisor");
						dsSupervisor.AcceptChanges();
						daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
						dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
						DataGrid.DataSource = dvDataGrid;
						richTextBox1.SaveFile(szRTFSavedFile);
						System.Diagnostics.Process print = new System.Diagnostics.Process(); 
						print.StartInfo.FileName = szRTFSavedFile;
						print.StartInfo.CreateNoWindow = true;
						print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
						print.StartInfo.Verb = "print";
						print.Start(); //Start the process
						print.Dispose();

						LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was successful from file {1}", LogIn.FormatedDate(1),openFileDialog.FileName);
						sqlTransaction.Commit();
					}
					else
					{
						LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was NOT successful, the user pressed 'Cancel' ('OpenFileDialog'), at time: {0}", LogIn.FormatedDate(1));
					}
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was NOT successful from file {0}, the error was {1}, at {2}", szUploadFile, sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSupervisor.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was NOT successful from file {1}, the error was {1}, at {2}", szUploadFile, ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSupervisor.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (fs != null)
						fs.Close();
					if (foutUpload != null)
						foutUpload.Close();
					if (sqlConnection != null)
						sqlConnection.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Upload Numbers') at {0}", LogIn.FormatedDate(1));
			}
		}
		
		private void btnReceiveConfirm_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Confirm receive numbers' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmReceiveNumbers, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirSupervisorConfirmUpload = "SupervisorNumbersConfirm";
					if (Directory.Exists(szDirSupervisorConfirmUpload) == false)
					{
						Directory.CreateDirectory(szDirSupervisorConfirmUpload);
					}
					String szRTFSavedFile = String.Format("{0}\\SupervisorNumbersConfirm_{1}.rtf", szDirSupervisorConfirmUpload, LogIn.FormatedDate(0));
					dsSupervisor = new DataSet();
					daSupervisor.Fill(dsSupervisor, "Supervisor");
					DataRow [] dr = dsSupervisor.Tables["Supervisor"].Select("SentUserID = " + LogIn.UserID + " AND statusCardID = 1");
					int nCard5Euro = 0, nCard10Euro = 0, nCard20Euro = 0;
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daSupervisor.UpdateCommand.Transaction = sqlTransaction;

					string sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					String szOldBatch = "", szNewBatch = "";
					long nSerialNumber = 0, nMinSerialNumber = 0, nMaxSerialNumber = 0;
					int nNumberOfCurrentCards = 0;
					int nCardOldValue = 0, nCardNewValue = 0;
					string szSerial = "";
					int nCurrentRecord = 0;

					for (int i = 0; i < dr.Length; i++)
					{
						DataRow [] drValue = dsCardInformation.Tables["CardInformation"].Select("CardID = " + dr[i]["CardID"]);
						if (drValue.Length == 0)
							continue;
						
						nCardNewValue = Convert.ToInt32(drValue[0]["CardValue"]);
						szNewBatch = drValue[0]["Batch"].ToString();
						nSerialNumber = Convert.ToInt64(drValue[0]["CardSerialNumber"]);

						if (nCurrentRecord == 0)
						{
							nCardOldValue = nCardNewValue;
							szOldBatch = szNewBatch;
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drValue[0]["CardSerialNumber"]);
						}
							
						if (nCardOldValue != nCardNewValue)
						{
							szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
							if (nCardOldValue == 5)
								sz5EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
							else if (nCardOldValue == 10)
                                sz10EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
							else if (nCardOldValue == 20)
                                sz20EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);

							nNumberOfCurrentCards = 0;
							szOldBatch = szNewBatch;
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drValue[0]["CardSerialNumber"]);
							nCardOldValue = nCardNewValue;
						}
						else if (szOldBatch != szNewBatch)
						{
							szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
							if (nCardOldValue == 5)
                                sz5EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
							else if (nCardOldValue == 10)
                                sz10EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
							else if (nCardOldValue == 20)
                                sz20EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
							nNumberOfCurrentCards = 0;
							szOldBatch = szNewBatch;
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drValue[0]["CardSerialNumber"]);
						}
						if (nMinSerialNumber > nSerialNumber || nMinSerialNumber == 0)
							nMinSerialNumber = nSerialNumber;
						if (nMaxSerialNumber < nSerialNumber)
							nMaxSerialNumber = nSerialNumber;

						nNumberOfCurrentCards++;
						if (Convert.ToInt32(drValue[0]["CardValue"]) == 5)
						{
							nCard5Euro++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 10)
						{
							nCard10Euro++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 20)
						{
							nCard20Euro++;
						}

						dr[i]["ReceivedFromSupervisorDate"] = LogIn.FormatedDate(2);
						dr[i]["ReceivedUserID"] = LogIn.UserID;
						dr[i]["StatusCardID"] = 2;
						dr[i]["ReceivedFromSupervisorFile"] = szRTFSavedFile;
						drValue[0]["StatusCardID"] = 2;
						nCurrentRecord++;
					}
					szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
					if (nCardOldValue == 5)
                        sz5EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
					else if (nCardOldValue == 10)
                        sz10EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
					else if (nCardOldValue == 20)
                        sz20EuroSerial += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardOldValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardOldValue, szOldBatch, szSerial);
					if (sz5EuroSerial == "")
                        sz5EuroSerial = "Number of cards of 5 EURO: 0, TOTAL: 0 EURO";
					if (sz10EuroSerial == "")
                        sz10EuroSerial = "Number of cards of 10 EURO: 0, TOTAL: 0 EURO";
					if (sz20EuroSerial == "")
                        sz20EuroSerial = "Number of cards of 20 EURO: 0, TOTAL: 0 EURO";

					richTextBox1.Text = "";
					String szTextToPrint;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					szTextToPrint = String.Format("Confirm of card insertion from postal office {0} on date {1} for '{2}' ", szPostal, szCurrentDate, LogIn.UserID);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = sz5EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

					szTextToPrint = sz10EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

					szTextToPrint = sz20EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nCard5Euro * 5 + nCard10Euro * 10 + nCard20Euro * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n\n");

					szTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);
					richTextBox1.AppendText(szTextToPrint);
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);

					richTextBox1.SaveFile(szRTFSavedFile);

					System.Diagnostics.Process print = new System.Diagnostics.Process(); 
					print.StartInfo.FileName = szRTFSavedFile;
					print.StartInfo.CreateNoWindow = true;
					print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
					print.StartInfo.Verb = "print";
					print.Start(); //Start the process
					print.Dispose();

					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();
					daSupervisor.Update(dsSupervisor, "Supervisor");
					dsSupervisor.AcceptChanges();

					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsSupervisor.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsSupervisor.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				finally
				{
					if (sqlConnection != null)
						sqlConnection.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
		}

		public void EmptyEditBoxes()
		{
			txtNumberOf5EuroCards.Text = "";
			txtNumberOf10EuroCards.Text = "";
			txtNumberOf20EuroCards.Text = "";
		}


		private void btnInsertNumberForSalesman_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Inserto Kartelat per shitësin' button at {0}", LogIn.FormatedDate(1));
			String szComboUserEmpty = "No salesman was selected";
			if (cmbSalesmanUser.Text == "" || cmbSalesmanUser.Enabled == false)
			{
				MessageBox.Show(szComboUserEmpty, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("{0} at {1}", szComboUserEmpty, LogIn.FormatedDate(1));
				return;
			}
			int nNumberOf5EuroCards = txtNumberOf5EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf5EuroCards.Text);
			int nNumberOf10EuroCards = txtNumberOf10EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf10EuroCards.Text);
			int nNumberOf20EuroCards = txtNumberOf20EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf20EuroCards.Text);
			if (nNumberOf5EuroCards == 0 && 
				nNumberOf10EuroCards == 0 && 
				nNumberOf20EuroCards == 0)
			{
				MessageBox.Show("All edit boxes are empty or have 0 values!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogIn.foutLogFile.WriteLine("All edit boxes are empty or have 0 values ('Insert cards for salesman') at {0}", LogIn.FormatedDate(1));
				return;
			}
			string szConfirmInsertForSalesman = String.Format("Are you sure you want to insert these cards for salesman {0}? \n 5 Euro - {1} cards\n 10 Euro - {2} cards\n 20 Euro - {3} cards", cmbSalesmanUser.Text, nNumberOf5EuroCards, nNumberOf10EuroCards, nNumberOf20EuroCards);

			DialogResult result = MessageBox.Show(szConfirmInsertForSalesman, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Inserto Kartelat for user') button at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirSupervisorToSalesman = "SupervisorToSalesman";
					if (Directory.Exists(szDirSupervisorToSalesman) == false)
					{
						Directory.CreateDirectory(szDirSupervisorToSalesman);
					}

					dsUserTable = new DataSet();
					daUserTable.Fill(dsUserTable, "UserTable");
					DataRow [] drUser = dsUserTable.Tables["UserTable"].Select("UserTableID = " + cmbSalesmanUser.SelectedValue);
					String szUserName = drUser[0]["FirstName"] + " " + drUser[0]["LastName"];
					int nUserName = Convert.ToInt32(drUser[0]["UserTableID"]);

					dsSupervisor = new DataSet();
					daSupervisor.Fill(dsSupervisor, "Supervisor");
					dsSalesman = new DataSet();
					daSalesman.Fill(dsSalesman, "Salesman");
					DataRow [] drConfirmed = dsSupervisor.Tables["Supervisor"].Select("StatusCardID = 2 AND SentUserID = " + LogIn.UserID);

					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");

					int nAvailable5EuroCards = 0, nAvailable10EuroCards = 0, nAvailable20EuroCards = 0;

					ArrayList arr5Euro = new ArrayList();
					ArrayList arr10Euro = new ArrayList();
					ArrayList arr20Euro = new ArrayList();
					for (int i = 0; i < drConfirmed.Length; i++)
					{
						DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drConfirmed[i]["CardID"]);
						if (drCardInformation.Length == 0)
							continue;
						if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 5)
						{
							arr5Euro.Add(drCardInformation[0]["CardID"]);
							nAvailable5EuroCards++;
						}
						else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 10)
						{
							arr10Euro.Add(drCardInformation[0]["CardID"]);
							nAvailable10EuroCards++;
						}
						else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 20)
						{
							arr20Euro.Add(drCardInformation[0]["CardID"]);
							nAvailable20EuroCards++;
						}
					}

					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daSupervisor.UpdateCommand.Transaction = sqlTransaction;
					daSalesman.InsertCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;

					String sz5EuroError = String.Format("Ekzistojne vetem {0} kartela te lira te 5 Eurove!", nAvailable5EuroCards);
					String sz10EuroError = String.Format("Ekzistojne vetem {0} kartela te lira te 10 Eurove!", nAvailable10EuroCards);
					String sz20EuroError = String.Format("Ekzistojne vetem {0} kartela te lira te 20 Eurove!", nAvailable20EuroCards);
					
					if (nNumberOf5EuroCards > nAvailable5EuroCards)
					{
						throw new Exception(sz5EuroError);
					}
					if (nNumberOf10EuroCards > nAvailable10EuroCards)
					{
						throw new Exception(sz10EuroError);
					}
					if (nNumberOf20EuroCards > nAvailable20EuroCards)
					{
						throw new Exception(sz20EuroError);
					}
					String szRTFSavedFile = String.Format("{0}\\SupervisorToSalesman_{1}.rtf", szDirSupervisorToSalesman, LogIn.FormatedDate(0));

					String sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					FillSalesmanTable(arr5Euro, nNumberOf5EuroCards, szRTFSavedFile, ref sz5EuroSerial);
					FillSalesmanTable(arr10Euro, nNumberOf10EuroCards, szRTFSavedFile, ref sz10EuroSerial);
					FillSalesmanTable(arr20Euro, nNumberOf20EuroCards, szRTFSavedFile, ref sz20EuroSerial);
					if (sz5EuroSerial == "")
						sz5EuroSerial = "Number of 5 EURO cards : 0, TOTAL: 0 EURO";
					if (sz10EuroSerial == "")
                        sz10EuroSerial = "Number of 10 EURO cards : 0, TOTAL: 0 EURO";
					if (sz20EuroSerial == "")
                        sz20EuroSerial = "Number of 20 EURO cards : 0, TOTAL: 0 EURO";

					richTextBox1.Text = "";
					String szTextToPrint;
					DateTime CurrentTime = DateTime.Now;
					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					szTextToPrint = String.Format("Number of uploaded cards for user: '{0}' on date: {1}", nUserName, szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = sz5EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
					szTextToPrint = sz10EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
					szTextToPrint = sz20EuroSerial;
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nNumberOf5EuroCards * 5 + nNumberOf10EuroCards * 10 + nNumberOf20EuroCards * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n\n");
					szTextToPrint = String.Format("Shtypur me: {0}",  szCurrentDateAndTime);
					richTextBox1.AppendText(szTextToPrint);
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);

					daSupervisor.Update(dsSupervisor, "Supervisor");
					dsSupervisor.AcceptChanges();
					daSalesman.Update(dsSalesman, "Salesman");
					dsSalesman.AcceptChanges();
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();

					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
					EmptyEditBoxes();

					richTextBox1.SaveFile(szRTFSavedFile);
					System.Diagnostics.Process print = new System.Diagnostics.Process(); 
					print.StartInfo.FileName = szRTFSavedFile;
					print.StartInfo.CreateNoWindow = true;
					print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
					print.StartInfo.Verb = "print";
					print.Start(); //Start the process
					print.Dispose();

					LogIn.foutLogFile.WriteLine("Number of 5 euro cards generated: {0},  Number of 10 euro cards generated: {1}, Number of 20 euro cards generated: {2}, at time {3}", nNumberOf5EuroCards, nNumberOf10EuroCards, nNumberOf20EuroCards, LogIn.FormatedDate(1));
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsSupervisor.RejectChanges();
					dsSalesman.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsSupervisor.RejectChanges();
					dsSalesman.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				finally
				{
					if (sqlConnection != null)
						sqlConnection.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Inserto Kartelat per shitësin') button at {0}", LogIn.FormatedDate(1));
			}
		}

		public void FillSalesmanTable(ArrayList array, int nNumberOfCards, String szRTFSavedFile, ref string szTextToPrint)
		{
			String szFormatedDate = LogIn.FormatedDate(2);
			String szOldBatch = "", szNewBatch = "";
			int nNumberOfCurrentCards = 0;
			int nCardValue = 0;
			string szSerial = "";
			long nSerialNumber = 0, nMinSerialNumber = 0, nMaxSerialNumber = 0;
			for (int i = 0; i < nNumberOfCards; i++)
			{
				DataRow [] drSupervisor = dsSupervisor.Tables["Supervisor"].Select("cardID = " + array[i]);
				drSupervisor[0]["StatusCardID"] = 3;

				DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("cardID = " + array[i]);
				drCardInformation[0]["StatusCardID"] = 1;
				drCardInformation[0]["UserTableID"] = cmbSalesmanUser.SelectedValue;
				nSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
				if (i == 0)
				{
					szOldBatch = drCardInformation[0]["Batch"].ToString();
					nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
				}
				if (nMinSerialNumber > nSerialNumber)
					nMinSerialNumber = nSerialNumber;
				if (nMaxSerialNumber < nSerialNumber)
					nMaxSerialNumber = nSerialNumber;

				szNewBatch = drCardInformation[0]["Batch"].ToString();
				nCardValue = Convert.ToInt32(drCardInformation[0]["CardValue"]);
				if (szOldBatch != szNewBatch)
				{
					szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
					szTextToPrint += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardValue, szOldBatch, szSerial);
					nNumberOfCurrentCards = 0;
					szOldBatch = szNewBatch;
					nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
				}
				nNumberOfCurrentCards++;

				DataRow drNewSalesmanRecord = dsSalesman.Tables["Salesman"].NewRow();
				drNewSalesmanRecord["CardID"] = drSupervisor[0]["CardID"];
				drNewSalesmanRecord["SentToSalesmanDate"] = LogIn.FormatedDate(2);
				drNewSalesmanRecord["ReceivedFromSalesmanDate"] = DBNull.Value;
				drNewSalesmanRecord["SentToSalesmanFile"] = szRTFSavedFile;
				drNewSalesmanRecord["ReceivedFromSalesmanFile"] = DBNull.Value;
				drNewSalesmanRecord["SentUserID"] = cmbSalesmanUser.SelectedValue;
				drNewSalesmanRecord["ReceivedUserID"] = DBNull.Value;
				drNewSalesmanRecord["StatusCardID"] = 1;
				dsSalesman.Tables["Salesman"].Rows.Add(drNewSalesmanRecord);
			}
			if (nNumberOfCurrentCards != 0)
			{
				szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
                szTextToPrint += String.Format("Number of cards of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}", nCardValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardValue, szOldBatch, szSerial);
			}
		}

		private void btnDownloadReconciliation_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Download for Reconciliation' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmDownloadForReconiliation, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				FileStream fs = null;
				BinaryWriter foutReconcile = null;
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Download for Reconciliation') at {0}", LogIn.FormatedDate(1));
				String szReconcileSavedFile = "";
				try
				{
					richTextBox1.Text = "";
					String szDownloadReconcileClient = "DownloadSupervisorReconcile";
					if (Directory.Exists(szDownloadReconcileClient) == false)
					{
						Directory.CreateDirectory(szDownloadReconcileClient);
					}
					szReconcileSavedFile = String.Format("{0}\\reconcile_{1}_{2}_{3}.rec", szDownloadReconcileClient, szRegion, szPostal, LogIn.FormatedDate(0));
					String szDirSupervisorReconcileDownload = "SupervisorReconcileDownload";
					if (Directory.Exists(szDirSupervisorReconcileDownload) == false)
					{
						Directory.CreateDirectory(szDirSupervisorReconcileDownload);
					}
					String szRTFSavedFile = String.Format("{0}\\SupervisorReconcileDownload_{1}.rtf", szDirSupervisorReconcileDownload, LogIn.FormatedDate(0));

					fs = new FileStream(szReconcileSavedFile, FileMode.Create);
					foutReconcile = new BinaryWriter(fs);
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					dsSalesman = new DataSet();
					daSalesman.Fill(dsSalesman, "Salesman");
					dsSupervisor = new DataSet();
					daSupervisor.Fill(dsSupervisor, "Supervisor");
					dsEndOfDay = new DataSet();
					daEndOfDay.Fill(dsEndOfDay, "EndOfDay");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daSalesman.UpdateCommand.Transaction = sqlTransaction;
					daSupervisor.SelectCommand.Transaction = sqlTransaction;
					daEndOfDay.UpdateCommand.Transaction = sqlTransaction;
					
					int nNumberOfUsers = dsUserTable.Tables["UserTable"].Rows.Count;
					String szTextToPrint;
					szTextToPrint = String.Format("Card reconciliation for region: {0}, postal office: {1} ", szRegion, szPostal);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					DateTime CurrentTime = DateTime.Now;
					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					String szCurrentDateAndTime = LogIn.FormatedDate(1);

					int nEndOfCycle = 0;
					for (int j = 0; j < nNumberOfUsers; j++)
					{
						DataRow [] drSalesman = dsSalesman.Tables["Salesman"].Select("StatusCardID = 5 AND SentUserID = " + dsUserTable.Tables["UserTable"].Rows[j]["UserTableID"]);
						String szUserName = dsUserTable.Tables["UserTable"].Rows[j]["UserTableID"] + " " + dsUserTable.Tables["UserTable"].Rows[j]["LastName"];
						int nUserName = Convert.ToInt32(dsUserTable.Tables["UserTable"].Rows[j]["UserTableID"]);
						int nCurrent5EuroCards = 0, nCurrent10EuroCards = 0, nCurrent20EuroCards = 0;
						String szFormatedDate = LogIn.FormatedDate(2);
						szTextToPrint = String.Format("Number of card reconciled for user: '{0}' on date: {1}", nUserName, szCurrentDate);
						richTextBox1.AppendText(szTextToPrint +  
							"\n\n---------------------------------------------------------------------------------------------\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);

						for (int i = 0; i < drSalesman.Length; i++)
						{
							drSalesman[i]["StatusCardID"] = 6;
							drSalesman[i]["ReconcileDate"] = szFormatedDate;
							drSalesman[i]["ReconcileFile"] = szReconcileSavedFile;
							DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drSalesman[i]["CardID"]);
							if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 5)
								nCurrent5EuroCards++;
							else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 10)
								nCurrent10EuroCards++;
							else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 20)
								nCurrent20EuroCards++;
							DataRow [] drSupervisor = dsSupervisor.Tables["Supervisor"].Select("CardID = " + drSalesman[i]["CardID"]);
							drCardInformation[0]["StatusCardID"] = 6;
							foutReconcile.Write((int) drSalesman[i]["CardID"]);
							foutReconcile.Write((string) drSupervisor[0]["ReceivedFromSupervisorDate"].ToString());
							foutReconcile.Write((string) drSupervisor[0]["ReceivedFromSupervisorFile"].ToString());
							foutReconcile.Write((int) drSupervisor[0]["ReceivedUserID"]);
							foutReconcile.Write((int) drCardInformation[0]["UserTableID"]);
							foutReconcile.Write((int) drCardInformation[0]["StatusCardID"]);
							foutReconcile.Write((string) drSalesman[0]["SentToSalesmanDate"].ToString());
							foutReconcile.Write((string) drSalesman[0]["ReceivedFromSalesmanDate"].ToString());
							foutReconcile.Write((string) drSalesman[0]["SentToSalesmanFile"].ToString());
							foutReconcile.Write((string) drSalesman[0]["ReceivedFromSalesmanFile"].ToString());
							foutReconcile.Write((int) drSalesman[0]["SentUserID"]);
							foutReconcile.Write((int) drSalesman[0]["ReceivedUserID"]);
							foutReconcile.Write((int) drSalesman[0]["StatusCardID"]);
							foutReconcile.Write((string) drSalesman[0]["SoldCardDate"].ToString());
							foutReconcile.Write((string) drSalesman[0]["SoldCardFile"].ToString());
							foutReconcile.Write((string) drSalesman[0]["EndOfDayDate"].ToString());
							foutReconcile.Write((string) drSalesman[0]["EndOfDayFile"].ToString());
							foutReconcile.Write((string) drSalesman[0]["ReconcileDate"].ToString());
							foutReconcile.Write((string) drSalesman[0]["ReconcileFile"].ToString());
						}
						if (drSalesman.Length != 0)
						{
							foutReconcile.Write((int) nEndOfCycle);
							foutReconcile.Write((string) "User");
							foutReconcile.Write((int) nUserName);
							foutReconcile.Write((int) nCurrent5EuroCards);
							foutReconcile.Write((int) nCurrent10EuroCards);
							foutReconcile.Write((int) nCurrent20EuroCards);
						}

						szTextToPrint = String.Format("Number of uploaded cards of 5 EURO: {0}, TOTAL: {1} EURO", nCurrent5EuroCards, nCurrent5EuroCards * 5);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
                        szTextToPrint = String.Format("Number of uploaded cards of 10 EURO: {0}, TOTAL: {1} EURO", nCurrent10EuroCards, nCurrent10EuroCards * 10);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
                        szTextToPrint = String.Format("Number of uploaded cards of 20 EURO: {0}, TOTAL: {1} EURO", nCurrent20EuroCards, nCurrent20EuroCards * 20);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
						richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
						szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nCurrent5EuroCards * 5 + nCurrent10EuroCards * 10 + nCurrent20EuroCards * 20);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
						richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n\n");
					}
					szTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);

					for (int i = 0; i < dsEndOfDay.Tables["EndOfDay"].Rows.Count; i++)
					{
						dsEndOfDay.Tables["EndOfDay"].Rows[i]["IsReconiled"] = 1;
						foutReconcile.Write((int) nEndOfCycle);
						foutReconcile.Write((string) "EndOfDay");
						foutReconcile.Write((int) dsEndOfDay.Tables["EndOfDay"].Rows[i]["UserTableID"]);
						foutReconcile.Write((string) dsEndOfDay.Tables["EndOfDay"].Rows[i]["StartDate"].ToString());
						foutReconcile.Write((string) dsEndOfDay.Tables["EndOfDay"].Rows[i]["EndDate"].ToString());
						foutReconcile.Write((int) dsEndOfDay.Tables["EndOfDay"].Rows[i]["Total5EuroCards"]);
						foutReconcile.Write((int) dsEndOfDay.Tables["EndOfDay"].Rows[i]["Total10EuroCards"]);
						foutReconcile.Write((int) dsEndOfDay.Tables["EndOfDay"].Rows[i]["Total20EuroCards"]);
						foutReconcile.Write((int) dsEndOfDay.Tables["EndOfDay"].Rows[i]["IsReconiled"]);
					}
					richTextBox1.AppendText(szTextToPrint);
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
						
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();
					daSalesman.Update(dsSalesman, "Salesman");
					dsSalesman.AcceptChanges();
					daEndOfDay.Update(dsEndOfDay, "EndOfDay");
					dsEndOfDay.AcceptChanges();
					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
						
					richTextBox1.SaveFile(szRTFSavedFile);
					System.Diagnostics.Process print = new System.Diagnostics.Process(); 
					print.StartInfo.FileName = szRTFSavedFile;
					print.StartInfo.CreateNoWindow = true;
					print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
					print.StartInfo.Verb = "print";
					print.Start(); //Start the process
					print.Dispose();

					LogIn.foutLogFile.WriteLine("Procedure 'Download for reconciliation' was successful, the created file: {1}", LogIn.FormatedDate(1), szReconcileSavedFile);
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Download for reconciliation' was NOT successful the error was {0}, at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSalesman.RejectChanges();
					dsEndOfDay.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Download for reconciliation' was NOT successful the error was {0}, at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsEndOfDay.RejectChanges();
					dsSalesman.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (fs != null)
						fs.Close();
					if (foutReconcile != null)
						foutReconcile.Close();
					if (sqlConnection != null)
						sqlConnection.Close();
					FileInfo fin = new FileInfo(szReconcileSavedFile);
					if (fin.Length == 0)
						fin.Delete();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Download for reconciliation') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void btnResetPassword_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Reset Password' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmResetPassword, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				try
				{
					LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Reset Password') at {0}", LogIn.FormatedDate(1));
					String szProposedPassword = "123456";
					MD5 md5 = new MD5CryptoServiceProvider();
					UnicodeEncoding unicode = new UnicodeEncoding();
					byte [] btPassword = ASCIIEncoding.ASCII.GetBytes(szProposedPassword);
					md5 = new MD5CryptoServiceProvider();
					String szPassword = unicode.GetString(md5.ComputeHash(btPassword));

					DataRow [] dr = dsUserTable.Tables["UserTable"].Select("UserName = '" + cmbResetPassword.Text + "'");
					dr[0]["Password"] = szPassword;
					daUserTable.Update(dsUserTable, "UserTable");
					dsUserTable.AcceptChanges();
					LogIn.foutLogFile.WriteLine("Reseting password was successfull for user {0} at {1}", cmbResetPassword.Text, LogIn.FormatedDate(1));
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Reset Password' was NOT successful at {0}", LogIn.FormatedDate(1));
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Reset Password') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void txtNumberOf5EuroCards_TextChanged(object sender, System.EventArgs e)
		{
			if (IsNumeric(txtNumberOf5EuroCards.Text) == false)
			{
				txtNumberOf5EuroCards.Text = "";
			}
		}

		private void txtNumberOf10EuroCards_TextChanged(object sender, System.EventArgs e)
		{
			if (IsNumeric(txtNumberOf10EuroCards.Text) == false)
			{
				txtNumberOf10EuroCards.Text = "";
			}
		}

		private void txtNumberOf20EuroCards_TextChanged(object sender, System.EventArgs e)
		{
			if (IsNumeric(txtNumberOf20EuroCards.Text) == false)
			{
				txtNumberOf20EuroCards.Text = "";
			}
		}

		private static bool IsNumeric(object Expression)
		{
			bool isNum;
			double retNum;
			isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
			return isNum;
		}

		private void LoadCardInformation()
		{
			daCardInformation = new SqlDataAdapter();

			SqlCommand cmdCardInformationSelect = LogIn.conn.CreateCommand();
			cmdCardInformationSelect.CommandType = CommandType.Text;
			cmdCardInformationSelect.CommandText = "select * from CardInformation where CardInformation.StatusCardID != 8";
			
			SqlCommand cmdCardInformationInsert = LogIn.conn.CreateCommand();
			cmdCardInformationInsert.CommandType = CommandType.Text;
			cmdCardInformationInsert.CommandText = "Insert into Cardinformation (CardID, CardCode, CardValue, Batch, UserTableID, StatusCardID, CardSerialNumber) VALUES (@CardID, @CardCode, @CardValue, @Batch, @UserTableID, @StatusCardID, @CardSerialNumber)";
			cmdCardInformationInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationInsert.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationInsert.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationInsert.Parameters.Add("@Batch", SqlDbType.NVarChar, 50, "Batch");
			cmdCardInformationInsert.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdCardInformationInsert.Parameters.Add("@CardSerialNumber", SqlDbType.NVarChar, 50, "CardSerialNumber");
			cmdCardInformationInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdCardInformationUpdate = LogIn.conn.CreateCommand();
			cmdCardInformationUpdate.CommandType = CommandType.Text;
			cmdCardInformationUpdate.CommandText = "update CardInformation SET CardCode = @CardCode, CardValue = @CardValue, Batch = @Batch, UserTableID = @UserTableID, StatusCardID = @StatusCardID, CardSerialNumber = @CardSerialNumber WHERE CardID = @CardID";
			cmdCardInformationUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationUpdate.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationUpdate.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationUpdate.Parameters.Add("@Batch", SqlDbType.NVarChar, 50, "Batch");
			cmdCardInformationUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdCardInformationUpdate.Parameters.Add("@CardSerialNumber", SqlDbType.NVarChar, 50, "CardSerialNumber");
			cmdCardInformationUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daCardInformation.SelectCommand = cmdCardInformationSelect;
			daCardInformation.UpdateCommand = cmdCardInformationUpdate;
			daCardInformation.InsertCommand = cmdCardInformationInsert;
		}

		private void LoadCardInformationGrouped()
		{
			daCardInformationGroup = new SqlDataAdapter();

			SqlCommand cmdCardInformationGroup = LogIn.conn.CreateCommand();
			cmdCardInformationGroup.CommandType = CommandType.Text;
			cmdCardInformationGroup.CommandText = "select Cast(Round(Received.cardvalue, 0) as int) as 'Kartela (Euro)', Received.cn as 'Pranuar', Confirmed.cn as 'Konfirmuar' from (select cardvalue, count(*) as cn from Supervisor RIGHT JOIN CardInformation ON Supervisor.CardID = CardInformation.CardID where Supervisor.StatusCardID = 1 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue ) as Received inner join (select cardvalue, count(*) as cn from Supervisor RIGHT JOIN CardInformation ON Supervisor.CardID = CardInformation.CardID where Supervisor.StatusCardID = 2 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Confirmed on Received.cardvalue = Confirmed.cardvalue";
			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void LoadPostalOffice()
		{
			daPostalOffice = new SqlDataAdapter();

			SqlCommand cmdPostalOffice = LogIn.conn.CreateCommand();
			cmdPostalOffice.CommandType = CommandType.Text;
			cmdPostalOffice.CommandText = "select * from PostalOffice where RegionID = " + nRegionID;
			daPostalOffice.SelectCommand = cmdPostalOffice;
		}

		private void LoadUserTable()
		{
			daUserTable = new SqlDataAdapter();

			SqlCommand cmdUserSelect = LogIn.conn.CreateCommand();
			cmdUserSelect.CommandType = CommandType.Text;
			cmdUserSelect.CommandText = "select * from UserTable where roleID = 4 and regionid = " + nRegionID + " AND postalID = " + nPostalID;

			daUserTable.SelectCommand = cmdUserSelect;
		}

		private void LoadUserTablePassword()
		{
			daUserTablePassword = new SqlDataAdapter();

			SqlCommand cmdUserSelect = LogIn.conn.CreateCommand();
			cmdUserSelect.CommandType = CommandType.Text;
			cmdUserSelect.CommandText = "select * from UserTable where roleID = 4 and regionid = " + nRegionID + " AND postalID = " + nPostalID;

			SqlCommand cmdUserUpdate = LogIn.conn.CreateCommand();
			cmdUserUpdate.CommandType = CommandType.Text;
			cmdUserUpdate.CommandText = "update UserTable SET Password = @Password WHERE UserTableID = @UserTableID";
			cmdUserUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserUpdate.Parameters.Add("@Password", SqlDbType.NVarChar, 30, "Password");
			cmdUserUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daUserTablePassword.SelectCommand = cmdUserSelect;
			daUserTablePassword.UpdateCommand = cmdUserUpdate;
		}

		private void LoadSupervisor()
		{
			daSupervisor = new SqlDataAdapter();

			SqlCommand cmdSupervisorSelect = LogIn.conn.CreateCommand();
			cmdSupervisorSelect.CommandType = CommandType.Text;
			cmdSupervisorSelect.CommandText = "select * from Supervisor";

			SqlCommand cmdSupervisorInsert = LogIn.conn.CreateCommand();
			cmdSupervisorInsert.CommandType = CommandType.Text;
			cmdSupervisorInsert.CommandText = "Insert into Supervisor (CardID, SentToSupervisorDate, ReceivedFromSupervisorDate, SentToSupervisorFile, ReceivedFromSupervisorFile, SentUserID, ReceivedUserID, StatusCardID) VALUES (@CardID, @SentToSupervisorDate, @ReceivedFromSupervisorDate, @SentToSupervisorFile, @ReceivedFromSupervisorFile, @SentUserID, @ReceivedUserID, @StatusCardID)";
			cmdSupervisorInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdSupervisorInsert.Parameters.Add("@SentToSupervisorDate", SqlDbType.DateTime, 8, "SentToSupervisorDate");
			cmdSupervisorInsert.Parameters.Add("@ReceivedFromSupervisorDate", SqlDbType.DateTime, 8, "ReceivedFromSupervisorDate");
			cmdSupervisorInsert.Parameters.Add("@SentToSupervisorFile", SqlDbType.NVarChar, 500, "SentToSupervisorFile");
			cmdSupervisorInsert.Parameters.Add("@ReceivedFromSupervisorFile", SqlDbType.NVarChar, 500, "ReceivedFromSupervisorFile");
			cmdSupervisorInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdSupervisorInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdSupervisorInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdSupervisorInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdSupervisorUpdate = LogIn.conn.CreateCommand();
			cmdSupervisorUpdate.CommandType = CommandType.Text;
			cmdSupervisorUpdate.CommandText = "update Supervisor SET SentToSupervisorDate = @SentToSupervisorDate, ReceivedFromSupervisorDate = @ReceivedFromSupervisorDate, SentToSupervisorFile = @SentToSupervisorFile, ReceivedFromSupervisorFile = @ReceivedFromSupervisorFile, SentUserID = @SentUserID, ReceivedUserID = @ReceivedUserID, StatusCardID = @StatusCardID WHERE CardID = @CardID";
			cmdSupervisorUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdSupervisorUpdate.Parameters.Add("@SentToSupervisorDate", SqlDbType.DateTime, 8, "SentToSupervisorDate");
			cmdSupervisorUpdate.Parameters.Add("@ReceivedFromSupervisorDate", SqlDbType.DateTime, 8, "ReceivedFromSupervisorDate");
			cmdSupervisorUpdate.Parameters.Add("@SentToSupervisorFile", SqlDbType.NVarChar, 500, "SentToSupervisorFile");
			cmdSupervisorUpdate.Parameters.Add("@ReceivedFromSupervisorFile", SqlDbType.NVarChar, 500, "ReceivedFromSupervisorFile");
			cmdSupervisorUpdate.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdSupervisorUpdate.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdSupervisorUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdSupervisorUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daSupervisor.SelectCommand = cmdSupervisorSelect;
			daSupervisor.InsertCommand = cmdSupervisorInsert;
			daSupervisor.UpdateCommand = cmdSupervisorUpdate;
		}
		
		private void LoadSalesman()
		{
			daSalesman = new SqlDataAdapter();

			SqlCommand cmdSalesmanSelect = LogIn.conn.CreateCommand();
			cmdSalesmanSelect.CommandType = CommandType.Text;
			cmdSalesmanSelect.CommandText = "select * from Salesman  where StatusCardID = 1 or StatusCardID = 5";

			SqlCommand cmdSalesmanInsert = LogIn.conn.CreateCommand();
			cmdSalesmanInsert.CommandType = CommandType.Text;
			cmdSalesmanInsert.CommandText = "Insert into Salesman (CardID, SentToSalesmanDate, ReceivedFromSalesmanDate, SentToSalesmanFile, ReceivedFromSalesmanFile, SentUserID, ReceivedUserID, StatusCardID) VALUES (@CardID, @SentToSalesmanDate, @ReceivedFromSalesmanDate, @SentToSalesmanFile, @ReceivedFromSalesmanFile, @SentUserID, @ReceivedUserID, @StatusCardID)";
			cmdSalesmanInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdSalesmanInsert.Parameters.Add("@SentToSalesmanDate", SqlDbType.DateTime, 8, "SentToSalesmanDate");
			cmdSalesmanInsert.Parameters.Add("@ReceivedFromSalesmanDate", SqlDbType.DateTime, 8, "ReceivedFromSalesmanDate");
			cmdSalesmanInsert.Parameters.Add("@SentToSalesmanFile", SqlDbType.NVarChar, 500, "SentToSalesmanFile");
			cmdSalesmanInsert.Parameters.Add("@ReceivedFromSalesmanFile", SqlDbType.NVarChar, 500, "ReceivedFromSalesmanFile");
			cmdSalesmanInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdSalesmanInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdSalesmanInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");

			cmdSalesmanInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdSalesmanUpdate = LogIn.conn.CreateCommand();
			cmdSalesmanUpdate.CommandType = CommandType.Text;
			cmdSalesmanUpdate.CommandText = "update Salesman SET SentToSalesmanDate = @SentToSalesmanDate, ReceivedFromSalesmanDate = @ReceivedFromSalesmanDate, SentToSalesmanFile = @SentToSalesmanFile, ReceivedFromSalesmanFile = @ReceivedFromSalesmanFile, SentUserID = @SentUserID, ReceivedUserID = @ReceivedUserID, StatusCardID = @StatusCardID, SoldCardDate = @SoldCardDate, SoldCardFile = @SoldCardFile, EndOfDayDate = @EndOfDayDate, EndOfDayFile  = @EndOfDayFile, ReconcileDate = @ReconcileDate, ReconcileFile = @ReconcileFile, FinishedDate = @FinishedDate, FinishedFile = @FinishedFile WHERE CardID = @CardID";
			cmdSalesmanUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdSalesmanUpdate.Parameters.Add("@SentToSalesmanDate", SqlDbType.DateTime, 8, "SentToSalesmanDate");
			cmdSalesmanUpdate.Parameters.Add("@ReceivedFromSalesmanDate", SqlDbType.DateTime, 8, "ReceivedFromSalesmanDate");
			cmdSalesmanUpdate.Parameters.Add("@SentToSalesmanFile", SqlDbType.NVarChar, 500, "SentToSalesmanFile");
			cmdSalesmanUpdate.Parameters.Add("@ReceivedFromSalesmanFile", SqlDbType.NVarChar, 500, "ReceivedFromSalesmanFile");
			cmdSalesmanUpdate.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdSalesmanUpdate.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdSalesmanUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdSalesmanUpdate.Parameters.Add("@SoldCardDate", SqlDbType.DateTime, 8, "SoldCardDate");
			cmdSalesmanUpdate.Parameters.Add("@SoldCardFile", SqlDbType.NVarChar, 500, "SoldCardFile");
			cmdSalesmanUpdate.Parameters.Add("@EndOfDayDate", SqlDbType.DateTime, 8, "EndOfDayDate");
			cmdSalesmanUpdate.Parameters.Add("@EndOfDayFile", SqlDbType.NVarChar, 500, "EndOfDayFile");
			cmdSalesmanUpdate.Parameters.Add("@ReconcileDate", SqlDbType.DateTime, 8, "ReconcileDate");
			cmdSalesmanUpdate.Parameters.Add("@ReconcileFile", SqlDbType.NVarChar, 500, "ReconcileFile");
			cmdSalesmanUpdate.Parameters.Add("@FinishedDate", SqlDbType.DateTime, 8, "FinishedDate");
			cmdSalesmanUpdate.Parameters.Add("@FinishedFile", SqlDbType.NVarChar, 500, "FinishedFile");

			cmdSalesmanUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daSalesman.SelectCommand = cmdSalesmanSelect;
			daSalesman.InsertCommand = cmdSalesmanInsert;
			daSalesman.UpdateCommand = cmdSalesmanUpdate;
		}

		private void LoadEndOfDay()
		{
			daEndOfDay = new SqlDataAdapter();

			SqlCommand cmdEndOfDaySelect = LogIn.conn.CreateCommand();
			cmdEndOfDaySelect.CommandType = CommandType.Text;
			cmdEndOfDaySelect.CommandText = "SELECT * FROM EndOfDay INNER JOIN UserTable ON EndOfDay.UserTableID = UserTable.UserTableID WHERE ((IsReconiled <> 1) OR (IsReconiled IS NULL)) AND RegionID = " + nRegionID; 

			SqlCommand cmdEndOfDayUpdate = LogIn.conn.CreateCommand();
			cmdEndOfDayUpdate.CommandType = CommandType.Text;
			cmdEndOfDayUpdate.CommandText = "update EndOfDay SET IsReconiled = @IsReconiled where UserTableID = @UserTableID AND EndDate = @EndDate";
			cmdEndOfDayUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdEndOfDayUpdate.Parameters.Add("@StartDate", SqlDbType.DateTime, 8, "StartDate");
			cmdEndOfDayUpdate.Parameters.Add("@EndDate", SqlDbType.DateTime, 8, "EndDate");
			cmdEndOfDayUpdate.Parameters.Add("@Total5EuroCards", SqlDbType.Int, 4, "Total5EuroCards");
			cmdEndOfDayUpdate.Parameters.Add("@Total10EuroCards", SqlDbType.Int, 4, "Total10EuroCards");
			cmdEndOfDayUpdate.Parameters.Add("@Total20EuroCards", SqlDbType.Int, 4, "Total20EuroCards");
			cmdEndOfDayUpdate.Parameters.Add("@IsReconiled", SqlDbType.Int, 4, "IsReconiled");
			cmdEndOfDayUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daEndOfDay.SelectCommand = cmdEndOfDaySelect;
			daEndOfDay.UpdateCommand = cmdEndOfDayUpdate;
		}

        private void btnUploadUsers_Click(object sender, EventArgs e)
        {
            LogIn.foutLogFile.WriteLine("User pressed 'Upload Users' button at {0}", LogIn.FormatedDate(1));
            DialogResult result = MessageBox.Show(ConfirmUploadUser, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                try
                {
                    LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Upload Users') at {0}", LogIn.FormatedDate(1));
                    SqlConnection cn = LogIn.conn;
                    SqlCommand cmdUsers = cn.CreateCommand();
                    cmdUsers.CommandType = CommandType.StoredProcedure;
                    cmdUsers.CommandText = "insertUsers";
                    cn.Open();
                    cmdUsers.ExecuteNonQuery();
                    cn.Close();
                    LogIn.foutLogFile.WriteLine("Procedure 'Upload Users' was successful at {0}", LogIn.FormatedDate(1));
                }
                catch (Exception ex)
                {
                    LogIn.foutLogFile.WriteLine("Procedure 'Upload Users' was NOT successful at {0}", LogIn.FormatedDate(1));
                    MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Upload Users') at {0}", LogIn.FormatedDate(1));
            }
        }

	}
}
