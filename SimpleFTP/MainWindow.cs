using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SimpleFTP.Core.FileSystem;
using SimpleFTP.Core.Ftp;
using SimpleFTP.Properties;

namespace SimpleFTP
{
    public partial class MainWindow : Form
    {
        private const string ParentDirectory = "..";
        private static string CurrentLocalPath { get; set; }
        private static string CurrentRemotePath { get; set; }

        private readonly IFtpClient _client;
        private readonly IFileSystemHelper _fsHelper;
        private readonly Settings _appSettings;

        public MainWindow()
        {
            _fsHelper = AppConfigurator.Instance.Resolve<IFileSystemHelper>();
            _client = AppConfigurator.Instance.Resolve<IFtpClient>();
            _appSettings = Settings.Default;
            _client.ListingDirectoryReceived += ClientOnListingDirectoryReceived;
            
            InitializeComponent();
        }

        private void ClientOnListingDirectoryReceived(List<FileSystemItem> items, string path)
        {
            CurrentRemotePath = path;
            remoteFilesList.BeginInvoke(new Action<ListView, IEnumerable<FileSystemItem>>(PopulateFilesList),
                remoteFilesList, items);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            CurrentLocalPath = Directory.Exists(_appSettings.LatestLocalPath)
                ? _appSettings.LatestLocalPath
                : _fsHelper.TrimPath(AppDomain.CurrentDomain.BaseDirectory);
            serverUriTextBox.Text = _appSettings.LatestServerUri;
            userNameTextBox.Text = _appSettings.LatestUsername;
            PopulateLocalFilesFromCurrentPath(CurrentLocalPath);
        }

        private void PopulateLocalFilesFromCurrentPath(string path)
        {
            CurrentLocalPath = path;
            var items = _fsHelper.GetFolderContent(CurrentLocalPath);
            PopulateFilesList(localFilesList, items);
        }

        private static void PopulateFilesList(ListView listview, IEnumerable<FileSystemItem> items)
        {
            listview.Items.Clear();
            foreach (var item in items)
            {
                if (item.IsParentNavigation)
                {
                    listview.Items.Add(new ListViewItem(new[] { ".." }) { BackColor = Color.Azure, Tag = item });
                }
                else if (item.IsDirectory)
                {
                    listview.Items.Add(new ListViewItem(new[] { string.Format("[{0}]", item.Name) }) {  BackColor = Color.AliceBlue, Tag = item });
                }
                else
                {
                    listview.Items.Add(new ListViewItem(new[] { item.Name, item.Extension, item.Size }) { Tag = item });
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
            CurrentRemotePath = string.Empty;
        }

        private void localFilesList_DoubleClick(object sender, EventArgs e)
        {
            if (localFilesList.SelectedItems.Count <= 0) return;
            var item = localFilesList.SelectedItems[0];
            var tag = item.Tag as FileSystemItem;
            if (tag == null) return;
            if (tag.IsParentNavigation)
            {
                PopulateLocalFilesFromCurrentPath(Directory.GetParent(CurrentLocalPath).FullName);
            }
            else if (tag.IsDirectory)
            {
                PopulateLocalFilesFromCurrentPath(Path.Combine(CurrentLocalPath, tag.Name));
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appSettings.LatestLocalPath = CurrentLocalPath;
            _appSettings.LatestServerUri = serverUriTextBox.Text;
            _appSettings.LatestUsername = userNameTextBox.Text;
            _appSettings.Save();
        }
    }
}
