using System;
using System.Windows.Forms;

namespace Comparacao_de_string
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.AutoCheck = true; // isso para iniciar o form com os radiobuttons desmarcados.
            radioButton2.AutoCheck = true; // selecionar todos os radiobuttons no design e marcar a proriedade AutoCheck para False.
            radioButton3.AutoCheck = true;
            radioButton4.AutoCheck = true;
            textBox1.Select();
            textBox1.Focus();

        }


        // rotina para verificar o radio buttom selecionado. Retorna o índice que começa com zero
        public int getCheckedRadioButton(Control c)
        {
            int i, index = -1;
            Control.ControlCollection cc = c.Controls;
            for (i = 0; i < cc.Count; i++)
            {
                if (cc[i] is RadioButton)
                {
                    index++;
                    RadioButton rb = cc[i] as RadioButton;
                    if (rb.Checked)
                    {
                        return index;  //retorna o indice do RadioButton selecionado
                    }
                }
            }
            
            return -1;
        }

        // rotina para comparar
        private void btn_Compara_Click(object sender, EventArgs e)
        {
                 int ver = getCheckedRadioButton(groupBox1); // chama a função que retorna o índice do RadioButton selecionado e guarda em ver
                 if (ver == -1)
                 {
                     System.Console.Beep();
                     label3.Text = "Favor selecionar um método.";
                 }
                 else
                     if ((textBox1.Text == string.Empty || textBox2.Text == string.Empty) || (textBox1.Text == string.Empty && textBox2.Text == string.Empty))
                     {
                         System.Console.Beep();
                         label3.Text = "Favor preencher as strings a serem comparadas.";
                         //textBox1.Text = ver.ToString(); // SE QUISESSE RETORNAR O NOME SERIA DESSA FORMA.
                     }
                     else
                     {
                         switch (ver)
                         {
                             case 0:
                                 System.Console.Beep();
                                 // Compara as strings usando String.Equals  
                                 if (String.Equals(textBox1.Text, textBox2.Text))
                                     label3.Text = "As strings são iguais.";
                                 else
                                     label3.Text = "As strings são diferentes.";
                                 break;

                             case 1:
                                 System.Console.Beep();
                                 // Usando o método String.Compare
                                 if (String.Compare(textBox1.Text, textBox2.Text) == 0)
                                     label3.Text = "As strings são iguais.";
                                 else if (String.Compare(textBox1.Text, textBox2.Text) < 0)
                                     label3.Text = textBox1.Text + " vem antes de " + textBox2.Text;
                                 else if (String.Compare(textBox1.Text, textBox2.Text) > 0)
                                     label3.Text = textBox1.Text + " vem depois de " + textBox2.Text;
                                 break;

                             case 2:
                                 System.Console.Beep();
                                 // Usando o método CompareTo
                                 if (textBox1.Text.CompareTo(textBox2.Text) == 0)
                                     label3.Text = "As strings são iguais.";
                                 else if (textBox1.Text.CompareTo(textBox2.Text) < 0)
                                     label3.Text = textBox1.Text + " vem antes de " + textBox2.Text;
                                 else if (textBox1.Text.CompareTo(textBox2.Text) > 0)
                                     label3.Text = textBox1.Text + " vem depois de " + textBox2.Text;
                                 break;

                             case 3:
                                 System.Console.Beep();
                                 //Usando StringComparer  
                                 StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                                 if (comparer.Compare(textBox1.Text, textBox2.Text) == 0)
                                     label3.Text = "As strings são iguais.";
                                 else if (comparer.Compare(textBox1.Text, textBox2.Text) < 0)
                                     label3.Text = textBox1.Text + " vem antes de " + textBox2.Text;
                                 else if (comparer.Compare(textBox1.Text, textBox2.Text) > 0)
                                     label3.Text = textBox1.Text + " vem depois de " + textBox2.Text;
                                 break;

                         }
                     }
        }


        // Rotina que limpa os controles
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            label3.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
