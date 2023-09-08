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
            listView1.Columns.Add("Contatos",80);
            listView1.Columns.Add("Status", 80);
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
                MessageBox.Show("Nenhum Contato encontrado");
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
            ListViewItem newcontato = new ListViewItem(textBox1.Text);
            listView1.Items.Add(newcontato);
            textBox1.Text = "";
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
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text ;
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
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            }
        }
    }
}