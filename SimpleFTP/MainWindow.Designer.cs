namespace SimpleFTP
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.localFilesList = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.extensionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remoteFilesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloadBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.transferProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.transferProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.transferRateLabelText = new System.Windows.Forms.ToolStripStatusLabel();
            this.transferRateValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.estimatedTimeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.estimatedTimeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.sytesTransveredTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.bytesTransfferedValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.serverUriTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.userNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.passwordTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.connectButton = new System.Windows.Forms.ToolStripButton();
            this.disconnectButton = new System.Windows.Forms.ToolStripButton();
            this.mainLayout.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.ColumnCount = 3;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.mainLayout.Controls.Add(this.localFilesList, 0, 0);
            this.mainLayout.Controls.Add(this.remoteFilesList, 2, 0);
            this.mainLayout.Controls.Add(this.downloadBtn, 1, 0);
            this.mainLayout.Location = new System.Drawing.Point(0, 25);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(730, 317);
            this.mainLayout.TabIndex = 1;
            // 
            // localFilesList
            // 
            this.localFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localFilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.extensionColumn,
            this.sizeColumn});
            this.localFilesList.FullRowSelect = true;
            this.localFilesList.GridLines = true;
            this.localFilesList.Location = new System.Drawing.Point(3, 3);
            this.localFilesList.Name = "localFilesList";
            this.localFilesList.Size = new System.Drawing.Size(300, 311);
            this.localFilesList.TabIndex = 0;
            this.localFilesList.UseCompatibleStateImageBehavior = false;
            this.localFilesList.View = System.Windows.Forms.View.Details;
            this.localFilesList.DoubleClick += new System.EventHandler(this.localFilesList_DoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 160;
            // 
            // extensionColumn
            // 
            this.extensionColumn.Text = "Ext";
            this.extensionColumn.Width = 50;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            this.sizeColumn.Width = 50;
            // 
            // remoteFilesList
            // 
            this.remoteFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteFilesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.remoteFilesList.FullRowSelect = true;
            this.remoteFilesList.GridLines = true;
            this.remoteFilesList.Location = new System.Drawing.Point(425, 3);
            this.remoteFilesList.Name = "remoteFilesList";
            this.remoteFilesList.Size = new System.Drawing.Size(302, 311);
            this.remoteFilesList.TabIndex = 1;
            this.remoteFilesList.UseCompatibleStateImageBehavior = false;
            this.remoteFilesList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ext";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 50;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(316, 20);
            this.downloadBtn.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(96, 23);
            this.downloadBtn.TabIndex = 2;
            this.downloadBtn.Text = "<< Download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferProgressBar,
            this.transferProgressLabel,
            this.transferRateLabelText,
            this.transferRateValue,
            this.estimatedTimeText,
            this.estimatedTimeValue,
            this.sytesTransveredTest,
            this.bytesTransfferedValue});
            this.statusStrip.Location = new System.Drawing.Point(0, 342);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(730, 24);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // transferProgressBar
            // 
            this.transferProgressBar.Name = "transferProgressBar";
            this.transferProgressBar.Size = new System.Drawing.Size(100, 18);
            this.transferProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.transferProgressBar.ToolTipText = "Transfer progress";
            this.transferProgressBar.Value = 100;
            // 
            // transferProgressLabel
            // 
            this.transferProgressLabel.Name = "transferProgressLabel";
            this.transferProgressLabel.Size = new System.Drawing.Size(35, 19);
            this.transferProgressLabel.Text = "100%";
            // 
            // transferRateLabelText
            // 
            this.transferRateLabelText.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.transferRateLabelText.Name = "transferRateLabelText";
            this.transferRateLabelText.Size = new System.Drawing.Size(80, 19);
            this.transferRateLabelText.Text = "Transfer rate:";
            this.transferRateLabelText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // transferRateValue
            // 
            this.transferRateValue.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.transferRateValue.Name = "transferRateValue";
            this.transferRateValue.Size = new System.Drawing.Size(56, 19);
            this.transferRateValue.Text = "125 Kb/s";
            this.transferRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // estimatedTimeText
            // 
            this.estimatedTimeText.Name = "estimatedTimeText";
            this.estimatedTimeText.Size = new System.Drawing.Size(60, 19);
            this.estimatedTimeText.Text = "Time Left:";
            this.estimatedTimeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // estimatedTimeValue
            // 
            this.estimatedTimeValue.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.estimatedTimeValue.Name = "estimatedTimeValue";
            this.estimatedTimeValue.Size = new System.Drawing.Size(42, 19);
            this.estimatedTimeValue.Text = "0m 0s";
            this.estimatedTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sytesTransveredTest
            // 
            this.sytesTransveredTest.Name = "sytesTransveredTest";
            this.sytesTransveredTest.Size = new System.Drawing.Size(66, 19);
            this.sytesTransveredTest.Text = "Transfered:";
            this.sytesTransveredTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bytesTransfferedValue
            // 
            this.bytesTransfferedValue.Name = "bytesTransfferedValue";
            this.bytesTransfferedValue.Size = new System.Drawing.Size(62, 19);
            this.bytesTransfferedValue.Text = "1024 bytes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.serverUriTextBox,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.userNameTextBox,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.passwordTextBox,
            this.toolStripSeparator3,
            this.connectButton,
            this.disconnectButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel2.Text = "Server: ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "ftp://";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverUriTextBox
            // 
            this.serverUriTextBox.Name = "serverUriTextBox";
            this.serverUriTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel3.Text = "Username:";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel4.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // connectButton
            // 
            this.connectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectButton.Image = ((System.Drawing.Image)(resources.GetObject("connectButton.Image")));
            this.connectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(56, 22);
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.disconnectButton.Image = ((System.Drawing.Image)(resources.GetObject("disconnectButton.Image")));
            this.disconnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(70, 22);
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 366);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainLayout);
            this.Name = "MainWindow";
            this.Text = "Simple FTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainLayout.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListView localFilesList;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader extensionColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ListView remoteFilesList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.ToolStripProgressBar transferProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel transferProgressLabel;
        private System.Windows.Forms.ToolStripStatusLabel transferRateLabelText;
        private System.Windows.Forms.ToolStripStatusLabel transferRateValue;
        private System.Windows.Forms.ToolStripStatusLabel estimatedTimeText;
        private System.Windows.Forms.ToolStripStatusLabel estimatedTimeValue;
        private System.Windows.Forms.ToolStripStatusLabel sytesTransveredTest;
        private System.Windows.Forms.ToolStripStatusLabel bytesTransfferedValue;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox serverUriTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox userNameTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox passwordTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton connectButton;
        private System.Windows.Forms.ToolStripButton disconnectButton;
    }
}

