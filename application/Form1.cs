using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Non_Existent_Data_LLM_Stress_Testing
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(60) };
        private string ModelName = "";
        private string thinkingLevel = "";
        private string outputPath = "C:\\Users\\Edward\\Documents\\GitHub\\OllamaPromptAutomatedTesting\\"; // remove when publishing
        private string prompt = "";
        private string system = "";
        private int testCount = 100;
        private int context = 1024;
        private float temperature = 0.7f;
        private bool stop = false;
        // Main() variables
        private Dictionary<string, object> requestBody = new Dictionary<string, object> { };
        private HttpResponseMessage response = new HttpResponseMessage();
        private string resultJson = "";
        private string fileName = "";
        private string aiResponse = "";
        private string aiThinking = "";
        private Int64 aiDuration = 0;
        // persona shifting
        private string ossTemplate = "<|start|>system<|message|>";
        private string ossPersona = "You are ChatGPT, a large language model trained by OpenAI.";
        private string llamaPersona = "You are a helpful assistant with tool calling capabilities.";
        private string chosenPersona = "";
        // main form
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Low");
            comboBox1.Items.Add("Medium");
            comboBox1.Items.Add("High");
            comboBox2.Items.Add("gpt-oss:20b");
            comboBox2.Items.Add("llama3.2");
            comboBox2.Items.Add("gemma3:27b");
            comboBox2.Items.Add("deepseek-r1:8b"); // added deepseek-r1:8b
            comboBox3.Items.Add("gpt-oss:20b");
            comboBox3.Items.Add("llama3.2");
            comboBox3.Items.Add("gemma3:27b");
            comboBox3.Items.Add("deepseek-r1:8b"); // added deepseek-r1:8b
            comboBox1.SelectedIndex = 2;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
        // thinking level
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { thinkingLevel = comboBox1.Text.ToLower(); }
        // selected model
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { ModelName = comboBox2.Text; comboBox3.SelectedIndex = comboBox2.SelectedIndex; comboBox3_SelectedIndexChanged(null!, null!); }
        // run test button
        private async void button1_Click(object sender, EventArgs e)
        {
            if (prompt == "" || outputPath == "")
            {
                MessageBox.Show("Please enter a prompt and or output path!");
                return;
            }
            label4.Text = "0";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            comboBox3.Enabled = false;
            await Main();
        }
        // execute test
        async Task Main()
        {
            //Debug.WriteLine($"Starting Stress Test on {ModelName}...");
            for (int i = 1; i <= testCount && !stop; i++)
            {
                label4.Text = i.ToString();
                requestBody = new Dictionary<string, object>
                {
                    { "model", ModelName },
                    { "prompt", prompt },
                    { "stream", false },
                    { "keep_alive", -1 },
                    { "options", new { temperature = temperature, num_ctx = context } }
                };
                if (checkBox1.Checked) // append custom system prompt
                {
                    requestBody.Add("system", system); // new system prompt
                }
                if (checkBox2.Checked && comboBox2.SelectedIndex != 3) // change template persona
                {
                    requestBody.Add("template", chosenPersona); // ignore default modelfile
                }
                if (comboBox2.SelectedIndex == 0) { requestBody.Add("think", thinkingLevel); } // thinking models
                else if (comboBox2.SelectedIndex == 3) { requestBody.Add("think", true); } // thinking models
                StringContent content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"); // inline later maybe

                //try
                //{
                response = await client.PostAsync("http://localhost:11434/api/generate", content);
                resultJson = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(resultJson);

                // https://ollama.com/blog/thinking
                if (doc.RootElement.TryGetProperty("thinking", out var tracePart))
                {
                    aiThinking = tracePart.GetString()!;
                }
                // Robust check for the response key
                if (doc.RootElement.TryGetProperty("response", out var respProp))
                {
                    aiResponse = respProp.GetString()!;
                }
                if (doc.RootElement.TryGetProperty("total_duration", out var durationProp))
                {
                    aiDuration = durationProp.GetInt64();
                }

                fileName = Path.Combine(outputPath, $"{i:D8}_{thinkingLevel}_{aiDuration}_{ModelName.Replace(":", ".")}.txt");
                await File.WriteAllTextAsync(fileName, aiResponse);
                if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 3) // non - thinking models
                {
                    await File.WriteAllTextAsync(fileName.Replace(".txt", "_thinking.txt"), aiThinking);
                }

                /*}
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error on iteration {i}: {ex.Message}");
                }*/
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            richTextBox1.Enabled = true;
            richTextBox2.Enabled = checkBox1.Checked;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            comboBox3.Enabled = checkBox2.Checked;
        }
        // select output directory button
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (outputPath != "") { folderBrowserDialog.InitialDirectory = outputPath; }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog.SelectedPath;
                if (!outputPath.EndsWith("\\")) { outputPath += "\\"; } // prevents just "C:" values
                textBox1.Text = outputPath;
            }
        }
        // set test count numeric up down control
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { testCount = (int)numericUpDown1.Value; }
        // prompt rich text box text changed
        private void richTextBox1_TextChanged(object sender, EventArgs e) { prompt = richTextBox1.Text.Trim(); }
        // stop button click
        private void button3_Click(object sender, EventArgs e)
        {
            stop = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            richTextBox1.Enabled = true;
            richTextBox2.Enabled = checkBox1.Checked;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            comboBox3.Enabled = checkBox2.Checked;
        }
        // system prompt rich text box changed
        private void richTextBox2_TextChanged(object sender, EventArgs e) { system = richTextBox2.Text.Trim(); }
        // enable custom system prompt checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { richTextBox2.Enabled = checkBox1.Checked; }
        // persona selection combobox
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked) { richTextBox3.Text = ""; return; }
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    chosenPersona = ossPersona;
                    break;
                case 1:
                    chosenPersona = llamaPersona;
                    break;
                case 2:
                    chosenPersona = "";
                    break;
                case 3:
                    chosenPersona = "deepseek-r1:8b persona shifting not implemented.";
                    break;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    chosenPersona = ossTemplate + chosenPersona + "\n" + LoadResource("template-gpt-oss.20b.txt");
                    break;
                case 1:
                    chosenPersona = LoadResource("template-llama3.2-start.txt") + chosenPersona + "\n" + LoadResource("template-llama3.2-end.txt");
                    break;
                case 2:
                    if (comboBox3.SelectedIndex == 2)
                    {
                        chosenPersona = LoadResource("template-gemma3.27b-start.txt") + LoadResource("template-gemma3.27b-end.txt");
                    }
                    else
                    {
                        chosenPersona = LoadResource("template-gemma3.27b-start.txt") + chosenPersona + "\n" + LoadResource("template-gemma3.27b-end.txt");
                    }
                    break;
                case 3:
                    //
                    break;
            }
            richTextBox3.Text = chosenPersona;
        }
        private string LoadResource(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"Non_Existent_Data_LLM_Stress_Testing.templates.{fileName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)
                   ?? throw new FileNotFoundException($"Could not find resource: {resourceName}"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        // persona shift checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { comboBox3.Enabled = checkBox2.Checked; comboBox3_SelectedIndexChanged(null!, null!); }
        // temperature numeric up down control
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { temperature = (float)numericUpDown2.Value; }
        // converse
        private void button4_Click(object sender, EventArgs e) { newForm(new Converse()); }
        // create new form method
        private void newForm(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
            form.Move += (s, args) => { if (this.Location != form.Location) { this.Location = form.Location; } };
        }
        // context tokens
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { context = (int)numericUpDown3.Value; }
    }
}