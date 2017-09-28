using EfCoreTester.Data;
using EfCoreTester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EfCoreTester
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<Blog> _blogs = new ObservableCollection<Blog>();

        public MainPage()
        {
            this.InitializeComponent();

            gridAddPost.Visibility = Visibility.Collapsed;
            lvPosts.Visibility = Visibility.Collapsed;

            LoadBlogs();
        }

        private void LoadBlogs()
        {
            _blogs.Clear();

            var blogs = DataAccessService.Instance.GetBlogs();
            foreach (var blog in blogs)
            {
                _blogs.Add(blog);
            }
        }

        private async void btnAddBlog_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBlogName.Text))
            {
                var newBlog = new Blog() { Name = txtBlogName.Text };
                DataAccessService.Instance.AddBlog(newBlog);
                _blogs.Add(newBlog);
                txtBlogName.Text = string.Empty;
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Please enter blog name");
                await dialog.ShowAsync();
            }
        }

        private async void btnAddPost_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPostMessage.Text))
            {
                var newPost = new Post() { Message = txtPostMessage.Text };
                var blog = lvBlogs.SelectedItem as Blog;

                blog.Posts.Add(newPost);
                DataAccessService.Instance.UpdateBlog(blog);
                txtPostMessage.Text = string.Empty;

                lvPosts.Items.Add(newPost);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Please enter post name");
                await dialog.ShowAsync();
            }
        }

        private void lvBlogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBlogs.SelectedItem == null)
            {
                lvPosts.Visibility = Visibility.Collapsed;
                gridAddPost.Visibility = Visibility.Collapsed;
                lvPosts.Items.Clear();
            }
            else
            {
                lvPosts.Visibility = Visibility.Visible;
                gridAddPost.Visibility = Visibility.Visible;

                foreach (var post in (lvBlogs.SelectedItem as Blog).Posts)
                {
                    lvPosts.Items.Add(post);
                }
            }
        }
    }
}
