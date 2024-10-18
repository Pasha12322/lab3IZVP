using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace List
{
    public partial class FormStart : Form
    {
        ElementList LastList;
        public FormStart()
        {
            InitializeComponent();
            LastList = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   string res = "";
            string PIB = Interaction.InputBox("Введіть ПІБ учня для запису у список");
            if (LastList == null || String.Compare(PIB, LastList.PIB)<0)
            {
                ElementList p = new ElementList(PIB);
                p.next = LastList;
                LastList = p;
                res = "Елемент вставлено в кінець списку";
                goto endProc;
            }
            else
            {
                ElementList current = LastList;
                while (current.next != null)
                {
                    if (current.next.PIB == PIB)
                    {
                        res = "Такий елемент вже наявний в списку";
                        goto endProc;
                    }
                    if (String.Compare(PIB, current.next.PIB) > 0)
                        current = current.next;
                    else
                        break;
                }
                ElementList p = new ElementList(PIB);
                p.next = current.next;
                current.next=p;
                res = "Елемент вставлено в список";
            }
            endProc:
                MessageBox.Show(res);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string res = "";
            ElementList p=LastList;
            while (p!=null)
            {
                res += "\n"+p.PIB;
                p = p.next;
            }
            MessageBox.Show("Елементи списку " + (res == "" ? "відсутні" : res));
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LastList==null)
            {
                MessageBox.Show("Список порожній");
                return;
            }
            string PIB = Interaction.InputBox("Введіть ПІБ учня для вилучення зі списку");
            if (LastList.PIB==PIB)
            {
                LastList = LastList.next;
                return;
            }
            ElementList current = LastList;
            bool znaydeno = false;
            while (current.next != null)
                if (current.next.PIB == PIB)
                {
                    current.next = current.next.next;
                    znaydeno = true;
                    break;
                }
                else
                    current = current.next;
            MessageBox.Show("Елемент '"+PIB+"' " + (znaydeno ? "вилучено успішно" : "не знайдено в списку"));
        }
    }
}
