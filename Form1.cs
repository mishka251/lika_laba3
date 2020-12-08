using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lika_laba3
{
    public partial class Form1 : Form
    {
        private const int tbH = 30;
        private const int tbW = 160;

        private const int tbPad = 20;
        private const int tbTopPad = 35;
        
        List<ItemControl> items = new List<ItemControl>();
        
        public Form1()
        {
            InitializeComponent();
            //данные варианта
            var data =
                new[]
                {
                    new {w = 4, c = 40},
                    new {w = 5, c = 49},
                    new {w = 7, c = 50},
                    new {w = 8, c = 51},
                    new {w = 9, c = 53},
                };

            for (int i = 0; i < data.Length; i++)
            {
                ItemControl component = new ItemControl()
                {
                    Cost = data[i].c,
                    Weight = data[i].w,
                    Index = (i+1)
                };
                component.Left = 10;
                component.Width = tbW;
                component.Top = tbTopPad + i * (tbH + tbPad);
                component.Height = tbH;
                component.ButtonClick += this.onComponentDelete;
                
                this.panel1.Controls.Add(component);
                items.Add(component);

            }
        }

        void onComponentDelete(int index)
        {
            panel1.Controls.Remove(items[index]);
            items.RemoveAt(index);

            for (int i = index; i < items.Count; i++)
            {
                items[i].Index = i+1;
                items[i].Top -= tbH + tbPad;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ItemControl component = new ItemControl()
            {
                Cost = 0,
                Weight = 0,
                Index = this.items.Count,
            };
            component.Left = 10;
            component.Width = tbW;
            component.Top = tbTopPad + items.Count * (tbH + tbPad);
            component.Height = tbH;
            component.ButtonClick += this.onComponentDelete;
                
            this.panel1.Controls.Add(component);
            items.Add(component);
        }
    }
}
