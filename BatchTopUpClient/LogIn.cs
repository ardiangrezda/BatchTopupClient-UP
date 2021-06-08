using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class LogIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.Label lblUserID;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnChangePassword;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox2;

		public static DataSet dsText;
		public static DataSet dsLanguage;
		public static String Language;
		public static SqlConnection conn;
		public static String Role;
		public static int UserID;
		public static String UserName;
		public static String szRegKey = @"Software\AG7447BG";
		public static StreamWriter foutLogFile;
		public const String szErrorStringConnection = "Could not open the application, the connection string was not correct";
		public const String error = "Error!";
		public static string szConnection = "";
		private System.Windows.Forms.PictureBox pictureBox1;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LogIn()
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
				if (components != null) 
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
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(128, 24);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(120, 20);
            this.txtUserID.TabIndex = 1;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(24, 24);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(72, 23);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "UserID";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(24, 64);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(72, 23);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(79, 312);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Log In";
            this.btnOK.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(247, 312);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(104, 32);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(163, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUserID);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtUserID);
            this.groupBox2.Location = new System.Drawing.Point(67, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(139, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LogIn
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(398, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

			/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			String szLogDirectory = "LogFiles";
			if (Directory.Exists(szLogDirectory) == false)
			{
				Directory.CreateDirectory(szLogDirectory);
			}
			foutLogFile = new StreamWriter(String.Format("{0}\\Log_{1}.log", szLogDirectory, FormatedDate(0)));

			RegistryKey szRegistryKey = Registry.CurrentUser.OpenSubKey(szRegKey, true);
			if (szRegistryKey == null) 
			{
				szRegistryKey = Registry.CurrentUser.CreateSubKey(szRegKey);
			}
			if (szRegistryKey.GetValue("ConnectionString") == null )
			{
				foutLogFile.WriteLine("Error: {0} at {1}", szErrorStringConnection, FormatedDate(1));
				foutLogFile.Close();
				SimMessageBox msg = new SimMessageBox();
				DialogResult a1 = msg.ShowDialog();
				return;
			}
			string szConnectionString = szRegistryKey.GetValue("ConnectionString").ToString();
			szConnection = String.Format("Data Source = {0};initial catalog = BatchTopUp;integrated security=sspi", szConnectionString);

			LogIn ld = new LogIn();
			DialogResult a;
			a = ld.ShowDialog();
			if (a == DialogResult.OK)
			{
				ld.Close();
				ld.Dispose();

				if (Role == "0")
				{
					foutLogFile.WriteLine("The user tried to access Administrator application at {0}",FormatedDate(1));
					Application.Run(new Admin());
				}
				else if (Role == "1")
				{
					foutLogFile.WriteLine("The user tried to access Distribution application at {0}",FormatedDate(1));
					Application.Run(new Distribution());
				}
				else if (Role == "2")
				{
					foutLogFile.WriteLine("The user tried to access Region Center application {0}",FormatedDate(1));
					Application.Run(new RegionCenter());
				}
				else if (Role == "3")
				{
					foutLogFile.WriteLine("The user tried to access Supervisor application at {0}",FormatedDate(1));
					Application.Run(new Supervisor());
				}
				else if (Role == "4")
				{
					foutLogFile.WriteLine("The user tried to access Salesman application at {0}",FormatedDate(1));
					Application.Run(new Salesman());
				}
			}
			else if (a == DialogResult.Cancel)
			{
				foutLogFile.WriteLine("The user pressed 'Cancel' button at {0}",FormatedDate(1));
				foutLogFile.Close();
				Application.Exit();
			}
			else if (a == DialogResult.Yes)
			{
				a = ld.ShowDialog();
			}
		}

		private void LogIn_Load(object sender, System.EventArgs e)
		{
			foutLogFile.WriteLine("User opened the application at {0}", FormatedDate(1));
			conn = new SqlConnection();
			conn.ConnectionString = szConnection;
		}

		private void btnLogIn_Click(object sender, System.EventArgs e)
		{
			foutLogFile.WriteLine("User Clicked 'LogIn button at {0}",FormatedDate(1));

			UnicodeEncoding unicode = new UnicodeEncoding();
			byte [] btPassword = ASCIIEncoding.ASCII.GetBytes(txtPassword.Text);
			MD5 md5 = new MD5CryptoServiceProvider();
			String szPassword = unicode.GetString(md5.ComputeHash(btPassword));

			SqlCommand cmdUserTable = LogIn.conn.CreateCommand();
			cmdUserTable.CommandType = CommandType.Text;
			cmdUserTable.CommandText = "select * from UserTable";
			SqlDataAdapter daUser = new SqlDataAdapter();
			DataSet dsUser = new DataSet();
			daUser.SelectCommand = cmdUserTable;
			daUser.Fill(dsUser, "UserTable");
			DataRow [] dr = dsUser.Tables["UserTable"].Select("UserName = '" + txtUserID.Text + "'");
			String message;
			if (dr.Length == 0)
			{
				SimMessageBox msg = new SimMessageBox();
				msg.label1.Text = "This user does not exist!";
				DialogResult a1 = msg.ShowDialog();
				EmptyEditBoxes();
				foutLogFile.WriteLine("Error! The typed password was wrong, time {0}",FormatedDate(1));
				return;
			}

			if (String.CompareOrdinal(szPassword, dr[0]["Password"].ToString()) != 0)
			{
				SimMessageBox msg = new SimMessageBox();
				msg.label1.Text = "The typed password was wrong!";
				DialogResult a1 = msg.ShowDialog();
				EmptyEditBoxes();
				foutLogFile.WriteLine("Error! The typed password was wrong, time {0}",FormatedDate(1));
				return;
			}
			Role = dr[0]["RoleID"].ToString();
			if (Role != "0" && Role != "1" && Role != "2" && Role != "3" && Role != "4")
			{
				message = "There is no role for this user!";
				SimMessageBox msg = new SimMessageBox();
				msg.label1.Text = message;
				DialogResult a1 = msg.ShowDialog();
				EmptyEditBoxes();
				foutLogFile.WriteLine("Error! The typed password was wrong, time {0}",FormatedDate(1));
				return;
			}
			String szFirstTimeEntrance = dr[0]["FirstTimeEntrance"].ToString();
			int nFirstTimeEntrance = szFirstTimeEntrance == "" ? 0 : Convert.ToInt32(dr[0]["FirstTimeEntrance"].ToString());

			if (nFirstTimeEntrance != 1)
			{
				foutLogFile.WriteLine("User entered the application for the first time at {0}", FormatedDate(1));
				ChangePassword changePassord = new ChangePassword();
				DialogResult passwordChangeResult = changePassord.ShowDialog();
				if (passwordChangeResult == DialogResult.Cancel)
				{
					message = "The user did not changed the password!";
					SimMessageBox msg = new SimMessageBox();
					msg.label1.Text = message;
					DialogResult a1 = msg.ShowDialog();
					EmptyEditBoxes();
					foutLogFile.WriteLine("Error! The typed password was wrong, time {0}",FormatedDate(1));
					return;
				}
			}
			if (Role == "4")
			{
				System.DateTime dateNow = System.DateTime.Now.Date;
				System.DateTime dateLastEndOfDate = dr[0]["LastEndOfDayDate"].ToString() == "" ? dateNow.AddDays(-1) : DateTime.Parse(dr[0]["LastEndOfDayDate"].ToString()).Date;
				TimeSpan dtDayDiff =  dateLastEndOfDate - dateNow;
				if (dtDayDiff.Days >= 0)
				{
					message = "The user has generated procedure 'END of DAY' and could not enter into the system!";
					SimMessageBox msg = new SimMessageBox();
					msg.label1.Text = message;
					DialogResult a1 = msg.ShowDialog();
					EmptyEditBoxes();
					foutLogFile.WriteLine("Error! The typed password was wrong, time {0}",FormatedDate(1));
					return;
				}
			}
			UserID = Convert.ToInt32(dr[0]["UserTableID"].ToString());
			UserName = dr[0]["FirstName"] + " " + dr[0]["LastName"];
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			foutLogFile.WriteLine("1. User pressed 'Cancel' button at {0}", FormatedDate(1));
			this.DialogResult = DialogResult.Cancel;
		}

		private void btnChangePassword_Click(object sender, System.EventArgs e)
		{
			foutLogFile.WriteLine("User pressed 'Change password' button at {0}", FormatedDate(1));
			ChangePassword changePassord = new ChangePassword();
			DialogResult dialogResult = changePassord.ShowDialog();
		}

		public static string FormatedDate(int nReceivedFormat)
		{
			DateTime CurrentTime = DateTime.Now;
			if (nReceivedFormat == 0) 
				return String.Format("{0,0:D2}_{1,0:D2}_{2,0:D4}_{3,0:D2}_{4,0:D2}_{5,0:D2}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year, CurrentTime.Hour, CurrentTime.Minute, CurrentTime.Second);
			else if (nReceivedFormat == 1) 
				return String.Format("{0,0:D2}.{1,0:D2}.{2,0:D4} {3,0:D2}:{4,0:D2}:{5,0:D2}", CurrentTime.Day, CurrentTime.Month, CurrentTime.Year, CurrentTime.Hour, CurrentTime.Minute, CurrentTime.Second);
			else if (nReceivedFormat == 2)
				return String.Format("{0,0:D4}-{1,0:D2}-{2,0:D2} {3,0:D2}:{4,0:D2}:{5,0:D2}", CurrentTime.Year, CurrentTime.Month, CurrentTime.Day, CurrentTime.Hour, CurrentTime.Minute, CurrentTime.Second);
			else 
				return "";
		}
		
		private void  EmptyEditBoxes()
		{
			txtUserID.Text = txtPassword.Text = "";
		}
	}
}
