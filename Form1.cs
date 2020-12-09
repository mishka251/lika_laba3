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
    class Item
    {
        public int w;
        public int c;
    }

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
                new Item[]
                {
                    new Item() {w = 4, c = 40},
                    new Item() {w = 5, c = 49},
                    new Item() {w = 7, c = 50},
                    new Item() {w = 8, c = 51},
                    new Item() {w = 9, c = 53},
                };

            for (int i = 0; i < data.Length; i++)
            {
                ItemControl component = new ItemControl()
                {
                    Cost = data[i].c,
                    Weight = data[i].w,
                    Index = (i + 1)
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
                items[i].Index = i + 1;
                items[i].Top -= tbH + tbPad;
            }
        }

        List<int> rukzak = new List<int>();
        List<int> bestIndex = new List<int>();
        List<int> itemsCount = new List<int>();

        List<Item> parseData()
        {
            return items.Select(item => new Item() {w = item.Weight, c = item.Cost}).ToList();
        }

        void calculate()
        {
            int maxW = int.Parse(this.tbY.Text);

            rukzak = new List<int>();
            bestIndex = new List<int>();
            List<Item> data = parseData();
            int minW = data.Min(item => item.w);


            for (int w = 0; w <minW; w++)
            {
                rukzak.Add(0);
                bestIndex.Add(-1);
            }

            for (int w = minW; w <= maxW; w++)
            {
                int max = rukzak[w - 1];
                int bestI = -1;
                for (int i = 0; i < data.Count; i++)
                {
                    var item = data[i];
                    if (item.w > w)
                    {
                        continue;
                    }

                    int cost = item.c + rukzak[w - item.w];
                    if (cost > max)
                    {
                        max = cost;
                        bestI = i;
                    }
                }

                rukzak.Add(max);
                bestIndex.Add(bestI);
            }

            this.itemsCount = new List<int>();

            foreach (var item in items)
            {
                itemsCount.Add(0);
            }
            
            int tmp = maxW;
            while (tmp > 0)
            {
                
                int index = bestIndex[tmp];
                if (index == -1)
                {
                    if (rukzak[tmp] > 0)
                    {
                        while (index == -1)
                        {
                            tmp--;
                            index = bestIndex[tmp];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                itemsCount[index] += 1;
                tmp -= data[index].w;
            }
            
            this.ShowData(maxW);
        }

        void ShowData(int maxW)
        {
            int lblW = 25;
            int lblPad = 5;

            int lblH = 15;

            this.panel2.Controls.Clear();
            for (int i = 0; i <= maxW; i++)
            {
                Label w = new Label();
                w.Top = 10;
                w.Left = 25 + lblPad + i * (lblW + lblPad);
                w.Height = 20;
                w.Width = lblW;
                w.Text = i.ToString();

                Label c = new Label();
                c.Top = 10 + (lblPad + 20);
                c.Left = 25 + lblPad + i * (lblW + lblPad);
                c.Height = 20;
                c.Width = lblW;
                c.Text = rukzak[i].ToString();

                Label ind = new Label();
                ind.Top = 10 + 2 * (lblPad + 20);
                ind.Left = 25 + lblPad + i * (lblW + lblPad);
                ind.Height = 20;
                ind.Width = lblW;
                ind.Text = bestIndex[i].ToString();

                panel2.Controls.Add(w);
                panel2.Controls.Add(c);
                panel2.Controls.Add(ind);
            }

            this.panel3.Controls.Clear();
            for (int i = 0; i < itemsCount.Count; i++)
            {
                Label ind = new Label();
                ind.Top = 10 + i * (lblPad + lblH);
                ind.Left = 10;
                ind.Height = lblH;
                ind.Width = 30;
                ind.Text = i.ToString();
                
                Label cnt = new Label();
                cnt.Top = 10 + i * (lblPad + lblH);
                cnt.Left = 10+30+10;
                cnt.Height = lblH;
                cnt.Width = 30;
                cnt.Text = itemsCount[i].ToString();
                
                panel3.Controls.Add(ind);
                panel3.Controls.Add(cnt);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.calculate();
        }
    }
}