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
            _client.Eror += ClientOnEror;
            InitializeComponent();
        }

        private static void ClientOnEror(Exception exception)
        {
            ShowErrorAlert(exception.Message);
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
            NavigatetoLocalPath(CurrentLocalPath);
        }

        private void NavigatetoLocalPath(string path)
        {
            try
            {
                var items = _fsHelper.GetFolderContent(path);
                PopulateFilesList(localFilesList, items);
                CurrentLocalPath = path;
            }
            catch (Exception exception)
            {
                ShowErrorAlert(exception.Message);
            }
        }
        private void NavigatetoRemotePath(string path)
        {
            try
            {
                _client.GetDirectoryListing(path);
            }
            catch (Exception exception)
            {
                ShowErrorAlert(exception.Message);
            }
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
                _client.ListingDirectoryReceived += ClientOnFirstListingDirectoryReceived;
                topToolStrip.Enabled = false;
                remoteFilesList.Items.Clear();
                remoteFilesList.Enabled = false;
                _client.GetDirectoryListing();
            }
            catch (Exception exception)
            {
                ShowErrorAlert(exception.Message);
            }
            
        }

        private void ClientOnFirstListingDirectoryReceived(List<FileSystemItem> fileSystemItems, string s)
        {
            _client.ListingDirectoryReceived -= ClientOnFirstListingDirectoryReceived;
            CurrentRemotePath = string.Empty;
            topToolStrip.BeginInvoke(new Action(() =>
            {
                topToolStrip.Enabled = true;
                disconnectButton.Visible = true;
                connectButton.Visible = false;
            }));

            remoteFilesList.BeginInvoke(new Action(() => remoteFilesList.Enabled = true));
        }


        private void disconnectButton_Click(object sender, EventArgs e)
        {
            var confirmResult =  MessageBox.Show(Resources.DisconnectConfirmation_Text, Resources.DisconnectConfirmation_Header, MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes) return;
            passwordTextBox.Text = string.Empty;
            disconnectButton.Visible = false;
            connectButton.Visible = true;
            remoteFilesList.Items.Clear();
        }

        private static void ShowErrorAlert(string message)
        {
            MessageBox.Show(message, Resources.ErrorAlert_Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void localFilesList_DoubleClick(object sender, EventArgs e)
        {
            var tag = GetListViewFileItem(sender);
            if (tag == null) return;
            if (tag.IsParentNavigation)
            {
                NavigatetoLocalPath(Directory.GetParent(CurrentLocalPath).FullName);
            }
            else if (tag.IsDirectory)
            {
                NavigatetoLocalPath(Path.Combine(CurrentLocalPath, tag.Name));
            }
        }

        private static FileSystemItem GetListViewFileItem(object sender)
        {
            var listView = sender as ListView;
            if (listView == null) return null;
            if (listView.SelectedItems.Count <= 0) return null;
            var item = listView.SelectedItems[0];
            return item.Tag as FileSystemItem;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appSettings.LatestLocalPath = CurrentLocalPath;
            _appSettings.LatestServerUri = serverUriTextBox.Text;
            _appSettings.LatestUsername = userNameTextBox.Text;
            _appSettings.Save();
        }

        private void remoteFilesList_DoubleClick(object sender, EventArgs e)
        {
            var tag = GetListViewFileItem(sender);
            if (tag == null) return;
            if (tag.IsParentNavigation)
            {
                NavigatetoLocalPath(Directory.GetParent(CurrentLocalPath).FullName);
            }
            else if (tag.IsDirectory)
            {
                NavigatetoLocalPath(Path.Combine(CurrentLocalPath, tag.Name));
            }
        }
    }
}
