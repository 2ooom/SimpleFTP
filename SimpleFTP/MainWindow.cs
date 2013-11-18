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

        private bool _isConnected;

        public MainWindow()
        {
            _fsHelper = AppConfigurator.Instance.Resolve<IFileSystemHelper>();
            _client = AppConfigurator.Instance.Resolve<IFtpClient>();
            _client.ListingDirectoryReceived += ClientOnListingDirectoryReceived;
            CurrentLocalPath = AppDomain.CurrentDomain.BaseDirectory;
            if (CurrentLocalPath.EndsWith("/") || CurrentLocalPath.EndsWith("\\"))
            {
                CurrentLocalPath = CurrentLocalPath.Substring(0, CurrentLocalPath.Length - 1);
            }
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
            PopulateLocalFilesFromCurrentPath();
        }

        private void PopulateLocalFilesFromCurrentPath()
        {
            var items = _fsHelper.GetFolderContent(CurrentLocalPath);

            if (Directory.GetParent(CurrentLocalPath) != null)
            {
                items.Insert(0, new FileSystemItem { IsParentNavigation = true, Name = ParentDirectory });
            }
            PopulateFilesList(localFilesList, items);
        }

        private static void PopulateFilesList(ListView listview, IEnumerable<FileSystemItem> items)
        {
            listview.Items.Clear();
            foreach (var item in items)
            {
                if (item.IsParentNavigation)
                {
                    listview.Items.Add(new ListViewItem(new[] { item.Name }, string.Empty,
                        DefaultForeColor, Color.Azure, DefaultFont) { Tag = item });
                }
                else if (item.IsDirectory)
                {
                    listview.Items.Add(new ListViewItem(new[] { string.Format("[{0}]", item.Name) }, string.Empty,
                        DefaultForeColor, Color.AliceBlue, DefaultFont) { Tag = item });
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
        }

        private void localFilesList_DoubleClick(object sender, EventArgs e)
        {
            if (localFilesList.SelectedItems.Count <= 0) return;
            var item = localFilesList.SelectedItems[0];
            var name = item.SubItems[0].Text;
            if (name == ParentDirectory)
            {
                CurrentLocalPath = Directory.GetParent(CurrentLocalPath).FullName;
                PopulateLocalFilesFromCurrentPath();
                return;
            }
            var tag = item.Tag as FileSystemItem;
            if (tag == null) return;
            if (tag.IsDirectory)
            {
                CurrentLocalPath = Path.Combine(CurrentLocalPath, tag.Name);
                PopulateLocalFilesFromCurrentPath();
            }
        }
    }
}
