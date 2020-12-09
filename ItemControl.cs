using System;
using System.Windows.Forms;

namespace lika_laba3
{
    public delegate void ItemClickHandler(int index); 
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        public int Index
        {
            get => int.Parse(i.Text);
            set => i.Text = value.ToString();
        }

        public int Cost
        {
            get => int.Parse(c.Text);
            set => c.Text = value.ToString();
        }
       
        public int Weight
        {
            get => int.Parse(w.Text);
            set => w.Text = value.ToString();
        }
        
        public event ItemClickHandler ButtonClick;
        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this.Index);
        }
    }
}