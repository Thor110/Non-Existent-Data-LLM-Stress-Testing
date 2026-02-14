using System.Text;
using System.Text.Json;
namespace Non_Existent_Data_LLM_Stress_Testing
{
    public partial class Converse : Form
    {
        private static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(60) };
        private string ModelName = "";
        private string FirstModelName = "";
        private string SecondModelName = "";
        private string prompt = "";
        private int testCount = 10;
        private int context = 1024;
        private int currentCount = 1;
        private float temperature = 0.7f;
        private bool stop = false;
        private Dictionary<string, object> requestBody = new Dictionary<string, object> { };
        private HttpResponseMessage response = new HttpResponseMessage();
        private string resultJson = "";
        private string fileName = "test.txt";
        private string aiResponse = "";
        public Converse()
        {
            InitializeComponent();
            comboBox1.Items.Add("gpt-oss:20b");
            comboBox1.Items.Add("llama3.2");
            comboBox1.Items.Add("gemma3:27b");
            comboBox1.Items.Add("deepseek-r1:8b");
            comboBox2.Items.Add("gpt-oss:20b");
            comboBox2.Items.Add("llama3.2");
            comboBox2.Items.Add("gemma3:27b");
            comboBox2.Items.Add("deepseek-r1:8b");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        // execute test
        async Task Main()
        {
            button2.Enabled = true;
            for (currentCount = currentCount; currentCount <= testCount && !stop; currentCount++)
            {
                label3.Text = currentCount.ToString();
                if (currentCount % 2 != 0) { ModelName = FirstModelName; }
                else { ModelName = SecondModelName; }
                requestBody = new Dictionary<string, object>
                {
                    { "model", ModelName },
                    { "prompt", prompt },
                    { "stream", false },
                    { "keep_alive", -1 },
                    { "options", new { temperature = temperature, num_ctx = context } }
                };
                if (currentCount % 2 != 0) // thinking models
                {
                    if (comboBox1.SelectedIndex == 0) { requestBody.Add("think", "high"); }
                    else if (comboBox1.SelectedIndex == 3) { requestBody.Add("think", true); }
                }
                else
                {
                    if (comboBox2.SelectedIndex == 0) { requestBody.Add("think", "high"); }
                    else if (comboBox2.SelectedIndex == 3) { requestBody.Add("think", true); }
                }
                response = await client.PostAsync("http://localhost:11434/api/generate", new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));
                resultJson = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(resultJson);
                if (doc.RootElement.TryGetProperty("response", out var respProp)) { aiResponse = respProp.GetString()!; }
                await File.WriteAllTextAsync(fileName, aiResponse);
                if (currentCount % 2 != 0) { prompt = aiResponse; }
                else { prompt = aiResponse; }
                richTextBox1.Text += ModelName + ":\n" + prompt + "\n";
            }
            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }
        // first model
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { FirstModelName = comboBox1.Text; }
        // second model
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { SecondModelName = comboBox2.Text; }
        // conversation length
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { testCount = (int)numericUpDown1.Value; }
        // start
        private void button1_Click(object sender, EventArgs e)
        {
            prompt = "Hi " + FirstModelName + ", talk to " + SecondModelName + " and see what they say.";
            prompt += "\nFor context, I have created a system where you can engage in discussions with other LLMs, so your response should be directed towards them.";
            richTextBox1.Text = "";
            currentCount = 1;
            testCount = (int)numericUpDown1.Value;
            Run();
        }
        // stop
        private void button2_Click(object sender, EventArgs e) { button1.Enabled = true; stop = true; }
        // continue
        private void button3_Click(object sender, EventArgs e) { testCount += (int)numericUpDown1.Value; Run(); }
        // engage
        private async void Run()
        {
            stop = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            await Main();
        }
        // context tokens
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { context = (int)numericUpDown3.Value; }
    }
}