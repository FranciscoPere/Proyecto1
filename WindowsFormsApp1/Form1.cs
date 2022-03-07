using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        List<Visitas> Veces = new List<Visitas>();
        int ContadorVisitas =0;
        public Form1()
        {
            InitializeComponent();
            string ux = "";
            LeerDatos(ux);
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string lnk = "";
            if (comboBox2.Text != null)
                lnk = comboBox2.Text;
            else if (comboBox2.SelectedItem != null)
                lnk = comboBox2.SelectedItem.ToString();
            if (!lnk.Contains("."))
                lnk = "https://www.google.com/search?q=" + lnk;
            if (!lnk.Contains("https://"))
                lnk = "https://" + lnk;
            int nuevo = 0;
            webBrowser1.Navigate(new Uri(lnk));
            Guardar(lnk+","+"1");
            /**************************************************/

           


            }



        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void sigueinteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();

        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        private void Guardar(String varLnk){
            try
            {
                using (StreamWriter w = File.AppendText("C:/Users/Francisco/Desktop/Progra ll/Links.txt"))
                {
                    w.WriteLine(""+varLnk);
                }
            
           }
            catch (Exception e) {      
            }
           
            LeerDatos(varLnk);

        }





        private void LeerDatos(String AuxL)
        {
            llenarLista();
            comboBox2.Items.Clear();
            using (StreamReader leer=new StreamReader("C:/Users/Francisco/Desktop/Progra ll/Links.txt"))
            {
                while (!leer.EndOfStream)
                {
                    String aux = leer.ReadLine();
                  
                        char[] separador = { ',' };
                        String[] seprados = aux.Split(separador);


                        int num_var = Int32.Parse(seprados[1]);
                        Visitas Nhisto = new Visitas(seprados[0], num_var);
                        

                        comboBox2.Items.Add(seprados[0]);
                    
                   
                   
                }


            }


        }



        private void button3_Click(object sender, EventArgs e)
        {
           
            comboBox2.Items.Clear();
            IEnumerable<Visitas> ordenado = Veces.OrderByDescending(Norder => Norder.contados());
            foreach (Visitas Norder in ordenado)
            {
                comboBox2.Items.Add(Norder.Link());  

            }


            }
            
        



        public void llenarLista() {
           
            using (StreamReader leer = new StreamReader("C:/Users/Francisco/Desktop/Progra ll/Links.txt"))
            {
                int cont = 0;
                while (!leer.EndOfStream)
                {
                    String aux = leer.ReadLine();
                    llenardos(aux);
                    
                }


            }
        }




        private void llenardos(String aux)
        {
           
            
                char[] separador = { ',' };
                String[] seprados = aux.Split(separador);
              

                    int num_var = Int32.Parse(seprados[1]);
                    Visitas Nhisto = new Visitas(seprados[0], num_var);
                    Veces.Add(Nhisto);
                
            

         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Remove(comboBox2.Text);
        }
    }
}
