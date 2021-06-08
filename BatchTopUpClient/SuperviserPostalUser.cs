using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Client.
	/// </summary>
	public class SuperviserPostalUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button txt5Euro;
		private System.Windows.Forms.Button txt10Euro;
		private System.Windows.Forms.Button txt20Euro;
		private System.Windows.Forms.Button btnEndOfDay;
		private System.Windows.Forms.Button btnUploadNumbers;
		private System.Windows.Forms.Button btnDownloadReconciliation;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.DataGrid DataGrid;
		private System.Windows.Forms.Button btnUploadUsers;
		private System.Windows.Forms.GroupBox grpResetPassword;
		private System.Windows.Forms.Button btnResetPassword;
		private System.Windows.Forms.ComboBox cmbResetPassword;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SuperviserPostalUser()
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
            this.btnEndOfDay = new System.Windows.Forms.Button();
            this.btnUploadNumbers = new System.Windows.Forms.Button();
            this.btnDownloadReconciliation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpResetPassword = new System.Windows.Forms.GroupBox();
            this.cmbResetPassword = new System.Windows.Forms.ComboBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnUploadUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpResetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGrid);
            this.groupBox1.Controls.Add(this.txt20Euro);
            this.groupBox1.Controls.Add(this.txt10Euro);
            this.groupBox1.Controls.Add(this.txt5Euro);
            this.groupBox1.Location = new System.Drawing.Point(76, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 224);
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
            this.DataGrid.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGrid.ForeColor = System.Drawing.Color.Black;
            this.DataGrid.GridLineColor = System.Drawing.Color.Silver;
            this.DataGrid.HeaderBackColor = System.Drawing.Color.Black;
            this.DataGrid.HeaderFont = new System.Drawing.Font("Tahoma", 10F);
            this.DataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.DataGrid.LinkColor = System.Drawing.Color.Purple;
            this.DataGrid.Location = new System.Drawing.Point(3, 93);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ParentRowsBackColor = System.Drawing.Color.Gray;
            this.DataGrid.ParentRowsForeColor = System.Drawing.Color.White;
            this.DataGrid.PreferredColumnWidth = 100;
            this.DataGrid.ReadOnly = true;
            this.DataGrid.SelectionBackColor = System.Drawing.Color.Maroon;
            this.DataGrid.SelectionForeColor = System.Drawing.Color.White;
            this.DataGrid.Size = new System.Drawing.Size(434, 128);
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
            // btnEndOfDay
            // 
            this.btnEndOfDay.BackColor = System.Drawing.SystemColors.Control;
            this.btnEndOfDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndOfDay.Location = new System.Drawing.Point(238, 256);
            this.btnEndOfDay.Name = "btnEndOfDay";
            this.btnEndOfDay.Size = new System.Drawing.Size(116, 32);
            this.btnEndOfDay.TabIndex = 1;
            this.btnEndOfDay.Text = "Close the till";
            this.btnEndOfDay.UseVisualStyleBackColor = false;
            this.btnEndOfDay.Click += new System.EventHandler(this.btnEndOfDay_Click);
            // 
            // btnUploadNumbers
            // 
            this.btnUploadNumbers.BackColor = System.Drawing.SystemColors.Control;
            this.btnUploadNumbers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadNumbers.Location = new System.Drawing.Point(16, 56);
            this.btnUploadNumbers.Name = "btnUploadNumbers";
            this.btnUploadNumbers.Size = new System.Drawing.Size(104, 48);
            this.btnUploadNumbers.TabIndex = 0;
            this.btnUploadNumbers.Text = "Upload serial numbers from file";
            this.btnUploadNumbers.UseVisualStyleBackColor = false;
            this.btnUploadNumbers.Click += new System.EventHandler(this.btnUploadNumbers_Click);
            // 
            // btnDownloadReconciliation
            // 
            this.btnDownloadReconciliation.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownloadReconciliation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadReconciliation.Location = new System.Drawing.Point(134, 56);
            this.btnDownloadReconciliation.Name = "btnDownloadReconciliation";
            this.btnDownloadReconciliation.Size = new System.Drawing.Size(100, 48);
            this.btnDownloadReconciliation.TabIndex = 1;
            this.btnDownloadReconciliation.Text = "Download for reconciliation";
            this.btnDownloadReconciliation.UseVisualStyleBackColor = false;
            this.btnDownloadReconciliation.Click += new System.EventHandler(this.btnDownloadReconciliation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpResetPassword);
            this.groupBox2.Controls.Add(this.btnUploadNumbers);
            this.groupBox2.Controls.Add(this.btnDownloadReconciliation);
            this.groupBox2.Controls.Add(this.btnUploadUsers);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CAREFUL WITH THESE BUTTONS";
            // 
            // grpResetPassword
            // 
            this.grpResetPassword.Controls.Add(this.cmbResetPassword);
            this.grpResetPassword.Controls.Add(this.btnResetPassword);
            this.grpResetPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResetPassword.Location = new System.Drawing.Point(368, 16);
            this.grpResetPassword.Name = "grpResetPassword";
            this.grpResetPassword.Size = new System.Drawing.Size(184, 120);
            this.grpResetPassword.TabIndex = 3;
            this.grpResetPassword.TabStop = false;
            this.grpResetPassword.Text = "Reset password";
            // 
            // cmbResetPassword
            // 
            this.cmbResetPassword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResetPassword.Location = new System.Drawing.Point(24, 72);
            this.cmbResetPassword.Name = "cmbResetPassword";
            this.cmbResetPassword.Size = new System.Drawing.Size(144, 21);
            this.cmbResetPassword.TabIndex = 1;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(48, 32);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(104, 23);
            this.btnResetPassword.TabIndex = 0;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnUploadUsers
            // 
            this.btnUploadUsers.BackColor = System.Drawing.SystemColors.Control;
            this.btnUploadUsers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadUsers.Location = new System.Drawing.Point(248, 56);
            this.btnUploadUsers.Name = "btnUploadUsers";
            this.btnUploadUsers.Size = new System.Drawing.Size(104, 48);
            this.btnUploadUsers.TabIndex = 2;
            this.btnUploadUsers.Text = "Upload users";
            this.btnUploadUsers.UseVisualStyleBackColor = false;
            this.btnUploadUsers.Click += new System.EventHandler(this.btnUploadUsers_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(238, 464);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(40, 512);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // SuperviserPostalUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(592, 566);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEndOfDay);
            this.MaximumSize = new System.Drawing.Size(640, 800);
            this.MinimumSize = new System.Drawing.Size(480, 600);
            this.Name = "SuperviserPostalUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superviser Postal User";
            this.Load += new System.EventHandler(this.SuperviserPostalUser_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpResetPassword.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private const char cFieldSeparator		= '|';
		private const char cLineSeparator		= '\n';
		private const string Confirm5Euro		= "Are you sure you want to generate a 5 euro card?";
        private const string Confirm10Euro      = "Are you sure you want to generate a 10 euro card?";
        private const string Confirm20Euro      = "Are you sure you want to generate a 20 euro card?";
		private const string ConfirmTitle		= "Confirm";
		private const string error				= "Error!";
		private const string ConfirmEndOfDay	= "Are you sure you want to do End of Day procedure?";
		private const string ConfirmUploadSerialNumbers			= "Are you sure you want to upload serial numbers?";
		private const string ConfirmDownloadForReconiliation	= "Are you sure you want to do reconsiliation?";
		private const String ConfirmUploadUser	= "Are you sure you want to do user insertion?";
		private const string ConfirmResetPassword = "Are you sure you want to reset the password?";

		private int nCardValue;
		private SqlDataAdapter daCardInformation;
		private SqlDataAdapter daCardInformationGroup;
		private DataSet dsCardInformation;
		private DataSet dsUserTable;
		private SqlDataAdapter daUserTable;
		private DataView dvDataGrid;

		private void SuperviserPostalUser_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User has been entered the Superviser Postal User form at {0}", LogIn.FormatedDate(1));
			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");

			LoadUserTable();
			dsUserTable = new DataSet();
			daUserTable.Fill(dsUserTable, "UserTable");

			cmbResetPassword.DataSource = dsUserTable.Tables["UserTable"];
			cmbResetPassword.DisplayMember = "UserName";
			cmbResetPassword.ValueMember = "UserTableID";

			LoadCardInformationGrouped();
			daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
			dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
			dvDataGrid.AllowNew = false;
			dvDataGrid.AllowEdit = false;
			DataGrid.DataSource = dvDataGrid;
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

				byte[] key;
				byte[] IV;

				if (szRegistryKey.GetValue("Key") == null )
				{
					szRegistryKey.SetValue("Key",  textConverter.GetString(RijndaelAlg.Key));
				}
				if (szRegistryKey.GetValue("IV") == null )
				{
					szRegistryKey.SetValue("IV",  textConverter.GetString(RijndaelAlg.IV));
				}

				key = textConverter.GetBytes(szRegistryKey.GetValue("Key").ToString());
				IV = textConverter.GetBytes(szRegistryKey.GetValue("IV").ToString());

				dsCardInformation = new DataSet();
				daCardInformation.Fill(dsCardInformation, "CardInformation");
				DataRow [] dr = dsCardInformation.Tables["CardInformation"].Select("StatusNr = 2 AND UserTableID = " + LogIn.UserID.ToString() + " AND CardValue = " + nCardValue.ToString());

				String szNoCards = "";
				if (dr.Length == 0)
				{
					szNoCards = String.Format("There are no {0} euro cards", nCardValue);
					throw new Exception(szNoCards);
				}
				
				String szSerialNumber = dr[0]["CardCode"].ToString();
				ICryptoTransform decryptor = RijndaelAlg.CreateDecryptor(key, IV);
				byte [] byteSerialNumber = unicode.GetBytes(szSerialNumber);

				MemoryStream msDecrypt = new MemoryStream(byteSerialNumber);
				CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
				byte [] byteDecryptedSerialNumber = new byte[byteSerialNumber.Length];

				csDecrypt.Read(byteDecryptedSerialNumber, 0, byteDecryptedSerialNumber.Length);
				String szDecryptedSerialNumber = textConverter.GetString(byteDecryptedSerialNumber);

				String szSplitedDecryptedSerialNumber = "";
				while (szDecryptedSerialNumber.Length > 0)
				{
					if (szDecryptedSerialNumber.Length - 4 > 0)
					{
						szSplitedDecryptedSerialNumber += szDecryptedSerialNumber.Substring(0, 4) + " ";
						szDecryptedSerialNumber = szDecryptedSerialNumber.Substring(4,szDecryptedSerialNumber.Length - 4);

					}
					else
					{
						szSplitedDecryptedSerialNumber += szDecryptedSerialNumber.Substring(0, szDecryptedSerialNumber.Length) + " ";
						szDecryptedSerialNumber = "";
					}
				}

				// save into rtf file and print
				String szTextToPrint;
				szTextToPrint = "Serial number of the refill: ";
				szTextToPrint += szSplitedDecryptedSerialNumber;
				richTextBox1.AppendText(szTextToPrint);
				richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
				richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
				szTextToPrint = "\n\n";
				richTextBox1.AppendText(szTextToPrint);
				DateTime CurrentTime = DateTime.Now;
				String szCurrentTime = LogIn.FormatedDate(1);
				szTextToPrint = "Data/time of the print: ";
				szTextToPrint += szCurrentTime;
				richTextBox1.AppendText(szTextToPrint);
				richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
				richTextBox1.SelectionFont = new Font("Verdana", 8, FontStyle.Regular);
				szTextToPrint = "\n\n";
				richTextBox1.AppendText(szTextToPrint);
				
				String szDirectoryForInvoices = "Invoices";
				if (Directory.Exists(szDirectoryForInvoices) == false)
				{
					Directory.CreateDirectory(szDirectoryForInvoices);
				}
				String szRTFSavedFile = String.Format("{0}\\Invoice_{1}.rtf", szDirectoryForInvoices, LogIn.FormatedDate(0));

				richTextBox1.SaveFile(szRTFSavedFile);

				System.Diagnostics.Process print = new System.Diagnostics.Process(); 
				print.StartInfo.FileName = szRTFSavedFile;
				print.StartInfo.CreateNoWindow = true;
				print.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
				print.StartInfo.Verb = "print";
				print.Start(); //Start the process
				print.Dispose();

				dr[0]["StatusNr"] = 3;
				dr[0]["DateOfCardSale"] = CurrentTime;
				dr[0]["FileNameSold"] = szRTFSavedFile;
				daCardInformation.Update(dsCardInformation, "CardInformation");
				dsCardInformation.AcceptChanges();
				daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
				dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
				DataGrid.DataSource = dvDataGrid;

				LogIn.foutLogFile.WriteLine("A {0} Euro card was generated at {1}", nCardValue, LogIn.FormatedDate(1));
			}
			catch (CryptographicException e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to cryptographic exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (UnauthorizedAccessException e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to UnauthorizedAccessException exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (SqlException sqlEx)
			{
				LogIn.foutLogFile.WriteLine("Error was generated due to SQL Exception {0}, the error was {1}", sqlEx.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception e)
			{
				LogIn.foutLogFile.WriteLine("Error {0} was generated due to exception at {1}", e.Message, LogIn.FormatedDate(1));
				dsCardInformation.RejectChanges();
				MessageBox.Show(e.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
			Application.Exit();
		}

        private void btnEndOfDay_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'End of Day' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmEndOfDay, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			
			if (result == DialogResult.OK)
			{
				try
				{
					LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('End of Day') at {0}", LogIn.FormatedDate(1));
					richTextBox1.Text = "";
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					String szDirectoryForEndOfDay = "EndOfDay";
					if (Directory.Exists(szDirectoryForEndOfDay) == false)
					{
						Directory.CreateDirectory(szDirectoryForEndOfDay);
					}
					String szRTFSavedFile = String.Format("{0}\\EndOfDay_{1}.rtf", szDirectoryForEndOfDay, LogIn.FormatedDate(0));

					String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
					String szCurrentTimeMin = szCurrentTime + " 00:00:00";
					String szCurrentTimeMax = szCurrentTime + " 23:59:59";
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);

					DataRow [] drSold5Euro = dsCardInformation.Tables["CardInformation"].Select("StatusNr = 3 AND UserTableID = " + LogIn.UserID.ToString() + " AND CardValue = 5");
					DataRow [] drSold10Euro = dsCardInformation.Tables["CardInformation"].Select("StatusNr = 3 AND UserTableID = " + LogIn.UserID.ToString() + " AND CardValue = 10");
					DataRow [] drSold20Euro = dsCardInformation.Tables["CardInformation"].Select("StatusNr = 3 AND UserTableID = " + LogIn.UserID.ToString() + " AND CardValue = 20");
					
					String szTextToPrint;
					szTextToPrint = String.Format("Sales sumary for the user: {0} on date: {1}", LogIn.UserName, szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n--------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = String.Format("Number of sold cards of 5 EURO: {0}, TOTAL: {1} EURO", drSold5Euro.Length, drSold5Euro.Length * 5);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of sold cards of 10 EURO: {0}, TOTAL: {1} EURO", drSold10Euro.Length, drSold10Euro.Length * 10);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);

                    szTextToPrint = String.Format("Number of sold cards of 20 EURO: {0}, TOTAL: {1} EURO", drSold20Euro.Length, drSold20Euro.Length * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
					
					richTextBox1.AppendText("--------------------------------------------------------------------------\n");
					szTextToPrint = String.Format("                          TOTAL:         {0} EURO", drSold5Euro.Length * 5 + drSold10Euro.Length * 10 + drSold20Euro.Length * 20);
					richTextBox1.AppendText(szTextToPrint + "\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
					richTextBox1.AppendText("--------------------------------------------------------------------------\n\n");

					szTextToPrint = String.Format("Printed on : {0}",  szCurrentDateAndTime);
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

					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					DataRow [] dr = dsCardInformation.Tables["CardInformation"].Select("UserTableID = " + LogIn.UserID.ToString() + " AND StatusNr = 3 AND DateOfCardSale >= '" +szCurrentTimeMin + "' AND DateOfCardSale <= '" + szCurrentTimeMax + "'");
					for (int i = 0; i < dr.Length; i++)
					{
						dr[i]["StatusNr"] = 4;
						dr[i]["DateOfCardEndOfDay"] = CurrentTime;
						dr[i]["FileNameEndOfDay"] = szRTFSavedFile;
					}
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();
					daCardInformationGroup.Fill(dsCardInformation, "CardInformationGrouped");
					dvDataGrid = new DataView(dsCardInformation.Tables["CardInformationGrouped"]);
					DataGrid.DataSource = dvDataGrid;
					LogIn.foutLogFile.WriteLine("Procedure 'End of Day' was successful at {0}", LogIn.FormatedDate(1));
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error in 'End of Day' procedure due to SQL Exception {0}, the error was {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error in 'End of Day' procedure, time {0}", LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('End of Day') at {0}", LogIn.FormatedDate(1));
			}
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
					String ErrorInUPLFile = "Error in UPL File";
					String ErrorUserNotInPostalOffice = "This user does not belong in this postal office";
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
						String szDirectoryForUploadSerialNumbers = "UploadSerialNumbers";
						if (Directory.Exists(szDirectoryForUploadSerialNumbers) == false)
						{
							Directory.CreateDirectory(szDirectoryForUploadSerialNumbers);
						}

						szUploadFile = openFileDialog.FileName;
						fs = new FileStream(szUploadFile, FileMode.Open);
						foutUpload = new BinaryReader(fs, Encoding.Unicode);
						dsCardInformation = new DataSet();
						daCardInformation.Fill(dsCardInformation, "CardInformation");

						sqlConnection = LogIn.conn;
						sqlConnection.Open();
						sqlTransaction = sqlConnection.BeginTransaction();
						daCardInformation.InsertCommand.Transaction = sqlTransaction;
						daCardInformationGroup.SelectCommand.Transaction = sqlTransaction;
						int nNumberOf5EuroCards = 0, nNumberOf10EuroCards = 0, nNumberOf20EuroCards = 0;
						String szRTFSavedFile = String.Format("{0}\\UploadSerialNumbers_{1}.rtf", szDirectoryForUploadSerialNumbers, LogIn.FormatedDate(0));

						String szUserName = "";

						while (foutUpload.PeekChar() != -1)
						{
							int nCardID = foutUpload.ReadInt32();
							DataRow [] drRepeat = dsCardInformation.Tables["CardInformation"].Select("CardID = " + nCardID);
							if (drRepeat.Length != 0)
								throw new Exception(ErrorInUPLFile);
							DataRow dr = dsCardInformation.Tables["CardInformation"].NewRow();
							dr["CardID"] = nCardID;
							dr["CardCode"] = foutUpload.ReadString();
							int nStatus = foutUpload.ReadInt32();
							if (nStatus != 1)
								throw new Exception(ErrorInUPLFile);
							dr["StatusNr"] = 2;
							dr["UserTableID"] = foutUpload.ReadInt32();
							int nUserTableID = Convert.ToInt32(dr["UserTableID"]);
							DataRow [] drUserName = dsUserTable.Tables["UserTable"].Select("usertableID = " + nUserTableID);
							if (drUserName.Length == 0)
								throw new Exception(ErrorUserNotInPostalOffice);
							szUserName =  drUserName[0]["FirstName"] + " " + drUserName[0]["LastName"];
							dr["CardValue"] = foutUpload.ReadString();
							if (Convert.ToInt32(dr["CardValue"]) == 5)
								nNumberOf5EuroCards++;
							else if (Convert.ToInt32(dr["CardValue"]) == 10)
								nNumberOf10EuroCards++;
							else if (Convert.ToInt32(dr["CardValue"]) == 20)
								nNumberOf20EuroCards++;
							dr["DateOfCardCreation"] = foutUpload.ReadString();
							dr["DateOfCardIssue"] = foutUpload.ReadString();
							dr["DateOfCardReceive"] = DateTime.Now;
							dr["DateOfCardSale"] = DBNull.Value;
							dr["DateOfCardEndOfDay"] = DBNull.Value;
							dr["DateOfCardReconciled"] = DBNull.Value;
							dr["DateOfCardFinished"] = DBNull.Value;
							dr["FileNameCardCreation"] = foutUpload.ReadString();
							dr["FileNameIssued"] = foutUpload.ReadString();
							dr["FileNameReceived"] = szUploadFile;
							dr["FileNameSold"] = DBNull.Value;
							dr["FileNameEndOfDay"] = DBNull.Value;
							dr["FileNameReconciled"] = DBNull.Value;
							dr["FileNameFinished"] = DBNull.Value;
							dsCardInformation.Tables["CardInformation"].Rows.Add(dr);
						}

						String szTextToPrint;
						DateTime CurrentTime = DateTime.Now;
						String szCurrentTime = String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day);
						String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
						String szCurrentDateAndTime = LogIn.FormatedDate(1);
						szTextToPrint = String.Format("Number of uploaded card for user: {0} on date: {1}", szUserName, szCurrentDate);
						richTextBox1.AppendText(szTextToPrint +  
							"\n\n--------------------------------------------------------------------------\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
						szTextToPrint = String.Format("Number of uploaded cards of 5 EURO: {0}, TOTAL: {1} EURO", nNumberOf5EuroCards, nNumberOf5EuroCards * 5);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                        szTextToPrint = String.Format("Number of uploaded cards of 10 EURO: {0}, TOTAL: {1} EURO", nNumberOf10EuroCards, nNumberOf10EuroCards * 10);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                        szTextToPrint = String.Format("Number of uploaded cards of 20 EURO: {0}, TOTAL: {1} EURO", nNumberOf20EuroCards, nNumberOf20EuroCards * 20);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
						
						richTextBox1.AppendText("--------------------------------------------------------------------------\n");
						szTextToPrint = String.Format("                          TOTAL:         {0} EURO", nNumberOf5EuroCards * 5 + nNumberOf10EuroCards * 10 + nNumberOf20EuroCards * 20);
						richTextBox1.AppendText(szTextToPrint + "\n");
						richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
						richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
						richTextBox1.AppendText("--------------------------------------------------------------------------\n\n");

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
						//					print.Start(); //Start the process
						//					print.Dispose();

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
					LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was NOT successful from file {1}, the error was {2}", LogIn.FormatedDate(1), szUploadFile, sqlEx.Message);
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Upload serial number' was NOT successful from file {1}, the error was {2}", LogIn.FormatedDate(1), szUploadFile, ex.Message);
					dsCardInformation.RejectChanges();
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

		private void btnDownloadReconciliation_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Download for Reconciliation' button at {0}", LogIn.FormatedDate(1));
			DialogResult result = MessageBox.Show(ConfirmDownloadForReconiliation, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				FileStream fs = null;
				BinaryWriter foutReconcile = null;
				
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Download for Reconciliation') at {0}", LogIn.FormatedDate(1));
				try
				{
					String szDirectoryForReconciliation = "Reconciliaton";
					if (Directory.Exists(szDirectoryForReconciliation) == false)
					{
						Directory.CreateDirectory(szDirectoryForReconciliation);
					}
					String szReconcileSavedFile = String.Format("{0}\\reconcile_{1}.rec", szDirectoryForReconciliation, LogIn.FormatedDate(0));

					fs = new FileStream(szReconcileSavedFile, FileMode.Create);
					foutReconcile = new BinaryWriter(fs);
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					int nNumberOfUsers = dsUserTable.Tables["UserTable"].Rows.Count;
					for (int j = 0; j < nNumberOfUsers; j++)
					{
						DataRow [] dr = dsCardInformation.Tables["CardInformation"].Select("StatusNr = 4 AND UserTableID = " + dsUserTable.Tables["UserTable"].Rows[j]["UserTableID"]);

						String szFormatedDate = LogIn.FormatedDate(2);
						for (int i = 0; i < dr.Length; i++)
						{
							dr[i]["StatusNr"] = 5;
							dr[i]["DateOfCardReconciled"] = szFormatedDate;
							dr[i]["FileNameReconciled"] = szReconcileSavedFile;
							foutReconcile.Write((int) dr[i]["CardID"]);
							foutReconcile.Write((int) dr[i]["StatusNr"]);
							foutReconcile.Write((string) dr[i]["DateOfCardReceive"].ToString());
							foutReconcile.Write((string) dr[i]["DateOfCardSale"].ToString());
							foutReconcile.Write((string) dr[i]["DateOfCardEndOfDay"].ToString());
							foutReconcile.Write((string) dr[i]["DateOfCardReconciled"].ToString());
							foutReconcile.Write((string) dr[i]["FileNameReceived"].ToString());
							foutReconcile.Write((string) dr[i]["FileNameSold"].ToString());
							foutReconcile.Write((string) dr[i]["FileNameEndOfDay"].ToString());
							foutReconcile.Write((string) dr[i]["FileNameReconciled"].ToString());
						}
					}
					daCardInformation.Update(dsCardInformation, "CardInformation");
					dsCardInformation.AcceptChanges();
					LogIn.foutLogFile.WriteLine("Procedure 'Reconciliation' was successfuly saved to file '{1}' at {0}", LogIn.FormatedDate(1), szReconcileSavedFile);
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Procedure 'Reconciliation' was NOT successful at {0}", LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (foutReconcile != null)
						foutReconcile.Close();
					if (fs != null)
						fs.Close();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Download for Reconciliation') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void SuperviserPostalUser_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User exited Superviser Postal User form at {0}", LogIn.FormatedDate(1));
			LogIn.foutLogFile.Close();
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

		private void btnUploadUsers_Click(object sender, System.EventArgs e)
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

		private void LoadUserTable()
		{
			daUserTable = new SqlDataAdapter();

			SqlCommand cmdUserSelect = LogIn.conn.CreateCommand();
			cmdUserSelect.CommandType = CommandType.Text;
			cmdUserSelect.CommandText = "select * from usertable where postalnr = (select postalnr from usertable where usertableid = " + LogIn.UserID + ")";
			
			SqlCommand cmdUserUpdate = LogIn.conn.CreateCommand();
			cmdUserUpdate.CommandType = CommandType.Text;
			cmdUserUpdate.CommandText = "update UserTable SET Password = @Password WHERE UserTableID = @UserTableID";
			cmdUserUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserUpdate.Parameters.Add("@Password", SqlDbType.NVarChar, 30, "Password");
			cmdUserUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daUserTable.SelectCommand = cmdUserSelect;
			daUserTable.UpdateCommand = cmdUserUpdate;
		}

		private void LoadCardInformationGrouped()
		{
			daCardInformationGroup = new SqlDataAdapter();
			SqlCommand cmdCardInformationGroup = LogIn.conn.CreateCommand();
			cmdCardInformationGroup.CommandType = CommandType.Text;
			cmdCardInformationGroup.CommandText = "select Cast(Round(Available.cardvalue, 0) as int) as 'Kartela (Euro)', Available.cn as 'Ne stoqe', Sold.cn as 'Te shitura' from (select cardvalue, count(*) as cn from cardinformation where statusNr = 2 AND UserTableID = " + LogIn.UserID + " group  by all cardvalue) as Available inner join (select cardvalue, count(*) as cn from cardinformation where statusNr = 3 AND UserTableID = " + LogIn.UserID + " group  by all cardvalue) as Sold on Available.cardvalue = Sold.cardvalue";
			daCardInformationGroup.SelectCommand = cmdCardInformationGroup;
		}

		private void LoadCardInformation()
		{
			daCardInformation = new SqlDataAdapter();

			SqlCommand cmdCardInformationSelect = LogIn.conn.CreateCommand();
			cmdCardInformationSelect.CommandType = CommandType.Text;
			cmdCardInformationSelect.CommandText = "select * from CardInformation";
			
			SqlCommand cmdCardInformationInsert = LogIn.conn.CreateCommand();
			cmdCardInformationInsert.CommandType = CommandType.Text;
			cmdCardInformationInsert.CommandText = "Insert into Cardinformation (CardID, CardCode, StatusNr, UserTableID, CardValue, DateOfCardCreation, DateOfCardIssue, DateOfCardReceive, DateOfCardSale, DateOfCardEndOfDay, DateOfCardReconciled, DateOfCardFinished, FileNameCardCreation, FileNameIssued, FileNameReceived, FileNameSold, FileNameEndOfDay, FileNameReconciled, FileNameFinished) VALUES (@CardID, @CardCode, @StatusNr, @UserTableID, @CardValue, @DateOfCardCreation, @DateOfCardIssue, @DateOfCardReceive, @DateOfCardSale, @DateOfCardEndOfDay, @DateOfCardReconciled, @DateOfCardFinished, @FileNameCardCreation, @FileNameIssued, @FileNameReceived, @FileNameSold, @FileNameEndOfDay, @FileNameReconciled, @FileNameFinished)";
			cmdCardInformationInsert.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationInsert.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationInsert.Parameters.Add("@StatusNr", SqlDbType.Int, 4, "StatusNr");
			cmdCardInformationInsert.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationInsert.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardCreation", SqlDbType.DateTime, 8, "DateOfCardCreation");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardIssue", SqlDbType.DateTime, 8, "DateOfCardIssue");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardReceive", SqlDbType.DateTime, 8, "DateOfCardReceive");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardSale", SqlDbType.DateTime, 8, "DateOfCardSale");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardEndOfDay", SqlDbType.DateTime, 8, "DateOfCardEndOfDay");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardReconciled", SqlDbType.DateTime, 8, "DateOfCardReconciled");
			cmdCardInformationInsert.Parameters.Add("@DateOfCardFinished", SqlDbType.DateTime, 8, "DateOfCardFinished");
			cmdCardInformationInsert.Parameters.Add("@FileNameCardCreation", SqlDbType.NVarChar, 500, "FileNameCardCreation");
			cmdCardInformationInsert.Parameters.Add("@FileNameIssued", SqlDbType.NVarChar, 500, "FileNameIssued");
			cmdCardInformationInsert.Parameters.Add("@FileNameReceived", SqlDbType.NVarChar, 500, "FileNameReceived");
			cmdCardInformationInsert.Parameters.Add("@FileNameSold", SqlDbType.NVarChar, 500, "FileNameSold");
			cmdCardInformationInsert.Parameters.Add("@FileNameEndOfDay", SqlDbType.NVarChar, 500, "FileNameEndOfDay");
			cmdCardInformationInsert.Parameters.Add("@FileNameReconciled", SqlDbType.NVarChar, 500, "FileNameReconciled");
			cmdCardInformationInsert.Parameters.Add("@FileNameFinished", SqlDbType.NVarChar, 500, "FileNameFinished");
			cmdCardInformationInsert.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			SqlCommand cmdCardInformationUpdate = LogIn.conn.CreateCommand();
			cmdCardInformationUpdate.CommandType = CommandType.Text;
			cmdCardInformationUpdate.CommandText = "update CardInformation SET CardCode = @CardCode, StatusNr = @StatusNr, UserTableID = @UserTableID, CardValue = @CardValue, DateOfCardCreation = @DateOfCardCreation, DateOfCardIssue = @DateOfCardIssue, DateOfCardReceive = @DateOfCardReceive, DateOfCardSale = @DateOfCardSale, DateOfCardEndOfDay = @DateOfCardEndOfDay, DateOfCardReconciled = @DateOfCardReconciled, DateOfCardFinished = @DateOfCardFinished, FileNameCardCreation = @FileNameCardCreation, FileNameIssued = @FileNameIssued, FileNameReceived = @FileNameReceived, FileNameSold = @FileNameSold, FileNameEndOfDay = @FileNameEndOfDay, FileNameReconciled = @FileNameReconciled, FileNameFinished = @FileNameFinished WHERE CardID = @CardID";
			cmdCardInformationUpdate.Parameters.Add("@CardID", SqlDbType.Int, 4, "CardID");
			cmdCardInformationUpdate.Parameters.Add("@CardCode", SqlDbType.NVarChar, 50, "CardCode");
			cmdCardInformationUpdate.Parameters.Add("@StatusNr", SqlDbType.Int, 4, "StatusNr");
			cmdCardInformationUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdCardInformationUpdate.Parameters.Add("@CardValue", SqlDbType.Money, 8, "CardValue");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardCreation", SqlDbType.DateTime, 8, "DateOfCardCreation");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardIssue", SqlDbType.DateTime, 8, "DateOfCardIssue");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardReceive", SqlDbType.DateTime, 8, "DateOfCardReceive");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardSale", SqlDbType.DateTime, 8, "DateOfCardSale");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardEndOfDay", SqlDbType.DateTime, 8, "DateOfCardEndOfDay");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardReconciled", SqlDbType.DateTime, 8, "DateOfCardReconciled");
			cmdCardInformationUpdate.Parameters.Add("@DateOfCardFinished", SqlDbType.DateTime, 8, "DateOfCardFinished");
			cmdCardInformationUpdate.Parameters.Add("@FileNameCardCreation", SqlDbType.NVarChar, 500, "FileNameCardCreation");
			cmdCardInformationUpdate.Parameters.Add("@FileNameIssued", SqlDbType.NVarChar, 500, "FileNameIssued");
			cmdCardInformationUpdate.Parameters.Add("@FileNameReceived", SqlDbType.NVarChar, 500, "FileNameReceived");
			cmdCardInformationUpdate.Parameters.Add("@FileNameSold", SqlDbType.NVarChar, 500, "FileNameSold");
			cmdCardInformationUpdate.Parameters.Add("@FileNameEndOfDay", SqlDbType.NVarChar, 500, "FileNameEndOfDay");
			cmdCardInformationUpdate.Parameters.Add("@FileNameReconciled", SqlDbType.NVarChar, 500, "FileNameReconciled");
			cmdCardInformationUpdate.Parameters.Add("@FileNameFinished", SqlDbType.NVarChar, 500, "FileNameFinished");
			cmdCardInformationUpdate.Parameters["@CardID"].SourceVersion = DataRowVersion.Original;

			daCardInformation.SelectCommand = cmdCardInformationSelect;
			daCardInformation.UpdateCommand = cmdCardInformationUpdate;
			daCardInformation.InsertCommand = cmdCardInformationInsert;

		}
	}
}

