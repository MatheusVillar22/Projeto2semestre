using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace UniFit
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
          
        }

        private void buttonInsiraUmaFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void CarregarFoto(object sender, CancelEventArgs e)
        {
            OpenFileDialog p = (OpenFileDialog)sender;

            pictureBox2.Image = Image.FromFile(p.FileName);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBuscarCep_Click(object sender, EventArgs e)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + textBoxCep.Text + "/json/?ra=123&senha=uni9");
            myReq.ContentType = "application/json";
            myReq.Method = "GET";
            var myResp = (HttpWebResponse)myReq.GetResponse();

            using (var streamReader = new StreamReader(myResp.GetResponseStream()))
            {
                var resultQR = streamReader.ReadToEnd();
                string jsonStringsign = resultQR;
                JObject meuJson = JObject.Parse(jsonStringsign);

                textBoxLogradouro.Text = meuJson.Root["logradouro"].ToString();
                textBoxBairro.Text = meuJson.Root["bairro"].ToString();
                //textBoxCidade.Text = meuJson.Root["localidade"].ToString();
                //textBoxEstado.Text = meuJson.Root["uf"].ToString();
            }
        }
    }
}
