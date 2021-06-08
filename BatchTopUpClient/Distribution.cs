using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Distribution.
	/// </summary>
	public class Distribution : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblRegionCenter;

		private SqlDataAdapter daDistribution;
		private SqlDataAdapter daUserTable;
		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private SqlDataAdapter daRegionCenter;
		private SqlDataAdapter daRegion;
		private SqlDataAdapter daBatch5EuCharged, daBatch10EuCharged, daBatch20EuCharged;
		private SqlDataAdapter daBatch5EuConfirmed, daBatch10EuConfirmed, daBatch20EuConfirmed;

		private DataSet dsDistribution;
		private DataSet dsUserTable;
		private DataSet dsCardInformation;
		private DataSet dsRegionCenter;
		private DataSet dsRegion;
		private DataSet dsBatch;
		private DataView dvDataGrid;
		private DataView dvCombo;
		private System.Windows.Forms.ComboBox cmbRegionCenterUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbRegion;
		private int nCheckForCombo;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private const string error = "Error!";
		private const string ConfirmTitle	= "Confirm";
		private System.Windows.Forms.Button btnInsertNumberForRegionCenters;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox listBox6;
		private System.Windows.Forms.ListBox listBox5;
		private System.Windows.Forms.ListBox listBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblBath5EuCharged;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnReceiveConfirm;
		private System.Windows.Forms.Panel panel1;

		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Distribution()
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
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRegionCenterUser = new System.Windows.Forms.ComboBox();
            this.lblRegionCenter = new System.Windows.Forms.Label();
            this.btnInsertNumberForRegionCenters = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblBath5EuCharged = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnReceiveConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.Location = new System.Drawing.Point(128, 144);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(120, 21);
            this.cmbRegion.TabIndex = 7;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Region Center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRegionCenterUser
            // 
            this.cmbRegionCenterUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionCenterUser.Location = new System.Drawing.Point(128, 168);
            this.cmbRegionCenterUser.Name = "cmbRegionCenterUser";
            this.cmbRegionCenterUser.Size = new System.Drawing.Size(120, 21);
            this.cmbRegionCenterUser.TabIndex = 9;
            // 
            // lblRegionCenter
            // 
            this.lblRegionCenter.Location = new System.Drawing.Point(8, 168);
            this.lblRegionCenter.Name = "lblRegionCenter";
            this.lblRegionCenter.Size = new System.Drawing.Size(104, 23);
            this.lblRegionCenter.TabIndex = 8;
            this.lblRegionCenter.Text = "Region Center User";
            this.lblRegionCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInsertNumberForRegionCenters
            // 
            this.btnInsertNumberForRegionCenters.Location = new System.Drawing.Point(32, 200);
            this.btnInsertNumberForRegionCenters.Name = "btnInsertNumberForRegionCenters";
            this.btnInsertNumberForRegionCenters.Size = new System.Drawing.Size(192, 24);
            this.btnInsertNumberForRegionCenters.TabIndex = 10;
            this.btnInsertNumberForRegionCenters.Text = "Insert Numbers for Region Centers";
            this.btnInsertNumberForRegionCenters.Click += new System.EventHandler(this.btnInsertNumberForRegionCenters_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(184, 456);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 24);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 536);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 400);
            this.groupBox1.TabIndex = 0;
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
            this.DataGrid.Location = new System.Drawing.Point(3, 301);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.Size = new System.Drawing.Size(458, 96);
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
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbRegion);
            this.groupBox3.Controls.Add(this.lblRegionCenter);
            this.groupBox3.Controls.Add(this.cmbRegionCenterUser);
            this.groupBox3.Controls.Add(this.btnInsertNumberForRegionCenters);
            this.groupBox3.Location = new System.Drawing.Point(200, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 240);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Confirmed Batches  ";
            // 
            // listBox6
            // 
            this.listBox6.Location = new System.Drawing.Point(168, 32);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(40, 95);
            this.listBox6.TabIndex = 5;
            // 
            // listBox5
            // 
            this.listBox5.Location = new System.Drawing.Point(112, 32);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(40, 95);
            this.listBox5.TabIndex = 4;
            // 
            // listBox4
            // 
            this.listBox4.Location = new System.Drawing.Point(56, 32);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(40, 95);
            this.listBox4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "5 Eu";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "20 Eu";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "10 Eu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
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
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "10 Eu";
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(24, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 488);
            this.panel1.TabIndex = 3;
            // 
            // Distribution
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(520, 600);
            this.Name = "Distribution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribution";
            this.Load += new System.EventHandler(this.Distribution_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Distribution_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered the Distribution form at {0}", LogIn.FormatedDate(1));

			nCheckForCombo = 0;
			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");
			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
			LoadUserTable();
			LoadDistribution();
			LoadRegionCenter();
			LoadRegion();

			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");
			dsRegion = new DataSet();
			daRegion.Fill(dsRegion, "Region");

			cmbRegion.DataSource = dsRegion.Tables["Region"];
			cmbRegion.DisplayMember = "RegionDescription";
			cmbRegion.ValueMember = "RegionID";
			cmbRegion.SelectedIndex = -1;
			dvCombo = new DataView(dsUserTable.Tables["UserTable"]);
			cmbRegionCenterUser.DataSource = dsUserTable.Tables["UserTable"];
			cmbRegionCenterUser.DisplayMember = "UserName";
			cmbRegionCenterUser.ValueMember = "UserTableID";
			cmbRegionCenterUser.SelectedIndex = -1;

			dsDistribution = new DataSet();
			daDistribution.Fill(dsDistribution, "Distribution");
			dsRegionCenter = new DataSet();
			daRegionCenter.Fill(dsRegionCenter, "RegionCenter");
			
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
			nCheckForCombo = 1;
		}

		private void btnInsertNumberForRegionCenters_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert Numbers for Region Centers' button at {0}", LogIn.FormatedDate(1));
			if (cmbRegionCenterUser.Text == "")
			{
				MessageBox.Show("No Combo Box selected for Region Center User", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No Combo Box selected for Region Center User ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));
				return;
			}
			if (listBox4.SelectedIndex == -1 && listBox5.SelectedIndex == -1 && listBox6.SelectedIndex == -1)
			{
				MessageBox.Show("There was not any batch selected", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There was not any batch selected ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));				return;
			}
			if (listBox4.SelectedIndex != -1 && listBox5.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 3 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 3 listBoxes selected ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));				listBox4.SelectedIndex = -1;
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
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));				listBox4.SelectedIndex = -1;
				listBox5.SelectedIndex = -1;
				listBox4.ClearSelected();
				listBox5.ClearSelected();
				return;
			}
			if (listBox5.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 2 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));				listBox5.SelectedIndex = -1;
				listBox6.SelectedIndex = -1;
				listBox5.ClearSelected();
				listBox6.ClearSelected();
				return;
			}
			if (listBox4.SelectedIndex != -1 && listBox6.SelectedIndex != -1)
			{
				MessageBox.Show("There are 2 listBoxes selected!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("There are 2 listBoxes selected ('Insert Numbers for Region Centers') at {0}", LogIn.FormatedDate(1));							listBox4.SelectedIndex = -1;
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
			string ConfirmInsertNumberForRegionCenter = String.Format("Are you sure you want to insert for the Region Center batch '{0}' valued {1} Euro?", strBatch, nCurrentValue);

			DialogResult result = MessageBox.Show(ConfirmInsertNumberForRegionCenter, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Insert Numbers for Region Centers') button at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirDistributionToRegionCenter = "DistributionToRegionCenter";
					if (Directory.Exists(szDirDistributionToRegionCenter) == false)
					{
						Directory.CreateDirectory(szDirDistributionToRegionCenter);
					}
					String szRTFSavedFile = String.Format("{0}\\DistributionToRegionCenter_{1}.rtf", szDirDistributionToRegionCenter, LogIn.FormatedDate(0));

					dsUserTable = new DataSet();
					daUserTable.Fill(dsUserTable, "UserTable");
					DataRow [] drUser = dsUserTable.Tables["UserTable"].Select("UserTableID = " + cmbRegionCenterUser.SelectedValue);
					String szUserName = drUser[0]["FirstName"] + " " + drUser[0]["LastName"];
					int nUserName = Convert.ToInt32(drUser[0]["UserTableID"]);

					dsDistribution = new DataSet();
					daDistribution.Fill(dsDistribution, "Distribution");
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					dsRegionCenter = new DataSet();
					daRegionCenter.Fill(dsRegionCenter, "RegionCenter");

					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daBatch5EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch10EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch20EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daDistribution.UpdateCommand.Transaction = sqlTransaction;
					daRegionCenter.InsertCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;

					DataRow [] drBatchToProcess = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + strBatch + "'");
					int nNumberOf5EuroCards = 0, nNumberOf10EuroCards = 0, nNumberOf20EuroCards = 0;
					long nCurrentMinCards = 0, nCurrentMaxCards = 0, nSerialNumber = 0;
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
						drBatchToProcess[i]["UserTableID"] = cmbRegionCenterUser.SelectedValue;
						DataRow [] drDistribution = dsDistribution.Tables["Distribution"].Select("CardID = " + drBatchToProcess[i]["CardID"]);
						drDistribution[0]["StatusCardID"] = 3;
						DataRow drNewRegionCenterRecord = dsRegionCenter.Tables["RegionCenter"].NewRow();
						drNewRegionCenterRecord["CardID"] = drBatchToProcess[i]["CardID"];
						drNewRegionCenterRecord["SentToRegionCenterDate"] = LogIn.FormatedDate(2);
						drNewRegionCenterRecord["ReceivedFromRegionCenterDate"] = DBNull.Value;
						drNewRegionCenterRecord["SentToRegionCenterFile"] = szRTFSavedFile;
						drNewRegionCenterRecord["ReceivedFromRegionCenterFile"] = DBNull.Value;
						drNewRegionCenterRecord["SentUserID"] = cmbRegionCenterUser.SelectedValue;
						drNewRegionCenterRecord["ReceivedUserID"] = DBNull.Value;
						drNewRegionCenterRecord["StatusCardID"] = 1;
						dsRegionCenter.Tables["RegionCenter"].Rows.Add(drNewRegionCenterRecord);
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
					szTextToPrint = String.Format("Count of uploaded cards for user'{0}' on date {1}", nUserName, szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = String.Format("Count of 5 EURO cards : {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf5EuroCards, nNumberOf5EuroCards * 5, szBatch5Euro, sz5EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                    szTextToPrint = String.Format("Count of 10 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf10EuroCards, nNumberOf10EuroCards * 10, szBatch10Euro, sz10EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                    szTextToPrint = String.Format("Count of 20 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", nNumberOf20EuroCards, nNumberOf20EuroCards * 20, szBatch20Euro, sz20EuroSerial);
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

					daDistribution.Update(dsDistribution, "Distribution");
					dsDistribution.AcceptChanges();
					daRegionCenter.Update(dsRegionCenter, "RegionCenter");
					dsRegionCenter.AcceptChanges();
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
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsDistribution.RejectChanges();
					dsRegionCenter.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsDistribution.RejectChanges();
					dsRegionCenter.RejectChanges();
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
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Generate Numbers for Postal Offices') button at {0}", LogIn.FormatedDate(1));
			}
		}

		private void cmbRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nCheckForCombo != 0)
			{
				cmbRegionCenterUser.Enabled = true;
				dvCombo.RowFilter = "RegionID = " + cmbRegion.SelectedValue;
				cmbRegionCenterUser.DataSource = dvCombo;
			}
			else
			{
				cmbRegionCenterUser.Enabled = false;
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
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
					String szDirDistributionConfirm = "DistributionNumbersConfirm";
					if (Directory.Exists(szDirDistributionConfirm) == false)
					{
						Directory.CreateDirectory(szDirDistributionConfirm);
					}
					String szRTFSavedFile = String.Format("{0}\\DistributionNumbersConfirm_{1}.rtf", szDirDistributionConfirm, LogIn.FormatedDate(0));
					dsDistribution = new DataSet();
					daDistribution.Fill(dsDistribution, "Distribution");
					DataRow [] dr = dsDistribution.Tables["Distribution"].Select("SentUserID = " + LogIn.UserID + " AND statusCardID = 1");

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
					daDistribution.UpdateCommand.Transaction = sqlTransaction;

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
						DataRow [] drValue = dsDistribution.Tables["Distribution"].Select("CardId = " + drBatch5Euro[i]["CardID"]);
						drValue[0]["ReceivedFromDistDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromDistFile"] = szRTFSavedFile;
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
						DataRow [] drValue = dsDistribution.Tables["Distribution"].Select("CardId = " + drBatch10Euro[i]["CardID"]);
						drValue[0]["ReceivedFromDistDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromDistFile"] = szRTFSavedFile;
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
						DataRow [] drValue = dsDistribution.Tables["Distribution"].Select("CardId = " + drBatch20Euro[i]["CardID"]);
						drValue[0]["ReceivedFromDistDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromDistFile"] = szRTFSavedFile;
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
					szTextToPrint = String.Format("Insertion card confirmation on Distribution Database on date {0} for user '{1}' ", szCurrentDate, LogIn.UserID);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Bold);
                    szTextToPrint = String.Format("Count of 5 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch5Euro.Length, drBatch5Euro.Length * 5, listBox1.Text.ToString(), sz5EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);
                    szTextToPrint = String.Format("Count of 10 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch10Euro.Length, drBatch10Euro.Length * 10, listBox2.Text.ToString(), sz10EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

                    szTextToPrint = String.Format("Count of 20 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch20Euro.Length, drBatch20Euro.Length * 20, listBox3.Text.ToString(), sz20EuroSerial);
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

					daDistribution.Update(dsDistribution, "Distribution");
					dsDistribution.AcceptChanges();
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
					dsDistribution.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
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
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Confirm receive numbers') at {0}", LogIn.FormatedDate(1));
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
			cmdCardInformationInsert.CommandText = "Insert into Cardinformation (CardID, CardCode, CardValue, Batch, UserTableID, StatusCardID) VALUES (@CardID, @CardCode, @CardValue, @Batch, @UserTableID, @StatusCardID)";
			cmdCardInformationInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationInsert.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationInsert.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationInsert.Parameters.Add("@Batch", SqlDbType.NVarChar, 50, "Batch");
			cmdCardInformationInsert.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdCardInformationInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdCardInformationUpdate = LogIn.conn.CreateCommand();
			cmdCardInformationUpdate.CommandType = CommandType.Text;
			cmdCardInformationUpdate.CommandText = "update CardInformation SET CardCode = @CardCode, CardValue = @CardValue, Batch = @Batch, UserTableID = @UserTableID, StatusCardID = @StatusCardID WHERE CardID = @CardID";
			cmdCardInformationUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationUpdate.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationUpdate.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationUpdate.Parameters.Add("@Batch", SqlDbType.NVarChar, 50, "Batch");
			cmdCardInformationUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
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
			cmdCardInformationGroup.CommandText = "select Cast(Round(Received.cardvalue, 0) as int) as 'Card (Euro)', Received.cn as 'Received', Confirmed.cn as 'Confirmed' from (select cardvalue, count(*) as cn from Distribution RIGHT JOIN CardInformation ON Distribution.CardID = CardInformation.CardID where Distribution.StatusCardID = 1 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue ) as Received inner join (select cardvalue, count(*) as cn from Distribution RIGHT JOIN CardInformation ON Distribution.CardID = CardInformation.CardID where Distribution.StatusCardID = 2 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Confirmed on Received.cardvalue = Confirmed.cardvalue";
			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void LoadUserTable()
		{
			daUserTable = new SqlDataAdapter();

			SqlCommand cmdUserTable = LogIn.conn.CreateCommand();
			cmdUserTable.CommandType = CommandType.Text;
			cmdUserTable.CommandText = "select * from UserTable where roleID = 2";
			daUserTable.SelectCommand = cmdUserTable;
		}

		private void LoadDistribution()
		{
			daDistribution = new SqlDataAdapter();

			SqlCommand cmdDistributionSelect = LogIn.conn.CreateCommand();
			cmdDistributionSelect.CommandType = CommandType.Text;
			cmdDistributionSelect.CommandText = "select * from Distribution where SentUserID = " + LogIn.UserID + " AND statuscardid != 3";

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

			SqlCommand cmdDistributionUpdate = LogIn.conn.CreateCommand();
			cmdDistributionUpdate.CommandType = CommandType.Text;
			cmdDistributionUpdate.CommandText = "update Distribution SET SentToDistDate = @SentToDistDate, ReceivedFromDistDate = @ReceivedFromDistDate, SentToDistFile = @SentToDistFile, ReceivedFromDistFile = @ReceivedFromDistFile, SentUserID = @SentUserID, ReceivedUserID = @ReceivedUserID, StatusCardID = @StatusCardID WHERE CardID = @CardID";
			cmdDistributionUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdDistributionUpdate.Parameters.Add("@SentToDistDate", SqlDbType.DateTime, 8, "SentToDistDate");
			cmdDistributionUpdate.Parameters.Add("@ReceivedFromDistDate", SqlDbType.DateTime, 8, "ReceivedFromDistDate");
			cmdDistributionUpdate.Parameters.Add("@SentToDistFile", SqlDbType.NVarChar, 500, "SentToDistFile");
			cmdDistributionUpdate.Parameters.Add("@ReceivedFromDistFile", SqlDbType.NVarChar, 500, "ReceivedFromDistFile");
			cmdDistributionUpdate.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdDistributionUpdate.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdDistributionUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdDistributionUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daDistribution.SelectCommand = cmdDistributionSelect;
			daDistribution.InsertCommand = cmdDistributionInsert;
			daDistribution.UpdateCommand = cmdDistributionUpdate;
		}

		private void LoadRegion()
		{
			daRegion = new SqlDataAdapter();
			SqlCommand cmdRegion = LogIn.conn.CreateCommand();
			cmdRegion.CommandType = CommandType.Text;
			cmdRegion.CommandText = "select * from Region";
			daRegion.SelectCommand = cmdRegion;
		}

		private void LoadRegionCenter()
		{
			daRegionCenter = new SqlDataAdapter();

			SqlCommand cmdRegionCenterSelect = LogIn.conn.CreateCommand();
			cmdRegionCenterSelect.CommandType = CommandType.Text;
			cmdRegionCenterSelect.CommandText = "select * from RegionCenter where StatusCardID = 1";

			SqlCommand cmdRegionCenterInsert = LogIn.conn.CreateCommand();
			cmdRegionCenterInsert.CommandType = CommandType.Text;
			cmdRegionCenterInsert.CommandText = "Insert into RegionCenter (CardID, SentToRegionCenterDate, ReceivedFromRegionCenterDate, SentToRegionCenterFile, ReceivedFromRegionCenterFile, SentUserID, ReceivedUserID, StatusCardID) VALUES (@CardID, @SentToRegionCenterDate, @ReceivedFromRegionCenterDate, @SentToRegionCenterFile, @ReceivedFromRegionCenterFile, @SentUserID, @ReceivedUserID, @StatusCardID)";
			cmdRegionCenterInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdRegionCenterInsert.Parameters.Add("@SentToRegionCenterDate", SqlDbType.DateTime, 8, "SentToRegionCenterDate");
			cmdRegionCenterInsert.Parameters.Add("@ReceivedFromRegionCenterDate", SqlDbType.DateTime, 8, "ReceivedFromRegionCenterDate");
			cmdRegionCenterInsert.Parameters.Add("@SentToRegionCenterFile", SqlDbType.NVarChar, 500, "SentToRegionCenterFile");
			cmdRegionCenterInsert.Parameters.Add("@ReceivedFromRegionCenterFile", SqlDbType.NVarChar, 500, "ReceivedFromRegionCenterFile");
			cmdRegionCenterInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdRegionCenterInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdRegionCenterInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdRegionCenterInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daRegionCenter.SelectCommand = cmdRegionCenterSelect;
			daRegionCenter.InsertCommand = cmdRegionCenterInsert;
		}

		private void LoadBatch5EuCharged()
		{
			daBatch5EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuCharged()
		{
			daBatch10EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuCharged()
		{
			daBatch20EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch5EuConfirmed()
		{
			daBatch5EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuConfirmed()
		{
			daBatch10EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuConfirmed()
		{
			daBatch20EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, Distribution.StatusCardID as StatusCard FROM Distribution INNER JOIN CardInformation ON Distribution.CardID = CardInformation.CardID WHERE Distribution.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuConfirmed.SelectCommand = cmdBatchSelect;
		}
	}
}
