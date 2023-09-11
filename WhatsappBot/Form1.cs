namespace WhatsappBot
{
    public partial class Form1 : Form
    {
        private WhatsAppSendMessage WhatsAppSendMessage;


        public Form1()
        {
            InitializeComponent();
            WhatsAppSendMessage = new WhatsAppSendMessage(listView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            listView1.Columns.Add("Telefone",100);
            listView1.Columns.Add("Nome", 60);
            listView1.Columns.Add("Status", 60);
            WhatsAppSendMessage.EnterSite();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("Mensagem tem que ter algum valor");
            }
            else if(listView1.Items.Count == 0)
            {
                MessageBox.Show("Nenhum Telefone encontrado");
            }
            else
            {
                ListViewItem newcontato = new ListViewItem();
                List<string> telefone = new List<string>();
                List<string> nome = new List<string>();
                string mensagem = richTextBox1.Text;

                for (int i=0; i<listView1.Items.Count ;i++)
                {
                    telefone.Add(listView1.Items[i].Text);
                    nome.Add(listView1.Items[i].SubItems[1].Text);
                }

           

                WhatsAppSendMessage.SendMessage(mensagem, telefone, nome);
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mask = "(99) 9999-9999";
            string input = maskedTextBox1.Text;

            // Remova todos os caracteres não numéricos da entrada
            string numericInput = new string(input.Where(char.IsDigit).ToArray());

            // Verifique se o número de dígitos na entrada é igual ao número de dígitos na máscara
            bool isFilledWithNumbers = numericInput.Length == mask.Count(c => c == '9');

            if (isFilledWithNumbers)
            {
                ListViewItem newcontato = new ListViewItem(maskedTextBox1.Text);
                listView1.Items.Add(newcontato);
                newcontato.SubItems.Add(textBox2.Text);
                maskedTextBox1.Text = "";
                textBox2.Text = "";
                // O MaskedTextBox está preenchido com números.
                Console.WriteLine("O MaskedTextBox está preenchido com números.");
            }
            else
            {
                // O MaskedTextBox não está preenchido com números.
                MessageBox.Show("O MaskedTextBox não está preenchido com números.");
            }
          
            
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = maskedTextBox1.Text ;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.Text.Length != maskedTextBox1.Mask.Length)
                maskedTextBox1.ResetText();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

                maskedTextBox1.Mask = "(99) 9999-9999";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse CSV File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "CSV files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                try
                {
                    ImportCSV(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao importar o arquivo CSV: {ex.Message}");
                }
            }
        }


        private void ImportCSV(string filePath)
        {
            // Lê todas as linhas do arquivo CSV
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Limpa a ListView
            listView1.Items.Clear();

            // Adiciona colunas se não existirem
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Telefone", 100);
                listView1.Columns.Add("Nome", 60);
            }

            foreach (string line in lines)
            {
                // Divide a linha do CSV em campos
                string[] fields = line.Split(',');

                // Certifique-se de que há pelo menos 2 campos (Telefone e Nome)
                if (fields.Length >= 2)
                {
                    ListViewItem item = new ListViewItem(fields[0]);
                    item.SubItems.Add(fields[1]);
                    listView1.Items.Add(item);
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void ExportToCSV()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Salvar arquivo CSV",
                FileName = "exported_data.csv",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {

                    // Escreve os dados da ListView no arquivo CSV
                    foreach (ListViewItem item in listView1.Items)
                    {
                        string telefone = item.SubItems[0].Text;
                        string nome = item.SubItems[1].Text;
                        writer.WriteLine($"{telefone}, {nome}");
                    }
                }

                MessageBox.Show("Dados exportados com sucesso para arquivo CSV!");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text += "{nome}";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox2.Visible = true;
            richTextBox1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox2.Visible = false;
            richTextBox1.Visible = true;
        }
    }
}