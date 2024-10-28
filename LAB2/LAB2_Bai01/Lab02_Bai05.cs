using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_Bai01
{
    public partial class Lab02_Bai05 : Form
    {
        public Lab02_Bai05()
        {
            InitializeComponent();
        }

        private void Lab02_Bai05_Load(object sender, EventArgs e)
        {
            AddDriveNode(@"C:\");
            AddDriveNode(@"D:\"); 
        }

        private void AddDriveNode(string drivePath)
        {
            TreeNode driveNode = new TreeNode(drivePath)
            {
                Tag = drivePath // Store path information
            };
            // Add a dummy node to show the expand arrow
            driveNode.Nodes.Add(new TreeNode("Loading..."));
            DirectoryView.Nodes.Add(driveNode);
        }

        private void LoadDirectories(TreeNode node, string path)
        {
            try
            {
                string[] directories = System.IO.Directory.GetDirectories(path);

                foreach (string dir in directories)
                {
                    TreeNode dirNode = new TreeNode(System.IO.Path.GetFileName(dir))
                    {
                        Tag = dir
                    };

                    dirNode.Nodes.Add("Loading...");
                    node.Nodes.Add(dirNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied to folder: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading directories: " + ex.Message);
            }
        }

        private void LoadFiles(TreeNode node, string path)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(path);

                foreach (string file in files)
                {
                    TreeNode fileNode = new TreeNode(System.IO.Path.GetFileName(file))
                    {
                        Tag = file
                    };
                    node.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied to file in folder: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files: " + ex.Message);
            }
        }

        private void DirectoryView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            // Clear dummy node
            if (node.Nodes[0].Text == "Loading...")
            {
                node.Nodes.Clear();

                // Get directories and files for the selected path
                string path = node.Tag.ToString();
                LoadDirectories(node, path);
                LoadFiles(node, path);
            }
        }

        private void DirectoryView_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string filePath = selectedNode.Tag.ToString();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".txt")
                {
                    // Load text file content into RichTextBox
                    RichTextBox_FileContent.Text = File.ReadAllText(filePath);
                }
                else if (extension == ".jpg" || extension == ".png" || extension == ".bmp")
                {
                    // Clear existing text
                    RichTextBox_FileContent.Clear();

                    // Load image file content into RichTextBox
                    Clipboard.SetImage(new Bitmap(filePath));
                    RichTextBox_FileContent.Paste();
                }
                else
                {
                    // Unsupported file type message
                    RichTextBox_FileContent.Text = "Unsupported file type.";
                }
            }
        }

        private void Lab02_Bai05_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}