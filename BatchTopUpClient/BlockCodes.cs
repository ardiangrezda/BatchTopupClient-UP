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
	/// Summary description for BlockCodes.
	/// </summary>
	public class BlockCodes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstBatches;
		private System.Windows.Forms.TextBox txtFromNumber;
		private System.Windows.Forms.TextBox txtToNumber;
		private System.Windows.Forms.Label lblFromNumber;
		private System.Windows.Forms.Label lblToNumber;
		private System.Windows.Forms.Label lblMinSerialNumber;
		private System.Windows.Forms.Label lblMaxSerialNumber;
		private System.Windows.Forms.Button btnBlockNumbers;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BlockCodes()
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
            this.lstBatches = new System.Windows.Forms.ListBox();
            this.txtFromNumber = new System.Windows.Forms.TextBox();
            this.txtToNumber = new System.Windows.Forms.TextBox();
            this.lblFromNumber = new System.Windows.Forms.Label();
            this.lblToNumber = new System.Windows.Forms.Label();
            this.lblMinSerialNumber = new System.Windows.Forms.Label();
            this.lblMaxSerialNumber = new System.Windows.Forms.Label();
            this.btnBlockNumbers = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBatches
            // 
            this.lstBatches.Location = new System.Drawing.Point(48, 24);
            this.lstBatches.Name = "lstBatches";
            this.lstBatches.Size = new System.Drawing.Size(96, 212);
            this.lstBatches.TabIndex = 0;
            this.lstBatches.SelectedIndexChanged += new System.EventHandler(this.lstBatches_SelectedIndexChanged);
            // 
            // txtFromNumber
            // 
            this.txtFromNumber.Location = new System.Drawing.Point(160, 24);
            this.txtFromNumber.Name = "txtFromNumber";
            this.txtFromNumber.Size = new System.Drawing.Size(120, 20);
            this.txtFromNumber.TabIndex = 1;
            this.txtFromNumber.TextChanged += new System.EventHandler(this.txtFromNumber_TextChanged);
            // 
            // txtToNumber
            // 
            this.txtToNumber.Location = new System.Drawing.Point(160, 56);
            this.txtToNumber.Name = "txtToNumber";
            this.txtToNumber.Size = new System.Drawing.Size(120, 20);
            this.txtToNumber.TabIndex = 2;
            this.txtToNumber.TextChanged += new System.EventHandler(this.txtToNumber_TextChanged);
            // 
            // lblFromNumber
            // 
            this.lblFromNumber.Location = new System.Drawing.Point(8, 24);
            this.lblFromNumber.Name = "lblFromNumber";
            this.lblFromNumber.Size = new System.Drawing.Size(136, 24);
            this.lblFromNumber.TabIndex = 3;
            this.lblFromNumber.Text = "From Serial Number";
            this.lblFromNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToNumber
            // 
            this.lblToNumber.Location = new System.Drawing.Point(8, 56);
            this.lblToNumber.Name = "lblToNumber";
            this.lblToNumber.Size = new System.Drawing.Size(136, 24);
            this.lblToNumber.TabIndex = 4;
            this.lblToNumber.Text = "To Serial Number";
            this.lblToNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinSerialNumber
            // 
            this.lblMinSerialNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinSerialNumber.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMinSerialNumber.Location = new System.Drawing.Point(192, 32);
            this.lblMinSerialNumber.Name = "lblMinSerialNumber";
            this.lblMinSerialNumber.Size = new System.Drawing.Size(240, 16);
            this.lblMinSerialNumber.TabIndex = 5;
            this.lblMinSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxSerialNumber
            // 
            this.lblMaxSerialNumber.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblMaxSerialNumber.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMaxSerialNumber.Location = new System.Drawing.Point(192, 56);
            this.lblMaxSerialNumber.Name = "lblMaxSerialNumber";
            this.lblMaxSerialNumber.Size = new System.Drawing.Size(240, 16);
            this.lblMaxSerialNumber.TabIndex = 6;
            this.lblMaxSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBlockNumbers
            // 
            this.btnBlockNumbers.Location = new System.Drawing.Point(88, 88);
            this.btnBlockNumbers.Name = "btnBlockNumbers";
            this.btnBlockNumbers.Size = new System.Drawing.Size(104, 23);
            this.btnBlockNumbers.TabIndex = 7;
            this.btnBlockNumbers.Text = "Block Numbers";
            this.btnBlockNumbers.Click += new System.EventHandler(this.btnBlockNumbers_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToNumber);
            this.groupBox1.Controls.Add(this.lblFromNumber);
            this.groupBox1.Controls.Add(this.lblToNumber);
            this.groupBox1.Controls.Add(this.txtFromNumber);
            this.groupBox1.Controls.Add(this.btnBlockNumbers);
            this.groupBox1.Location = new System.Drawing.Point(112, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 128);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Block serial Numbers ";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(216, 432);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(8, 472);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(456, 40);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // BlockCodes
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 510);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMaxSerialNumber);
            this.Controls.Add(this.lblMinSerialNumber);
            this.Controls.Add(this.lstBatches);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximumSize = new System.Drawing.Size(550, 700);
            this.MinimumSize = new System.Drawing.Size(460, 520);
            this.Name = "BlockCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Block Serial Numbers from Batches";
            this.Load += new System.EventHandler(this.BlockCodes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private SqlDataAdapter daCardBlock;
		private DataSet dsCardBlock;
		private SqlDataAdapter daCardInformation;
		private DataSet dsCardInformation;

		private int nFirstEntrance;
		private const string error = "Error!";
		private const string ConfirmTitle	= "Confirm";
		private void BlockCodes_Load(object sender, System.EventArgs e)
		{
			nFirstEntrance = 0;
			LogIn.foutLogFile.WriteLine("User entered the Block Codes form at {0}", LogIn.FormatedDate(1));
			LoadCardInformation();
			dsCardInformation = new DataSet();
			daCardInformation.Fill(dsCardInformation, "CardInformation");

			LoadCardBlock();
			dsCardBlock = new DataSet();
			daCardBlock.Fill(dsCardBlock, "CardBlock");
		
			lstBatches.DataSource = dsCardBlock.Tables["CardBlock"];
			lstBatches.DisplayMember = "Batch";
			lstBatches.ValueMember = "Batch";
			lstBatches.SelectedIndex = -1;
			nFirstEntrance = 1;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Exit' button ('BlockCodes form')at {0}", LogIn.FormatedDate(1));
			this.DialogResult = DialogResult.Cancel;
		}

		private void txtFromNumber_TextChanged(object sender, System.EventArgs e)
		{
			if (IsNumeric(txtFromNumber.Text) == false)
			{
				txtFromNumber.Text = "";
			}
		}

		
		private void btnBlockNumbers_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Block Numbers' button at {0}", LogIn.FormatedDate(1));
			if (lstBatches.Text == "")
			{
				MessageBox.Show("No batch selected for confirmation", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("No batch selected for confirmation ('Block Numbers') at {0}", LogIn.FormatedDate(1));
				return;
			}
			
			if (txtFromNumber.Text == "")
			{
				MessageBox.Show("The Edit Box 'From Serial Number' is empty", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("The Edit Box 'From Serial Number' is empty at {0}", LogIn.FormatedDate(1));
				return;
			}
			if (txtToNumber.Text == "")
			{
				MessageBox.Show("The Edit Box 'To Serial Number' is empty", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("The Edit Box 'To Serial Number' is empty' is empty at {0}", LogIn.FormatedDate(1));
				return;
			}
			long nMinRequired = Convert.ToInt64(txtFromNumber.Text);
			long nMaxRequired = Convert.ToInt64(txtToNumber.Text);
			if (nMinRequired > nMaxRequired)
			{
				MessageBox.Show("The value of 'To Serial Number' is smaller then 'From serial Number'", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				LogIn.foutLogFile.WriteLine("The value of 'To Serial Number' is smaller then 'From serial Number' at {0}", LogIn.FormatedDate(1));
				return;
			}

			string ConfirmBlockCodes = String.Format("Are you sure you want to block Batch {0} from Serial No. {1} to Serial No. {2} ?", lstBatches.Text, txtFromNumber.Text, txtToNumber.Text);
			DialogResult result = MessageBox.Show(ConfirmBlockCodes, ConfirmTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Block Numbers') at {0}", LogIn.FormatedDate(1));
				SqlTransaction sqlTransaction = null;
				SqlConnection sqlConnection = null;
				try
				{
					String szDirAdminBlockNumbers = "AdminBlockNumbers";
					if (Directory.Exists(szDirAdminBlockNumbers) == false)
					{
						Directory.CreateDirectory(szDirAdminBlockNumbers);
					}
					String szRTFSavedFile = String.Format("{0}\\AdminBlockNumbers_{1}.rtf", szDirAdminBlockNumbers, LogIn.FormatedDate(0));
					dsCardInformation = new DataSet();
					daCardInformation.Fill(dsCardInformation, "CardInformation");
					sqlConnection = LogIn.conn;
					sqlConnection.Open();
					sqlTransaction = sqlConnection.BeginTransaction();
					daCardInformation.UpdateCommand.Transaction = sqlTransaction;
					daCardBlock.SelectCommand.Transaction = sqlTransaction;

					DataRow [] drCardInformation = dsCardInformation.Tables["CardInformation"].Select("Batch = " + lstBatches.SelectedValue);

					DataRow [] drCardBlock = dsCardBlock.Tables["CardBlock"].Select("Batch = " + lstBatches.SelectedValue);
					long nMinAvailable = Convert.ToInt64(drCardBlock[0]["MinSerialCard"]);
					long nMaxAvailable = Convert.ToInt64(drCardBlock[0]["MaxSerialCard"]);
					if (!(nMinRequired >= nMinAvailable && nMinRequired <= nMaxAvailable))
					{
						throw new Exception("The minimum serial number is not correct!");
					}
					if (!(nMaxRequired >= nMinAvailable && nMaxRequired <= nMaxAvailable))
					{
						throw new Exception("The maximum serial number is not correct!");
					}
					for (long i = nMinRequired; i <= nMaxRequired; i++)
					{
						DataRow [] drBlockCard = dsCardInformation.Tables["CardInformation"].Select("Batch = '" + lstBatches.Text + "' AND CardSerialNumber = " + i);
						drBlockCard[0]["StatusCardID"] = 8;
						drBlockCard[0]["UserTableID"] = LogIn.UserID;
					}
					richTextBox1.Text = "";
					String szTextToPrint;
					String szCurrentDateAndTime = LogIn.FormatedDate(1);
					DateTime CurrentTime = DateTime.Now;
					String szCurrentDate = String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year);
					szTextToPrint = String.Format("Confirmation of blocking cards on date {0} ", szCurrentDate);
					richTextBox1.AppendText(szTextToPrint +  
						"\n\n---------------------------------------------------------------------------------------------\n");
					richTextBox1.SelectionStart = richTextBox1.Find(szTextToPrint);
					richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
					szTextToPrint = String.Format("Blocked batch: {0} Serial number {1}-{2}", lstBatches.Text, nMinRequired, nMaxRequired);
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
					if (drCardBlock.Length != 0)
					{
						dsCardBlock.Tables["CardBlock"].Clear();
						daCardBlock.Fill(dsCardBlock, "CardBlock");
						lstBatches.DataSource = dsCardBlock.Tables["CardBlock"];
						lstBatches.DisplayMember = "Batch";
						lstBatches.ValueMember = "Batch";
						lstBatches.SelectedIndex = -1;
					}
					sqlTransaction.Commit();
				}
				catch (SqlException sqlEx)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", sqlEx.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(sqlEx.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				catch (Exception ex)
				{
					LogIn.foutLogFile.WriteLine("Error {0} was generated at {1}", ex.Message, LogIn.FormatedDate(1));
					dsCardInformation.RejectChanges();
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
				}
				finally
				{
					if (sqlConnection != null)
						sqlConnection.Close();
					lstBatches.SelectedIndex = -1;
					EmptyEditBoxes();
				}
			}
			else
			{
				LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Block numbers') at {0}", LogIn.FormatedDate(1));
			}
		}

		private void lstBatches_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (nFirstEntrance != 0 && lstBatches.SelectedIndex != -1)
			{
				DataRow [] drCardBlock = dsCardBlock.Tables["CardBlock"].Select("Batch = " + lstBatches.SelectedValue);

				lblMinSerialNumber.Text = "Min. Serial Number: " + drCardBlock[0]["MinSerialCard"];
				lblMaxSerialNumber.Text = "Max. Serial Number: " + drCardBlock[0]["MaxSerialCard"];
			}
		}

		private void txtToNumber_TextChanged(object sender, System.EventArgs e)
		{
			if (IsNumeric(txtToNumber.Text) == false)
			{
				txtToNumber.Text = "";
			}
		}

		private static bool IsNumeric(object Expression)
		{
			bool isNum;
			double retNum;
			isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
			return isNum;
		}

		public void EmptyEditBoxes()
		{
			txtFromNumber.Text = "";
			txtToNumber.Text = "";
			lblMinSerialNumber.Text = "";
			lblMaxSerialNumber.Text = "";
		}

		private void LoadCardBlock()
		{
			daCardBlock = new SqlDataAdapter();
			SqlCommand cmdCardBlock = LogIn.conn.CreateCommand();
			cmdCardBlock.CommandType = CommandType.Text;
			cmdCardBlock.CommandText = "select batch as Batch, Min (CardserialNumber) as MinSerialCard, max(CardSerialNumber) as MaxSerialCard from cardinformation where statuscardid = 1 or statuscardid = 2 or statusCardId = 3 group by batch";
			daCardBlock.SelectCommand = cmdCardBlock;
		}

		private void LoadCardInformation()
		{
			daCardInformation = new SqlDataAdapter();

			SqlCommand cmdCardInformationSelect = LogIn.conn.CreateCommand();
			cmdCardInformationSelect.CommandType = CommandType.Text;
			cmdCardInformationSelect.CommandText = "select * from CardInformation where statuscardid = 1 or statuscardid = 2 or statusCardId = 3";
			
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
		}
	}
}
