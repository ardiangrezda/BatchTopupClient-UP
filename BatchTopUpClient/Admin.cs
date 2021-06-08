using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Diagnostics;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Administrator.
	/// </summary>
	public class Admin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;

		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnUser;
		private System.Windows.Forms.Button btnPostalOffice;
		private System.Windows.Forms.Button btnUploadToDB;

		private SqlDataAdapter daAdmin;
		private SqlDataAdapter daPostalOffice;
		private SqlDataAdapter daUserTable;
		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private SqlDataAdapter daDistribution;
		private SqlDataAdapter daBatch5EuCharged, daBatch10EuCharged, daBatch20EuCharged;
		private SqlDataAdapter daBatch5EuConfirmed, daBatch10EuConfirmed, daBatch20EuConfirmed;

		private DataSet dsBatch;
		private DataSet dsAdmin;
		private DataSet dsPostalOffice;
		private DataSet dsUserTable;
		private DataSet dsCardInformation;
		private DataSet dsDistribution;
		
		private DataView dvDataGrid;
		private DataView dvCombo;
		private const char cFieldSeparator = ',';
		private const char cLineSeparator = '\n';
		private const string error = "Error!";
		private const string ConfirmReconcile		= "Are you sure you want to do reconciliation?";
		private const string ConfirmTitle	= "Confirm";
		private const string ConfirmUploadOriginalNumbersToDB = "Are you sure you want to upload original numbers to database?";
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ComboBox cmbDistribution;
		private System.Windows.Forms.Label lblDistribution;
		private System.Windows.Forms.Button btnReceiveConfirm;
		private System.Windows.Forms.Button btnInsertNumberForDistribution;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblBath5EuCharged;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox listBox5;
		private System.Windows.Forms.ListBox listBox6;
		private System.Windows.Forms.ListBox listBox4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnBlockSerialNumbers;
		private System.Windows.Forms.GroupBox groupBox4;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Admin()
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
            this.cmbDistribution = new System.Windows.Forms.ComboBox();
            this.lblDistribution = new System.Windows.Forms.Label();
            this.btnInsertNumberForDistribution = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBath5EuCharged = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnReceiveConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnPostalOffice = new System.Windows.Forms.Button();
            this.btnUploadToDB = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBlockSerialNumbers = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDistribution
            // 
            this.cmbDistribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistribution.Location = new System.Drawing.Point(16, 168);
            this.cmbDistribution.Name = "cmbDistribution";
            this.cmbDistribution.Size = new System.Drawing.Size(160, 21);
            this.cmbDistribution.TabIndex = 7;
            this.cmbDistribution.SelectedIndexChanged += new System.EventHandler(this.cmbDistribution_SelectedIndexChanged);
            // 
            // lblDistribution
            // 
            this.lblDistribution.Location = new System.Drawing.Point(32, 144);
            this.lblDistribution.Name = "lblDistribution";
            this.lblDistribution.Size = new System.Drawing.Size(96, 23);
            this.lblDistribution.TabIndex = 6;
            this.lblDistribution.Text = "Distribution User";
            this.lblDistribution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInsertNumberForDistribution
            // 
            this.btnInsertNumberForDistribution.Location = new System.Drawing.Point(8, 200);
            this.btnInsertNumberForDistribution.Name = "btnInsertNumberForDistribution";
            this.btnInsertNumberForDistribution.Size = new System.Drawing.Size(168, 24);
            this.btnInsertNumberForDistribution.TabIndex = 8;
            this.btnInsertNumberForDistribution.Text = "Insert Numbers for Distribution";
            this.btnInsertNumberForDistribution.Click += new System.EventHandler(this.btnInsertNumberForDistribution_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 360);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // DataGrid
            // 
            this.DataGrid.AllowNavigation = false;
            this.DataGrid.AllowSorting = false;
            this.DataGrid.CaptionText = "Info about cards";
            this.DataGrid.DataMember = "";
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(3, 261);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.Size = new System.Drawing.Size(386, 96);
            this.DataGrid.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox6);
            this.groupBox3.Controls.Add(this.listBox5);
            this.groupBox3.Controls.Add(this.listBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnInsertNumberForDistribution);
            this.groupBox3.Controls.Add(this.cmbDistribution);
            this.groupBox3.Controls.Add(this.lblDistribution);
            this.groupBox3.Location = new System.Drawing.Point(200, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 240);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Confirmed Batches  ";
            // 
            // listBox6
            // 
            this.listBox6.Location = new System.Drawing.Point(128, 32);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(40, 95);
            this.listBox6.TabIndex = 5;
            // 
            // listBox5
            // 
            this.listBox5.Location = new System.Drawing.Point(72, 32);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(40, 95);
            this.listBox5.TabIndex = 4;
            // 
            // listBox4
            // 
            this.listBox4.Location = new System.Drawing.Point(16, 32);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(40, 95);
            this.listBox4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "5 Eu";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "20 Eu";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "10 Eu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblBath5EuCharged);
            this.groupBox2.Controls.Add(this.listBox3);
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.btnReceiveConfirm);
            this.groupBox2.Location = new System.Drawing.Point(8, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 240);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Received Batches ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "20 Eu";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "10 Eu";
            // 
            // lblBath5EuCharged
            // 
            this.lblBath5EuCharged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBath5EuCharged.Location = new System.Drawing.Point(24, 16);
            this.lblBath5EuCharged.Name = "lblBath5EuCharged";
            this.lblBath5EuCharged.Size = new System.Drawing.Size(32, 16);
            this.lblBath5EuCharged.TabIndex = 0;
            this.lblBath5EuCharged.Text = "5 Eu";
            // 
            // listBox3
            // 
            this.listBox3.Location = new System.Drawing.Point(128, 32);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(40, 95);
            this.listBox3.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.Location = new System.Drawing.Point(72, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(40, 95);
            this.listBox2.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(16, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(40, 95);
            this.listBox1.TabIndex = 3;
            // 
            // btnReceiveConfirm
            // 
            this.btnReceiveConfirm.Location = new System.Drawing.Point(24, 200);
            this.btnReceiveConfirm.Name = "btnReceiveConfirm";
            this.btnReceiveConfirm.Size = new System.Drawing.Size(144, 24);
            this.btnReceiveConfirm.TabIndex = 6;
            this.btnReceiveConfirm.Text = "Confirm receive numbers ";
            this.btnReceiveConfirm.Click += new System.EventHandler(this.btnReceiveConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(160, 88);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(200, 16);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(184, 24);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Insert/Update/Delete User";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnPostalOffice
            // 
            this.btnPostalOffice.Location = new System.Drawing.Point(200, 48);
            this.btnPostalOffice.Name = "btnPostalOffice";
            this.btnPostalOffice.Size = new System.Drawing.Size(184, 24);
            this.btnPostalOffice.TabIndex = 1;
            this.btnPostalOffice.Text = "Insert/Update/Delete Postal Office";
            this.btnPostalOffice.Click += new System.EventHandler(this.btnPostalOffice_Click);
            // 
            // btnUploadToDB
            // 
            this.btnUploadToDB.Location = new System.Drawing.Point(8, 16);
            this.btnUploadToDB.Name = "btnUploadToDB";
            this.btnUploadToDB.Size = new System.Drawing.Size(176, 24);
            this.btnUploadToDB.TabIndex = 2;
            this.btnUploadToDB.Text = "Upload original numbers to DB";
            this.btnUploadToDB.Click += new System.EventHandler(this.btnUploadToDB_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 536);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(40, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 504);
            this.panel1.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUser);
            this.groupBox4.Controls.Add(this.btnPostalOffice);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnUploadToDB);
            this.groupBox4.Controls.Add(this.btnBlockSerialNumbers);
            this.groupBox4.Location = new System.Drawing.Point(16, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 120);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btnBlockSerialNumbers
            // 
            this.btnBlockSerialNumbers.Location = new System.Drawing.Point(8, 48);
            this.btnBlockSerialNumbers.Name = "btnBlockSerialNumbers";
            this.btnBlockSerialNumbers.Size = new System.Drawing.Size(176, 24);
            this.btnBlockSerialNumbers.TabIndex = 5;
            this.btnBlockSerialNumbers.Text = "Block serial Numbers";
            this.btnBlockSerialNumbers.Click += new System.EventHandler(this.btnBlockSerialNumbers_Click);
            // 
            // Admin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(512, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(480, 600);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Admin_Closing);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Admin_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered the Administrator form at {0}", LogIn.FormatedDate(1));
			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");
			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");

			LoadPostalOffice();
			LoadUserTable();
			LoadAdmin();
			LoadDistribution();
			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");

			dvCombo = new DataView(dsUserTable.Tables["UserTable"]);
			dsPostalOffice = new DataSet();
			daPostalOffice.Fill(dsPostalOffice, "PostalOffice");

			dsAdmin = new DataSet();
			daAdmin.Fill(dsAdmin, "Admin");
			dsDistribution = new DataSet();
			daDistribution.Fill(dsDistribution, "Distribution");

			cmbDistribution.DataSource = dsUserTable.Tables["UserTable"];
			cmbDistribution.DisplayMember = "UserName";
			cmbDistribution.ValueMember = "UserTableID";
			cmbDistribution.SelectedIndex = -1;

			LoadBatch5EuCharged();
			LoadBatch10EuCharged();
			LoadBatch20EuCharged();
			LoadBatch5EuConfirmed();
			LoadBatch10EuConfirmed();
			LoadBatch20EuConfirmed();

			dsBatch = new DataSet();
			daBatch5EuCharged.Fill(dsBatch, "Batch5EuCharged");
			daBatch10EuCharged.Fill(dsBatch, "Batch10EuCharged");
			daBatch20EuCharged.Fill(dsBatch, "Batch20EuCharged");
			daBatch5EuConfirmed.Fill(dsBatch, "Batch5EuConfirmed");
			daBatch10EuConfirmed.Fill(dsBatch, "Batch10EuConfirmed");
			daBatch20EuConfirmed.Fill(dsBatch, "Batch20EuConfirmed");
			
			listBox1.DataSource = dsBatch.Tables["Batch5EuCharged"];
			listBox1.DisplayMember = "Batch";
			listBox1.ValueMember = "CardValue";
			listBox1.SelectedIndex = -1;
			listBox2.DataSource = dsBatch.Tables["Batch10EuCharged"];
			listBox2.DisplayMember = "Batch";
			listBox2.ValueMember = "CardValue";
			listBox2.SelectedIndex = -1;
			listBox3.DataSource = dsBatch.Tables["Batch20EuCharged"];
			listBox3.DisplayMember = "Batch";
			listBox3.ValueMember = "CardValue";
			listBox3.SelectedIndex = -1;
			listBox4.DataSource = dsBatch.Tables["Batch5EuConfirmed"];
			listBox4.DisplayMember = "Batch";
			listBox4.ValueMember = "CardValue";
			listBox4.SelectedIndex = -1;
			listBox5.DataSource = dsBatch.Tables["Batch10EuConfirmed"];
			listBox5.DisplayMember = "Batch";
			listBox5.ValueMember = "CardValue";
			listBox5.SelectedIndex = -1;
			listBox6.DataSource = dsBatch.Tables["Batch20EuConfirmed"];
			listBox6.DisplayMember = "Batch";
			listBox6.ValueMember = "CardValue";
			listBox6.SelectedIndex = -1;

			dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
			dvDataGrid.AllowNew = false;
			dvDataGrid.AllowEdit = false;
			DataGrid.DataSource = dvDataGrid;
		}

		private void Admin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User exited Administrator form at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
		}

		private void btnReconcile_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Reconcile' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmReconcile, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Reconcile') at {0}", LogIn.FormatedDate(1));
				FileStream fs = null;
				BinaryReader foutReconcile = null;
				String szReconciledFile = ""; 
				try
				{
					String szErrorInReconciliation = "There was an error in reconciliation";
					String szErrorInStatusReconcile = "The status of the record was not correct";
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = "rec files (*.rec)|*.rec" ;
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						szReconciledFile = openFileDialog.FileName;
						fs = new FileStream(szReconciledFile, FileMode.Open);
						foutReconcile = new BinaryReader(fs);

						dsCardInformation = new DataSet();
						daCardInformation.Fill(dsCardInformation, "CardInformation");
						while (foutReconcile.PeekChar() != -1)
						{
							int nCardID = foutReconcile.ReadInt32();
							DataRow [] dr = dsCardInformation.Tables["CardInformation"].Select("CardID = " + nCardID);
							if (dr.Length == 0)
								throw new Exception(szErrorInReconciliation);
							int nStatus = foutReconcile.ReadInt32();
							if (nStatus != 5)
								throw new Exception(szErrorInStatusReconcile);
							dr[0]["StatusNr"] = 6;
							dr[0]["DateOfCardReceive"] = foutReconcile.ReadString();
							dr[0]["DateOfCardSale"] = foutReconcile.ReadString();
							dr[0]["DateOfCardEndOfDay"] = foutReconcile.ReadString();
							dr[0]["DateOfCardReconciled"] = foutReconcile.ReadString();
							dr[0]["DateOfCardFinished"] = LogIn.FormatedDate(2);
							dr[0]["FileNameReceived"] = foutReconcile.ReadString();
							dr[0]["FileNameSold"] = foutReconcile.ReadString();
							dr[0]["FileNameEndOfDay"] = foutReconcile.ReadString();
							dr[0]["FileNameReconciled"] = foutReconcile.ReadString();
							dr[0]["FileNameFinished"] = szReconciledFile;
						}

						daCardInformation.Update(dsCardInformation, "CardInformation");
						dsCardInformation.AcceptChanges();
						LogIn.foutLogFile.WriteLine("Procedure 'Reconcile Postal Users' was successful from file {0}, at time: {1}", szReconciledFile, LogIn.FormatedDate(1));
					}
					else
					{
						LogIn.foutLogFile.WriteLine("Procedure 'Reconcile Postal Users' was NOT successful, the user pressed 'Cancel' ('OpenFileDialog'), at time: {0}", LogIn.FormatedDate(1));
					}
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Reconcile Postal Users' was NOT successful from file {0}, the error was {1}, at time: {2}", szReconciledFile, sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Reconcile Postal Users' was NOT successful from file {0}, the error was {1}, at time: {2}", szReconciledFile, ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (fs != null)
						fs.Close();
					if (foutReconcile != null)
						foutReconcile.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Reconcile') at {0}", LogIn.FormatedDate(1));

			}
		}

		private void btnUser_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert/Update/Delete User' button at {0}", LogIn.FormatedDate(1));
			Users UsersDialog = new Users();
			UsersDialog.ShowDialog();
			UsersDialog.Dispose();
			LogIn.foutLogFile.WriteLine("User exited from 'Insert/Update/Delete User' button at {0}", LogIn.FormatedDate(1));
			Admin_Load(sender, e);
		}

		private void btnUploadToDB_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Upload original numbers to DB' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmUploadOriginalNumbersToDB, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Upload original numbers to DB') at {0}", LogIn.FormatedDate(1));
				String szUploadToDBFile = "";
				StreamReader foutUploadToDB = null;
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					UnicodeEncoding unicode = new UnicodeEncoding();
					ASCIIEncoding textConverter = new ASCIIEncoding();
					String szUploadline;
					String szErrorDuplicateData = "This serial number was already entered into database";
					String szErrorInFile = "There was an error in the the original file!";
					RegistryKey szRegistryKey = Registry.CurrentUser.OpenSubKey(LogIn.szRegKey, true);
					if (szRegistryKey == null) 
					{
						szRegistryKey = Registry.CurrentUser.CreateSubKey(LogIn.szRegKey);
					}
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = "txt files (*.txt)|*.txt" ;
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true;
					if(openFileDialog.ShowDialog() == DialogResult.OK)
					{
						String szDirectoryForUploadOriginalNumbers = "AdminUploadOrigNumbers";
						if (Directory.Exists(szDirectoryForUploadOriginalNumbers) == false)
						{
							Directory.CreateDirectory(szDirectoryForUploadOriginalNumbers);
						}
						String szRTFSavedFile = String.Format("{0}\\AdminOrigNumbers_{1}.rtf", szDirectoryForUploadOriginalNumbers, LogIn.FormatedDate(0));
						szUploadToDBFile = openFileDialog.FileName;
						foutUploadToDB = new StreamReader(szUploadToDBFile);
						string [] tempStrings = new string[3];
						char [] delimiters = new char[] {cFieldSeparator};

						dsCardInformation = new DataSet();
						daCardInformation.Fill(dsCardInformation, "CardInformation");
						dsAdmin = new DataSet();
						daAdmin.Fill(dsAdmin, "Admin");

						RijndaelManaged RijndaelAlg = new RijndaelManaged();
						byte [] key1;
						byte [] IV1;
						byte [] toEncrypt;
						byte [] encrypted;
						byte [] key = new byte[32];
						byte [] IV = new byte[16];
						if (szRegistryKey.GetValue("Key") == null)
						{
							szRegistryKey.SetValue("Key",  textConverter.GetString(RijndaelAlg.Key));
						}
						if (szRegistryKey.GetValue("IV") == null)
						{
							szRegistryKey.SetValue("IV",  textConverter.GetString(RijndaelAlg.IV));
						}

						IV1 = (byte []) szRegistryKey.GetValue("IV");
						int j = 0;
						for (int i = 0; i < IV1.Length; i++)
						{
							if (IV1[i] != 0)
							{
								IV[j] = IV1[i];
								j++;
							}
						}
						key1 = (byte []) szRegistryKey.GetValue("Key");
						j = 0;
						for (int i = 0; i < key1.Length; i++)
						{
							if (key1[i] != 0)
							{
								key[j] = key1[i];
								j++;
							}
						}
						
						SqlConnection cn = LogIn.conn;
						SqlCommand cmd = cn.CreateCommand();
						cmd.CommandType = CommandType.Text;
						cn.Open();
						cmd.CommandText = "select max(cardid) from cardinformation";
						String szMaxRecord = cmd.ExecuteScalar().ToString();
						cn.Close();
						int nMaxRecord = szMaxRecord == "" ? 0: Convert.ToInt32(szMaxRecord);

						sqlConnection = LogIn.conn;
						sqlConnection.Open();
						sqlTransaction = sqlConnection.BeginTransaction();
						daCardInformation.InsertCommand.Transaction = sqlTransaction;
						daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
						daBatch5EuCharged.SelectCommand.Transaction = sqlTransaction;
						daBatch10EuCharged.SelectCommand.Transaction = sqlTransaction;
						daBatch20EuCharged.SelectCommand.Transaction = sqlTransaction;
						daAdmin.InsertCommand.Transaction = sqlTransaction;

						ArrayList uploadArray = new ArrayList();
						int nNumberOfRecords = 0;
						while (foutUploadToDB.Peek() >= 0)
						{
							szUploadline = foutUploadToDB.ReadLine();
							tempStrings = szUploadline.Split(delimiters);
							if (tempStrings.Length != 6)
								throw new Exception(szErrorInFile);
							structUploadOriginal tempUpload = new structUploadOriginal();
							string szPin = tempStrings[2].Substring(5,5);
							string ssScnum = tempStrings[3].Substring(7,9);
							string szSenum = tempStrings[4].Substring(7,15);
							string szScrpref;
							if (tempStrings[5][17] >= '0' && tempStrings[5][17] <= '9')
								szScrpref = tempStrings[5].Substring(16,2);
							else
								szScrpref = tempStrings[5].Substring(16,1);

							tempUpload.szOriginalNumber = ssScnum + szPin;
							tempUpload.nValue = Convert.ToInt32(szScrpref);
							tempUpload.szBatch = ssScnum.Substring(0, 5);
							tempUpload.szSerialNumber = szSenum;
							uploadArray.Add(tempUpload);
							nNumberOfRecords++;
						}
						foutUploadToDB.Close();

						IEnumerator enumerator = uploadArray.GetEnumerator();
						structUploadOriginal strUpload;
						String szOriginalCodeNumber;
						long nSerialNumber, nMinSerialNumber = Convert.ToInt64(((structUploadOriginal)uploadArray[0]).szSerialNumber), nMaxSerialNumber = 0;
						int nCardValue = ((structUploadOriginal) uploadArray[0]).nValue;
						string strBatch = ((structUploadOriginal)uploadArray[0]).szBatch;
						String szEncrypted = "";

						int nCard5Euro = 0, nCard10Euro = 0, nCard20Euro = 0;
						string strBatch5Euro = "", strBatch10Euro = "", strBatch20Euro = "";
						if (nCardValue == 5)
						{
							nCard5Euro = nNumberOfRecords;
							strBatch5Euro = strBatch;
						}
						if (nCardValue == 10)
						{
							nCard10Euro = nNumberOfRecords;
							strBatch10Euro = strBatch;
						}
						if (nCardValue == 20)
						{
							nCard20Euro = nNumberOfRecords;
							strBatch20Euro = strBatch;
						}
						
						while (enumerator.MoveNext())
						{
							nMaxRecord++;
							strUpload = (structUploadOriginal) enumerator.Current;
							szOriginalCodeNumber = strUpload.szOriginalNumber;
							nSerialNumber = Convert.ToInt64(strUpload.szSerialNumber);
							if (nMinSerialNumber > nSerialNumber)
								nMinSerialNumber = nSerialNumber;
							if (nMaxSerialNumber < nSerialNumber)
								nMaxSerialNumber = nSerialNumber;

							ICryptoTransform encryptor = RijndaelAlg.CreateEncryptor(key, IV);
							MemoryStream msEncrypt = new MemoryStream();
							CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
							toEncrypt = textConverter.GetBytes(szOriginalCodeNumber);
							csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
							csEncrypt.FlushFinalBlock();
							encrypted = msEncrypt.ToArray();
							szEncrypted = unicode.GetString(encrypted);
							DataRow [] dr = dsCardInformation.Tables["CardInformation"].Select("CardCode = '" + szEncrypted + "'");
							if (dr.Length != 0)
							{
								throw new Exception(szErrorDuplicateData + ": " +szOriginalCodeNumber);
							}
							DataRow drNewRecord = dsCardInformation.Tables["CardInformation"].NewRow();
							drNewRecord["CardID"] = nMaxRecord;
							drNewRecord["CardCode"] = szEncrypted;
							drNewRecord["CardValue"] = nCardValue;
							drNewRecord["Batch"] = strBatch;
							drNewRecord["UserTableID"] = LogIn.UserID;
							drNewRecord["StatusCardID"] = 1;
							drNewRecord["CardSerialNumber"] = strUpload.szSerialNumber;

							dsCardInformation.Tables["CardInformation"].Rows.Add(drNewRecord);

							DataRow drNewAdminRecord = dsAdmin.Tables["Admin"].NewRow();
							drNewAdminRecord["CardID"] = nMaxRecord;
							drNewAdminRecord["SentToAdminDate"] = LogIn.FormatedDate(2);
							drNewAdminRecord["ReceivedFromAdminDate"] = DBNull.Value;
							drNewAdminRecord["SentToAdminFile"] = szUploadToDBFile;
							drNewAdminRecord["ReceivedFromAdminFile"] = DBNull.Value;
							drNewAdminRecord["SentUserID"] = LogIn.UserID;
							drNewAdminRecord["ReceivedUserID"] = DBNull.Value;
							drNewAdminRecord["StatusCardID"] = 1;
							dsAdmin.Tables["Admin"].Rows.Add(drNewAdminRecord);
						}

						String sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
						if (nCardValue == 5)
						{
							sz5EuroSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
						}
						else if (nCardValue == 10)
						{
							sz10EuroSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
						}
						else if (nCardValue == 20)
						{
							sz20EuroSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
						}

						richTextBox1.Text = "";
						String szTextToPrint;
						String szCurrentDateAndTime = LogIn.FormatedDate(1);
						DateTime CurrentTime = DateTime.Now;
						String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
						szTextToPrint = String.Format("Sumary of card insertion by Admin in database on date {0}", szCurrentDate);
						richTextBox1.AppendText(szTextToPrint +  
							"\n\n---------------------------------------------------------------------------------------------\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
						szTextToPrint = String.Format("Total 5 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nCard5Euro, nCard5Euro * 5, strBatch5Euro, sz5EuroSerial);
						richTextBox1.AppendText(szTextToPrint + "\n\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                        szTextToPrint = String.Format("Total 10 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nCard10Euro, nCard10Euro * 10, strBatch10Euro, sz10EuroSerial);
						richTextBox1.AppendText(szTextToPrint + "\n\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                        szTextToPrint = String.Format("Total 20 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nCard20Euro, nCard20Euro * 20, strBatch20Euro, sz20EuroSerial);
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
						daAdmin.Update(dsAdmin, "Admin");
						dsAdmin.AcceptChanges();
						daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
						dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
						DataGrid.DataSource = dvDataGrid;
						if (nCardValue == 5)
						{
							dsBatch.Tables["Batch5EuCharged"].Clear();
							daBatch5EuCharged.Fill(dsBatch, "Batch5EuCharged");
							listBox1.DataSource = dsBatch.Tables["Batch5EuCharged"];
							listBox1.DisplayMember = "Batch";
							listBox1.ValueMember = "CardValue";
							listBox1.SelectedIndex = -1;
						}
						else if (nCardValue == 10)
						{
							dsBatch.Tables["Batch10EuCharged"].Clear();
							daBatch10EuCharged.Fill(dsBatch, "Batch10EuCharged");
							listBox2.DataSource = dsBatch.Tables["Batch10EuCharged"];
							listBox2.DisplayMember = "Batch";
							listBox2.ValueMember = "CardValue";
							listBox2.SelectedIndex = -1;
						}
						else if (nCardValue == 20)
						{
							dsBatch.Tables["Batch20EuCharged"].Clear();
							daBatch20EuCharged.Fill(dsBatch, "Batch20EuCharged");
							listBox3.DataSource = dsBatch.Tables["Batch20EuCharged"];
							listBox3.DisplayMember = "Batch";
							listBox3.ValueMember = "CardValue";
							listBox3.SelectedIndex = -1;
						}
						LogIn.foutLogFile.WriteLine("Procedure 'Upload original numbers to DB' was successful, there were total {0} records entered, from which {1} records with 5 Euro, {2} records with 10 Euro and {3} records with 20 Euro, at time: {4}", nNumberOfRecords, nCard5Euro, nCard10Euro, nCard20Euro, LogIn.FormatedDate(1));
						sqlTransaction.Commit();
					}
					else
					{
						LogIn.foutLogFile.WriteLine("Procedure 'Upload original numbers to DB' was NOT successful, the user pressed 'Cancel' ('OpenFileDialog'), at time: {0}", LogIn.FormatedDate(1));
					}
				}
				catch (CryptographicException ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated due to cryptographic exception at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsAdmin.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (UnauthorizedAccessException ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated due to UnauthorizedAccessException exception at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsAdmin.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsAdmin.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsAdmin.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (foutUploadToDB != null)
						foutUploadToDB.Close();
					if (sqlConnection != null)
						sqlConnection.Close();
					LogIn.conn.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Upload original numbers to DB') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void btnPostalOffice_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert/Update/Delete Postal Office' button at {0}", LogIn.FormatedDate(1));
			PostalOffice PostalOfficeDialog = new PostalOffice();
			PostalOfficeDialog.ShowDialog();
			PostalOfficeDialog.Dispose();
			LogIn.foutLogFile.WriteLine("User exited from 'Insert/Update/Delete Postal Office' button at {0}", LogIn.FormatedDate(1));
			Admin_Load(sender, e);
		}

		private void btnUsersLocalDB_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert/Update Users to Local DB' button at {0}", LogIn.FormatedDate(1));
			try
			{
				SqlConnection cn = LogIn.conn;
				SqlCommand cmdUsers = cn.CreateCommand();
				cmdUsers.CommandType = CommandType.StoredProcedure;
				cmdUsers.CommandText = "insertUsers";
				cn.Open();
				cmdUsers.ExecuteNonQuery();
				cn.Close();
				LogIn.foutLogFile.WriteLine("Inserting users from store procedure was succesfull at {0}", LogIn.FormatedDate(1));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("Inserting users from store procedure was  NOT succesfull at {0}", LogIn.FormatedDate(1));
			}
		}
		
		private static bool IsNumeric(object Expression)
		{
			bool isNum;
			double retNum;
			isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
			return isNum;
		}
		
		private void btnReceiveConfirm_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Confirm receive numbers' button at {0}", LogIn.FormatedDate(1));
			if (listBox1.Text == "" && listBox2.Text == "" && listBox3.Text == "")
			{
				MessageBox.Show("No batch selected for confirmation", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No batch selected for confirmation ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
				return;
			}
			string ConfirmReceiveNumbers = String.Format("Are you sure you want to confirm received batches:\n 5 Euro - {0}\n 10 Euro - {1}\n 20 Euro - {2}", listBox1.Text, listBox2.Text, listBox3.Text);
			DialogResult result = MessageBox.Show(ConfirmReceiveNumbers, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirForConfirmUpload = "AdminUploadOrigNumbersConfirm";
					if (Directory.Exists(szDirForConfirmUpload) == false)
					{
						Directory.CreateDirectory(szDirForConfirmUpload);
					}
					String szRTFSavedFile = String.Format("{0}\\AdminOrigNumbersConfirm_{1}.rtf", szDirForConfirmUpload, LogIn.FormatedDate(0));
					DataRow [] dr = dsAdmin.Tables["Admin"].Select("SentUserID = " + LogIn.UserID + " AND statusCardID = 1");

					dsAdmin = new DataSet();
					daAdmin.Fill(dsAdmin, "Admin");
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daBatch5EuCharged.SelectCommand.Transaction = sqlTransaction;
					daBatch10EuCharged.SelectCommand.Transaction = sqlTransaction;
					daBatch20EuCharged.SelectCommand.Transaction = sqlTransaction;
					daBatch5EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch10EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch20EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daAdmin.UpdateCommand.Transaction = sqlTransaction;

					DataRow [] drBatch5Euro = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + listBox1.Text.ToString() + "'");
					DataRow [] drBatch10Euro = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + listBox2.Text + "'");
					DataRow [] drBatch20Euro = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + listBox3.Text + "'");

					long nSerialNumber, nMin5SerialNumber = 0, nMax5SerialNumber = 0, nMin10SerialNumber = 0, nMax10SerialNumber = 0, nMin20SerialNumber = 0, nMax20SerialNumber = 0;

					for (int i = 0; i < drBatch5Euro.Length; i++)
					{
						nSerialNumber = Convert.ToInt64(drBatch5Euro[i]["CardSerialNumber"]);
						if (i == 0)
							nMin5SerialNumber = nMax5SerialNumber = Convert.ToInt64(drBatch5Euro[0]["CardSerialNumber"]);
						if (nMin5SerialNumber > nSerialNumber)
							nMin5SerialNumber = nSerialNumber;
						if (nMax5SerialNumber < nSerialNumber)
							nMax5SerialNumber = nSerialNumber;
						DataRow [] drValue = dsAdmin.Tables["Admin"].Select("CardId = " + drBatch5Euro[i]["CardID"]);
						drValue[0]["ReceivedFromAdminDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromAdminFile"] = szRTFSavedFile;
						drBatch5Euro[i]["StatusCardID"] = 2;
					}
					for (int i = 0; i < drBatch10Euro.Length; i++)
					{
						nSerialNumber = Convert.ToInt64(drBatch10Euro[i]["CardSerialNumber"]);
						if (i == 0)
							nMin10SerialNumber = nMax10SerialNumber = Convert.ToInt64(drBatch10Euro[0]["CardSerialNumber"]);

						if (nMin10SerialNumber > nSerialNumber)
							nMin10SerialNumber = nSerialNumber;
						if (nMax10SerialNumber < nSerialNumber)
							nMax10SerialNumber = nSerialNumber;
						DataRow [] drValue = dsAdmin.Tables["Admin"].Select("CardId = " + drBatch10Euro[i]["CardID"]);
						drValue[0]["ReceivedFromAdminDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromAdminFile"] = szRTFSavedFile;
						drBatch10Euro[i]["StatusCardID"] = 2;
					}
					for (int i = 0; i < drBatch20Euro.Length; i++)
					{
						nSerialNumber = Convert.ToInt64(drBatch20Euro[i]["CardSerialNumber"]);
						if (i == 0)
							nMin20SerialNumber = nMax20SerialNumber = Convert.ToInt64(drBatch20Euro[0]["CardSerialNumber"]);

						if (nMin20SerialNumber > nSerialNumber)
							nMin20SerialNumber = nSerialNumber;
						if (nMax20SerialNumber < nSerialNumber)
							nMax20SerialNumber = nSerialNumber;
						DataRow [] drValue = dsAdmin.Tables["Admin"].Select("CardId = " + drBatch20Euro[i]["CardID"]);
						drValue[0]["ReceivedFromAdminDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromAdminFile"] = szRTFSavedFile;
						drBatch20Euro[i]["StatusCardID"] = 2;
					}
					String sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					if (drBatch5Euro.Length != 0)
						sz5EuroSerial = String.Format("Serial: {0}-{1}", nMin5SerialNumber, nMax5SerialNumber);
					if (drBatch10Euro.Length != 0)
						sz10EuroSerial = String.Format("Serial: {0}-{1}", nMin10SerialNumber, nMax10SerialNumber);
					if (drBatch20Euro.Length != 0)
						sz20EuroSerial = String.Format("Serial: {0}-{1}", nMin20SerialNumber, nMax20SerialNumber);

					richTextBox1.Text = "";
					String szTextToPrint;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					szTextToPrint = String.Format("Confirmation of card insertion on Admin Database on date {0}", szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
                    szTextToPrint = String.Format("Total 5 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch5Euro.Length, drBatch5Euro.Length * 5, listBox1.Text.ToString(), sz5EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

                    szTextToPrint = String.Format("Total 10 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch10Euro.Length, drBatch10Euro.Length * 10, listBox2.Text.ToString(), sz10EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

                    szTextToPrint = String.Format("Total 20 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch20Euro.Length, drBatch20Euro.Length * 20, listBox3.Text.ToString(), sz20EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", drBatch5Euro.Length * 5 + drBatch10Euro.Length * 10 + drBatch20Euro.Length * 20);
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

					daAdmin.Update(dsAdmin, "Admin");
					dsAdmin.AcceptChanges();
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();

					if (drBatch5Euro.Length != 0)
					{
						dsBatch.Tables["Batch5EuCharged"].Clear();
						daBatch5EuCharged.Fill(dsBatch, "Batch5EuCharged");
						listBox1.DataSource = dsBatch.Tables["Batch5EuCharged"];
						listBox1.DisplayMember = "Batch";
						listBox1.ValueMember = "CardValue";
						listBox1.SelectedIndex = -1;

						dsBatch.Tables["Batch5EuConfirmed"].Clear();
						daBatch5EuConfirmed.Fill(dsBatch, "Batch5EuConfirmed");
						listBox4.DataSource = dsBatch.Tables["Batch5EuConfirmed"];
						listBox4.DisplayMember = "Batch";
						listBox4.ValueMember = "CardValue";
						listBox4.SelectedIndex = -1;
					}

					if (drBatch10Euro.Length != 0)
					{
						dsBatch.Tables["Batch10EuCharged"].Clear();
						daBatch10EuCharged.Fill(dsBatch, "Batch10EuCharged");
						listBox2.DataSource = dsBatch.Tables["Batch10EuCharged"];
						listBox2.DisplayMember = "Batch";
						listBox2.ValueMember = "CardValue";
						listBox2.SelectedIndex = -1;

						dsBatch.Tables["Batch10EuConfirmed"].Clear();
						daBatch10EuConfirmed.Fill(dsBatch, "Batch10EuConfirmed");
						listBox5.DataSource = dsBatch.Tables["Batch10EuConfirmed"];
						listBox5.DisplayMember = "Batch";
						listBox5.ValueMember = "CardValue";
						listBox5.SelectedIndex = -1;
					}

					if (drBatch20Euro.Length != 0)
					{
						dsBatch.Tables["Batch20EuCharged"].Clear();
						daBatch20EuCharged.Fill(dsBatch, "Batch20EuCharged");
						listBox3.DataSource = dsBatch.Tables["Batch20EuCharged"];
						listBox3.DisplayMember = "Batch";
						listBox3.ValueMember = "CardValue";
						listBox3.SelectedIndex = -1;

						dsBatch.Tables["Batch20EuConfirmed"].Clear();
						daBatch20EuConfirmed.Fill(dsBatch, "Batch20EuConfirmed");
						listBox6.DataSource = dsBatch.Tables["Batch20EuConfirmed"];
						listBox6.DisplayMember = "Batch";
						listBox6.ValueMember = "CardValue";
						listBox6.SelectedIndex = -1;
					}

					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsAdmin.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsAdmin.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void btnInsertNumberForDistribution_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert Numbers for Distribution' button at {0}", LogIn.FormatedDate(1));
			if (cmbDistribution.Text == "")
			{
				MessageBox.Show("No Combo Box selected for Distribution User", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No Combo Box selected for Distribution User ('Insert Numbers for Distribution') at {0}", LogIn.FormatedDate(1));
				return;
			}
			if (listBox4.SelectedIndex == -1 && listBox5.SelectedIndex == -1 && listBox6.SelectedIndex == -1)
			{
				MessageBox.Show("No batch selected for confirmation", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No batch selected for confirmation ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
				return;
			}
			if (listBox4.SelectedIndex != -1 && listBox5.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 3 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 3 listBoxes selected! ('Insert Numbers for Distribution') at {0}", LogIn.FormatedDate(1));
				listBox4.SelectedIndex = -1;
				listBox5.SelectedIndex = -1;
				listBox6.SelectedIndex = -1;
				listBox4.ClearSelected();
				listBox5.ClearSelected();
				listBox6.ClearSelected();
				return;
			}
			if (listBox4.SelectedIndex != -1 && listBox5.SelectedIndex != -1)
			{
				MessageBox.Show("There are 2 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected! ('Insert Numbers for Distribution') at {0}", LogIn.FormatedDate(1));
				listBox4.SelectedIndex = -1;
				listBox5.SelectedIndex = -1;
				listBox4.ClearSelected();
				listBox5.ClearSelected();
				return;
			}

			if (listBox5.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 2 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected! ('Insert Numbers for Distribution') at {0}", LogIn.FormatedDate(1));
				listBox5.SelectedIndex = -1;
				listBox6.SelectedIndex = -1;
				listBox5.ClearSelected();
				listBox6.ClearSelected();
				return;
			}
			if (listBox4.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 2 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected! ('Insert Numbers for Distribution') at {0}", LogIn.FormatedDate(1));
				listBox4.SelectedIndex = -1;
				listBox6.SelectedIndex = -1;
				listBox4.ClearSelected();
				listBox6.ClearSelected();
				return;
			}
			int nCurrentValue = 0;
			string strBatch = "";
			if (listBox4.SelectedIndex != -1)
			{
				nCurrentValue = 5;
				strBatch = listBox4.Text;
			}
			if (listBox5.SelectedIndex != -1)
			{
				nCurrentValue = 10;
				strBatch = listBox5.Text;
			}
			if (listBox6.SelectedIndex != -1)
			{
				nCurrentValue = 20;
				strBatch = listBox6.Text;
			}
			string ConfirmInsertNumberForDistribution = String.Format("Are you sure you want to insert for distribution batch '{0}' valued {1} Euro?", strBatch, nCurrentValue);

			DialogResult result = MessageBox.Show(ConfirmInsertNumberForDistribution, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Insert Numbers for Distribution') button at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirAdminToDistribution = "AdminToDistribution";
					if (Directory.Exists(szDirAdminToDistribution) == false)
					{
						Directory.CreateDirectory(szDirAdminToDistribution);
					}
					String szRTFSavedFile = String.Format("{0}\\AdminToDistribution_{1}.rtf", szDirAdminToDistribution, LogIn.FormatedDate(0));

					dsUserTable = new DataSet();
					daUserTable.Fill(dsUserTable, "UserTable");
					DataRow [] drUser = dsUserTable.Tables["UserTable"].Select("UserTableID = " + cmbDistribution.SelectedValue);
					String szUserName = drUser[0]["FirstName"] + " " + drUser[0]["LastName"];
					int nUserName = Convert.ToInt32(drUser[0]["UserTableID"]);

					dsAdmin = new DataSet();
					daAdmin.Fill(dsAdmin, "Admin");
					dsDistribution = new DataSet();
					daDistribution.Fill(dsDistribution, "Distribution");
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");

					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daBatch5EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch10EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch20EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daAdmin.UpdateCommand.Transaction = sqlTransaction;
					daDistribution.InsertCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;

					DataRow [] drBatchToProcess = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + strBatch + "'");

					int nNumberOf5EuroCards = 0, nNumberOf10EuroCards = 0, nNumberOf20EuroCards = 0;
					long nSerialNumber = 0, nCurrentMinCards = 0, nCurrentMaxCards = 0 ;

					for (int i = 0; i < drBatchToProcess.Length; i++)
					{
						nSerialNumber = Convert.ToInt64(drBatchToProcess[i]["CardSerialNumber"]);
						if (i == 0)
							nCurrentMinCards = nCurrentMaxCards = Convert.ToInt64(drBatchToProcess[0]["CardSerialNumber"]);
						if (nCurrentMinCards > nSerialNumber)
							nCurrentMinCards = nSerialNumber;
						if (nCurrentMaxCards < nSerialNumber)
							nCurrentMaxCards = nSerialNumber;

						drBatchToProcess[i]["StatusCardID"] = 1;
						drBatchToProcess[i]["UserTableID"] = cmbDistribution.SelectedValue;
						DataRow [] drAdmin = dsAdmin.Tables["Admin"].Select("CardID = " + drBatchToProcess[i]["CardID"]);
						drAdmin[0]["StatusCardID"] = 3;
						DataRow drNewDistRecord = dsDistribution.Tables["Distribution"].NewRow();
						drNewDistRecord["CardID"] = drBatchToProcess[i]["CardID"];
						drNewDistRecord["SentToDistDate"] = LogIn.FormatedDate(2);
						drNewDistRecord["ReceivedFromDistDate"] = DBNull.Value;
						drNewDistRecord["SentToDistFile"] = szRTFSavedFile;
						drNewDistRecord["ReceivedFromDistFile"] = DBNull.Value;
						drNewDistRecord["SentUserID"] = cmbDistribution.SelectedValue;
						drNewDistRecord["ReceivedUserID"] = DBNull.Value;
						drNewDistRecord["StatusCardID"] = 1;
						dsDistribution.Tables["Distribution"].Rows.Add(drNewDistRecord);
					}

					string szBatch5Euro = "", szBatch10Euro = "", szBatch20Euro = "";
					String sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					if (nCurrentValue == 5)
					{
						nNumberOf5EuroCards = drBatchToProcess.Length;
						szBatch5Euro = strBatch;
						sz5EuroSerial = String.Format("Serial: {0}-{1}", nCurrentMinCards, nCurrentMaxCards);
					}
					if (nCurrentValue == 10)
					{
						nNumberOf10EuroCards = drBatchToProcess.Length;
						szBatch10Euro = strBatch;
						sz10EuroSerial = String.Format("Serial: {0}-{1}", nCurrentMinCards, nCurrentMaxCards);
					}
					if (nCurrentValue == 20)
					{
						nNumberOf20EuroCards = drBatchToProcess.Length;
						szBatch20Euro = strBatch;
						sz20EuroSerial = String.Format("Serial: {0}-{1}", nCurrentMinCards, nCurrentMaxCards);
					}

					richTextBox1.Text = "";
					String szTextToPrint;
					DateTime CurrentTime = DateTime.Now;
					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					szTextToPrint = String.Format("Number of loaded card for user: '{0}' on date: {1}", nUserName, szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
                    szTextToPrint = String.Format("Total 5 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf5EuroCards, nNumberOf5EuroCards * 5, szBatch5Euro, sz5EuroSerial);

					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                    szTextToPrint = String.Format("Total 10 EURO Card: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf10EuroCards, nNumberOf10EuroCards * 10, szBatch10Euro, sz10EuroSerial);

					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                    szTextToPrint = String.Format("Total 20: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf20EuroCards, nNumberOf20EuroCards * 20, szBatch20Euro, sz20EuroSerial);

					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
						
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nNumberOf5EuroCards * 5 + nNumberOf10EuroCards * 10 + nNumberOf20EuroCards * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n\n");
					szTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);
					richTextBox1.AppendText(szTextToPrint);
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);

					daAdmin.Update(dsAdmin, "Admin");
					dsAdmin.AcceptChanges();
					daDistribution.Update(dsDistribution, "Distribution");
					dsDistribution.AcceptChanges();
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();
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

					if (nCurrentValue == 5)
					{
						dsBatch.Tables["Batch5EuConfirmed"].Clear();
						daBatch5EuConfirmed.Fill(dsBatch, "Batch5EuConfirmed");
						listBox4.DataSource = dsBatch.Tables["Batch5EuConfirmed"];
						listBox4.DisplayMember = "Batch";
						listBox4.ValueMember = "CardValue";
						listBox4.SelectedIndex = -1;
					}
					else if (nCurrentValue == 10)
					{
						dsBatch.Tables["Batch10EuConfirmed"].Clear();
						daBatch10EuConfirmed.Fill(dsBatch, "Batch10EuConfirmed");
						listBox5.DataSource = dsBatch.Tables["Batch10EuConfirmed"];
						listBox5.DisplayMember = "Batch";
						listBox5.ValueMember = "CardValue";
						listBox5.SelectedIndex = -1;
					}
					else if (nCurrentValue == 20)
					{
						dsBatch.Tables["Batch20EuConfirmed"].Clear();
						daBatch20EuConfirmed.Fill(dsBatch, "Batch20EuConfirmed");
						listBox6.DataSource = dsBatch.Tables["Batch20EuConfirmed"];
						listBox6.DisplayMember = "Batch";
						listBox6.ValueMember = "CardValue";
						listBox6.SelectedIndex = -1;
					}
					LogIn.foutLogFile.WriteLine("Number of 5 euro cards generated: {0},  Number of 10 euro cards generated: {1}, Number of 20 euro cards generated: {2}, at time {3}", nNumberOf5EuroCards, nNumberOf10EuroCards, nNumberOf20EuroCards, LogIn.FormatedDate(1));
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsAdmin.RejectChanges();
					dsDistribution.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsAdmin.RejectChanges();
					dsDistribution.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (sqlConnection != null)
						sqlConnection.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Insert Numbers for Distribution') button at {0}", LogIn.FormatedDate(1));
			}
		}

		private void LoadCardInformation()
		{
			daCardInformation = new SqlDataAdapter();

			SqlCommand cmdCardInformationSelect = LogIn.conn.CreateCommand();
			cmdCardInformationSelect.CommandType = CommandType.Text;
			cmdCardInformationSelect.CommandText = "select * from CardInformation where StatusCardID != 8";
			
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

		private void LoadPostalOffice()
		{
			daPostalOffice = new SqlDataAdapter();

			SqlCommand cmdPostalOffice = LogIn.conn.CreateCommand();
			cmdPostalOffice.CommandType = CommandType.Text;
			cmdPostalOffice.CommandText = "select * from PostalOffice";
			daPostalOffice.SelectCommand = cmdPostalOffice;
		}

		private void LoadCardInformationGrouped()
		{
			daCardInformationGroup = new SqlDataAdapter();

			SqlCommand cmdCardInformationGroup = LogIn.conn.CreateCommand();
			cmdCardInformationGroup.CommandType = CommandType.Text;
			cmdCardInformationGroup.CommandText = "select Cast(Round(Received.cardvalue, 0) as int) as 'Card (Euro)', Received.cn as 'Received', Confirmed.cn as 'Confirmed' from (select cardvalue, count(*) as cn from Admin RIGHT JOIN CardInformation ON Admin.CardID = CardInformation.CardID where Admin.StatusCardID = 1 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue ) as Received inner join (select cardvalue, count(*) as cn from Admin RIGHT JOIN CardInformation ON Admin.CardID = CardInformation.CardID where Admin.StatusCardID = 2 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Confirmed on Received.cardvalue = Confirmed.cardvalue";

			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void LoadUserTable()
		{
			daUserTable = new SqlDataAdapter();

			SqlCommand cmdUserTable = LogIn.conn.CreateCommand();
			cmdUserTable.CommandType = CommandType.Text;
			cmdUserTable.CommandText = "select * from UserTable where roleID = 1";
			daUserTable.SelectCommand = cmdUserTable;
		}

		private void LoadAdmin()
		{
			daAdmin = new SqlDataAdapter();

			SqlCommand cmdAdminSelect = LogIn.conn.CreateCommand();
			cmdAdminSelect.CommandType = CommandType.Text;
			cmdAdminSelect.CommandText = "select * from admin where SentUserID = " + LogIn.UserID + " AND statuscardid != 3 ";

			SqlCommand cmdAdminInsert = LogIn.conn.CreateCommand();
			cmdAdminInsert.CommandType = CommandType.Text;
			cmdAdminInsert.CommandText = "Insert into Admin (CardID, SentToAdminDate, ReceivedFromAdminDate, SentToAdminFile, ReceivedFromAdminFile, SentUserID, ReceivedUserID, StatusCardID) VALUES (@CardID, @SentToAdminDate, @ReceivedFromAdminDate, @SentToAdminFile, @ReceivedFromAdminFile, @SentUserID, @ReceivedUserID, @StatusCardID)";
			cmdAdminInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdAdminInsert.Parameters.Add("@SentToAdminDate", SqlDbType.DateTime, 8, "SentToAdminDate");
			cmdAdminInsert.Parameters.Add("@ReceivedFromAdminDate", SqlDbType.DateTime, 8, "ReceivedFromAdminDate");
			cmdAdminInsert.Parameters.Add("@SentToAdminFile", SqlDbType.NVarChar, 500, "SentToAdminFile");
			cmdAdminInsert.Parameters.Add("@ReceivedFromAdminFile", SqlDbType.NVarChar, 500, "ReceivedFromAdminFile");
			cmdAdminInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdAdminInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdAdminInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdAdminInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdAdminUpdate = LogIn.conn.CreateCommand();
			cmdAdminUpdate.CommandType = CommandType.Text;
			cmdAdminUpdate.CommandText = "update Admin SET SentToAdminDate = @SentToAdminDate, ReceivedFromAdminDate = @ReceivedFromAdminDate, SentToAdminFile = @SentToAdminFile, ReceivedFromAdminFile = @ReceivedFromAdminFile, SentUserID = @SentUserID, ReceivedUserID = @ReceivedUserID, StatusCardID = @StatusCardID WHERE CardID = @CardID";
			cmdAdminUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdAdminUpdate.Parameters.Add("@SentToAdminDate", SqlDbType.DateTime, 8, "SentToAdminDate");
			cmdAdminUpdate.Parameters.Add("@ReceivedFromAdminDate", SqlDbType.DateTime, 8, "ReceivedFromAdminDate");
			cmdAdminUpdate.Parameters.Add("@SentToAdminFile", SqlDbType.NVarChar, 500, "SentToAdminFile");
			cmdAdminUpdate.Parameters.Add("@ReceivedFromAdminFile", SqlDbType.NVarChar, 500, "ReceivedFromAdminFile");
			cmdAdminUpdate.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdAdminUpdate.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdAdminUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdAdminUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daAdmin.SelectCommand = cmdAdminSelect;
			daAdmin.InsertCommand = cmdAdminInsert;
			daAdmin.UpdateCommand = cmdAdminUpdate;
		}

		private void LoadDistribution()
		{
			daDistribution = new SqlDataAdapter();

			SqlCommand cmdDistributionSelect = LogIn.conn.CreateCommand();
			cmdDistributionSelect.CommandType = CommandType.Text;
			cmdDistributionSelect.CommandText = "select * from Distribution where StatusCardid = 1";

			SqlCommand cmdDistributionInsert = LogIn.conn.CreateCommand();
			cmdDistributionInsert.CommandType = CommandType.Text;
			cmdDistributionInsert.CommandText = "Insert into Distribution (CardID, SentToDistDate, ReceivedFromDistDate, SentToDistFile, ReceivedFromDistFile, SentUserID, ReceivedUserID, StatusCardID) VALUES (@CardID, @SentToDistDate, @ReceivedFromDistDate, @SentToDistFile, @ReceivedFromDistFile, @SentUserID, @ReceivedUserID, @StatusCardID)";
			cmdDistributionInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdDistributionInsert.Parameters.Add("@SentToDistDate", SqlDbType.DateTime, 8, "SentToDistDate");
			cmdDistributionInsert.Parameters.Add("@ReceivedFromDistDate", SqlDbType.DateTime, 8, "ReceivedFromDistDate");
			cmdDistributionInsert.Parameters.Add("@SentToDistFile", SqlDbType.NVarChar, 500, "SentToDistFile");
			cmdDistributionInsert.Parameters.Add("@ReceivedFromDistFile", SqlDbType.NVarChar, 500, "ReceivedFromDistFile");
			cmdDistributionInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdDistributionInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdDistributionInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdDistributionInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daDistribution.SelectCommand = cmdDistributionSelect;
			daDistribution.InsertCommand = cmdDistributionInsert;
		}

		private void LoadBatch5EuCharged()
		{
			daBatch5EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 1 and CardInformation.StatusCardID != 8 And cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuCharged()
		{
			daBatch10EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuCharged()
		{
			daBatch20EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch5EuConfirmed()
		{
			daBatch5EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuConfirmed()
		{
			daBatch10EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuConfirmed()
		{
			daBatch20EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Admin.StatusCardID as StatusCard FROM Admin INNER JOIN CardInformation ON Admin.CardID = CardInformation.CardID WHERE Admin.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void btnBlockSerialNumbers_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Block serial Numbers' button at {0}", LogIn.FormatedDate(1));
			BlockCodes BlockCodes = new BlockCodes();
			BlockCodes.ShowDialog();
			BlockCodes.Dispose();
			LogIn.foutLogFile.WriteLine("User exited from 'Block serial Numbers' button at {0}", LogIn.FormatedDate(1));
			Admin_Load(sender, e);
		}

		private void cmbDistribution_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
	public class structUploadOriginal
	{
		public String szOriginalNumber;
		public int nValue;
		public String szBatch;
		public String szSerialNumber;
	}
}
