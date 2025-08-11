using System.Text;

namespace Application.Common.Extension
{
    public class HttpExtension
    {
        public static async Task<T> RequestAsync<T>(string url, string requestType, object data = null, IDictionary<string, string> headers = null, CancellationTokenSource cts = null)
        {
            using HttpClient httpClient = new HttpClient();
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            HttpResponseMessage response;
            switch (requestType)
            {
                case "POST":
                    {
                        StringContent content = new StringContent(SerializerHelper.Serialize(data), Encoding.UTF8, "application/json");
                        response = ((cts == null) ? (await httpClient.PostAsync(url, content)) : (await httpClient.PostAsync(url, content, cts.Token)));
                        break;
                    }
                case "DELETE":
                    response = ((cts == null) ? (await httpClient.DeleteAsync(url)) : (await httpClient.DeleteAsync(url, cts.Token)));
                    break;
                case "PUT":
                    {
                        StringContent content2 = new StringContent(SerializerHelper.Serialize(data), Encoding.UTF8, "application/json");
                        response = ((cts == null) ? (await httpClient.PutAsync(url, content2)) : (await httpClient.PutAsync(url, content2, cts.Token)));
                        break;
                    }
                case "GET":
                    response = ((cts == null) ? (await httpClient.GetAsync(url)) : (await httpClient.GetAsync(url, cts.Token)));
                    break;
                default:
                    throw new Exception("Http request type doesn't exist");
            }

            if (response.IsSuccessStatusCode)
            {
                return SerializerHelper.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"Error fetching data from {requestType} {url}: {response.StatusCode} - {response.ReasonPhrase}");
        }

    }
}
