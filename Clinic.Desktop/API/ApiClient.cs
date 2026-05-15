using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Clinic.Desktop.API
{
    public static class ApiClient
    {
        private static readonly string BaseUrl = "https://localhost:7137/";
        private static readonly HttpClient _client = new HttpClient();

        // Hàm GET
        public static async Task<T?> GetAsync<T>(string endpoint, bool showError = true)
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl + endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }

                if (showError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi GET {(int)response.StatusCode}: {error}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default;
            }
            catch (Exception ex)
            {
                if (showError) MessageBox.Show($"Lỗi kết nối (GET): {ex.Message}");
                return default;
            }
        }

        // Hàm POST
        public static async Task<T?> PostAsync<T>(string endpoint, object data, bool showError = true)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(BaseUrl + endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }

                if (showError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi POST {(int)response.StatusCode}: {error}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default;
            }
            catch (Exception ex)
            {
                if (showError) MessageBox.Show($"Lỗi kết nối (POST): {ex.Message}");
                return default;
            }
        }

        // Hàm PUT có trả về Object
        public static async Task<T?> PutAsync<T>(string endpoint, object data, bool showError = true)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(BaseUrl + endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return default;

                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }

                if (showError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi PUT {(int)response.StatusCode}: {error}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default;
            }
            catch (Exception ex)
            {
                if (showError) MessageBox.Show($"Lỗi kết nối (PUT): {ex.Message}");
                return default;
            }
        }

        // Hàm PUT trả về bool (NoContent)
        public static async Task<bool> PutVoidAsync(string endpoint, object data, bool showError = true)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(BaseUrl + endpoint, content);

                if (!response.IsSuccessStatusCode && showError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi PUT {(int)response.StatusCode}: {error}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                if (showError) MessageBox.Show($"Lỗi kết nối (PUT): {ex.Message}");
                return false;
            }
        }

        // Hàm DELETE
        public static async Task<bool> DeleteAsync(string endpoint, bool showError = true)
        {
            try
            {
                var response = await _client.DeleteAsync(BaseUrl + endpoint);

                if (!response.IsSuccessStatusCode && showError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi DELETE {(int)response.StatusCode}: {error}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                if (showError) MessageBox.Show($"Lỗi kết nối (DELETE): {ex.Message}");
                return false;
            }
        }
    }
}