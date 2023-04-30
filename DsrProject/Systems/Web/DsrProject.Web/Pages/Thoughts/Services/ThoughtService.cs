using System.Text;
using System.Text.Json;

namespace DsrProject.Web
{
    public class ThoughtService : IThoughtService
    {
        private readonly HttpClient _httpClient;

        public ThoughtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ThoughtListItem>> GetThoughts(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/api/v1/thoughts?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<ThoughtListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ThoughtListItem>();

            return data;
        }

        public async Task<IEnumerable<ThoughtListItem>> GetRespondentThoughts(int offset = 0, int limit = 10)
        {
            string url = $"{Settings.ApiRoot}/api/v1/respondents?offset={offset}&limit={limit}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<ThoughtListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ThoughtListItem>();

            return data;
        }

        public async Task<ThoughtListItem> GetThought(int thoughtId)
        {
            string url = $"{Settings.ApiRoot}/api/v1/thoughts/{thoughtId}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<ThoughtListItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ThoughtListItem();

            return data;
        }

        public async Task AddThought(ThoughtModel model)
        {
            string url = $"{Settings.ApiRoot}/api/v1/thoughts";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task EditThought(int thoughtId, ThoughtModel model)
        {
            string url = $"{Settings.ApiRoot}/api/v1/thoughts/{thoughtId}";

            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task<bool> Subscribe(int thoughtId, SubscribeModel model)
        {
            string url = $"{Settings.ApiRoot}/api/v1/respondents/Subscribe";
            model.thoughtId = thoughtId;
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UnSubscribe(int thoughtId, SubscribeModel model)
        {
            string url = $"{Settings.ApiRoot}/api/v1/respondents/UnSubscribe";
            model.thoughtId = thoughtId;
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteThought(int thoughtId)
        {
            string url = $"{Settings.ApiRoot}/api/v1/thoughts/{thoughtId}";

            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task<IEnumerable<AuthorModel>> GetAuthorList()
        {
            string url = $"{Settings.ApiRoot}/api/v1/authors";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<AuthorModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AuthorModel>();

            return data;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            string url = $"{Settings.ApiRoot}/api/v1/categories";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var data = JsonSerializer.Deserialize<IEnumerable<CategoryModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CategoryModel>();

            return data;
        }

        public async Task<bool> AddComment(int thoughtId, AddCommentModel model)
        {
            string url = $"{Settings.ApiRoot}/api/v1/respondents/AddComment";
            model.thoughtId = thoughtId;
            var body = JsonSerializer.Serialize(model);
            var request = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, request);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
