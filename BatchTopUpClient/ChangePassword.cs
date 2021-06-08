using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for ChangePassword.
	/// </summary>
	public class ChangePassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblUserID;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.Label lblOldPassword;
		private System.Windows.Forms.Label lblNewPassword;
		private System.Windows.Forms.TextBox txtOldPassword;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.TextBox txtVerifyNewPassword;
		private System.Windows.Forms.Label lblVerifyNewPassword;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChangePassword()
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
            this.lblUserID = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtVerifyNewPassword = new System.Windows.Forms.TextBox();
            this.lblVerifyNewPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(88, 64);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(128, 20);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "UserID";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(104, 272);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(224, 64);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 3;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Location = new System.Drawing.Point(88, 112);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(128, 20);
            this.lblOldPassword.TabIndex = 4;
            this.lblOldPassword.Text = "Old password";
            this.lblOldPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new System.Drawing.Point(88, 160);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(128, 20);
            this.lblNewPassword.TabIndex = 6;
            this.lblNewPassword.Text = "New password";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(224, 112);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(100, 20);
            this.txtOldPassword.TabIndex = 7;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(224, 160);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNewPassword.TabIndex = 8;
            // 
            // txtVerifyNewPassword
            // 
            this.txtVerifyNewPassword.Location = new System.Drawing.Point(224, 208);
            this.txtVerifyNewPassword.Name = "txtVerifyNewPassword";
            this.txtVerifyNewPassword.PasswordChar = '*';
            this.txtVerifyNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtVerifyNewPassword.TabIndex = 9;
            // 
            // lblVerifyNewPassword
            // 
            this.lblVerifyNewPassword.Location = new System.Drawing.Point(88, 208);
            this.lblVerifyNewPassword.Name = "lblVerifyNewPassword";
            this.lblVerifyNewPassword.Size = new System.Drawing.Size(128, 20);
            this.lblVerifyNewPassword.TabIndex = 10;
            this.lblVerifyNewPassword.Text = "Verify new password";
            this.lblVerifyNewPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ChangePassword
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(408, 382);
            this.Controls.Add(this.lblVerifyNewPassword);
            this.Controls.Add(this.txtVerifyNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblUserID);
            this.Name = "ChangePassword";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private SqlDataAdapter daUser;
		private DataSet dsUser;

		private void ChangePassword_Load(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User entered into 'Change Password' form at {0}", LogIn.FormatedDate(1));
			this.Text = "Change Password";
			dsUser = new DataSet();
			LoadUserTable();
			daUser.Fill(dsUser, "UserTable");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			LogIn.foutLogFile.WriteLine("User pressed 'Cancel' button ('Change Password form')at {0}", LogIn.FormatedDate(1));
			this.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				LogIn.foutLogFile.WriteLine("User pressed 'OK' button ('Change Password' form) at {0}", LogIn.FormatedDate(1));
				int index;
				index = txtUserID.Text.IndexOf("'");
				String message, error;
				error = "Error!";
				if (index != -1)
				{
					message = "The user does not exist";
					error = "Error!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The user does not exist)", LogIn.FormatedDate(1));
					return;
				}

				UnicodeEncoding unicode = new UnicodeEncoding();
				byte [] btOldPassword = ASCIIEncoding.ASCII.GetBytes(txtOldPassword.Text);
				MD5 md5 = new MD5CryptoServiceProvider();
				String szOldPassword = unicode.GetString(md5.ComputeHash(btOldPassword));
				
				byte [] btNewPassword = ASCIIEncoding.ASCII.GetBytes(txtNewPassword.Text);
				md5 = new MD5CryptoServiceProvider();
				String szNewPassword = unicode.GetString(md5.ComputeHash(btNewPassword));

				DataRow [] dr = dsUser.Tables["UserTable"].Select("UserName = '" + txtUserID.Text + "'");
				if (dr.Length == 0)
				{
					message = "The user does not exist!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The user does not exist)", LogIn.FormatedDate(1));
					return;
				}

				index = txtOldPassword.Text.IndexOf("'");
				if (index != -1)
				{
					message = "Old password and new password are the same";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
					LogIn.foutLogFile.WriteLine("Error in changing password at {0} (The old and the new password are the same)", LogIn.FormatedDate(1));
					return;
				}

				if (String.CompareOrdinal(szOldPassword, dr[0]["Password"].ToString()) != 0)
				{
					message = "Old password is wrong!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The old password is wrong)", LogIn.FormatedDate(1));
					EmptyEditBoxes();
					return;
				}

				index = txtNewPassword.Text.IndexOf("'");
				if (index != -1)
				{
                    message = "Old password is wrong!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The old password is wrong)", LogIn.FormatedDate(1));
					EmptyEditBoxes();
					return;
				}

				if (txtOldPassword.Text == "" || txtNewPassword.Text == "")
				{
					message = "New password or old password are empty!Fjalekalimi i ri ose  i vjeter jane te zbrazet";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The old or new password are empty)", LogIn.FormatedDate(1));
					EmptyEditBoxes();
					return;
				}
																			  
				if (txtOldPassword.Text == txtNewPassword.Text)
				{
					message = "Old password and new password are the same!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					EmptyEditBoxes();
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The old and the new password are the same)", LogIn.FormatedDate(1));
					return;
				}

				if (txtVerifyNewPassword.Text != txtNewPassword.Text)
				{
					message = "New password an verifying passorda are not the same!";
					MessageBox.Show(message, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
					LogIn.foutLogFile.WriteLine("Error in changing pasword at {0} (The new and the verifying password are not the same)", LogIn.FormatedDate(1));
					EmptyEditBoxes();
					return;
				}

				dr[0]["Password"] = szNewPassword;
				dr[0]["FirstTimeEntrance"] = 1;
				LogIn.foutLogFile.WriteLine("Passord changed successfuly at {0}", LogIn.FormatedDate(1));
				daUser.Update(dsUser, "UserTable");
				dsUser.AcceptChanges();
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				LogIn.foutLogFile.WriteLine("There was an exception: {0} at {0}", ex.Message, LogIn.FormatedDate(1));
				dsUser.RejectChanges();
			}
		}

		private void EmptyEditBoxes()
		{
			txtUserID.Text = txtOldPassword.Text = txtNewPassword.Text = txtVerifyNewPassword.Text = "";
		}

		private void LoadUserTable()
		{
			SqlCommand cmdUserTableSelect = LogIn.conn.CreateCommand();
			cmdUserTableSelect.CommandType = CommandType.Text;
			cmdUserTableSelect.CommandText = "select * from UserTable";
			daUser = new SqlDataAdapter();
			
			SqlCommand cmdUserTableUpdate = LogIn.conn.CreateCommand();
			cmdUserTableUpdate.CommandType = CommandType.Text;
			cmdUserTableUpdate.CommandText = "Update UserTable Set UserName = @UserName, Password = @Password, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, RoleID = @RoleID,RegionID = @RegionID, PostalID = @PostalID, LastEndOfDayDate = @LastEndOfDayDate, FirstTimeEntrance = @FirstTimeEntrance where UserTableID = @UserTableID";
			cmdUserTableUpdate.Parameters.Add("@UserTableID", SqlDbType.Int, 4, "UserTableID");
			cmdUserTableUpdate.Parameters.Add("@UserName", SqlDbType.NVarChar, 30, "UserName");
			cmdUserTableUpdate.Parameters.Add("@Password", SqlDbType.NVarChar, 30, "Password");
			cmdUserTableUpdate.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
            cmdUserTableUpdate.Parameters.Add("@LastName", SqlDbType.NVarChar, 30, "LastName");
			cmdUserTableUpdate.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 8, "DateOfBirth");
			cmdUserTableUpdate.Parameters.Add("@RoleID", SqlDbType.Int, 4, "RoleID");
			cmdUserTableUpdate.Parameters.Add("@RegionID", SqlDbType.Int, 4, "RegionID");
			cmdUserTableUpdate.Parameters.Add("@PostalID", SqlDbType.Int, 4, "PostalID");
			cmdUserTableUpdate.Parameters.Add("@LastEndOfDayDate", SqlDbType.DateTime, 8, "LastEndOfDayDate");
			cmdUserTableUpdate.Parameters.Add("@FirstTimeEntrance", SqlDbType.Int, 4, "FirstTimeEntrance");

			cmdUserTableUpdate.Parameters["@UserTableID"].SourceVersion = DataRowVersion.Original;

			daUser.SelectCommand = cmdUserTableSelect;
			daUser.UpdateCommand = cmdUserTableUpdate;
		}
	}
}
