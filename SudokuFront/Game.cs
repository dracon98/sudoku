using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace SudokuModel
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game : System.Windows.Forms.Form
    {
        private IContainer components;
		private System.Windows.Forms.Button btnSolve;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numSpots;
		private System.Windows.Forms.Button btnUnique;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuSaveAs;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuProject;
		private System.Windows.Forms.MenuItem menuSolve;
		private System.Windows.Forms.MenuItem menuGenerate;
		private System.Windows.Forms.MenuItem menuCheck;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuPrint;
		private System.Windows.Forms.MenuItem menuPrintPreview;
		private System.Windows.Forms.MenuItem menuPageSetup;

		private ComboBox[,] boxes;
		private System.Windows.Forms.TextBox tbHistory;
		private PrintDocument m_printDocument;

		public Game()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			boxes = new ComboBox[9,9];
            Font font = null;

			for(int x = 0; x < 9; x++)
				for(int y = 0; y < 9; y++)
				{
					ComboBox comboBox = new ComboBox();
                    if(font == null)
                        font = new Font(comboBox.Font, FontStyle.Bold);
                    comboBox.Font = font;

					String[] items = new String[]{"-","1","2","3","4","5","6","7","8","9"};
					comboBox.Items.AddRange(items);
					comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
					comboBox.Location = new Point(x*40 + 10,y*30 + 10);
					comboBox.Size = new Size(36, 21);
					comboBox.SelectedIndex = 0;
					comboBox.MaxDropDownItems = 10;
					this.Controls.Add(comboBox);
					boxes[y,x] = comboBox;
				}

			m_printDocument = new PrintDocument();
			m_printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			Pen pen = new Pen(Color.Black, 3);
			Graphics formGfx = this.CreateGraphics();

			formGfx.DrawRectangle(pen, 6,6,362,267);
			pen.Width = 1;

			Rectangle[] rects = new Rectangle[]
			{
				new Rectangle(8,8,119,86), new Rectangle(127,8,119,86), new Rectangle(246,8,121,86),
				new Rectangle(8,94,119,90), new Rectangle(127,94,119,90), new Rectangle(246,94,121,90),
				new Rectangle(8,184,119,88), new Rectangle(127,184,119,88), new Rectangle(246,184,121,88)
			};
			formGfx.DrawRectangles(pen, rects);

			pen.Dispose();
			formGfx.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numSpots = new System.Windows.Forms.NumericUpDown();
            this.btnUnique = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuPrint = new System.Windows.Forms.MenuItem();
            this.menuPrintPreview = new System.Windows.Forms.MenuItem();
            this.menuPageSetup = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuProject = new System.Windows.Forms.MenuItem();
            this.menuSolve = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuGenerate = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuCheck = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.tbHistory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSpots)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(8, 280);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve";
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(8, 344);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(104, 280);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(103, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Spots:";
            // 
            // numSpots
            // 
            this.numSpots.Location = new System.Drawing.Point(143, 344);
            this.numSpots.Maximum = new decimal(new int[] {
            81,
            0,
            0,
            0});
            this.numSpots.Minimum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numSpots.Name = "numSpots";
            this.numSpots.Size = new System.Drawing.Size(42, 20);
            this.numSpots.TabIndex = 8;
            this.numSpots.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnUnique
            // 
            this.btnUnique.Location = new System.Drawing.Point(8, 312);
            this.btnUnique.Name = "btnUnique";
            this.btnUnique.Size = new System.Drawing.Size(75, 23);
            this.btnUnique.TabIndex = 9;
            this.btnUnique.Text = "Chk unique";
            this.btnUnique.Click += new System.EventHandler(this.btnUnique_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuProject,
            this.menuHelp});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpen,
            this.menuItem7,
            this.menuSaveAs,
            this.menuItem2,
            this.menuPrint,
            this.menuPrintPreview,
            this.menuPageSetup,
            this.menuItem6,
            this.menuExit});
            this.menuFile.Text = "File";
            // 
            // menuOpen
            // 
            this.menuOpen.Index = 0;
            this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuOpen.Text = "Open...";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Index = 2;
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // menuPrint
            // 
            this.menuPrint.Index = 4;
            this.menuPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuPrint.Text = "Print...";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintPreview
            // 
            this.menuPrintPreview.Index = 5;
            this.menuPrintPreview.Text = "Print preview...";
            this.menuPrintPreview.Click += new System.EventHandler(this.menuPrintPreview_Click);
            // 
            // menuPageSetup
            // 
            this.menuPageSetup.Index = 6;
            this.menuPageSetup.Text = "Page setup...";
            this.menuPageSetup.Click += new System.EventHandler(this.menuPageSetup_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 7;
            this.menuItem6.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 8;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuProject
            // 
            this.menuProject.Index = 1;
            this.menuProject.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSolve,
            this.menuItem14,
            this.menuGenerate,
            this.menuItem16,
            this.menuCheck});
            this.menuProject.Text = "Project";
            // 
            // menuSolve
            // 
            this.menuSolve.Index = 0;
            this.menuSolve.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuSolve.Text = "Solve";
            this.menuSolve.Click += new System.EventHandler(this.menuSolve_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "-";
            // 
            // menuGenerate
            // 
            this.menuGenerate.Index = 2;
            this.menuGenerate.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.menuGenerate.Text = "Generate";
            this.menuGenerate.Click += new System.EventHandler(this.menuGenerate_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 3;
            this.menuItem16.Text = "-";
            // 
            // menuCheck
            // 
            this.menuCheck.Index = 4;
            this.menuCheck.Text = "Check uniqueness";
            this.menuCheck.Click += new System.EventHandler(this.menuCheck_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 2;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuHelp.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tbHistory
            // 
            this.tbHistory.Location = new System.Drawing.Point(192, 280);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbHistory.Size = new System.Drawing.Size(216, 88);
            this.tbHistory.TabIndex = 10;
            this.tbHistory.WordWrap = false;
            // 
            // Game
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(429, 386);
            this.Controls.Add(this.tbHistory);
            this.Controls.Add(this.btnUnique);
            this.Controls.Add(this.numSpots);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSolve);
            this.Menu = this.mainMenu1;
            this.Name = "Game";
            this.Text = "Sudoku";
            ((System.ComponentModel.ISupportInitialize)(this.numSpots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private byte[,] GetData()
		{
			byte[,] d = new byte[9,9];
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					d[y,x] = (byte)boxes[y,x].SelectedIndex;

			return d;
		}

		private void SetData(byte[,] d)
		{
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					boxes[y,x].SelectedIndex = d[y,x];
		}

		// Solve
		private void btnSolve_Click(object sender, System.EventArgs e)
		{
			Sudoku s = new Sudoku();
			byte[,] d = GetData();
			s.Data = d;

            tbHistory.AppendText("-------------------------------\r\n");
			if(!s.IsSudokuFeasible())
			{
				tbHistory.AppendText("Sudoku not feasible\r\n");
				return;
			}

            DateTime now = DateTime.Now;
			tbHistory.AppendText("Solve started: " + now.ToLongTimeString() + "\r\n");

			if(s.Solve())
			{
				// Solve successful
				tbHistory.AppendText("Solve successful\r\n");

				d = s.Data;
				SetData(d);
			}
			else
			{
				// Solve failed
				tbHistory.AppendText("Solve failed\r\n");
			}
            tbHistory.AppendText(String.Format("{0} seconds\r\n", (DateTime.Now - now).TotalSeconds));

			// Add blank
            tbHistory.AppendText("\r\n");
		}

		// Test uniqueness
		private void btnTest_Click(object sender, System.EventArgs e)
		{
			Sudoku s = new Sudoku();
			byte[,] d = GetData();
			s.Data = d;

            tbHistory.AppendText("-------------------------------\r\n");
			if(s.IsSudokuFeasible())
			{
				tbHistory.AppendText("Sudoku feasible\r\n");
			}
			else
			{
				tbHistory.AppendText("Sudoku not feasible\r\n");
			}
		}

		// Clear board
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					boxes[y,x].SelectedIndex = 0;
		}

		// Generate
		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			Sudoku s = new Sudoku();
			byte[,] d = GetData();
			s.Data = d;

			Cursor oldCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			tbHistory.AppendText("-------------------------------\r\n");
			var result = s.Generate((int)numSpots.Value);
            if(result.Item2)
			{
				tbHistory.AppendText(String.Format("Sudoku generated succesfully after {0} tries\r\n", result.Item1));
				tbHistory.AppendText("Sudoku with " + numSpots.Value + " spots\r\n");

				d = s.Data;
				SetData(d);
			}
			else
			{
                tbHistory.AppendText(String.Format("Sudoku not found after {0} tries.\r\n Press generate to try again.\r\n", result.Item1));
			}

			Cursor.Current = oldCursor;
		}

		// Check uniqueness
		private void btnUnique_Click(object sender, System.EventArgs e)
		{
			Sudoku s = new Sudoku();
			byte[,] d = GetData();
			s.Data = d;

            tbHistory.AppendText("-------------------------------\r\n");
			if(s.IsSudokuUnique())
			{
				tbHistory.AppendText("Sudoku unique\r\n");
			}
			else
			{
				tbHistory.AppendText("Sudoku not unique\r\n");
			}
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			// Show about dialog
			string message = "Copyright(c) 2005 Jörgen Pramberg";
			string caption = "About";
			MessageBox.Show(this, message, caption, MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void menuSolve_Click(object sender, System.EventArgs e)
		{
			// Solve Sudoku
			btnSolve_Click(null, null);
		}

		private void menuGenerate_Click(object sender, System.EventArgs e)
		{
			// Generate Sudoku
			btnGenerate_Click(null, null);
		}

		private void menuCheck_Click(object sender, System.EventArgs e)
		{
			// Check uniqueness
			btnUnique_Click(null, null);
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			// Load Sudoku
			Stream myStream;
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*" ;
			openDlg.FilterIndex = 1;
			openDlg.RestoreDirectory = true ;

			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				if((myStream = openDlg.OpenFile())!= null)
				{
					DataSet ds = new DataSet();
					ds.ReadXml(myStream);
					myStream.Close();
					LoadData(ds);
				}
			}

		}

		private void menuSaveAs_Click(object sender, System.EventArgs e)
		{
			// Save Sudoku as...
			Stream myStream;
			SaveFileDialog saveDlg = new SaveFileDialog();
 
			saveDlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"  ;
			saveDlg.FilterIndex = 1;
			saveDlg.RestoreDirectory = true;
 
			if(saveDlg.ShowDialog() == DialogResult.OK)
			{
				if((myStream = saveDlg.OpenFile()) != null)
				{
					DataSet ds = CreateDataSet();
					ds.WriteXml(myStream, XmlWriteMode.WriteSchema);
					myStream.Close();
				}
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			// Exit program
			Application.Exit();
		}

		private void LoadData(DataSet ds)
		{
			DataRowCollection rows = ds.Tables[0].Rows;

			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
					boxes[y,x].SelectedIndex = (byte)rows[y*9+x][0];
		}

		private DataSet CreateDataSet()
		{
			DataSet ds = new DataSet();
			DataTable dt = ds.Tables.Add();
			dt.Columns.Add("spot", typeof(byte));
			object[] val = new object[1];

			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
				{
					val[0] = (byte)boxes[y,x].SelectedIndex;
					dt.Rows.Add(val);
				}

			return ds;
		}

		private void menuPrint_Click(object sender, System.EventArgs e)
		{
			PrintDialog pd = new PrintDialog();
			pd.AllowSelection = false;
			pd.Document = m_printDocument;
			if(pd.ShowDialog(this) == DialogResult.OK)
			{
				// Print page
				Print(pd.Document);
			}
		}

		private void menuPrintPreview_Click(object sender, System.EventArgs e)
		{
			PrintPreviewDialog ppd = new PrintPreviewDialog();
			ppd.Document = m_printDocument;
			ppd.ShowDialog();
		}

		private void menuPageSetup_Click(object sender, System.EventArgs e)
		{
			PageSetupDialog psd = new PageSetupDialog();
			psd.Document = m_printDocument;
			psd.ShowDialog();
		}

		private void Print(System.Drawing.Printing.PrintDocument doc)
		{
			doc.DocumentName = "Sudoku - " + DateTime.Now.ToLongTimeString();
			doc.Print();
		}

		// The PrintPage event is raised for each page to be printed.
		private void PrintPage(object sender, PrintPageEventArgs ev) 
		{
			float yPos = 0;
			float xPos = 0;
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top;
			Font printFont = new Font("Arial", (ev.MarginBounds.Right - ev.MarginBounds.Left) / 18);
			float width = ev.Graphics.MeasureString("M", printFont).Width;
			float height = printFont.Height;

			// Center
			leftMargin += ((ev.MarginBounds.Right - ev.MarginBounds.Left) - width * 9) / 2;
			topMargin += ((ev.MarginBounds.Bottom - ev.MarginBounds.Top) - height * 9) / 2;

			byte[,] d = GetData();

			for(int y = 0; y < 9; y++)
				for(int x = 0; x < 9; x++)
				{
					// Draw symbols
					if(d[y,x] == 0)
						continue;

					string symbol = new String((char)(d[y,x] + '0'), 1);

					xPos = leftMargin + x * width;
					yPos = topMargin + y * height;
					ev.Graphics.DrawString(symbol, printFont, Brushes.Black, xPos, yPos);
				}

			Pen penBlack = new Pen(Color.Black,5);
			Pen penGray = new Pen(Color.Black, 1);

			// Draw lines
			for(int x = 0; x < 10; x++)
			{
				if(x % 3 == 0)
					ev.Graphics.DrawLine(penBlack, leftMargin+x*width, topMargin, leftMargin+x*width, topMargin+9*height);
				else
					ev.Graphics.DrawLine(penGray, leftMargin+x*width, topMargin, leftMargin+x*width, topMargin+9*height);
			}

			// Draw lines
			for(int y = 0; y < 10; y++)
			{
				if(y % 3 == 0)
					ev.Graphics.DrawLine(penBlack, leftMargin, topMargin+y*height, leftMargin+9*width, topMargin+y*height);
				else
					ev.Graphics.DrawLine(penGray, leftMargin, topMargin+y*height, leftMargin+9*width, topMargin+y*height);
			}

			printFont.Dispose();

			// Print header
			printFont = new Font("Arial", 10);
			xPos = (float)ev.MarginBounds.Left;
			yPos = (float)ev.MarginBounds.Top;
			ev.Graphics.DrawString("Sudoku created: " + DateTime.Now.ToShortDateString(), printFont, Brushes.Black, xPos, yPos);
			printFont.Dispose();

			penBlack.Dispose();
			penGray.Dispose();

			ev.HasMorePages = false;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Game());
		}

	}
}
