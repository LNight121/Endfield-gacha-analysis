using System.Numerics;

namespace Endfield
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.label1, "在旧卡池中投入的抽数，大于60的填入60");
            var toolTip2 = new System.Windows.Forms.ToolTip();
            toolTip2.SetToolTip(this.label4, "旧卡池的剩余免费抽数");
        }
        double fpow(double a, long b)
        {
            double res = 1;
            while (b != 0)
            {
                if ((b & 1) != 0) res *= a;
                a *= a;
                b >>= 1;
            }
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            double[] frac = new double[11];
            frac[0] = 1;
            for (int i = 1; i < 11; i++) frac[i] = frac[i - 1] * i;
            double[] f = new double[11];
            for (int i = 0; i <= 10; i++)
            {
                f[i] = frac[10] / frac[i] / frac[10 - i] * fpow(1 - 0.004, 10 - i) * fpow(0.004, i);
            }
            int k = int.Parse(maskedTextBox4.Text);
            double[,,,] dp5 = new double[2, 120, 80, k + 1];//总抽数，大保底，小保底，出了几个
            double[,,,] dp15 = new double[2, 120, 80, k + 1];
            for (int i = 120 * k - 1; i >= 0; i--)
            {
                for (int a = 0; a < 120; a++)
                {
                    if (a + 1 == 120)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp5[i & 1, a, b, c] = dp5[i & 1 ^ 1, 0, 0, c + 1] + 1;
                            }
                        }
                    }
                    else
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            double g = 0.008;
                            if (b >= 65) g += 0.05 * (b - 64);
                            if (b + 1 == 80) g = 1;
                            for (int c = 0; c < k; c++)
                            {
                                dp5[i & 1, a, b, c] = (dp5[i & 1 ^ 1, a + 1, 0, c] + dp5[i & 1 ^ 1, 0, 0, c + 1]) * g / 2;
                                if (b + 1 < 80) dp5[i & 1, a, b, c] += (1 - g) * dp5[i & 1 ^ 1, a + 1, b + 1, c];
                                if (i >= 5) dp5[i & 1, a, b, c]++;
                            }
                        }
                    }
                }
                if (i % 240 == 0 && i != 0)
                {
                    for (int a = 0; a < 120; a++)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp5[i & 1, a, b, c] = dp5[i & 1, a, b, c + 1];
                            }
                        }
                    }
                }
                if (i == 30)
                {
                    for (int a = 0; a < 120; a++)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp5[i & 1, a, b, c] = dp5[i & 1, a, b, c] * f[0];
                                for (int ze = 1; ze + c < k; ze++)
                                {
                                    dp5[i & 1, a, b, c] += dp5[i & 1, a, b, c + ze] * f[ze];
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 120 * k - 1; i >= 0; i--)
            {
                for (int a = 0; a < 120; a++)
                {
                    if (a + 1 == 120)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp15[i & 1, a, b, c] = dp15[i & 1 ^ 1, 0, 0, c + 1] + 1;
                            }
                        }
                    }
                    else
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            double g = 0.008;
                            if (b >= 65) g += 0.05 * (b - 64);
                            if (b + 1 == 80) g = 1;
                            for (int c = 0; c < k; c++)
                            {
                                dp15[i & 1, a, b, c] = (dp15[i & 1 ^ 1, a + 1, 0, c] + dp15[i & 1 ^ 1, 0, 0, c + 1]) * g / 2;
                                if (b + 1 < 80) dp15[i & 1, a, b, c] += (1 - g) * dp15[i & 1 ^ 1, a + 1, b + 1, c];
                                if (i >= 15) dp15[i & 1, a, b, c]++;
                            }
                        }
                    }
                }
                if (i % 240 == 0 && i != 0)
                {
                    for (int a = 0; a < 120; a++)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp15[i & 1, a, b, c] = dp15[i & 1, a, b, c + 1];
                            }
                        }
                    }
                }
                if (i == 30)
                {
                    for (int a = 0; a < 120; a++)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            for (int c = 0; c < k; c++)
                            {
                                dp15[i & 1, a, b, c] = dp15[i & 1, a, b, c] * f[0];
                                for (int ze = 1; ze + c < k; ze++)
                                {
                                    dp15[i & 1, a, b, c] += dp15[i & 1, a, b, c + ze] * f[ze];
                                }
                            }
                        }
                    }
                }
            }
            int x = int.Parse(maskedTextBox1.Text);
            int y = int.Parse(maskedTextBox2.Text);
            int z = int.Parse(maskedTextBox3.Text);
            int w = int.Parse(maskedTextBox5.Text);
            if (x > 60) x = 60;
            double[,,,] dp2 = new double[2, 120, 80, w + 1];//总抽数，大保底，小保底，剩多少赠送
            for (int i = 0; i < 2; i++)
            {
                for (int a = 0; a < 120; a++)
                {
                    for (int b = 0; b < 80; b++)
                    {
                        dp2[i, a, b, 0] = dp15[0, 0, b, 0];
                    }
                }
            }
            if (x == 60 && w == 0)
            {
                double tmp = 0;
                if (y + 1 == 120) tmp = dp2[1, 0, 0, 0];
                else
                {
                    if (z + 1 == 80)
                    {
                        tmp = (dp2[1, 0, 0, 0] + dp2[1, y, 0, 0]) / 2;
                    }
                    else
                    {
                        double g = 0.008;
                        if (z >= 65) g += 0.05 * (z - 64);
                        tmp = g * (dp2[1, 0, 0, 0] + dp2[1, y, 0, 0]) / 2 + (1 - g) * dp2[1, y + 1, z + 1, 0];
                    }
                }
                label5.Text = $"此时不应该抽卡\n抽卡的期望为:{tmp + 1}\n不抽卡的期望为:{dp2[0, y, z, 0]}";
            }
            for (int c = 1; c <= w; c++)
            {
                for (int a = 0; a < 120; a++)
                {
                    for (int b = 0; b < 80; b++)
                    {
                        dp2[0, a, b, c] = dp15[0, 0, b, 0];
                        double tmp = 0;
                        if (a + 1 == 120) tmp = dp2[1, 0, 0, c - 1];
                        else
                        {
                            if (b + 1 == 80)
                            {
                                tmp = (dp2[1, 0, 0, c - 1] + dp2[1, a, 0, c - 1]) / 2;
                            }
                            else
                            {
                                double g = 0.008;
                                if (b >= 65) g += 0.05 * (b - 64);
                                tmp = g * (dp2[1, 0, 0, c - 1] + dp2[1, a, 0, c - 1]) / 2 + (1 - g) * dp2[1, a + 1, b + 1, c - 1];
                            }
                        }
                        if (tmp < dp2[0, a, b, c])
                        {
                            if (x == 60 && y == a && z == b && w == c) label5.Text = $"此时应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[0, a, b, c]}";
                            dp2[0, a, b, c] = tmp;
                        }
                        else
                        {
                            if (x == 60 && y == a && z == b && w == c) label5.Text = $"此时不应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[0, a, b, c]}";
                        }
                        dp2[1, a, b, c] = dp2[0, a, b, c];
                    }
                }
            }
            for (int i = 59; i >= 0; i--)
            {
                for (int c = 1; c <= w; c++)
                {
                    for (int a = 0; a < 120; a++)
                    {
                        for (int b = 0; b < 80; b++)
                        {
                            dp2[i & 1, a, b, c] = dp5[0, 0, b, 0];
                            double tmp = 0;
                            if (a + 1 == 120) tmp = dp2[1 & 1 ^ 1, 0, 0, c - 1];
                            else
                            {
                                if (b + 1 == 80)
                                {
                                    tmp = (dp2[i & 1 ^ 1, 0, 0, c - 1] + dp2[i & 1 ^ 1, a, 0, c - 1]) / 2;
                                }
                                else
                                {
                                    double g = 0.008;
                                    if (b >= 65) g += 0.05 * (b - 64);
                                    tmp = g * (dp2[i & 1 ^ 1, 0, 0, c - 1] + dp2[i & 1 ^ 1, a, 0, c - 1]) / 2 + (1 - g) * dp2[i & 1 ^ 1, a + 1, b + 1, c - 1];
                                }
                            }
                            if (tmp < dp2[i & 1, a, b, c])
                            {
                                if (x == i && y == a && z == b && w == c) label5.Text = $"此时应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[i & 1, a, b, c]}";
                                dp2[i & 1, a, b, c] = tmp;
                            }
                            else
                            {
                                if (x == i && y == a && z == b && w == c) label5.Text = $"此时不应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[i & 1, a, b, c]}";
                            }
                        }
                    }
                }
                for (int a = 0; a < 120; a++)
                {
                    for (int b = 0; b < 80; b++)
                    {
                        dp2[i & 1, a, b, 0] = dp5[0, 0, b, 0];
                        double tmp = 0;
                        if (a + 1 == 120) tmp = dp2[1 & 1 ^ 1, 0, 0, 0];
                        else
                        {
                            if (b + 1 == 80)
                            {
                                tmp = (dp2[i & 1 ^ 1, 0, 0, 0] + dp2[i & 1 ^ 1, a, 0, 0]) / 2;
                            }
                            else
                            {
                                double g = 0.008;
                                if (b >= 65) g += 0.05 * (b - 64);
                                tmp = g * (dp2[i & 1 ^ 1, 0, 0, 0] + dp2[i & 1 ^ 1, a, 0, 0]) / 2 + (1 - g) * dp2[i & 1 ^ 1, a + 1, b + 1,0];
                            }
                        }
                        tmp++;
                        if (tmp < dp2[i & 1, a, b, 0])
                        {
                            if (x == i && y == a && z == b && w == 0) label5.Text = $"此时应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[i & 1, a, b, 0]}";
                            dp2[i & 1, a, b, 0] = tmp;
                        }
                        else
                        {
                            if (x == i && y == a && z == b && w == 0) label5.Text = $"此时不应该抽卡\n抽卡的期望为:{tmp}\n不抽卡的期望为:{dp2[i & 1, a, b, 0]}";
                        }
                    }
                }
            }
        }
    }
}
