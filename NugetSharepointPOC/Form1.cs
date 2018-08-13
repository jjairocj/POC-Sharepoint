using System;
using System.Linq;
using System.Security;
using System.Net;
using Microsoft.SharePoint.Client;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.SharePoint;
using System.Windows.Forms;
using static System.Console;

namespace NugetSharepointPOC
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private string _siteCollectionUrl;
        private string _userName;
        private string _password;
        private string _listFiles;
        private string _filePath;
        private string _rootPath;
        private string _folderName;
        private ClientContext _ctx;

        public Form1()
        {
            InitializeComponent();
        }

        private void SharepointConnectionTest()
        {
            // server running SharePoint. 
            //ClientContext context = new ClientContext("http://win-i0t7l3gjl54");
            var context = new ClientContext("http://win-0nfiqiub1b1:9640/default.aspx");

            // The SharePoint web at the URL.
            var web = context.Web;

            // We want to retrieve the web's properties.
            context.Load(web);

            // Execute the query to the server.
            context.ExecuteQuery();

            // Now, the web's properties are available and we could display 
            // web properties, such as title. 
            lblServerName.Text = web.Title;
        }

        private void SharepointConnectionTest2()
        {

            // Namespace: Microsoft.SharePoint.Client  
            var ctx = new ClientContext(_siteCollectionUrl);

            // Namespace: System.Security
            var secureString = new SecureString();
            _password.ToList().ForEach(secureString.AppendChar);

            // Namespace: Microsoft.SharePoint.Client  
            ctx.Credentials = new SharePointOnlineCredentials(_userName, secureString);

            //Sharepoint old versions
            //NetworkCredential nt = new NetworkCredential(userName, password);
            //ctx.Credentials = nt;

            // The SharePoint web at the URL.
            var web = ctx.Web;
            //web.Title = "New Title";
            //web.Description = "New Description";
            // Note that the web.Update() does not trigger a request to the server
            // because the client library until ExecuteQuery() is called. 
            //web.Update();

            // Namespace: Microsoft.SharePoint.Client  
            var site = ctx.Site;

            // Assume the web has a list named "Announcements". 
            var documentsList = ctx.Web.Lists.GetByTitle("Documents");

            // This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll" 
            // so that it grabs all list items, regardless of the folder they are in. 
            //CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            //ListItemCollection items = documentsList.GetItems(query);

            ctx.Load(site);

            // We want to retrieve the web's properties.
            ctx.Load(web);

            // We want to retrieve the web's title and description. 
            ctx.Load(web, w => w.Title, w => w.Description);

            ctx.Load(web.Lists,
             lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id. 
                                    list => list.Id));

            //ctx.Load(items);

            ctx.ExecuteQuery();

            lblServerName.Text = $@"{web.Title} - {web.Description}";

            //// Enumerate the web.Lists. 
            foreach (var list in web.Lists)
            {
                lblServerName.Text = $@"{lblServerName.Text}, {list.Title}";
                WriteLine(list.Title);
            }

            //foreach (ListItem listItem in items)
            //{
            //    // We have all the list item data. For example, Title. 
            //    label1.Text = label1.Text + ", " + listItem["Title"];
            //    Console.WriteLine(listItem["Title"]);
            //}

        }

        private void Connect()
        {
            _ctx = new ClientContext(_siteCollectionUrl);
            if (rb2010.Checked || rb2013.Checked || rb2016.Checked)
            {
                var nt = new NetworkCredential(_userName, _password);
                _ctx.Credentials = nt;
            }
            else
            {
                var secureString = new SecureString();
                _password.ToList().ForEach(secureString.AppendChar);
                _ctx.Credentials = new SharePointOnlineCredentials(_userName, secureString);
            }
        }

        private void GetServerInfo()
        {
            var web = _ctx.Web;
            var site = _ctx.Site;

            //List documentsList = ctx.Web.Lists.GetByTitle("Documents");

            var query = CamlQuery.CreateAllItemsQuery(100);
            //ListItemCollection items = documentsList.GetItems(query);

            _ctx.Load(site);
            _ctx.Load(web);
            _ctx.Load(web, w => w.Title, w => w.Description);
            _ctx.Load(web.Folders,
             folders => folders.Include(folder => folder.Name//, // For each list, retrieve Title and Id. 
                                                             // folder => folder.xxx
                                    ));
            _ctx.ExecuteQuery();
            //ctx.Load(items);

            _ctx.ExecuteQuery();

            lblServerName.Text = $@"Server Name: {web.Title}";
            lblServerDesc.Text = $@"Server Description: {web.Description}";

            //// Enumerate the web.Lists. 
            foreach (var folder in web.Folders)
            {
                WriteLine(folder.Name);
            }
        }

        private void rb2010_CheckedChanged(object sender, EventArgs e)
        {
            //Sharepoint 2010
            _siteCollectionUrl = "http://win-i0t7l3gjl54:36044/";
            _userName = "sharepointvm";
            _password = "ABCde123";
            UpdateLoginInfo();
        }

        private void rb2013_CheckedChanged(object sender, EventArgs e)
        {
            //Sharepoint 2013
            _siteCollectionUrl = "http://abcuniversity/";
            _userName = "Administrator";
            _password = "Training45";
            UpdateLoginInfo();
        }

        private void rbOnlineTest_CheckedChanged(object sender, EventArgs e)
        {
            //Sharepoint Online - Test
            _siteCollectionUrl = "https://testyz.sharepoint.com/";
            _userName = "michael@testyz.onmicrosoft.com";
            _password = @"Modeler!""#";
            UpdateLoginInfo();
        }

        private void UpdateLoginInfo()
        {
            tbURL.Text = _siteCollectionUrl;
            tbUser.Text = _userName;
            tbPass.Text = _password;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            GetServerInfo();
            GetTreeFolder();
        }

        private void GetTreeFolder()
        {
            //Load Libraries from SharePoint
            _ctx.Load(_ctx.Web.Lists);
            _ctx.ExecuteQuery();

            treeFolders.Nodes.Clear();
            treeFolders.Nodes.Add("Root");
            foreach (var list in _ctx.Web.Lists)
            {
                _ctx.Load(list);
                if (!list.Hidden)
                {
                    string entityName = String.Empty;


                    if (list.ParentWebUrl == @"/")
                    {
                        entityName = list.Title;
                    }
                    else
                    {
                        entityName = $"{list.ParentWebUrl}/{list.Title}";
                    }

                    treeFolders.Nodes[0].Nodes.Add(new TreeNode()
                    {
                        Name = entityName,
                        Text = list.EntityTypeName.Replace(@"_x0020_", " ")
                    });
                }
            }
            treeFolders.ExpandAll();


            //Web oWebsite = ctx.Web;
            //FolderCollection collList = oWebsite.Folders;

            //var resultCollection = ctx.LoadQuery(
            // collList.Include(
            //     folder => folder.Name,
            //     folder => folder.ParentFolder,
            //     folder => folder.Properties,
            //     folder => folder.ServerRelativeUrl)
            //     );


            //ctx.ExecuteQuery();

            //treeFolders.Nodes.Clear();
            //treeFolders.Nodes.Add("Root");
            //int i = 0;
            //foreach (Folder oList in resultCollection)
            //{
            //    if (oList.Name.ToLower() != "_w")
            //    {
            //        treeFolders.Nodes[0].Nodes.Add("Title: {0} Created: {1}", oList.Name, oList.ServerRelativeUrl.ToString());

            //        CamlQuery camlQuery = new CamlQuery();
            //        camlQuery.ViewXml = @"<View Scope='Recursive' />";
            //    }


            //    //ListItemCollection collListItem = oList.GetItems(camlQuery);
            //    //ctx.Load(collListItem,
            //    // items => items.Include(
            //    //    item => item.Id,
            //    //    item => item.DisplayName));

            //    //ctx.ExecuteQuery();
            //    //foreach (ListItem oListItem in collListItem)
            //    //{
            //    //    treeFolders.Nodes[0].Nodes[i].Nodes.Add("Title: {0} ID: {1}", oListItem.DisplayName, oListItem.Id);
            //    //    //Console.WriteLine("ID: {0} \nTitle: {1} \nBody: {2}", oListItem.Id, oListItem["Title"], oListItem["Body"]);

            //    //}
            //    //i++;
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Sharepoint 2016
            _siteCollectionUrl = "http://win-0nfiqiub1b1/sites/Sharepoint2016";
            _userName = @"SHAREPOINT\Administrator";
            _password = "Bizagi2018";
            UpdateLoginInfo();
        }

        private void rbOnlineBizagi_CheckedChanged(object sender, EventArgs e)
        {
            //Sharepoint Online - Bizagi
            _siteCollectionUrl = "https://bizagi.sharepoint.com/";
            _userName = "michael.salazar@bizagi.com";
            _password = @"";
            UpdateLoginInfo();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            var folder = "E:\\ModelUpload";
            _rootPath = folder;
            _folderName = Path.GetFileName(folder);
            _filePath = _folderName;
            ProcessDirectory(folder);




            //exportBatchSharepoint(siteCollectionUrl, userName, password, "Documents", new List<Dir> { new Dir { documents = new List<string> { "C:\\index.html" }, name = "Folders" } });

        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName, _filePath);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                _filePath = $"{_folderName}/{GetPathUpload(subdirectory)}";
                ProcessDirectory(subdirectory);
            }


            textBoxLog.Text = _listFiles;
        }

        private string GetPathUpload(string subdirectory)
        {
            return RelativePath(_rootPath, subdirectory);
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path, string folderName)
        {
            _listFiles = _listFiles + $@"Processed file '{path}', {folderName}." + Environment.NewLine;
            ImportFile(path, folderName);
        }

        public void ImportFile(string fileName, string folderName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var fi = new FileInfo(fileName);
                var uri = treeFolders.SelectedNode;

                var list = _ctx.Web.GetFolderByServerRelativeUrl(uri.Name);
                _ctx.Load(list);
                _ctx.ExecuteQuery();
                var fileUrl = $"{list.ServerRelativeUrl}/{folderName}/{fi.Name}";

                try
                {
                    var folders = list.Folders;

                    _ctx.Load(folders);

                    _ctx.ExecuteQuery();

                    folders.Add($"{list.ServerRelativeUrl}/{folderName}");

                    _ctx.ExecuteQuery();
                }
                catch (Exception ex)
                {
                    // ignored

                }


                Microsoft.SharePoint.Client.File.SaveBinaryDirect(_ctx, fileUrl, fs, true);
            }
        }

        private static void ExportBatchSharepoint(string website, string username, string password, string path, List<Dir> subdirs)
        {
            try
            {
                if (string.IsNullOrEmpty(website))
                    throw new Exception("Error: Sharepoint Not configured correctly.");

                using (ClientContext client = new ClientContext(website))
                {
                    System.Diagnostics.Debug.WriteLine("Connecting to Sharepoint site...");

                    client.Credentials = new System.Net.NetworkCredential(username, password);
                    System.Diagnostics.Debug.WriteLine("Connected.");

                    var rootFolder = client.Web.GetFolderByServerRelativeUrl(path) ?? client.Web.Folders.Add(path);

                    System.Diagnostics.Debug.WriteLine("\tCreating Sharepoint Sub-Directory \"" + path + "\".");

                    foreach (var dir in subdirs)
                    {
                        var dirPath = Uri.EscapeUriString(dir.Name).Replace("?", "_");
                        System.Diagnostics.Debug.WriteLine("\t\tCreating Document Directory \"" + dirPath + "\".");

                        var dirFolder = rootFolder.Folders.Add(dirPath);

                        foreach (var doc in dir.Documents)
                        {
                            var docPath = Path.GetFileName(doc);

                            var uplfileStream = System.IO.File.ReadAllBytes(doc);
                            dirFolder.Files.Add(new FileCreationInformation()
                            {
                                Content = uplfileStream,
                                Overwrite = true,
                                Url = docPath
                            });
                        }

                    }

                    System.Diagnostics.Debug.WriteLine("\tUploading to Sharepoint Server is Done.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void CreateDirectories(string path, SPFolderCollection oFolderCollection)
        {
            //Upload Multiple Files
            foreach (var oFi in new DirectoryInfo(path).GetFiles())
            {
                var fileStream = System.IO.File.OpenRead(oFi.FullName);
                var spfile = oFolderCollection.Folder.Files.Add
                            (oFi.Name, fileStream, true);
                spfile.Update();
            }

            //Upload Multiple Folders
            foreach (var oDi in new DirectoryInfo(path).GetDirectories())
            {
                var sFolderName = oDi.FullName.Split('\\')
                            [oDi.FullName.Split('\\').Length - 1];
                var spNewFolder = oFolderCollection.Add(sFolderName);
                spNewFolder.Update();
                //Recursive call to create child folder
                CreateDirectories(oDi.FullName, spNewFolder.SubFolders);
            }
        }

        public void IterateFolders(TreeNode mainNode, Folder subFolder, ClientContext clientcontext)
        {
            clientcontext.Load(subFolder.Folders);
            clientcontext.ExecuteQuery();
            foreach (var folder in subFolder.Folders)
            {
                var subNode = new TreeNode()
                {
                    Name = folder.ServerRelativeUrl,
                    Text = folder.Name
                };
                mainNode.Nodes.Add(subNode);
                IterateFolders(subNode, folder, clientcontext);
            }
        }

        private void treeFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        public string RelativePath(string absPath, string relTo)
        {
            string[] absDirs = absPath.Split('\\');
            string[] relDirs = relTo.Split('\\');

            // Get the shortest of the two paths
            int len = absDirs.Length < relDirs.Length ? absDirs.Length :
                relDirs.Length;

            // Use to determine where in the loop we exited
            int lastCommonRoot = -1;
            int index;

            // Find common root
            for (index = 0; index < len; index++)
            {
                if (absDirs[index] == relDirs[index]) lastCommonRoot = index;
                else break;
            }

            // If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base");
            }

            // Build up the relative path
            StringBuilder relativePath = new StringBuilder();

            // Add on the ..
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) relativePath.Append("");
            }

            // Add on the folders
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + "/");
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);

            return relativePath.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = _ctx.Web.Lists.GetByTitle(treeFolders.SelectedNode.Name);
            _ctx.Load(list);
            _ctx.ExecuteQuery();
            _ctx.Load(list.RootFolder);
            _ctx.Load(list.RootFolder.Folders);
            _ctx.ExecuteQuery();
            treeFolders.ShowLines = true;
            var rootNode = new TreeNode(list.Title);
            //treeFolders.SelectedNode.Nodes.Add(RootNode);

            foreach (var subFolder in list.RootFolder.Folders)
            {
                if (subFolder.Name != "Forms")
                {
                    var topNode = new TreeNode()
                    {
                        Name = subFolder.ServerRelativeUrl,
                        Text = subFolder.Name
                    };

                    treeFolders.SelectedNode.Nodes.Add(topNode);
                    IterateFolders(topNode, subFolder, _ctx);
                }
            }

            treeFolders.ExpandAll();
        }
    }
}


public class Dir
{
    public string Name;
    public List<string> Documents;
}