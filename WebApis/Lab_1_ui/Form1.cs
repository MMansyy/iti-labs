using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Lab_1_ui
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:7147/api/Courses";

        private TextBox txtName, txtDesc, txtDuration;
        private Button btnAdd;
        private Label lblName, lblDesc, lblDuration, lblStatus;
        private DataGridView dgvCourses;

        public Form1()
        {
            InitializeComponent();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            _client = new HttpClient(handler);

            BuildUI();
            _ = LoadCourses();
        }

        private void BuildUI()
        {
            this.Text = "Courses Manager";
            this.Size = new Size(700, 550);

            lblName = new Label { Text = "Course Name:", Location = new Point(20, 20), AutoSize = true };
            txtName = new TextBox { Location = new Point(150, 18), Width = 200 };

            lblDesc = new Label { Text = "Description:", Location = new Point(20, 60), AutoSize = true };
            txtDesc = new TextBox { Location = new Point(150, 58), Width = 200 };

            lblDuration = new Label { Text = "Duration:", Location = new Point(20, 100), AutoSize = true };
            txtDuration = new TextBox { Location = new Point(150, 98), Width = 200 };

            btnAdd = new Button { Text = "Add Course", Location = new Point(150, 140), Width = 120 };
            btnAdd.Click += BtnAdd_Click;

            lblStatus = new Label { Location = new Point(20, 185), AutoSize = true, ForeColor = Color.Green };

            dgvCourses = new DataGridView
            {
                Location = new Point(20, 210),
                Size = new Size(640, 280),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                AllowUserToAddRows = false
            };

            this.Controls.AddRange(new Control[]
            {
                lblName, txtName,
                lblDesc, txtDesc,
                lblDuration, txtDuration,
                btnAdd, lblStatus,
                dgvCourses
            });
        }

        private async Task LoadCourses()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var courses = JsonSerializer.Deserialize<List<CourseDto>>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dgvCourses.DataSource = courses;
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Failed to load: {ex.Message}";
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Course name is required.";
                return;
            }

            var course = new
            {
                Crs_name = txtName.Text,
                crs_desc = txtDesc.Text,
                Duration = int.TryParse(txtDuration.Text, out int d) ? d : 0
            };

            var json = JsonSerializer.Serialize(course);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    txtName.Clear();
                    txtDesc.Clear();
                    txtDuration.Clear();

                    await LoadCourses();
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Exception: {ex.Message}";
            }
        }
    }

    // DTO عشان JsonSerializer يعرف يmap الداتا
    public class CourseDto
    {
        public int ID { get; set; }
        public string Crs_name { get; set; }
        public string crs_desc { get; set; }
        public int Duration { get; set; }
    }
}