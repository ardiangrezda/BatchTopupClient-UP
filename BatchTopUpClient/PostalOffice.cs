using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BatchTopUpClient
{
	/// <summary>
	/// Summary description for PostalOffice.
	/// </summary>
	public class PostalOffice : System.Windows.Forms.Form
	{
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter2;
		private BatchTopUpClient.dsPostalOffice objdsPostalOffice;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnCancelAll;
		private System.Windows.Forms.DataGrid grdPostalOffice;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PostalOffice()
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
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.objdsPostalOffice = new BatchTopUpClient.dsPostalOffice();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.grdPostalOffice = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.objdsPostalOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostalOffice)).BeginInit();
            this.SuspendLayout();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT PostalID, PostalDesc, RegionID FROM PostalOffice";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLOLEDB.1;Data Source=XXXXXX\\SQLEXPRESS;Persist Security Info=False;" +
    "Integrated Security=SSPI;Initial Catalog=BatchTopUp";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [PostalOffice] ([PostalID], [PostalDesc], [RegionID]) VALUES (?, ?, ?" +
    ")";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("PostalID", System.Data.OleDb.OleDbType.Integer, 0, "PostalID"),
            new System.Data.OleDb.OleDbParameter("PostalDesc", System.Data.OleDb.OleDbType.VarWChar, 0, "PostalDesc"),
            new System.Data.OleDb.OleDbParameter("RegionID", System.Data.OleDb.OleDbType.Integer, 0, "RegionID")});
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PostalOffice", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("PostalID", "PostalID"),
                        new System.Data.Common.DataColumnMapping("PostalDesc", "PostalDesc"),
                        new System.Data.Common.DataColumnMapping("RegionID", "RegionID")})});
            // 
            // oleDbDataAdapter2
            // 
            this.oleDbDataAdapter2.DeleteCommand = this.oleDbDeleteCommand2;
            this.oleDbDataAdapter2.InsertCommand = this.oleDbInsertCommand2;
            this.oleDbDataAdapter2.SelectCommand = this.oleDbSelectCommand2;
            this.oleDbDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Region", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("RegionID", "RegionID"),
                        new System.Data.Common.DataColumnMapping("RegionDescription", "RegionDescription")})});
            this.oleDbDataAdapter2.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM Region WHERE (RegionID = ?) AND (RegionDescription = ? OR ? IS NULL A" +
    "ND RegionDescription IS NULL)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_RegionID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RegionDescription", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RegionDescription1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionDescription", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO Region(RegionID, RegionDescription) VALUES (?, ?); SELECT RegionID, R" +
    "egionDescription FROM Region WHERE (RegionID = ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("RegionID", System.Data.OleDb.OleDbType.Integer, 4, "RegionID"),
            new System.Data.OleDb.OleDbParameter("RegionDescription", System.Data.OleDb.OleDbType.VarWChar, 50, "RegionDescription"),
            new System.Data.OleDb.OleDbParameter("Select_RegionID", System.Data.OleDb.OleDbType.Integer, 4, "RegionID")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT RegionID, RegionDescription FROM Region";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("RegionID", System.Data.OleDb.OleDbType.Integer, 4, "RegionID"),
            new System.Data.OleDb.OleDbParameter("RegionDescription", System.Data.OleDb.OleDbType.VarWChar, 50, "RegionDescription"),
            new System.Data.OleDb.OleDbParameter("Original_RegionID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RegionDescription", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RegionDescription1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RegionDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Select_RegionID", System.Data.OleDb.OleDbType.Integer, 4, "RegionID")});
            // 
            // objdsPostalOffice
            // 
            this.objdsPostalOffice.DataSetName = "dsPostalOffice";
            this.objdsPostalOffice.Locale = new System.Globalization.CultureInfo("en-GB");
            this.objdsPostalOffice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(472, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(472, 40);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAll.TabIndex = 2;
            this.btnCancelAll.Text = "Ca&ncel All";
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // grdPostalOffice
            // 
            this.grdPostalOffice.DataMember = "PostalOffice";
            this.grdPostalOffice.DataSource = this.objdsPostalOffice;
            this.grdPostalOffice.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPostalOffice.Location = new System.Drawing.Point(32, 96);
            this.grdPostalOffice.Name = "grdPostalOffice";
            this.grdPostalOffice.PreferredColumnWidth = 90;
            this.grdPostalOffice.Size = new System.Drawing.Size(534, 348);
            this.grdPostalOffice.TabIndex = 3;
            // 
            // PostalOffice
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 478);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.grdPostalOffice);
            this.Name = "PostalOffice";
            this.Text = "Postal Office";
            this.Load += new System.EventHandler(this.PostalOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objdsPostalOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostalOffice)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void FillDataSet(BatchTopUpClient.dsPostalOffice dataSet)
		{
			// Turn off constraint checking before the dataset is filled.
			// This allows the adapters to fill the dataset without concern
			// for dependencies between the tables.
			dataSet.EnforceConstraints = false;
			try 
			{
				// Open the connection.
				this.oleDbConnection1.Open();
				// Attempt to fill the dataset through the OleDbDataAdapter1.
				this.oleDbDataAdapter1.Fill(dataSet);
				this.oleDbDataAdapter2.Fill(dataSet);
			}
			catch (System.Exception fillException) 
			{
				// Add your error handling code here.
				throw fillException;
			}
			finally 
			{
				// Turn constraint checking back on.
				dataSet.EnforceConstraints = true;
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void UpdateDataSource(BatchTopUpClient.dsPostalOffice ChangedRows)
		{
			try 
			{
				// The data source only needs to be updated if there are changes pending.
				if ((ChangedRows != null)) 
				{
					// Open the connection.
					this.oleDbConnection1.Open();
					// Attempt to update the data source.
					oleDbDataAdapter1.Update(ChangedRows);
					oleDbDataAdapter2.Update(ChangedRows);
				}
			}
			catch (System.Exception updateException) 
			{
				// Add your error handling code here.
				throw updateException;
			}
			finally 
			{
				// Close the connection whether or not the exception was thrown.
				this.oleDbConnection1.Close();
			}

		}

		public void LoadDataSet()
		{
			// Create a new dataset to hold the records returned from the call to FillDataSet.
			// A temporary dataset is used because filling the existing dataset would
			// require the databindings to be rebound.
			BatchTopUpClient.dsPostalOffice objDataSetTemp;
			objDataSetTemp = new BatchTopUpClient.dsPostalOffice();
			try 
			{
				// Attempt to fill the temporary dataset.
				this.FillDataSet(objDataSetTemp);
			}
			catch (System.Exception eFillDataSet) 
			{
				// Add your error handling code here.
				throw eFillDataSet;
			}
			try 
			{
				grdPostalOffice.DataSource = null;
				// Empty the old records from the dataset.
				objdsPostalOffice.Clear();
				// Merge the records into the main dataset.
				objdsPostalOffice.Merge(objDataSetTemp);
				grdPostalOffice.SetDataBinding(objdsPostalOffice, "PostalOffice");
			}
			catch (System.Exception eLoadMerge) 
			{
				// Add your error handling code here.
				throw eLoadMerge;
			}

		}

		public void UpdateDataSet()
		{
			// Create a new dataset to hold the changes that have been made to the main dataset.
			BatchTopUpClient.dsPostalOffice objDataSetChanges = new BatchTopUpClient.dsPostalOffice();
			// Stop any current edits.
			this.BindingContext[objdsPostalOffice,"PostalOffice"].EndCurrentEdit();
			// Get the changes that have been made to the main dataset.
			objDataSetChanges = ((BatchTopUpClient.dsPostalOffice)(objdsPostalOffice.GetChanges()));
			// Check to see if any changes have been made.
			if ((objDataSetChanges != null)) 
			{
				try 
				{
					// There are changes that need to be made, so attempt to update the datasource by
					// calling the update method and passing the dataset and any parameters.
					this.UpdateDataSource(objDataSetChanges);
					objdsPostalOffice.Merge(objDataSetChanges);
					objdsPostalOffice.AcceptChanges();
				}
				catch (System.Exception eUpdate) 
				{
					// Add your error handling code here.
					throw eUpdate;
				}
				// Add your code to check the returned dataset for any errors that may have been
				// pushed into the row object's error.
			}

		}

		private void btnCancelAll_Click(object sender, System.EventArgs e)
		{
			this.objdsPostalOffice.RejectChanges();
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			try 
			{
				// Attempt to load the dataset.
				this.LoadDataSet();
			}
			catch (System.Exception eLoad) 
			{
				// Add your error handling code here.
				// Display error message, if any.
				System.Windows.Forms.MessageBox.Show(eLoad.Message);
			}

		}

		private void PostalOffice_Load(object sender, System.EventArgs e)
		{
			try 
			{
				// Attempt to load the dataset.
				this.LoadDataSet();
			}
			catch (System.Exception eLoad) 
			{
				// Add your error handling code here.
				// Display error message, if any.
				System.Windows.Forms.MessageBox.Show(eLoad.Message);
			}
		}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDataSet();
        }
	}
}
