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
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Salesman.
	/// </summary>
	public class Salesman : System.Windows.Forms.Form
	{
		[DllImport("kernel32.dll")]
		private static extern int CreateFile(
			string lpFileName,
			uint dwDesiredAccess,
			int dwShareMode,
			int lpSecurityAttributes,
			uint dwCreationDisposition,
			int dwFlagsAndAttributes,
			int hTemplateFile );
		private const uint OPEN_EXISTING = 3; 
		private const uint GENERIC_READ = 0x80000000; 
		private const uint GENERIC_WRITE = 0x40000000; 


		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Button txt20Euro;
		private System.Windows.Forms.Button txt10Euro;
		private System.Windows.Forms.Button txt5Euro;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnEndOfDay;

		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private SqlDataAdapter daUserTable;
		private SqlDataAdapter daSalesman;
		private SqlDataAdapter daEndOfDay;

		private DataSet dsSalesman;
		private DataSet dsCardInformation;
		private DataSet dsUserTable;
		private DataSet dsEndOfDay;
		private DataView dvDataGrid;
		private int nCardValue;
		private System.Windows.Forms.Button btnReceiveConfirm;
		private const string ConfirmReceiveNumbers = "Are you sure you want to confirm received numbers?";
		private const string Confirm5Euro		= "Are you sure you want to generate a 5 euro card?";
        private const string Confirm10Euro      = "Are you sure you want to generate a 10 euro card?";
        private const string Confirm20Euro      = "Are you sure you want to generate a 20 euro card?";
		private const string ConfirmEndOfDay	= "Are you sure you want to do 'End of day'?";
		private const string ConfirmTitle	= "Confirm";
		private const string error				= "Error!";
		private const char cFieldSeparator = '|';
		private System.Windows.Forms.Panel panel1;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Salesman()
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
            this.DataGrid = new System.Windows.Forms.DataGrid();
            this.txt20Euro = new System.Windows.Forms.Button();
            this.txt10Euro = new System.Windows.Forms.Button();
            this.txt5Euro = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEndOfDay = new System.Windows.Forms.Button();
            this.btnReceiveConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.txt20Euro);
            this.groupBox1.Controls.Add(this.txt10Euro);
            this.groupBox1.Controls.Add(this.txt5Euro);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DataGrid
            // 
            this.DataGrid.AllowNavigation = false;
            this.DataGrid.AllowSorting = false;
            this.DataGrid.AlternatingBackColor = System.Drawing.Color.White;
            this.DataGrid.BackColor = System.Drawing.Color.White;
            this.DataGrid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataGrid.CaptionBackColor = System.Drawing.Color.Teal;
            this.DataGrid.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.DataGrid.CaptionForeColor = System.Drawing.Color.White;
            this.DataGrid.DataMember = "";
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGrid.FlatMode = true;
            this.DataGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DataGrid.ForeColor = System.Drawing.Color.Black;
            this.DataGrid.GridLineColor = System.Drawing.Color.Silver;
            this.DataGrid.HeaderBackColor = System.Drawing.Color.Black;
            this.DataGrid.HeaderFont = new System.Drawing.Font("Tahoma", 10F);
            this.DataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.DataGrid.LinkColor = System.Drawing.Color.Purple;
            this.DataGrid.Location = new System.Drawing.Point(3, 117);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsBackColor = System.Drawing.Color.Gray;
            this.DataGrid.ParentRowsForeColor = System.Drawing.Color.White;
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.SelectionBackColor = System.Drawing.Color.Maroon;
            this.DataGrid.SelectionForeColor = System.Drawing.Color.White;
            this.DataGrid.Size = new System.Drawing.Size(450, 144);
            this.DataGrid.TabIndex = 3;
            // 
            // txt20Euro
            // 
            this.txt20Euro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt20Euro.Location = new System.Drawing.Point(296, 32);
            this.txt20Euro.Name = "txt20Euro";
            this.txt20Euro.Size = new System.Drawing.Size(88, 40);
            this.txt20Euro.TabIndex = 2;
            this.txt20Euro.Text = "20 Euro";
            this.txt20Euro.Click += new System.EventHandler(this.txt20Euro_Click);
            // 
            // txt10Euro
            // 
            this.txt10Euro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt10Euro.Location = new System.Drawing.Point(176, 32);
            this.txt10Euro.Name = "txt10Euro";
            this.txt10Euro.Size = new System.Drawing.Size(88, 40);
            this.txt10Euro.TabIndex = 1;
            this.txt10Euro.Text = "10 Euro";
            this.txt10Euro.Click += new System.EventHandler(this.txt10Euro_Click);
            // 
            // txt5Euro
            // 
            this.txt5Euro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5Euro.Location = new System.Drawing.Point(56, 32);
            this.txt5Euro.Name = "txt5Euro";
            this.txt5Euro.Size = new System.Drawing.Size(88, 40);
            this.txt5Euro.TabIndex = 0;
            this.txt5Euro.Text = "5 Euro";
            this.txt5Euro.Click += new System.EventHandler(this.txt5Euro_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(40, 432);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(392, 64);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(144, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEndOfDay
            // 
            this.btnEndOfDay.BackColor = System.Drawing.SystemColors.Control;
            this.btnEndOfDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndOfDay.Location = new System.Drawing.Point(144, 344);
            this.btnEndOfDay.Name = "btnEndOfDay";
            this.btnEndOfDay.Size = new System.Drawing.Size(200, 24);
            this.btnEndOfDay.TabIndex = 2;
            this.btnEndOfDay.Text = "Close the till";
            this.btnEndOfDay.UseVisualStyleBackColor = false;
            this.btnEndOfDay.Click += new System.EventHandler(this.btnEndOfDay_Click);
            // 
            // btnReceiveConfirm
            // 
            this.btnReceiveConfirm.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnReceiveConfirm.Location = new System.Drawing.Point(144, 304);
            this.btnReceiveConfirm.Name = "btnReceiveConfirm";
            this.btnReceiveConfirm.Size = new System.Drawing.Size(200, 24);
            this.btnReceiveConfirm.TabIndex = 1;
            this.btnReceiveConfirm.Text = "Confirm received numbers";
            this.btnReceiveConfirm.Click += new System.EventHandler(this.btnReceiveConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnEndOfDay);
            this.panel1.Controls.Add(this.btnReceiveConfirm);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(24, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 448);
            this.panel1.TabIndex = 5;
            // 
            // Salesman
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(520, 480);
            this.Name = "Salesman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salesman";
            this.Load += new System.EventHandler(this.Salesman_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void Salesman_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User has entered the Salesman form at {0}", LogIn.FormatedDate(1));
			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");

			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");

			LoadSalesman();
			dsSalesman = new DataSet();
			daSalesman.Fill(dsSalesman, "Salesman");
			LoadEndOfDay();
			dsEndOfDay = new DataSet();
			daEndOfDay.Fill(dsEndOfDay, "EndOfDay");
			LoadUserTable();
			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");

			dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
			dvDataGrid.AllowNew = false;
			dvDataGrid.AllowEdit = false;
			DataGrid.DataSource = dvDataGrid;
		}

		private void LoadCardInformation()
		{
			daCardInformation = new SqlDataAdapter();

			SqlCommand cmdCardInformationSelect = LogIn.conn.CreateCommand();
			cmdCardInformationSelect.CommandType = CommandType.Text;
			cmdCardInformationSelect.CommandText = "select * from CardInformation where CardInformation.StatusCardID != 8";
			
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

			cmdCardInformationGroup.CommandText = "select Cast(Round(Received.cardvalue, 0) as int) as 'Kartela (Euro)', Received.cn as 'Pranuar', Confirmed.cn as 'Konfirmuar', Sold.cn as 'Shitur'  from (select cardvalue, count(*) as cn from Salesman RIGHT JOIN CardInformation ON Salesman.CardID = CardInformation.CardID where Salesman.StatusCardID = 1 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue ) as Received inner join (select cardvalue, count(*) as cn from Salesman RIGHT JOIN CardInformation ON Salesman.CardID = CardInformation.CardID where Salesman.StatusCardID = 2 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Confirmed on Received.cardvalue = Confirmed.cardvalue inner join (select cardvalue, count(*) as cn from Salesman RIGHT JOIN CardInformation ON Salesman.CardID = CardInformation.CardID where Salesman.StatusCardID = 4 AND SentUserID = " + LogIn.UserID + " AND CardInformation.StatusCardID != 8 group  by all cardvalue) as Sold on Received.cardvalue = Sold.cardvalue";

			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
		}

		private void btnEndOfDay_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Close the till' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmEndOfDay, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			
			if (result == DialogResult.OK)
			{
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
                LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Close the till') at {0}", LogIn.FormatedDate(1));
				try
				{
					richTextBox1.Text = "";
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					String szDirSalesmanEndOfDay = "SalesmanEndOfDay";
					if (Directory.Exists(szDirSalesmanEndOfDay) == false)
					{
						Directory.CreateDirectory(szDirSalesmanEndOfDay);
					}
					String szRTFSavedFile = String.Format("{0}\\SalesmanEndOfDay_{1}.rtf", szDirSalesmanEndOfDay, LogIn.FormatedDate(0));

					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentTimeMin = szCurrentTime + " 00:00:00";
					String szCurrentTimeMax = szCurrentTime + " 23:59:59";
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);

					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					dsSalesman = new DataSet();
					daSalesman.Fill(dsSalesman, "Salesman");
					dsEndOfDay = new DataSet();
					daEndOfDay.Fill(dsEndOfDay, "EndOfDay");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daEndOfDay.InsertCommand.Transaction = sqlTransaction;
					daSalesman.UpdateCommand.Transaction = sqlTransaction;
					daUserTable.UpdateCommand.Transaction = sqlTransaction;

					DataRow [] drSold = dsSalesman.Tables["Salesman"].Select("StatusCardID = 4 AND SentUserID = " + LogIn.UserID);

					int nSold5EuroCards = 0, nSold10EuroCards = 0, nSold20EuroCards = 0;
					ArrayList arr5Euro = new ArrayList();
					ArrayList arr10Euro = new ArrayList();
					ArrayList arr20Euro = new ArrayList();
					int nFirstRecord = drSold.Length == 0 ? 0: Convert.ToInt32(drSold[0]["CardID"].ToString());
					for (int i = 0; i < drSold.Length; i++)
					{
						DataRow [] drValue = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drSold[i]["CardID"]);
						if (Convert.ToInt32(drValue[0]["CardValue"]) == 5)
						{
							arr5Euro.Add(drValue[0]["CardID"]);
							nSold5EuroCards++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 10)
						{
							arr10Euro.Add(drValue[0]["CardID"]);
							nSold10EuroCards++;
						}
						else if (Convert.ToInt32(drValue[0]["CardValue"]) == 20)
						{
							arr20Euro.Add(drValue[0]["CardID"]);
							nSold20EuroCards++;
						}
					}

					for (int i = 0; i < drSold.Length; i++)
					{
						DataRow [] drValue = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drSold[i]["CardID"]);
						drValue[0]["StatusCardID"] = 5;
						drSold[i]["StatusCardID"] = 5;
						drSold[i]["EndOfDayDate"] = CurrentTime;
						drSold[i]["EndOfDayFile"] = szRTFSavedFile;
					}

					DataRow drNewEndOfDayRecord = dsEndOfDay.Tables["EndOfDay"].NewRow();
					drNewEndOfDayRecord["UserTableID"] = LogIn.UserID;
					drNewEndOfDayRecord["StartDate"] = drSold.Length == 0 ? DBNull.Value :drSold[0]["SoldCardDate"];
					drNewEndOfDayRecord["EndDate"] = LogIn.FormatedDate(2);
					drNewEndOfDayRecord["Total5EuroCards"] = nSold5EuroCards;
					drNewEndOfDayRecord["Total10EuroCards"] = nSold10EuroCards;
					drNewEndOfDayRecord["Total20EuroCards"] = nSold20EuroCards;
					drNewEndOfDayRecord["IsReconiled"] = 0;
					dsEndOfDay.Tables["EndOfDay"].Rows.Add(drNewEndOfDayRecord);
					dsUserTable.Tables["UserTable"].Rows[0]["LastEndOfDayDate"] = LogIn.FormatedDate(2);

					String szTextToPrint;
					szTextToPrint = String.Format("Sumary of sales from user: '{0}' on date: {1}", LogIn.UserID, szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = String.Format("Number of sold 5 EURO cards: {0}, TOTAL: {1} EURO", nSold5EuroCards, nSold5EuroCards * 5);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of sold 10 EURO cards: {0}, TOTAL: {1} EURO", nSold10EuroCards, nSold10EuroCards * 10);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of sold 20 EURO cards: {0}, TOTAL: {1} EURO", nSold20EuroCards, nSold20EuroCards * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);
					
					richTextBox1.AppendText("---------------------------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          \t\tTOTAL:         {0} EURO", nSold5EuroCards * 5 + nSold10EuroCards * 10 + nSold20EuroCards * 20);
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

					daSalesman.Update(dsSalesman, "Salesman");
					dsSalesman.AcceptChanges();
					daEndOfDay.Update(dsEndOfDay, "EndOfDay");
					dsEndOfDay.AcceptChanges();
					daUserTable.Update(dsUserTable, "UserTable");
					dsUserTable.AcceptChanges();
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();

					sqlTransaction.Commit();
					LogIn.foutLogFile.WriteLine("Procedure 'Close the till' was successful at {0}", LogIn.FormatedDate(1));
					LogIn.foutLogFile.Close();
					Application.Exit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error in 'Close the till' procedure due to SQL Exception {0}, the error was {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsEndOfDay.RejectChanges();
					dsSalesman.RejectChanges();
					dsUserTable.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error in 'Close the till' procedure, time {0}", LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					dsEndOfDay.RejectChanges();
					dsSalesman.RejectChanges();
					dsUserTable.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Mbyllja e arkes') at {0}", LogIn.FormatedDate(1));
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
					String szDirSalesmanConfirm = "SalesmanNumbersConfirm";
					if (Directory.Exists(szDirSalesmanConfirm) == false)
					{
						Directory.CreateDirectory(szDirSalesmanConfirm);
					}
					String szRTFSavedFile = String.Format("{0}\\SalesmanNumbersConfirm_{1}.rtf", szDirSalesmanConfirm, LogIn.FormatedDate(0));
					dsSalesman = new DataSet();
					daSalesman.Fill(dsSalesman, "Salesman");
					DataRow [] drSalesman = dsSalesman.Tables["Salesman"].Select("SentUserID = " + LogIn.UserID + " AND statusCardID = 1");
					int nCard5Euro = 0, nCard10Euro = 0, nCard20Euro = 0;
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daSalesman.UpdateCommand.Transaction = sqlTransaction;
					
					string sz5EuroSerial = "", sz10EuroSerial = "", sz20EuroSerial = "";
					String szOldBatch = "", szNewBatch = "";
					long nSerialNumber = 0, nMinSerialNumber = 0, nMaxSerialNumber = 0;
					int nNumberOfCurrentCards = 0;
					int nCardOldValue = 0, nCardNewValue = 0;
					string szSerial = "";
					int nCurrentRecord = 0;

					for (int i = 0; i < drSalesman.Length; i++)
					{
						DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drSalesman[i]["CardID"]);
						if (drCardInformation.Length == 0)
							continue;
						nCardNewValue = Convert.ToInt32(drCardInformation[0]["CardValue"]);
						szNewBatch = drCardInformation[0]["Batch"].ToString();
						nSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
						if (i == 0)
						{
							nCardOldValue = nCardNewValue;
							szOldBatch = szNewBatch;
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
						}
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
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
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
							nMinSerialNumber = nMaxSerialNumber = Convert.ToInt64(drCardInformation[0]["CardSerialNumber"]);
						}
						if (nMinSerialNumber > nSerialNumber)
							nMinSerialNumber = nSerialNumber;
						if (nMaxSerialNumber < nSerialNumber)
							nMaxSerialNumber = nSerialNumber;
						nNumberOfCurrentCards++;

						if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 5)
							nCard5Euro++;
						else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 10)
							nCard10Euro++;
						else if (Convert.ToInt32(drCardInformation[0]["CardValue"]) == 20)
							nCard20Euro++;
						drSalesman[i]["ReceivedFromSalesmanDate"] = LogIn.FormatedDate(2);
						drSalesman[i]["ReceivedUserID"] = LogIn.UserID;
						drSalesman[i]["StatusCardID"] = 2;
						drSalesman[i]["ReceivedFromSalesmanFile"] = szRTFSavedFile;
						drCardInformation[0]["StatusCardID"] = 2;
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

					richTextBox1.Text = "";
					String szTextToPrint;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					szTextToPrint = String.Format("Confirmation of card insertion for user: '{0}' on date: {1} ", LogIn.UserID, szCurrentDate);
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
					daSalesman.Update(dsSalesman, "Salesman");
					dsSalesman.AcceptChanges();

					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsSalesman.RejectChanges();
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsSalesman.RejectChanges();
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
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Konfirmo numrat e pranuar') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void LoadSalesman()
		{
			daSalesman = new SqlDataAdapter();

			SqlCommand cmdSalesmanSelect = LogIn.conn.CreateCommand();
			cmdSalesmanSelect.CommandType = CommandType.Text;
			cmdSalesmanSelect.CommandText = "select * from Salesman where SentUserID = " + LogIn.UserID + " AND (statuscardid = 1 or statuscardid = 2 or statuscardid = 4)";

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

		private void LoadUserTable()
		{
			daUserTable = new SqlDataAdapter();

			SqlCommand cmdUserSelect = LogIn.conn.CreateCommand();
			cmdUserSelect.CommandType = CommandType.Text;
			cmdUserSelect.CommandText = "select * from UserTable where UserTableID = " + LogIn.UserID;

			SqlCommand cmdUserUpdate = LogIn.conn.CreateCommand();
			cmdUserUpdate.CommandType = CommandType.Text;
			cmdUserUpdate.CommandText = "update UserTable SET LastEndOfDayDate = @LastEndOfDayDate WHERE UserTableID = @UserTableID";
			cmdUserUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserUpdate.Parameters.Add("@LastEndOfDayDate", SqlDbType.DateTime, 8, "LastEndOfDayDate");
			cmdUserUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daUserTable.SelectCommand = cmdUserSelect;
			daUserTable.UpdateCommand = cmdUserUpdate;
		}

		private void txt5Euro_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed '5 Euro' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(Confirm5Euro, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				nCardValue = 5;
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('5 Euro') at {0}", LogIn.FormatedDate(1));
				ProcessCard(nCardValue);				
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('5 Euro') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void txt10Euro_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed '10 Euro' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(Confirm10Euro, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('10 Euro') at {0}", LogIn.FormatedDate(1));
				nCardValue = 10;
				ProcessCard(nCardValue);
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('10 Euro') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void txt20Euro_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed '20 Euro' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(Confirm20Euro, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('20 Euro') at {0}", LogIn.FormatedDate(1));
				nCardValue = 20;
				ProcessCard(nCardValue);
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('20 Euro') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void ProcessCard(int nCardValue)
		{
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			try
			{
				richTextBox1.Text = "";
				UnicodeEncoding unicode = new UnicodeEncoding();
				ASCIIEncoding textConverter = new ASCIIEncoding();

				RegistryKey szRegistryKey = Registry.CurrentUser.OpenSubKey(LogIn.szRegKey, true);
				if (szRegistryKey == null) 
				{
					szRegistryKey = Registry.CurrentUser.CreateSubKey(LogIn.szRegKey);
				}

				RijndaelManaged RijndaelAlg = new RijndaelManaged();
				byte [] key = new byte[32];
				byte [] IV = new byte[16];
				byte [] key1;
				byte [] IV1;
				if (szRegistryKey.GetValue("Key") == null )
				{
					szRegistryKey.SetValue("Key",  textConverter.GetString(RijndaelAlg.Key));
				}
				if (szRegistryKey.GetValue("IV") == null )
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

				dsCardInformation = new DataSet();
				daCardInformation.Fill(dsCardInformation, "CardInformation");
				dsSalesman = new DataSet();
				daSalesman.Fill(dsSalesman, "Salesman");

				sqlConnection = LogIn.conn;
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction();
				daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
				daCardInformation.UpdateCommand.Transaction = sqlTransaction;
				daSalesman.UpdateCommand.Transaction = sqlTransaction;

				DataRow [] drSalesman = dsSalesman.Tables["Salesman"].Select("StatusCardID = 2 AND SentUserID = " + LogIn.UserID.ToString());

				ArrayList arr = new ArrayList();
				int nCardID = 0;
				for (int i = 0; i < drSalesman.Length; i++)
				{
					DataRow [] drCardID = dsCardInformation.Tables["CardInformation"].Select("CardID = " + drSalesman[i]["CardID"]);
					if (drCardID.Length == 0)
						continue;
					if (Convert.ToInt32(drCardID[0]["CardValue"]) == nCardValue)
					{
						nCardID = Convert.ToInt32(drCardID[0]["CardID"]);
						break;
					}
				}

				String szNoCards = "";
				if (nCardID == 0)
				{
					szNoCards = String.Format("There is no cards of {0} euro!!", nCardValue);
					throw new Exception(szNoCards);
				}
				
				DataRow [] drValue = dsCardInformation.Tables["CardInformation"].Select("CardID = " + nCardID);
				drValue[0]["StatusCardID"] = 4;
				long nSerial = Convert.ToInt64(drValue[0]["CardSerialNumber"]);
				String szSerialNumber = drValue[0]["CardSerialNumber"].ToString();
				string szBatch = drValue[0]["Batch"].ToString();

				String szSerialCode = drValue[0]["CardCode"].ToString();
				ICryptoTransform decryptor = RijndaelAlg.CreateDecryptor(key, IV);
				byte [] byteSerialCode = unicode.GetBytes(szSerialCode);

				MemoryStream msDecrypt = new MemoryStream(byteSerialCode);
				CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
				byte [] byteDecryptedSerialCode = new byte[byteSerialCode.Length];

				csDecrypt.Read(byteDecryptedSerialCode, 0, byteDecryptedSerialCode.Length);
				String szDecryptedCode = textConverter.GetString(byteDecryptedSerialCode);

				String szSplitedDecryptedCode = "";
				while (szDecryptedCode.Length > 0)
				{
					if (szDecryptedCode.Length - 4 > 0)
					{
						szSplitedDecryptedCode += szDecryptedCode.Substring(0, 4) + " ";
						szDecryptedCode = szDecryptedCode.Substring(4,szDecryptedCode.Length - 4);

					}
					else
					{
						szSplitedDecryptedCode += szDecryptedCode.Substring(0, szDecryptedCode.Length) + " ";
						szDecryptedCode = "";
					}
				}

				// initilize printer
				String szTextToPrint = "";
				szTextToPrint += String.Format("Refill code: \n\n");
				// spacing 1
				szTextToPrint += "\x1b";
				szTextToPrint += "\x20";
				szTextToPrint += "\x01";
				// double letters
				szTextToPrint += "\x0e";
				szTextToPrint += String.Format("{0}\n\n", szSplitedDecryptedCode);
				// regular letters
				szTextToPrint += "\x14";
				// bold
				szTextToPrint += "\x1b";
				szTextToPrint += "\x45";
				szTextToPrint += String.Format("Profili: {0} EURO\n\n", nCardValue);
				// not bold
				szTextToPrint += "\x1b";
				szTextToPrint +=  "\x46";
				// spacing 0
				szTextToPrint += "\x1b";
				szTextToPrint += "\x20";
				szTextToPrint += "\x00";
				szTextToPrint += String.Format("Batch: '{0}'\n", szBatch);
				szTextToPrint += String.Format("Serial number: '{0}'\n", szSerialNumber);
				szTextToPrint += String.Format("Salesman: '{0}'\n", LogIn.UserID);
				// eject
				szTextToPrint += "\x1b";
				szTextToPrint += "\x0c";
				szTextToPrint += "\x04";

				int hdl = CreateFile("LPT1", GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);
				FileStream PrintedFile = new FileStream((IntPtr)hdl,
					FileAccess.ReadWrite);

				Byte[] Buff = new Byte[2048];
				Buff = System.Text.Encoding.ASCII.GetBytes(szTextToPrint);
				PrintedFile.Write(Buff,0,Buff.Length);
				PrintedFile.Close();

				// save into rtf file 
				String szRTFTextToPrint;
				String szCurrentDateAndTime = LogIn.FormatedDate(1);
				DateTime CurrentTime = DateTime.Now;
				szRTFTextToPrint = String.Format("Sold card: '{0}' from Salesman: '{1}'", nCardID, LogIn.UserID);
				richTextBox1.AppendText(szRTFTextToPrint + "\n\n");
				richTextBox1.SelectionStart = richTextBox1.Find(szRTFTextToPrint);
				richTextBox1.SelectionFont = new Font("Verdana", 9, FontStyle.Regular);

				szRTFTextToPrint = String.Format("Printed on: {0}",  szCurrentDateAndTime);
				richTextBox1.AppendText(szRTFTextToPrint);
				richTextBox1.SelectionStart = richTextBox1.Find(szRTFTextToPrint);
				richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
				
				String szDirSalesmanInvoices = "SalesmanInvoices";
				if (Directory.Exists(szDirSalesmanInvoices) == false)
				{
					Directory.CreateDirectory(szDirSalesmanInvoices);
				}
				String szRTFSavedFile = String.Format("{0}\\SalesmanInvoice_{1}.rtf", szDirSalesmanInvoices, LogIn.FormatedDate(0));

				richTextBox1.SaveFile(szRTFSavedFile);

				DataRow [] drSaledCard = dsSalesman.Tables["Salesman"].Select("CardID = " + nCardID);

				drSaledCard[0]["StatusCardID"] = 4;
				drSaledCard[0]["SoldCardDate"] = CurrentTime;
				drSaledCard[0]["SoldCardFile"] = szRTFSavedFile;
				daSalesman.Update(dsSalesman, "Salesman");
				dsSalesman.AcceptChanges();
				daCardInformation.Update(dsCardInformation, "CardInformation");
				dsCardInformation.AcceptChanges();
				daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
				dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
				DataGrid.DataSource = dvDataGrid;

				LogIn.foutLogFile.WriteLine("A {0} Euro card was generated at {1}", nCardValue, LogIn.FormatedDate(1));
				sqlTransaction.Commit();
			}
			catch (CryptographicException e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to cryptographic exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				dsSalesman.RejectChanges();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				sqlTransaction.Rollback();
			}
			catch (UnauthorizedAccessException e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to UnauthorizedAccessException exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				dsSalesman.RejectChanges();
				sqlTransaction.Rollback();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (SqlException sqlEx)
			{
				LogIn.foutLogFile.WriteLine("Error was generated due to SQL Exception {0}, the error was {1}", sqlEx.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				dsSalesman.RejectChanges();
				sqlTransaction.Rollback();
				MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				dsSalesman.RejectChanges();
				sqlTransaction.Rollback();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (sqlConnection != null)
					sqlConnection.Close();
			}
		}
	}
}
