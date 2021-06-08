using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for RegionCenter.
	/// </summary>
	public class RegionCenter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblNumberOf20Cards;
		private System.Windows.Forms.TextBox txtNumberOf20EuroCards;
		private System.Windows.Forms.Label lblNumberOf10Cards;
		private System.Windows.Forms.TextBox txtNumberOf10EuroCards;
		private System.Windows.Forms.Label lblNumberOf5Cards;
		private System.Windows.Forms.TextBox txtNumberOf5EuroCards;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnReceiveConfirm;

		private SqlDataAdapter daRegionCenter;
		private SqlDataAdapter daUserTable;
		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private SqlDataAdapter daSupervisor;
		private SqlDataAdapter daSalesman;
		private SqlDataAdapter daPostalOffice;
		private SqlDataAdapter daEndOfDay;
		private SqlDataAdapter daBatch5EuCharged, daBatch10EuCharged, daBatch20EuCharged;
		private SqlDataAdapter daBatch5EuConfirmed, daBatch10EuConfirmed, daBatch20EuConfirmed;

		private DataSet dsRegionCenter;
		private DataSet dsUserTable;
		private DataSet dsCardInformation;
		private DataSet dsSupervisor;
		private DataSet dsPostalOffice;
		private DataSet dsSalesman;
		private DataSet dsBatch;
		private DataSet dsEndOfDay;
		private DataView dvDataGrid;
		private DataView dvCombo;
		private int nCheckForCombo;
		private System.Windows.Forms.ComboBox cmbCashOffice;
		private int nRegionID;
		private string szRegion;
		private const string error = "Error!";
		private const string ConfirmInsertNumbers	= "Are you sure you want to insert numbers into region center?";
		private const string ConfirmDownloadForReconiliation	= "Are you sure you want to do the reconciliation?";
		private const string ConfirmTitle	= "Confirm";
		private System.Windows.Forms.ComboBox cmbSupervisorUser;
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
		private System.Windows.Forms.Button btnInsertNumberForCashOffices;
		private System.Windows.Forms.Label lblCashOffice;
		private System.Windows.Forms.Label lblSupervisorUser;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnReconcile;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RegionCenter()
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
            this.cmbCashOffice = new System.Windows.Forms.ComboBox();
            this.lblNumberOf20Cards = new System.Windows.Forms.Label();
            this.txtNumberOf20EuroCards = new System.Windows.Forms.TextBox();
            this.lblNumberOf10Cards = new System.Windows.Forms.Label();
            this.txtNumberOf10EuroCards = new System.Windows.Forms.TextBox();
            this.cmbSupervisorUser = new System.Windows.Forms.ComboBox();
            this.lblNumberOf5Cards = new System.Windows.Forms.Label();
            this.txtNumberOf5EuroCards = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReceiveConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsertNumberForCashOffices = new System.Windows.Forms.Button();
            this.lblCashOffice = new System.Windows.Forms.Label();
            this.lblSupervisorUser = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBath5EuCharged = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReconcile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCashOffice
            // 
            this.cmbCashOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashOffice.Location = new System.Drawing.Point(136, 144);
            this.cmbCashOffice.Name = "cmbCashOffice";
            this.cmbCashOffice.Size = new System.Drawing.Size(120, 21);
            this.cmbCashOffice.TabIndex = 14;
            this.cmbCashOffice.SelectedIndexChanged += new System.EventHandler(this.cmbCashOffice_SelectedIndexChanged);
            // 
            // lblNumberOf20Cards
            // 
            this.lblNumberOf20Cards.Location = new System.Drawing.Point(8, 248);
            this.lblNumberOf20Cards.Name = "lblNumberOf20Cards";
            this.lblNumberOf20Cards.Size = new System.Drawing.Size(136, 23);
            this.lblNumberOf20Cards.TabIndex = 11;
            this.lblNumberOf20Cards.Text = "Number of 20 Euro Cards";
            this.lblNumberOf20Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberOf20EuroCards
            // 
            this.txtNumberOf20EuroCards.Location = new System.Drawing.Point(160, 248);
            this.txtNumberOf20EuroCards.Name = "txtNumberOf20EuroCards";
            this.txtNumberOf20EuroCards.Size = new System.Drawing.Size(80, 20);
            this.txtNumberOf20EuroCards.TabIndex = 12;
            this.txtNumberOf20EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf20EuroCards_TextChanged);
            // 
            // lblNumberOf10Cards
            // 
            this.lblNumberOf10Cards.Location = new System.Drawing.Point(8, 224);
            this.lblNumberOf10Cards.Name = "lblNumberOf10Cards";
            this.lblNumberOf10Cards.Size = new System.Drawing.Size(136, 23);
            this.lblNumberOf10Cards.TabIndex = 9;
            this.lblNumberOf10Cards.Text = "Number of 10 Euro Cards";
            this.lblNumberOf10Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberOf10EuroCards
            // 
            this.txtNumberOf10EuroCards.Location = new System.Drawing.Point(160, 224);
            this.txtNumberOf10EuroCards.Name = "txtNumberOf10EuroCards";
            this.txtNumberOf10EuroCards.Size = new System.Drawing.Size(80, 20);
            this.txtNumberOf10EuroCards.TabIndex = 10;
            this.txtNumberOf10EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf10EuroCards_TextChanged);
            // 
            // cmbSupervisorUser
            // 
            this.cmbSupervisorUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisorUser.Location = new System.Drawing.Point(136, 168);
            this.cmbSupervisorUser.Name = "cmbSupervisorUser";
            this.cmbSupervisorUser.Size = new System.Drawing.Size(120, 21);
            this.cmbSupervisorUser.TabIndex = 0;
            // 
            // lblNumberOf5Cards
            // 
            this.lblNumberOf5Cards.Location = new System.Drawing.Point(16, 200);
            this.lblNumberOf5Cards.Name = "lblNumberOf5Cards";
            this.lblNumberOf5Cards.Size = new System.Drawing.Size(128, 23);
            this.lblNumberOf5Cards.TabIndex = 5;
            this.lblNumberOf5Cards.Text = "Number of 5 Euro Cards";
            this.lblNumberOf5Cards.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumberOf5EuroCards
            // 
            this.txtNumberOf5EuroCards.Location = new System.Drawing.Point(160, 200);
            this.txtNumberOf5EuroCards.Name = "txtNumberOf5EuroCards";
            this.txtNumberOf5EuroCards.Size = new System.Drawing.Size(80, 20);
            this.txtNumberOf5EuroCards.TabIndex = 6;
            this.txtNumberOf5EuroCards.TextChanged += new System.EventHandler(this.txtNumberOf5EuroCards_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 536);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(224, 496);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 24);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReceiveConfirm
            // 
            this.btnReceiveConfirm.Location = new System.Drawing.Point(24, 152);
            this.btnReceiveConfirm.Name = "btnReceiveConfirm";
            this.btnReceiveConfirm.Size = new System.Drawing.Size(144, 24);
            this.btnReceiveConfirm.TabIndex = 20;
            this.btnReceiveConfirm.Text = "Confirm receive numbers ";
            this.btnReceiveConfirm.Click += new System.EventHandler(this.btnReceiveConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(24, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 432);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
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
            this.DataGrid.Location = new System.Drawing.Point(3, 333);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.Size = new System.Drawing.Size(474, 96);
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
            this.groupBox3.Controls.Add(this.btnInsertNumberForCashOffices);
            this.groupBox3.Controls.Add(this.lblNumberOf5Cards);
            this.groupBox3.Controls.Add(this.txtNumberOf5EuroCards);
            this.groupBox3.Controls.Add(this.lblNumberOf10Cards);
            this.groupBox3.Controls.Add(this.txtNumberOf10EuroCards);
            this.groupBox3.Controls.Add(this.txtNumberOf20EuroCards);
            this.groupBox3.Controls.Add(this.lblNumberOf20Cards);
            this.groupBox3.Controls.Add(this.cmbSupervisorUser);
            this.groupBox3.Controls.Add(this.cmbCashOffice);
            this.groupBox3.Controls.Add(this.lblCashOffice);
            this.groupBox3.Controls.Add(this.lblSupervisorUser);
            this.groupBox3.Location = new System.Drawing.Point(200, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 312);
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
            this.listBox6.SelectedIndexChanged += new System.EventHandler(this.listBox6_SelectedIndexChanged);
            // 
            // listBox5
            // 
            this.listBox5.Location = new System.Drawing.Point(112, 32);
            this.listBox5.Name = "listBox5";
            this.listBox5.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox5.Size = new System.Drawing.Size(40, 95);
            this.listBox5.TabIndex = 4;
            this.listBox5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // listBox4
            // 
            this.listBox4.Location = new System.Drawing.Point(56, 32);
            this.listBox4.Name = "listBox4";
            this.listBox4.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox4.Size = new System.Drawing.Size(40, 95);
            this.listBox4.TabIndex = 3;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
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
            // btnInsertNumberForCashOffices
            // 
            this.btnInsertNumberForCashOffices.Location = new System.Drawing.Point(40, 280);
            this.btnInsertNumberForCashOffices.Name = "btnInsertNumberForCashOffices";
            this.btnInsertNumberForCashOffices.Size = new System.Drawing.Size(192, 24);
            this.btnInsertNumberForCashOffices.TabIndex = 10;
            this.btnInsertNumberForCashOffices.Text = "Insert Numbers for Cash Offices";
            this.btnInsertNumberForCashOffices.Click += new System.EventHandler(this.btnInsertNumberForCashOffices_Click);
            // 
            // lblCashOffice
            // 
            this.lblCashOffice.Location = new System.Drawing.Point(40, 144);
            this.lblCashOffice.Name = "lblCashOffice";
            this.lblCashOffice.Size = new System.Drawing.Size(80, 16);
            this.lblCashOffice.TabIndex = 6;
            this.lblCashOffice.Text = "Cash Office";
            this.lblCashOffice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSupervisorUser
            // 
            this.lblSupervisorUser.Location = new System.Drawing.Point(16, 168);
            this.lblSupervisorUser.Name = "lblSupervisorUser";
            this.lblSupervisorUser.Size = new System.Drawing.Size(104, 23);
            this.lblSupervisorUser.TabIndex = 8;
            this.lblSupervisorUser.Text = "Supervisor";
            this.lblSupervisorUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox2.Size = new System.Drawing.Size(184, 200);
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnReconcile);
            this.panel1.Location = new System.Drawing.Point(24, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 528);
            this.panel1.TabIndex = 24;
            // 
            // btnReconcile
            // 
            this.btnReconcile.Location = new System.Drawing.Point(224, 456);
            this.btnReconcile.Name = "btnReconcile";
            this.btnReconcile.Size = new System.Drawing.Size(112, 24);
            this.btnReconcile.TabIndex = 21;
            this.btnReconcile.Text = "Reconcile from file";
            this.btnReconcile.Click += new System.EventHandler(this.btnReconcile_Click);
            // 
            // RegionCenter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(576, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(520, 600);
            this.Name = "RegionCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Region Center";
            this.Load += new System.EventHandler(this.RegionCenter_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void RegionCenter_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered the Region Center form at {0}", LogIn.FormatedDate(1));

			nCheckForCombo = 0;
			SqlConnection cn = LogIn.conn;
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cn.Open();
			cmd.CommandText = "select regionid from usertable where usertableid = " + LogIn.UserID;
			nRegionID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
			cmd.CommandText = "select regionDescription from region where regionid = " + nRegionID;
			szRegion = cmd.ExecuteScalar().ToString();
			cn.Close();

			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");
			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
			LoadUserTable();
			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");

			LoadRegionCenter();
			LoadSupervisor();
			LoadSalesman();
			LoadPostalOffice();

			dvCombo = new DataView(dsUserTable.Tables["UserTable"]);
			dsPostalOffice = new DataSet();
			daPostalOffice.Fill(dsPostalOffice, "PostalOffice");

			cmbCashOffice.DataSource = dsPostalOffice.Tables["PostalOffice"];
			cmbCashOffice.DisplayMember = "PostalDesc";
			cmbCashOffice.ValueMember = "PostalID";
			cmbCashOffice.SelectedIndex = -1;

			cmbSupervisorUser.DataSource = dsUserTable.Tables["UserTable"];
			cmbSupervisorUser.DisplayMember = "UserName";
			cmbSupervisorUser.ValueMember = "UserTableID";
			cmbSupervisorUser.SelectedIndex = -1;

			dsRegionCenter = new DataSet();
			daRegionCenter.Fill(dsRegionCenter, "RegionCenter");
			dsSupervisor = new DataSet();
			daSupervisor.Fill(dsSupervisor, "Supervisor");
			dsSalesman = new DataSet();
			daSalesman.Fill(dsSalesman, "Salesman");
			LoadEndOfDay();
			dsEndOfDay = new DataSet();
			daEndOfDay.Fill(dsEndOfDay, "EndOfDay");

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
		

		private void btnInsertNumberForCashOffices_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Insert Numbers for Cash Offices' button at {0}", LogIn.FormatedDate(1));
			if (cmbSupervisorUser.Text == "")
			{
				MessageBox.Show("No Combo Box selected for Supervisor User", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No Combo Box selected for Supervisor User ('Supervisor') at {0}", LogIn.FormatedDate(1));
				return;
			}
			int nNumberOf5EuroCards = txtNumberOf5EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf5EuroCards.Text);
			int nNumberOf10EuroCards = txtNumberOf10EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf10EuroCards.Text);
			int nNumberOf20EuroCards = txtNumberOf20EuroCards.Text == "" ? 0: Convert.ToInt32(txtNumberOf20EuroCards.Text);
			if (nNumberOf5EuroCards == 0 && 
				nNumberOf10EuroCards == 0 && 
				nNumberOf20EuroCards == 0)
			{
				MessageBox.Show("All the edit box-es were empty or zeros!", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("All the edit box-es were empty or zeros ('Insert Numbers for Cash Offices') at {0}", LogIn.FormatedDate(1));
				return;
			}
			string ConfirmInsertNumberForCashOffices = String.Format("Are you sure you want to insert the following number for the Cash Office \n 5 Euro - {0} cards\n 10 Euro - {1} cards\n 20 Euro - {2} cards",nNumberOf5EuroCards, nNumberOf10EuroCards, nNumberOf20EuroCards);
			DialogResult result = MessageBox.Show(ConfirmInsertNumberForCashOffices, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Insert Numbers for Cash Offices') button at {0}", LogIn.FormatedDate(1));
				FileStream fs = null;
				BinaryWriter foutUpload = null;
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				String szUploadSavedFile = "";
				try
				{
					String szDirUploadRegionCenterToSupervisor = "UploadRegionCenterToSupervisor";
					if (Directory.Exists(szDirUploadRegionCenterToSupervisor) == false)
					{
						Directory.CreateDirectory(szDirUploadRegionCenterToSupervisor);
					}
					dsUserTable = new DataSet();
					daUserTable.Fill(dsUserTable, "UserTable");
					DataRow [] drUser = dsUserTable.Tables["UserTable"].Select("UserTableID = " + cmbSupervisorUser.SelectedValue);
					String szUserName = drUser[0]["FirstName"] + " " + drUser[0]["LastName"];
					int nUserName = Convert.ToInt32(drUser[0]["UserTableID"]);

					szUploadSavedFile = String.Format("{0}\\Upload_{1}_{2}.upl", szDirUploadRegionCenterToSupervisor, nUserName, LogIn.FormatedDate(0));

					fs = new FileStream(szUploadSavedFile, FileMode.Create);
					foutUpload = new BinaryWriter(fs, Encoding.Unicode);

					dsRegionCenter = new DataSet();
					daRegionCenter.Fill(dsRegionCenter, "RegionCenter");
					dsSupervisor = new DataSet();
					daSupervisor.Fill(dsSupervisor, "Supervisor");
					DataRow [] drCards = dsRegionCenter.Tables["RegionCenter"].Select("StatusCardID = 2 AND SentUserID = " + LogIn.UserID);

					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					int nAvailable5EuroCards = 0, nAvailable10EuroCards = 0, nAvailable20EuroCards = 0;
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daBatch5EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch10EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daBatch20EuConfirmed.SelectCommand.Transaction = sqlTransaction;
					daRegionCenter.UpdateCommand.Transaction = sqlTransaction;
					daSupervisor.InsertCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;

					ArrayList arr5Euro = new ArrayList();
					ArrayList arr10Euro = new ArrayList();
					ArrayList arr20Euro = new ArrayList();
					String sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					for (int i = 0; i < drCards.Length; i++)
					{
						DataRow [] drValue = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drCards[i]["CardID"]);
						if (drValue.Length == 0)
							continue;
						if (Convert.ToInt32(drValue[0]["CardValue"]) == 5)
						{
							arr5Euro.Add(drValue[0]["CardID"]);
							nAvailable5EuroCards++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 10)
						{
							arr10Euro.Add(drValue[0]["CardID"]);
							nAvailable10EuroCards++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 20)
						{
							arr20Euro.Add(drValue[0]["CardID"]);
							nAvailable20EuroCards++;
						}
					}

					String sz5EuroError = String.Format("There are {0} cards available valued 5 Euro!", nAvailable5EuroCards);
					String sz10EuroError = String.Format("There are only {0} cards available valued 10 Euro!", nAvailable10EuroCards);
					String sz20EuroError = String.Format("There are only {0} cards available valued 20 Euro!", nAvailable20EuroCards);
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
					String szDirRegionCenterToSupervisor = "RegionCenterToSupervisor";
					if (Directory.Exists(szDirRegionCenterToSupervisor) == false)
					{
						Directory.CreateDirectory(szDirRegionCenterToSupervisor);
					}

					String szRTFSavedFile = String.Format("{0}\\RegionCenterToSupervisor_{1}.rtf", szDirRegionCenterToSupervisor, LogIn.FormatedDate(0));
					FillFileWithRecords(foutUpload, arr5Euro, nNumberOf5EuroCards, szUploadSavedFile, ref sz5EuroSerial);
					FillFileWithRecords(foutUpload, arr10Euro, nNumberOf10EuroCards, szUploadSavedFile, ref sz10EuroSerial);
					FillFileWithRecords(foutUpload, arr20Euro, nNumberOf20EuroCards, szUploadSavedFile, ref sz20EuroSerial);
					if (sz5EuroSerial == "")
						sz5EuroSerial = "Number of 5 EURO cards: 0, TOTAL: 0 EURO";
					if (sz10EuroSerial == "")
                        sz10EuroSerial = "Number of 10 EURO cards: 0, TOTAL: 0 EURO";
					if (sz20EuroSerial == "")
                        sz20EuroSerial = "Number of 20 EURO cards: 0, TOTAL: 0 EURO";

					richTextBox1.Text = "";
					String szTextToPrint;
					DateTime CurrentTime = DateTime.Now;
					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					szTextToPrint = String.Format("Number of uploaded card for user: '{0}' on date {1}", nUserName, szCurrentDate);
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

					daRegionCenter.Update(dsRegionCenter, "RegionCenter");
					dsRegionCenter.AcceptChanges();
					daSupervisor.Update(dsSupervisor, "Supervisor");
					dsSupervisor.AcceptChanges();
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

					if (nNumberOf5EuroCards != 0)
					{
						dsBatch.Tables["Batch5EuConfirmed"].Clear();
						daBatch5EuConfirmed.Fill(dsBatch, "Batch5EuConfirmed");
						listBox4.DataSource = dsBatch.Tables["Batch5EuConfirmed"];
						listBox4.DisplayMember = "Batch";
						listBox4.ValueMember = "CardValue";
						listBox4.SelectedIndex = -1;
					}
					else if (nNumberOf10EuroCards != 0)
					{
						dsBatch.Tables["Batch10EuConfirmed"].Clear();
						daBatch10EuConfirmed.Fill(dsBatch, "Batch10EuConfirmed");
						listBox5.DataSource = dsBatch.Tables["Batch10EuConfirmed"];
						listBox5.DisplayMember = "Batch";
						listBox5.ValueMember = "CardValue";
						listBox5.SelectedIndex = -1;
					}
					else if (nNumberOf20EuroCards != 0)
					{
						dsBatch.Tables["Batch20EuConfirmed"].Clear();
						daBatch20EuConfirmed.Fill(dsBatch, "Batch20EuConfirmed");
						listBox6.DataSource = dsBatch.Tables["Batch20EuConfirmed"];
						listBox6.DisplayMember = "Batch";
						listBox6.ValueMember = "CardValue";
						listBox6.SelectedIndex = -1;
					}

					LogIn.foutLogFile.WriteLine("Transfer from Region Center to Cash Office, Number of 5 euro cards transfered: {0},  Number of 10 euro cards transfered: {1}, Number of 20 euro cards transfered: {2}, at time {3}", nNumberOf5EuroCards, nNumberOf10EuroCards, nNumberOf20EuroCards, LogIn.FormatedDate(1));
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsRegionCenter.RejectChanges();
					dsSupervisor.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Exception: No cards generated at {0}", LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSupervisor.RejectChanges();
					dsRegionCenter.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				finally
				{
					if (fs != null)
						fs.Close();
					if (foutUpload != null)
						foutUpload.Close();
					if (sqlConnection != null)
						sqlConnection.Close();
					FileInfo fin = new FileInfo(szUploadSavedFile);
					if (fin.Length == 0)
						fin.Delete();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Insert Numbers for Cash Offices') button at {0}", LogIn.FormatedDate(1));
			}
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
					String szDirRegionCenterConfirm = "RegionCenterNumbersConfirm";
					if (Directory.Exists(szDirRegionCenterConfirm) == false)
					{
						Directory.CreateDirectory(szDirRegionCenterConfirm);
					}
					String szRTFSavedFile = String.Format("{0}\\RegionCenterNumbersConfirm_{1}.rtf", szDirRegionCenterConfirm, LogIn.FormatedDate(0));
					dsRegionCenter = new DataSet();
					daRegionCenter.Fill(dsRegionCenter, "RegionCenter");
					DataRow [] dr = dsRegionCenter.Tables["RegionCenter"].Select("SentUserID = " + LogIn.UserID + " AND statusCardID = 1");
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
					daRegionCenter.UpdateCommand.Transaction = sqlTransaction;
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
						DataRow [] drValue = dsRegionCenter.Tables["RegionCenter"].Select("CardId = " + drBatch5Euro[i]["CardID"]);
						drValue[0]["ReceivedFromRegionCenterDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromRegionCenterFile"] = szRTFSavedFile;
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

						DataRow [] drValue = dsRegionCenter.Tables["RegionCenter"].Select("CardId = " + drBatch10Euro[i]["CardID"]);
						drValue[0]["ReceivedFromRegionCenterDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromRegionCenterFile"] = szRTFSavedFile;
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
						DataRow [] drValue = dsRegionCenter.Tables["RegionCenter"].Select("CardId = " + drBatch20Euro[i]["CardID"]);
						drValue[0]["ReceivedFromRegionCenterDate"] = LogIn.FormatedDate(2);
						drValue[0]["ReceivedUserID"] = LogIn.UserID;
						drValue[0]["StatusCardID"] = 2;
						drValue[0]["ReceivedFromRegionCenterFile"] = szRTFSavedFile;
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
					szTextToPrint = String.Format("Confirmation of card insertion on Region Cener {0} on date {1} by user '{2}' ", szRegion, szCurrentDate, LogIn.UserID);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = String.Format("Number of 5 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch5Euro.Length, drBatch5Euro.Length * 5, listBox1.Text.ToString(), sz5EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of 10 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch10Euro.Length, drBatch10Euro.Length * 10, listBox2.Text.ToString(), sz10EuroSerial);
					richTextBox1.AppendText(szTextToPrint + "\n\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 8.5f, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of 20 EURO cards: {0}, TOTAL: {1} EURO \tBatch: '{2}'\r{3}", drBatch20Euro.Length, drBatch20Euro.Length * 20, listBox3.Text.ToString(), sz20EuroSerial);
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

					daRegionCenter.Update(dsRegionCenter, "RegionCenter");
					dsRegionCenter.AcceptChanges();
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
					dsRegionCenter.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsRegionCenter.RejectChanges();
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

		private void btnReconcile_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Reconcile from file' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmDownloadForReconiliation, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Reconcile from file') at {0}", LogIn.FormatedDate(1));
				FileStream fs = null;
				BinaryReader foutReconcile = null;
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Filter = "rec files (*.rec)|*.rec" ;
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						String szErrorInReconciliation = "There was an error in reconciliation!";
						string szReconciledFile = openFileDialog.FileName;

						String szDirRegionCenterReconcile = "RegionCenterReconcile";
						if (Directory.Exists(szDirRegionCenterReconcile) == false)
						{
							Directory.CreateDirectory(szDirRegionCenterReconcile);
						}
						String szRTFSavedFile = String.Format("{0}\\RegionCenterReconcile_{1}.rtf", szDirRegionCenterReconcile, LogIn.FormatedDate(0));
						dsCardInformation = new DataSet();
						daCardInformation.Fill(dsCardInformation, "CardInformation");
						dsSupervisor = new DataSet();
						daSupervisor.Fill(dsSupervisor, "Supervisor");
						dsSalesman = new DataSet();
						daSalesman.Fill(dsSalesman, "Salesman");
						dsEndOfDay = new DataSet();
						daEndOfDay.Fill(dsEndOfDay, "EndOfDay");

						sqlConnection = LogIn.conn;
						sqlConnection.Open();
						sqlTransaction = sqlConnection.BeginTransaction();
						daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
						daCardInformation.UpdateCommand.Transaction = sqlTransaction;
						daSalesman.InsertCommand.Transaction = sqlTransaction;
						daSupervisor.UpdateCommand.Transaction = sqlTransaction;
						daEndOfDay.InsertCommand.Transaction = sqlTransaction;

						fs = new FileStream(szReconciledFile, FileMode.Open);
						if (fs.Length == 0)
							throw new Exception("The size of the file is 0 byte!");
						foutReconcile = new BinaryReader(fs);

						String szTextToPrint;
						szTextToPrint = String.Format("Cards reconsiliation for region {0}", szRegion);
						richTextBox1.Text = "";
						richTextBox1.AppendText(szTextToPrint +  
							"\n\n--------------------------------------------------------------------------\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
						DateTime CurrentTime = DateTime.Now;
						String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
						String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
						String szCurrentDateAndTime = LogIn.FormatedDate(1);

						string szTemp = "";
						int nStatusCard, nUserName;
						while (foutReconcile.PeekChar() != -1)
						{
							int nCardID = foutReconcile.ReadInt32();
							if (nCardID == 0)
							{
								szTemp = foutReconcile.ReadString();
								if (szTemp == "User")
								{
									nUserName =  foutReconcile.ReadInt32();
									int nCurrent5EuroCards = foutReconcile.ReadInt32();
									int nCurrent10EuroCards = foutReconcile.ReadInt32();
									int nCurrent20EuroCards = foutReconcile.ReadInt32();
									String szFormatedDate = LogIn.FormatedDate(2);
									szTextToPrint = String.Format("Number of reconciled cards for user '{0}' on date {1}", nUserName, szCurrentDate);
									richTextBox1.AppendText(szTextToPrint +  
										"\n\n--------------------------------------------------------------------------\n");
									richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
									richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
									szTextToPrint = String.Format("Number of reconciled 5 EURO cards for user: {0}, TOTAL: {1} EURO", nCurrent5EuroCards, nCurrent5EuroCards * 5);
									richTextBox1.AppendText(szTextToPrint + "\n");
									richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
									richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
									szTextToPrint = String.Format("Number of reconciled 10 EURO cards for user: {0}, TOTAL: {1} EURO", nCurrent10EuroCards, nCurrent10EuroCards * 10);
									richTextBox1.AppendText(szTextToPrint + "\n");
									richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
									richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
									szTextToPrint = String.Format("Number of reconciled 20 EURO cards for user: {0}, TOTAL: {1} EURO", nCurrent20EuroCards, nCurrent20EuroCards * 20);
									richTextBox1.AppendText(szTextToPrint + "\n");
									richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
									richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
									richTextBox1.AppendText("--------------------------------------------------------------------------\n");
									szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nCurrent5EuroCards * 5 + nCurrent10EuroCards * 10 + nCurrent20EuroCards * 20);
									richTextBox1.AppendText(szTextToPrint + "\n");
									richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
									richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
									richTextBox1.AppendText("--------------------------------------------------------------------------\n\n");
								}
								else if (szTemp == "EndOfDay")
								{
									DataRow drNewEndOfDayRecord = dsEndOfDay.Tables["EndOfDay"].NewRow();
									drNewEndOfDayRecord["UserTableID"] = foutReconcile.ReadInt32();
									string szStartDate = foutReconcile.ReadString();
									if (szStartDate == "")
										drNewEndOfDayRecord["StartDate"] = DBNull.Value;
									else
										drNewEndOfDayRecord["StartDate"] = szStartDate;
									drNewEndOfDayRecord["EndDate"] = foutReconcile.ReadString();
									drNewEndOfDayRecord["Total5EuroCards"] = foutReconcile.ReadInt32();
									drNewEndOfDayRecord["Total10EuroCards"] = foutReconcile.ReadInt32();
									drNewEndOfDayRecord["Total20EuroCards"] = foutReconcile.ReadInt32();
									drNewEndOfDayRecord["IsReconiled"] = foutReconcile.ReadInt32();
									DataRow [] drRepeat = dsEndOfDay.Tables["EndOfDay"].Select("UserTableID = " + drNewEndOfDayRecord["UserTableID"] + " AND EndDate = '" + drNewEndOfDayRecord["EndDate"] + "'");
									if (drRepeat.Length > 0)
										throw new Exception(szErrorInReconciliation);
									dsEndOfDay.Tables["EndOfDay"].Rows.Add(drNewEndOfDayRecord);								}
							}
							else
							{
								DataRow [] drSupervisor = dsSupervisor.Tables["Supervisor"].Select("CardID = " + nCardID);
								DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("CardID = " + nCardID);

								drSupervisor[0]["ReceivedFromSupervisorDate"] = foutReconcile.ReadString();
								drSupervisor[0]["ReceivedFromSupervisorFile"] = foutReconcile.ReadString();
								drSupervisor[0]["ReceivedUserID"] = foutReconcile.ReadInt32();
								drCardInformation[0]["UserTableID"] = foutReconcile.ReadInt32();
								nStatusCard = foutReconcile.ReadInt32();
								if (nStatusCard != 6)
									throw new Exception(szErrorInReconciliation);
								drCardInformation[0]["StatusCardID"] = 7;

								DataRow drNewSalesmanRecord = dsSalesman.Tables["Salesman"].NewRow();
								drNewSalesmanRecord["CardID"] = nCardID;
								drNewSalesmanRecord["SentToSalesmanDate"] = foutReconcile.ReadString();
								drNewSalesmanRecord["ReceivedFromSalesmanDate"] = foutReconcile.ReadString();
								drNewSalesmanRecord["SentToSalesmanFile"] = foutReconcile.ReadString();
								drNewSalesmanRecord["ReceivedFromSalesmanFile"] = foutReconcile.ReadString();
								drNewSalesmanRecord["SentUserID"] = foutReconcile.ReadInt32();
								drNewSalesmanRecord["ReceivedUserID"] = foutReconcile.ReadInt32();
								nStatusCard = foutReconcile.ReadInt32();
								if (nStatusCard != 6)
									throw new Exception(szErrorInReconciliation);
								drNewSalesmanRecord["StatusCardID"] = 7;
								drNewSalesmanRecord["SoldCardDate"] = foutReconcile.ReadString();
								drNewSalesmanRecord["SoldCardFile"] = foutReconcile.ReadString();
								drNewSalesmanRecord["EndOfDayDate"] = foutReconcile.ReadString();
								drNewSalesmanRecord["EndOfDayFile"] = foutReconcile.ReadString();
								drNewSalesmanRecord["ReconcileDate"] = foutReconcile.ReadString();
								drNewSalesmanRecord["ReconcileFile"] = foutReconcile.ReadString();
								drNewSalesmanRecord["FinishedDate"] = LogIn.FormatedDate(2);
								drNewSalesmanRecord["FinishedFile"] = szReconciledFile;
								dsSalesman.Tables["Salesman"].Rows.Add(drNewSalesmanRecord);
							}
						}
						szTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);
						richTextBox1.AppendText(szTextToPrint);
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);

						daCardInformation.Update(dsCardInformation, "CardInformation");
						dsCardInformation.AcceptChanges();
						daSalesman.Update(dsSalesman, "Salesman");
						dsSalesman.AcceptChanges();
						daSupervisor.Update(dsSupervisor, "Supervisor");
						dsSupervisor.AcceptChanges();
						daEndOfDay.Update(dsEndOfDay, "EndOfDay");
						dsEndOfDay.AcceptChanges();
						daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
						dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);

						richTextBox1.SaveFile(szRTFSavedFile);
						System.Diagnostics.Process print = new System.Diagnostics.Process(); 
						print.StartInfo.FileName = szRTFSavedFile;
						print.StartInfo.CreateNoWindow = true;
						print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
						print.StartInfo.Verb = "print";
						print.Start(); //Start the process
						print.Dispose();

						DataGrid.DataSource = dvDataGrid;
						sqlTransaction.Commit();
						sqlConnection = LogIn.conn;
					}
					else
					{
						LogIn.foutLogFile.WriteLine("Procedure 'Reconcile from file' was NOT successful, the user pressed 'Cancel' ('OpenFileDialog'), at time: {0}", LogIn.FormatedDate(1));
					}
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Download for reconciliation' was NOT successful the error was {0}, at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSalesman.RejectChanges();
					dsSupervisor.RejectChanges();
					dsEndOfDay.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Download for reconciliation' was NOT successful the error was {0}, at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsSalesman.RejectChanges();
					dsSupervisor.RejectChanges();
					dsEndOfDay.RejectChanges();
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
				}
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
		}

		private void cmbCashOffice_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nCheckForCombo == 0)
			{
				cmbSupervisorUser.Enabled = false;
			}
			else
			{
				cmbSupervisorUser.Enabled = true;
				dvCombo.RowFilter = "PostalID = " + cmbCashOffice.SelectedValue;
				cmbSupervisorUser.DataSource = dvCombo;
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

		private void listBox4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listBox4.ClearSelected();
		}

		private void listBox5_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listBox5.ClearSelected();
		}

		private void listBox6_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			listBox6.ClearSelected();
		}

		public void EmptyEditBoxes()
		{
			txtNumberOf5EuroCards.Text = "";
			txtNumberOf10EuroCards.Text = "";
			txtNumberOf20EuroCards.Text = "";
		}

		public void FillFileWithRecords(BinaryWriter foutUpload, ArrayList array, int nNumberOfCards, String szUploadSavedFile, ref String szTextToPrint)
		{
			String szFormatedDate = LogIn.FormatedDate(2);
			String szOldBatch = "", szNewBatch = "";
			int nNumberOfCurrentCards = 0;
			int nCardValue = 0;
			string szSerial = "";
			long nSerialNumber = 0, nMinSerialNumber = 0, nMaxSerialNumber = 0;
			for (int i = 0; i < nNumberOfCards; i++)
			{
				DataRow [] drRegionCenter = dsRegionCenter.Tables["RegionCenter"].Select("cardID = " + array[i]);
				drRegionCenter[0]["StatusCardID"] = 3;

				DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("cardID = " + array[i]);
				drCardInformation[0]["StatusCardID"] = 1;
				drCardInformation[0]["UserTableID"] = cmbSupervisorUser.SelectedValue;
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
					szTextToPrint += String.Format("Number of {0} EURO: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}\r", nCardValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardValue, szOldBatch, szSerial);
					nNumberOfCurrentCards = 0;
					szOldBatch = szNewBatch;
					nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
				}
				nNumberOfCurrentCards++;

				DataRow drNewSupervisorRecord = dsSupervisor.Tables["Supervisor"].NewRow();
				drNewSupervisorRecord["CardID"] = drRegionCenter[0]["CardID"];
				drNewSupervisorRecord["SentToSupervisorDate"] = LogIn.FormatedDate(2);
				drNewSupervisorRecord["ReceivedFromSupervisorDate"] = DBNull.Value;
				drNewSupervisorRecord["SentToSupervisorFile"] = szUploadSavedFile;
				drNewSupervisorRecord["ReceivedFromSupervisorFile"] = DBNull.Value;
				drNewSupervisorRecord["SentUserID"] = cmbSupervisorUser.SelectedValue;
				drNewSupervisorRecord["ReceivedUserID"] = DBNull.Value;
				drNewSupervisorRecord["StatusCardID"] = 1;
				dsSupervisor.Tables["Supervisor"].Rows.Add(drNewSupervisorRecord);

				foutUpload.Write((int) drRegionCenter[0]["CardID"]);
				foutUpload.Write((string) drCardInformation[0]["CardCode"]);
				foutUpload.Write((string) LogIn.FormatedDate(2));
				foutUpload.Write((string) szUploadSavedFile);
				foutUpload.Write((int) cmbSupervisorUser.SelectedValue);
				foutUpload.Write((string) drCardInformation[0]["CardValue"].ToString());
				foutUpload.Write((string) drCardInformation[0]["Batch"].ToString());
				foutUpload.Write((int) cmbSupervisorUser.SelectedValue);
				foutUpload.Write((string) drCardInformation[0]["CardSerialNumber"]);
			}
			if (nNumberOfCurrentCards != 0)
			{
				szSerial = String.Format("Serial: {0}-{1}", nMinSerialNumber, nMaxSerialNumber);
				szTextToPrint += String.Format("Number of cards of {0} EUROVE: {1}, TOTAL: {2} EURO \tBatch: '{3}'\r{4}", nCardValue, nNumberOfCurrentCards, nNumberOfCurrentCards * nCardValue, szOldBatch, szSerial);
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
			cmdCardInformationGroup.CommandText = "select Cast(Round(Received.cardvalue, 0) as int) as 'Card (Euro)', Received.cn as 'Received', Confirmed.cn as 'Confirmed' from (select cardvalue, count(*) as cn from RegionCenter RIGHT JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID where RegionCenter.StatusCardID = 1 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue ) as Received inner join (select cardvalue, count(*) as cn from RegionCenter RIGHT JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID where RegionCenter.StatusCardID = 2 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Confirmed on Received.cardvalue = Confirmed.cardvalue";
			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void LoadRegionCenter()
		{
			daRegionCenter = new SqlDataAdapter();

			SqlCommand cmdRegionCenterSelect = LogIn.conn.CreateCommand();
			cmdRegionCenterSelect.CommandType = CommandType.Text;
			cmdRegionCenterSelect.CommandText = "select * from RegionCenter where SentUserID = " + LogIn.UserID + " AND statuscardid != 3";
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

			SqlCommand cmdRegionCenterUpdate = LogIn.conn.CreateCommand();
			cmdRegionCenterUpdate.CommandType = CommandType.Text;
			cmdRegionCenterUpdate.CommandText = "update RegionCenter SET SentToRegionCenterDate = @SentToRegionCenterDate, ReceivedFromRegionCenterDate = @ReceivedFromRegionCenterDate, SentToRegionCenterFile = @SentToRegionCenterFile, ReceivedFromRegionCenterFile = @ReceivedFromRegionCenterFile, SentUserID = @SentUserID, ReceivedUserID = @ReceivedUserID, StatusCardID = @StatusCardID WHERE CardID = @CardID";
			cmdRegionCenterUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdRegionCenterUpdate.Parameters.Add("@SentToRegionCenterDate", SqlDbType.DateTime, 8, "SentToRegionCenterDate");
			cmdRegionCenterUpdate.Parameters.Add("@ReceivedFromRegionCenterDate", SqlDbType.DateTime, 8, "ReceivedFromRegionCenterDate");
			cmdRegionCenterUpdate.Parameters.Add("@SentToRegionCenterFile", SqlDbType.NVarChar, 500, "SentToRegionCenterFile");
			cmdRegionCenterUpdate.Parameters.Add("@ReceivedFromRegionCenterFile", SqlDbType.NVarChar, 500, "ReceivedFromRegionCenterFile");
			cmdRegionCenterUpdate.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdRegionCenterUpdate.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdRegionCenterUpdate.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdRegionCenterUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daRegionCenter.SelectCommand = cmdRegionCenterSelect;
			daRegionCenter.InsertCommand = cmdRegionCenterInsert;
			daRegionCenter.UpdateCommand = cmdRegionCenterUpdate;
		}

		private void LoadSupervisor()
		{
			daSupervisor = new SqlDataAdapter();

			SqlCommand cmdSupervisorSelect = LogIn.conn.CreateCommand();
			cmdSupervisorSelect.CommandType = CommandType.Text;
			cmdSupervisorSelect.CommandText = "select * from Supervisor where StatusCardID = 1 or StatusCardID = 3";

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
			cmdSalesmanInsert.CommandText = "Insert into Salesman (CardID, SentToSalesmanDate, ReceivedFromSalesmanDate, SentToSalesmanFile, ReceivedFromSalesmanFile, SentUserID, ReceivedUserID, StatusCardID, SoldCardDate, SoldCardFile, EndOfDayDate, EndOfDayFile, ReconcileDate, ReconcileFile, FinishedDate, FinishedFile) VALUES (@CardID, @SentToSalesmanDate, @ReceivedFromSalesmanDate, @SentToSalesmanFile, @ReceivedFromSalesmanFile, @SentUserID, @ReceivedUserID, @StatusCardID, @SoldCardDate, @SoldCardFile, @EndOfDayDate, @EndOfDayFile, @ReconcileDate, @ReconcileFile, @FinishedDate, @FinishedFile)";
			cmdSalesmanInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdSalesmanInsert.Parameters.Add("@SentToSalesmanDate", SqlDbType.DateTime, 8, "SentToSalesmanDate");
			cmdSalesmanInsert.Parameters.Add("@ReceivedFromSalesmanDate", SqlDbType.DateTime, 8, "ReceivedFromSalesmanDate");
			cmdSalesmanInsert.Parameters.Add("@SentToSalesmanFile", SqlDbType.NVarChar, 500, "SentToSalesmanFile");
			cmdSalesmanInsert.Parameters.Add("@ReceivedFromSalesmanFile", SqlDbType.NVarChar, 500, "ReceivedFromSalesmanFile");
			cmdSalesmanInsert.Parameters.Add("@SentUserID", SqlDbType.Int, 4, "SentUserID");
			cmdSalesmanInsert.Parameters.Add("@ReceivedUserID", SqlDbType.Int, 4, "ReceivedUserID");
			cmdSalesmanInsert.Parameters.Add("@StatusCardID", SqlDbType.Int, 4, "StatusCardID");
			cmdSalesmanInsert.Parameters.Add("@SoldCardDate", SqlDbType.DateTime, 8, "SoldCardDate");
			cmdSalesmanInsert.Parameters.Add("@SoldCardFile", SqlDbType.NVarChar, 500, "SoldCardFile");
			cmdSalesmanInsert.Parameters.Add("@EndOfDayDate", SqlDbType.DateTime, 8, "EndOfDayDate");
			cmdSalesmanInsert.Parameters.Add("@EndOfDayFile", SqlDbType.NVarChar, 500, "EndOfDayFile");
			cmdSalesmanInsert.Parameters.Add("@ReconcileDate", SqlDbType.DateTime, 8, "ReconcileDate");
			cmdSalesmanInsert.Parameters.Add("@ReconcileFile", SqlDbType.NVarChar, 500, "ReconcileFile");
			cmdSalesmanInsert.Parameters.Add("@FinishedDate", SqlDbType.DateTime, 8, "FinishedDate");
			cmdSalesmanInsert.Parameters.Add("@FinishedFile", SqlDbType.NVarChar, 500, "FinishedFile");

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

			daSalesman.SelectCommand = cmdSalesmanSelect;
			daSalesman.InsertCommand = cmdSalesmanInsert;
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

			SqlCommand cmdUserTable = LogIn.conn.CreateCommand();
			cmdUserTable.CommandType = CommandType.Text;
			cmdUserTable.CommandText = "select * from UserTable where roleID = 3 and regionid = " + nRegionID;
			daUserTable.SelectCommand = cmdUserTable;
		}

		private void LoadEndOfDay()
		{
			daEndOfDay = new SqlDataAdapter();

			SqlCommand cmdEndOfDaySelect = LogIn.conn.CreateCommand();
			cmdEndOfDaySelect.CommandType = CommandType.Text;
			cmdEndOfDaySelect.CommandText = "select * from EndOfDay";

			SqlCommand cmdEndOfDayInsert = LogIn.conn.CreateCommand();
			cmdEndOfDayInsert.CommandType = CommandType.Text;
			cmdEndOfDayInsert.CommandText = "Insert into EndOfDay (UserTableID, StartDate, EndDate, Total5EuroCards, Total10EuroCards, Total20EuroCards, IsReconiled) VALUES (@UserTableID, @StartDate, @EndDate, @Total5EuroCards, @Total10EuroCards, @Total20EuroCards, @IsReconiled)";
			cmdEndOfDayInsert.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdEndOfDayInsert.Parameters.Add("@StartDate", SqlDbType.DateTime, 8, "StartDate");
			cmdEndOfDayInsert.Parameters.Add("@EndDate", SqlDbType.DateTime, 8, "EndDate");
			cmdEndOfDayInsert.Parameters.Add("@Total5EuroCards", SqlDbType.Int, 4, "Total5EuroCards");
			cmdEndOfDayInsert.Parameters.Add("@Total10EuroCards", SqlDbType.Int, 4, "Total10EuroCards");
			cmdEndOfDayInsert.Parameters.Add("@Total20EuroCards", SqlDbType.Int, 4, "Total20EuroCards");
			cmdEndOfDayInsert.Parameters.Add("@IsReconiled", SqlDbType.Int, 4, "IsReconiled");
			cmdEndOfDayInsert.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;
			daEndOfDay.SelectCommand = cmdEndOfDaySelect;
			daEndOfDay.InsertCommand = cmdEndOfDayInsert;
		}

		private void LoadBatch5EuCharged()
		{
			daBatch5EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuCharged()
		{
			daBatch10EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuCharged()
		{
			daBatch20EuCharged = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 1 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuCharged.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch5EuConfirmed()
		{
			daBatch5EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 5 and UserTableID = " + LogIn.UserID;
			daBatch5EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch10EuConfirmed()
		{
			daBatch10EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 10 and UserTableID = " + LogIn.UserID;
			daBatch10EuConfirmed.SelectCommand = cmdBatchSelect;
		}

		private void LoadBatch20EuConfirmed()
		{
			daBatch20EuConfirmed = new SqlDataAdapter();
			SqlCommand cmdBatchSelect = LogIn.conn.CreateCommand();
			cmdBatchSelect.CommandType = CommandType.Text;
			cmdBatchSelect.CommandText = "Select distinct CardInformation.Batch as Batch, CardInformation.CardValue as CardValue, RegionCenter.StatusCardID as StatusCard FROM RegionCenter INNER JOIN CardInformation ON RegionCenter.CardID = CardInformation.CardID WHERE RegionCenter.StatusCardID = 2 and CardInformation.StatusCardID != 8 and cardvalue = 20 and UserTableID = " + LogIn.UserID;
			daBatch20EuConfirmed.SelectCommand = cmdBatchSelect;
		}
	}
}
