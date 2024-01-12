using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using BCS21090002_LABTEST.Model;

namespace BCS21090002_LABTEST.ViewModel
{
    public class Question3ViewModel : BindableObject
    {
        private HttpClient _client = new HttpClient();
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";
        public ObservableCollection<PostRecord> Posts { get; set; } = new ObservableCollection<PostRecord>();

        public Question3ViewModel()
        {
            LoadPostsCommand.Execute(null);
        }

        public ICommand LoadPostsCommand => new Command(async () => await LoadPostsAsync());
        public ICommand AddOrUpdatePostCommand => new Command<PostRecord>(async (post) => await AddOrUpdatePostAsync(post));
        public ICommand DeletePostCommand => new Command<int>(async (postId) => await DeletePostAsync(postId));

        private async Task LoadPostsAsync()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var posts = JsonSerializer.Deserialize<List<PostRecord>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (posts == null)
                    {
                        Console.WriteLine("Deserialized posts are null.");
                        return;
                    }

                    Device.BeginInvokeOnMainThread(() => {
                        Posts.Clear();
                        foreach (var post in posts)
                        {
                            Posts.Add(post);
                        }
                    });
                }
                else
                {
                    Console.WriteLine($"API call failed: {response.StatusCode}, Content: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during API call: {ex}");
            }
        }


        private async Task AddOrUpdatePostAsync(PostRecord post)
        {
            var json = JsonSerializer.Serialize(post, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            // Update if Id is not default value, otherwise create a new post
            if (post.Id != 0) // Use 0 as default(int) is always 0
            {
                response = await _client.PutAsync($"{BaseUrl}/{post.Id}", content);
            }
            else
            {
                response = await _client.PostAsync(BaseUrl, content);
            }

            if (response.IsSuccessStatusCode)
            {
                // If the response contains the serialized PostRecord, update the list
                var updatedJson = await response.Content.ReadAsStringAsync();
                var updatedPost = JsonSerializer.Deserialize<PostRecord>(updatedJson);
                if (updatedPost != null)
                {
                    var existingPost = Posts.FirstOrDefault(p => p.Id == updatedPost.Id);
                    if (existingPost != null)
                    {
                        // If existing post was found, update it
                        int index = Posts.IndexOf(existingPost);
                        Posts[index] = updatedPost;
                    }
                    else
                    {
                        // If no existing post was found, this was an add operation, so add the new post
                        Posts.Add(updatedPost);
                    }
                }
            }
            else
            {
                // Log or handle API call failure
                Console.WriteLine($"API call failed: {response.StatusCode}");
            }
        }

        private async Task DeletePostAsync(int postId)
        {
            var response = await _client.DeleteAsync($"{BaseUrl}/{postId}");
            if (response.IsSuccessStatusCode)
            {
                // Remove the post from the ObservableCollection
                var postToRemove = Posts.FirstOrDefault(p => p.Id == postId);
                if (postToRemove != null)
                {
                    Posts.Remove(postToRemove);
                }
            }
            else
            {
                // Log or handle API call failure
                Console.WriteLine($"API call failed: {response.StatusCode}");
            }
        }

    }
}
