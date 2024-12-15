using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_Bai5
{
    public partial class Bai5 : Form
    {

        private static readonly HttpClient client = new HttpClient();

        public Bai5()
        {
            InitializeComponent();
        }

        private async void buttonGetInf_Click(object sender, EventArgs e)
        {
            string accessToken = textboxAccessToken.Text;
            string url = "https://nt106.uitiot.vn/api/v1/user/me";

            if (string.IsNullOrEmpty(accessToken) )
            {
                MessageBox.Show("Please enter the access token!");
                return;
            }

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<JsonElement>(body);
                    MessageBox.Show("Successfully retrieved user's information!");
                    textboxUsername.Text = jsonResponse.GetProperty("username").GetString();
                    textboxEmail.Text = jsonResponse.GetProperty("email").GetString();
                    textboxFirstName.Text = jsonResponse.GetProperty("first_name").GetString();
                    textboxLastName.Text = jsonResponse.GetProperty("last_name").GetString();
                    textboxSex.Text = jsonResponse.GetProperty("sex").GetInt32().ToString();
                    textboxBirthday.Text = jsonResponse.GetProperty("birthday").GetString();
                    textboxLanguage.Text = jsonResponse.GetProperty("language").GetString();
                    textboxPhone.Text = jsonResponse.GetProperty("phone").GetString();
                }   
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    MessageBox.Show("Invalid or expired access token!");
                else
                    MessageBox.Show("Failed to get user's information!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void Bai5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
