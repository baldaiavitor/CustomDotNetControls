using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class CustomProgressBar : UserControl
    {
        public CustomProgressBar()
        {
            InitializeComponent();
            setDoubleBuffer(true);
        }

        #region Private Varables
        private int space = 0;
        private int blockSize = 0;
        private int progressWidth = 0;
        private int MaxValue = 100;
        private double lastValue;
        private List<Rectangle> blocks = new List<Rectangle>();
        #endregion

        #region Properties
        public Color FillColor
        {
            get { return VerticalBar1.BackColor; }
            set { VerticalBar1.BackColor = value; }
        }

        public Color TextColor
        {
            get { return Text.ForeColor; }
            set { Text.ForeColor = value; }
        }

        private decimal maximum = 100;
        public decimal Maximum
        {
            get { return maximum; }
            set { 
                if (value > 9999) { 
                    value = 9999; 
                }
                if (value < 100)
                {
                    value = 100;
                }
                maximum = value; 
            }
        }

        private decimal _value = 0;
        public decimal Value
        {
            get { return _value; }
            //set { _value = value; }
        }

        private Enums.FillMode _FillMode = Enums.FillMode.Block;
        public Enums.FillMode FillMode
        {
            get { return _FillMode; }
            set { _FillMode = value; }
        }

        #endregion

        #region Initialization Functions
        private void setDoubleBuffer(bool Bool)
        {
            DoubleBuffered = Bool;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, Bool);
        }
        #endregion

        #region Calculation Functions
        private void calculateBlocks()
        {
            this.blockSize = this.Width / this.MaxValue;
            this.space = blockSize / 4;
        }

        public int getPercentage()
        {
            decimal X = (this.Value / this.maximum) * 100m;
            int result = Decimal.ToInt32(X);
            return result;
        }

        private decimal getPercentage(decimal a, decimal b)
        {
            decimal X = (a / b) * 100m;
            return X;
        }
        #endregion

        #region Auxiliar Functions
        private Rectangle getBlock()
        {
            Rectangle rec = new Rectangle(VerticalBar1.Location, new Size(this.blockSize, VerticalBar1.Height));
            return rec;
        }

        private void addBlock()
        {
            Rectangle block = getBlock();
            int X = progressWidth + space;
            Point blockLocation = new Point(X, block.Location.Y);
            block.Location = blockLocation;
            blocks.Add(block);
            progressWidth = progressWidth + (space + block.Width);
        }
        
        private Brush getBrush(Enums.BrushType Type)
        {
            if(Type == Enums.BrushType.TextBrush)
            {
                return new SolidBrush(this.Text.ForeColor);
            }
            else
            {
                return new SolidBrush(this.VerticalBar1.BackColor);
            }
        }
        #endregion

        #region Painting Functions
        private void paintProgress(PaintEventArgs e)
        {
            if (FillMode == Enums.FillMode.Block)
            {
                foreach (Rectangle rec in blocks)
                {
                    //Progress
                    e.Graphics.FillRectangle(getBrush(Enums.BrushType.FillingBrush), rec);
                }
            }
            else
            {
                Rectangle rec = blocks[0];
                rec.Width = progressWidth;
                //Progress
                e.Graphics.FillRectangle(getBrush(Enums.BrushType.FillingBrush), rec);
            }

        }

        private void paintText(PaintEventArgs e)
        {
            //text
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Text.Text,
                this.Font, getBrush(Enums.BrushType.TextBrush), ClientRectangle, sf);
        }
        #endregion

        #region Events
        private void CustomProgressBar_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        private void CustomProgressBar_Paint(object sender, PaintEventArgs e)
        {
            doPainting(sender, e);
        }
        #endregion

        #region Event Functions
        private void onLoad()
        {
            Text.Font = this.Font;
            Text.Visible = false;
            calculateBlocks();
        }

        private void doPainting(object sender, PaintEventArgs e)
        {
            if (blocks.Count > 0)
            {
                paintProgress(e);
            }
            paintText(e);
        }
        #endregion

        #region Actions
        public void ProgressStep()
        {
            if (this.Value < this.maximum)
            {
                this._value = this.Value + 1;
                lastValue = lastValue + Decimal.ToDouble(getPercentage(1, this.Maximum));
                if (lastValue >= 1)
                {
                    addBlock();
                    lastValue = 0;
                }
                this.Text.Text = String.Format("{0}%", getPercentage());
                this.Refresh();
            }
        }


        public void Progress(int Percentage)
        {
            int percentage = getPercentage();
            int X = percentage + Percentage;
            if (percentage < MaxValue)
            {
                while (getPercentage() != X)
                {
                    if (getPercentage() == 100)
                    {
                        break;
                    }
                    else
                    {
                        ProgressStep();
                    }
                }
                this.Text.Text = String.Format("{0}%", getPercentage());
                this.Refresh();
            }
        }
        #endregion
    }
}
