using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SimpleFTP.Core.FileSystem;
using SimpleFTP.Core.Ftp;
using SimpleFTP.Properties;

namespace SimpleFTP
{
    public partial class MainWindow : Form
    {
        
        private static string CurrentLocalPath { get; set; }
        private static string CurrentRemotePath { get; set; }

        private readonly IFtpClient _client;
        private readonly IFileSystemHelper _fsHelper;

        private bool _isConnected;

        public MainWindow()
        {
            _fsHelper = AppConfigurator.Instance.Resolve<IFileSystemHelper>();
            _client = AppConfigurator.Instance.Resolve<IFtpClient>();
            _client.ListingDirectoryReceived += ClientOnListingDirectoryReceived;
            CurrentLocalPath = AppDomain.CurrentDomain.BaseDirectory;

            InitializeComponent();
        }

        private void ClientOnListingDirectoryReceived(List<FilySystemItem> filySystemItems, string path)
        {
            CurrentRemotePath = path;
            remoteFilesList.BeginInvoke(new Action<ListView, IEnumerable<FilySystemItem>>(PopulateFilesList),
                remoteFilesList, filySystemItems);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            PopulateLocalFilesFromCurrentPath();
        }

        private void PopulateLocalFilesFromCurrentPath()
        {
            var items = _fsHelper.GetFolderContent(CurrentLocalPath);

            PopulateFilesList(localFilesList, items);
        }

        private static void PopulateFilesList(ListView listview, IEnumerable<FilySystemItem> items)
        {
            listview.Items.Clear();
            foreach (var item in items)
            {
                if (item.IsDirectory)
                {
                    listview.Items.Add(new ListViewItem(new[] { string.Format("[{0}]", item.Name) }, string.Empty,
                        DefaultForeColor, Color.Aquamarine, DefaultFont));
                }
                else
                {
                    listview.Items.Add(new ListViewItem(new[] { item.Name, item.Extension, item.Size }, string.Empty,
                        DefaultForeColor, Color.Azure, DefaultFont));
                }
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                _client.Connect(userNameTextBox.Text, passwordTextBox.Text, serverUriTextBox.Text);
                _client.GetDirectoryListing();
                disconnectButton.Visible = true;
                connectButton.Visible = false;
            }
            catch (Exception exception)
            {
                ShowErrorAlert(exception.Message);
            }
            
        }

        private static void ShowErrorAlert(string message)
        {
            MessageBox.Show(message, Resources.ErrorAlert_Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            var confirmResult =  MessageBox.Show(Resources.DisconnectConfirmation_Text, Resources.DisconnectConfirmation_Header, MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes) return;
            userNameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            serverUriTextBox.Text = string.Empty;
            disconnectButton.Visible = false;
            connectButton.Visible = true;
            remoteFilesList.Items.Clear();
        }
    }
}
