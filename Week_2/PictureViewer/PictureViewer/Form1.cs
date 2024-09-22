using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private int SelectedImageIndex = 0;

        private List<Image> LoadedImages { get; set; }

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(navigationButton_KeyDown);
        }

        private void LoadImagesFromFolder(string[] paths)
        {
            LoadedImages = new List<Image>();
            foreach (var path in paths)
            {
                var tempImage = Image.FromFile(path);
                LoadedImages.Add(tempImage);
            }
        }

        private void ImageList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ImageList.SelectedIndices.Count > 0)
            {
                var selectedIndex = ImageList.SelectedIndices[0];
                Image selectedImage = LoadedImages[selectedIndex];
                MainPictureBox.Image = selectedImage;
                MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void navigationButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton.Text.Equals("Previous"))
            {
                if (SelectedImageIndex > 0)
                {
                    SelectedImageIndex -= 1;
                    Image selectedImage = LoadedImages[SelectedImageIndex];
                    MainPictureBox.Image = selectedImage;
                    MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                if (SelectedImageIndex < (LoadedImages.Count - 1))
                {
                    SelectedImageIndex += 1;
                    Image selectedImage = LoadedImages[SelectedImageIndex];
                    MainPictureBox.Image = selectedImage;
                    MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void navigationButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (SelectedImageIndex > 0)
                {
                    SelectedImageIndex -= 1;
                    Image selectedImage = LoadedImages[SelectedImageIndex];
                    MainPictureBox.Image = selectedImage;
                    MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (SelectedImageIndex < (LoadedImages.Count - 1))
                {
                    SelectedImageIndex += 1;
                    Image selectedImage = LoadedImages[SelectedImageIndex];
                    MainPictureBox.Image = selectedImage;
                    MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                var selectedDirectory = folderBrowser.SelectedPath;

                var imagePaths = Directory.GetFiles(selectedDirectory);

                LoadImagesFromFolder(imagePaths);

                ImageList images = new ImageList();
                images.ImageSize = new Size(130, 40);

                foreach (var image in LoadedImages)
                {
                    images.Images.Add(image);
                }

                ImageList.LargeImageList = images;

                for (int itemIndex = 1; itemIndex <= LoadedImages.Count; itemIndex++)
                {
                    ImageList.Items.Add(new ListViewItem($"Image {itemIndex}", itemIndex - 1));
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Open Image File",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Multiselect = true // false = single select, true = multi select
            };

            var folderBrowserDialog = new FolderBrowserDialog();
            // Open a single image file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var selectedImagePath in openFileDialog.FileNames)
                {
                    var selectedImage = Image.FromFile(selectedImagePath);

                    // Append each selected image to LoadedImages
                    if (LoadedImages == null)
                    {
                        LoadedImages = new List<Image>();
                    }
                    LoadedImages.Add(selectedImage);

                    // Update the ImageList with the new images
                    if (ImageList.LargeImageList == null)
                    {
                        ImageList.LargeImageList = new ImageList();
                        ImageList.LargeImageList.ImageSize = new Size(130, 40);
                    }

                    // Add the new image to the ImageList
                    ImageList.LargeImageList.Images.Add(selectedImage);

                    // Add the new item to the ListView
                    ImageList.Items.Add(new ListViewItem($"Image {LoadedImages.Count}", LoadedImages.Count - 1));
                }

                // Display the first selected image in the PictureBox (optional)
                if (LoadedImages.Count > 0)
                {
                    MainPictureBox.Image = LoadedImages[0];
                    MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}
// Credits: Tech In Talk & chatGPT