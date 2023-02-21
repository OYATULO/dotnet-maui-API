using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace workWithApi;
public partial class MainPage : ContentPage
{
    Resposts resposts = new Resposts();
    Posts posts = new Posts();
    public  MainPage()
	{
            InitializeComponent();
    }

    private  async void OnClickResponse(object sender, EventArgs e)
    {
        ListContent.ItemsSource = await posts.ResponseMethod();
    }
    private async void OnClickRequest(object sender, EventArgs e)
    {
        ListContent.ItemsSource = await posts.RequestMethod();
    }
    private async void OnClickInterface(object sender, EventArgs e)
    {
        ListContent.ItemsSource = await resposts.GetPostsAsync();
    }
    private  void reset(object sender, EventArgs e)
    {
        ListContent.ItemsSource = null;
    }

    
}

