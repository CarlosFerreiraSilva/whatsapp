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

                List<string> pessoa = new List<string>();  
                string mensagem = richTextBox1.Text;

                for (int i=0; i<listView1.Items.Count ;i++)
                {
                    pessoa.Add(listView1.Items[i].Text);
                }

                WhatsAppSendMessage.SendMessage(mensagem, pessoa);
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
            string mask = "(99) 99999-9999";
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
                Console.WriteLine("O MaskedTextBox não está preenchido com números.");
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

                maskedTextBox1.Mask = "(99) 99999-9999";

        }
    }
}