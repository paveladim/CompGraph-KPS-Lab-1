using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filters_KPS;

namespace CG_IMGPROC
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true) 
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void полутонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void повыситьРезкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new GreyWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ScharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторПрюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PrewittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves1Filter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волны2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves2Filter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void запускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void dilationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран структурный элемент", "Ошибка");
                return;
            }

            int chosen_elem = comboBox1.SelectedIndex;
            Filters filter = new DilationFilter(chosen_elem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран структурный элемент", "Ошибка");
                return;
            }

            int chosen_elem = comboBox1.SelectedIndex;
            Filters filter = new ErosionFilter(chosen_elem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран структурный элемент", "Ошибка");
                return;
            }

            int chosen_elem = comboBox1.SelectedIndex;
            Filters filter = new OpeningFilter(chosen_elem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран структурный элемент", "Ошибка");
                return;
            }

            int chosen_elem = comboBox1.SelectedIndex;
            Filters filter = new ClosingFilter(chosen_elem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Не выбран структурный элемент", "Ошибка");
                return;
            }

            int chosen_elem = comboBox1.SelectedIndex;
            Filters filter = new GradFilter(chosen_elem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new LinearTension();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}

namespace Filters_KPS
{
    abstract class Filters
    {
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending) 
                    return null;

                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    }

    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                                255 - sourceColor.G,
                                                255 - sourceColor.B);

            return resultColor;
        }
    }

    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            int Intensity = ((int)intensity);
            Color resultColor = Color.FromArgb(Intensity, Intensity, Intensity);

            return resultColor;
        }
    }

    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            int Intensity = ((int)intensity);
            double k = 25;
            int R = Clamp((int)(Intensity + 2 * k), 0, 255);
            int G = Clamp((int)(Intensity + 0.5 * k), 0, 255);
            int B = Clamp((int)(Intensity - k), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);

            return resultColor;
        }
    }

    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double k = 75;
            int R = Clamp((int)(sourceColor.R + k), 0, 255);
            int G = Clamp((int)(sourceColor.G + k), 0, 255);
            int B = Clamp((int)(sourceColor.B + k), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);

            return resultColor;
        }
    }

    class GreyWorldFilter : Filters
    {
        private bool f;
        private double sum_red;
        private double sum_green;
        private double sum_blue;
        private double avg;

        public GreyWorldFilter()
        {
            f = false;
            sum_red = 0.0;
            sum_green = 0.0;
            sum_blue = 0.0;
            avg = 0.0;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (f != true)
            {
                for (int i = 0; i < sourceImage.Width; ++i)
                {
                    for (int j = 0; j < sourceImage.Height; ++j)
                    {
                        Color sourceColor = sourceImage.GetPixel(i, j);
                        sum_red += sourceColor.R;
                        sum_green += sourceColor.G;
                        sum_blue += sourceColor.B;
                    }
                }

                sum_red /= (sourceImage.Width * sourceImage.Height);
                sum_green /= (sourceImage.Width * sourceImage.Height);
                sum_blue /= (sourceImage.Width * sourceImage.Height);
                avg = (sum_red + sum_green + sum_blue) / 3;

                f = true;
            }

            Color srcColor = sourceImage.GetPixel(x, y);
            int R = (int)(srcColor.R * avg / sum_red);
            int G = (int)(srcColor.G * avg / sum_green);
            int B = (int)(srcColor.B * avg / sum_blue);
            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));

            return resultColor;
        }
    }
    class GlassFilter : Filters
    {
        private Random rand;
        public GlassFilter()
        {
            rand = new Random(DateTime.Now.Millisecond);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            bool stat1 = (x >= 5) && (x <= sourceImage.Width - 6);
            bool stat2 = (y >= 5) && (y <= sourceImage.Height - 6);

            if (stat1 && stat2)
            {
                int k = (int)(x + (rand.NextDouble() - 0.5) * 10.0);
                int l = (int)(y + (rand.NextDouble() - 0.5) * 10.0);

                Color newColor = sourceImage.GetPixel(k, l);
                Color resultColor = Color.FromArgb(newColor.R, newColor.G, newColor.B);

                return resultColor;
            }

            return sourceColor;
        }
    }

    class Waves1Filter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            bool stat = (x >= 20) && (x <= sourceImage.Width - 21);

            if (stat)
            {
                int k = (int)(x + 20 * Math.Sin(2 * Math.PI * y / 60));
                int l = y;

                Color newColor = sourceImage.GetPixel(k, l);
                Color resultColor = Color.FromArgb(newColor.R, newColor.G, newColor.B);

                return resultColor;
            }

            return sourceColor;
        }
    }

    class Waves2Filter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            bool stat = (x >= 20) && (x <= sourceImage.Width - 21);

            if (stat)
            {
                int k = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
                int l = y;

                Color newColor = sourceImage.GetPixel(k, l);
                Color resultColor = Color.FromArgb(newColor.R, newColor.G, newColor.B);

                return resultColor;
            }

            return sourceColor;
        }
    }

    class LinearTension : Filters
    {
        private int min_red;
        private int max_red;
        private int min_green;
        private int max_green;
        private int min_blue;
        private int max_blue;

        public LinearTension()
        {
            min_red = 255;
            max_red = 0;
            min_green = 255;
            max_green = 0;
            min_blue = 255;
            max_blue = 0;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int i;
            for (i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    int bright_red = sourceColor.R;
                    int bright_green = sourceColor.G;
                    int bright_blue = sourceColor.B;

                    if (bright_red < min_red) min_red = bright_red;
                    if (bright_green < min_green) min_green = bright_green;
                    if (bright_blue < min_blue) min_blue = bright_blue;

                    if (bright_red > max_red) max_red = bright_red;
                    if (bright_green > max_green) max_green = bright_green;
                    if (bright_blue > max_blue) max_blue = bright_blue;
                }
            }

            for (i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width) / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int bright_red = sourceColor.R;
            int bright_green = sourceColor.G;
            int bright_blue = sourceColor.B;

            int newR = (int)(((bright_red - min_red) * 255) / (max_red - min_red));
            int newG = (int)(((bright_green - min_green) * 255) / (max_green - min_green));
            int newB = (int)(((bright_blue - min_blue) * 255) / (max_blue - min_blue));

            Color resultColor = Color.FromArgb(newR, newG, newB);

            return resultColor;
        }
    }

    class MedianFilter : Filters
    {
        private int[] arrRed;
        private int[] arrGreen;
        private int[] arrBlue;

        public MedianFilter()
        {
            arrRed = new int[9];
            arrGreen = new int[9];
            arrBlue = new int[9];
        }

        private void sortArr()
        {
            for (int i = 1; i < 9; i++)
            {
                int x = arrRed[i];
                int y = arrGreen[i];
                int z = arrBlue[i];
                int j = i - 1;
                while ((x < arrRed[j]) && (j > 0))
                {
                    arrRed[j + 1] = arrRed[j];
                    j--;
                }

                arrRed[j + 1] = x;

                j = i - 1;
                while ((y < arrGreen[j]) && (j > 0))
                {
                    arrGreen[j + 1] = arrGreen[j];
                    j--;
                }

                arrGreen[j + 1] = y;

                j = i - 1;
                while ((z < arrBlue[j]) && (j > 0))
                {
                    arrBlue[j + 1] = arrBlue[j];
                    j--;
                }

                arrBlue[j + 1] = z;
            }
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 1; i < sourceImage.Width - 1; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = 1; j < sourceImage.Height - 1; ++j)
                {
                    int num = 0;
                    for (int k = i - 1; k <= i + 1; k++)
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(k, l);
                            arrRed[num] = sourceColor.R;
                            arrGreen[num] = sourceColor.G;
                            arrBlue[num] = sourceColor.B;
                            num++;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            sortArr();
            int k = 9 / 2;
            Color resultColor = Color.FromArgb(arrRed[k], arrGreen[k], arrBlue[k]);

            return resultColor;
        }
    }

    class DilationFilter : Filters
    {
        private bool[,] kernel = null;
        private int sizeX;
        private int sizeY;

        private int maxR;
        private int maxG;
        private int maxB;

        public DilationFilter(int chosen_elem)
        {
            if (chosen_elem == 0)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;
            }
            else if (chosen_elem == 1)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                kernel[0, 0] = false;
                kernel[0, 1] = true;
                kernel[0, 2] = false;
                kernel[1, 0] = true;
                kernel[1, 1] = true;
                kernel[1, 2] = true;
                kernel[2, 0] = false;
                kernel[2, 1] = true;
                kernel[2, 2] = false;
            }
            else
            {
                sizeX = 7;
                sizeY = 7;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;

                kernel[0, 0] = false;
                kernel[0, 1] = false;
                kernel[1, 0] = false;

                kernel[0, 6] = false;
                kernel[0, 5] = false;
                kernel[1, 6] = false;

                kernel[6, 0] = false;
                kernel[5, 0] = false;
                kernel[6, 1] = false;

                kernel[6, 6] = false;
                kernel[6, 5] = false;
                kernel[5, 6] = false;
            }
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    maxR = 0;
                    maxG = 0;
                    maxB = 0;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R > maxR)) maxR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G > maxG)) maxG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B > maxB)) maxB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(maxR, maxG, maxB);
            return resultColor;
        }
    }

    class ErosionFilter : Filters
    {
        private bool[,] kernel = null;
        private int sizeX;
        private int sizeY;

        private int minR;
        private int minG;
        private int minB;

        public ErosionFilter(int chosen_elem)
        {
            if (chosen_elem == 0)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;
            }
            else if (chosen_elem == 1)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                kernel[0, 0] = false;
                kernel[0, 1] = true;
                kernel[0, 2] = false;
                kernel[1, 0] = true;
                kernel[1, 1] = true;
                kernel[1, 2] = true;
                kernel[2, 0] = false;
                kernel[2, 1] = true;
                kernel[2, 2] = false;
            }
            else
            {
                sizeX = 7;
                sizeY = 7;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;

                kernel[0, 0] = false;
                kernel[0, 1] = false;
                kernel[1, 0] = false;

                kernel[0, 6] = false;
                kernel[0, 5] = false;
                kernel[1, 6] = false;

                kernel[6, 0] = false;
                kernel[5, 0] = false;
                kernel[6, 1] = false;

                kernel[6, 6] = false;
                kernel[6, 5] = false;
                kernel[5, 6] = false;
            }
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    minR = 255;
                    minG = 255;
                    minB = 255;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R < minR)) minR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G < minG)) minG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B < minB)) minB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(minR, minG, minB);
            return resultColor;
        }
    }

    class OpeningFilter : Filters
    {
        private bool[,] kernel = null;
        private int sizeX;
        private int sizeY;

        private int maxR;
        private int maxG;
        private int maxB;

        private int minR;
        private int minG;
        private int minB;

        public OpeningFilter(int chosen_elem)
        {
            if (chosen_elem == 0)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;
            }
            else if (chosen_elem == 1)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                kernel[0, 0] = false;
                kernel[0, 1] = true;
                kernel[0, 2] = false;
                kernel[1, 0] = true;
                kernel[1, 1] = true;
                kernel[1, 2] = true;
                kernel[2, 0] = false;
                kernel[2, 1] = true;
                kernel[2, 2] = false;
            }
            else
            {
                sizeX = 7;
                sizeY = 7;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;

                kernel[0, 0] = false;
                kernel[0, 1] = false;
                kernel[1, 0] = false;

                kernel[0, 6] = false;
                kernel[0, 5] = false;
                kernel[1, 6] = false;

                kernel[6, 0] = false;
                kernel[5, 0] = false;
                kernel[6, 1] = false;

                kernel[6, 6] = false;
                kernel[6, 5] = false;
                kernel[5, 6] = false;
            }
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int i = 0;
            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    minR = 255;
                    minG = 255;
                    minB = 255;

                    maxR = 0;
                    maxG = 0;
                    maxB = 0;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R < minR)) minR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G < minG)) minG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B < minB)) minB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor1(sourceImage, i, j));
                }
            }

            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width - sizeX / 2) / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    maxR = 0;
                    maxG = 0;
                    maxB = 0;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R > maxR)) maxR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G > maxG)) maxG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B > maxB)) maxB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        protected Color calculateNewPixelColor1(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(minR, minG, minB);
            return resultColor;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(maxR, maxG, maxB);
            return resultColor;
        }
    }

    class ClosingFilter : Filters
    {
        private bool[,] kernel = null;
        private int sizeX;
        private int sizeY;

        private int maxR;
        private int maxG;
        private int maxB;

        private int minR;
        private int minG;
        private int minB;

        public ClosingFilter(int chosen_elem)
        {
            if (chosen_elem == 0)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;
            }
            else if (chosen_elem == 1)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                kernel[0, 0] = false;
                kernel[0, 1] = true;
                kernel[0, 2] = false;
                kernel[1, 0] = true;
                kernel[1, 1] = true;
                kernel[1, 2] = true;
                kernel[2, 0] = false;
                kernel[2, 1] = true;
                kernel[2, 2] = false;
            }
            else
            {
                sizeX = 7;
                sizeY = 7;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;

                kernel[0, 0] = false;
                kernel[0, 1] = false;
                kernel[1, 0] = false;

                kernel[0, 6] = false;
                kernel[0, 5] = false;
                kernel[1, 6] = false;

                kernel[6, 0] = false;
                kernel[5, 0] = false;
                kernel[6, 1] = false;

                kernel[6, 6] = false;
                kernel[6, 5] = false;
                kernel[5, 6] = false;
            }
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int i = 0;
            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    maxR = 0;
                    maxG = 0;
                    maxB = 0;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R > maxR)) maxR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G > maxG)) maxG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B > maxB)) maxB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width - sizeX / 2) / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    minR = 255;
                    minG = 255;
                    minB = 255;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R < minR)) minR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G < minG)) minG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B < minB)) minB = sourceColor.B;
                        }

                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        protected Color calculateNewPixelColor1(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(maxR, maxG, maxB);
            return resultColor;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(minR, minG, minB);
            return resultColor;
        }
    }

    class GradFilter : Filters
    {
        private bool[,] kernel = null;
        private int sizeX;
        private int sizeY;

        private int maxR;
        private int maxG;
        private int maxB;

        private int minR;
        private int minG;
        private int minB;

        private int diffRed;
        private int diffGreen;
        private int diffBlue;

        public GradFilter(int chosen_elem)
        {
            if (chosen_elem == 0)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;
            }
            else if (chosen_elem == 1)
            {
                sizeX = 3;
                sizeY = 3;
                kernel = new bool[sizeX, sizeY];

                kernel[0, 0] = false;
                kernel[0, 1] = true;
                kernel[0, 2] = false;
                kernel[1, 0] = true;
                kernel[1, 1] = true;
                kernel[1, 2] = true;
                kernel[2, 0] = false;
                kernel[2, 1] = true;
                kernel[2, 2] = false;
            }
            else
            {
                sizeX = 7;
                sizeY = 7;
                kernel = new bool[sizeX, sizeY];

                for (int i = 0; i < sizeX; ++i)
                    for (int j = 0; j < sizeY; ++j)
                        kernel[i, j] = true;

                kernel[0, 0] = false;
                kernel[0, 1] = false;
                kernel[1, 0] = false;

                kernel[0, 6] = false;
                kernel[0, 5] = false;
                kernel[1, 6] = false;

                kernel[6, 0] = false;
                kernel[5, 0] = false;
                kernel[6, 1] = false;

                kernel[6, 6] = false;
                kernel[6, 5] = false;
                kernel[5, 6] = false;
            }
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage1 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage2 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage3 = new Bitmap(sourceImage.Width, sourceImage.Height);

            int i = 0;
            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage1.Width * 33));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    maxR = 0;
                    maxG = 0;
                    maxB = 0;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R > maxR)) maxR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G > maxG)) maxG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B > maxB)) maxB = sourceColor.B;
                        }

                    resultImage1.SetPixel(i, j, calculateNewPixelColor1(sourceImage, i, j));
                }
            }

            for (i = sizeX / 2; i < sourceImage.Width - sizeX / 2; ++i)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width - sizeX / 2) / resultImage2.Width * 33));
                if (worker.CancellationPending)
                    return null;

                for (int j = sizeY / 2; j < sourceImage.Height - sizeY / 2; ++j)
                {
                    minR = 255;
                    minG = 255;
                    minB = 255;
                    for (int k = -sizeX / 2; k <= sizeX / 2; k++)
                        for (int l = -sizeY / 2; l <= sizeY / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(i + k, j + l);
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.R < minR)) minR = sourceColor.R;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.G < minG)) minG = sourceColor.G;
                            if ((kernel[k + sizeX / 2, l + sizeY / 2]) && (sourceColor.B < minB)) minB = sourceColor.B;
                        }

                    resultImage2.SetPixel(i, j, calculateNewPixelColor2(sourceImage, i, j));
                }
            }

            for (i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)(i + 2 * (sourceImage.Width - sizeX / 2)) / resultImage2.Width * 33));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color resultColor1 = resultImage1.GetPixel(i, j);
                    Color resultColor2 = resultImage2.GetPixel(i, j);

                    diffRed = Clamp(Math.Abs(resultColor1.R - resultColor2.R), 0, 255);
                    diffGreen = Clamp(Math.Abs(resultColor1.G - resultColor2.G), 0, 255);
                    diffBlue = Clamp(Math.Abs(resultColor1.B - resultColor2.B), 0, 255);

                    resultImage3.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage3;
        }

        protected Color calculateNewPixelColor1(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(maxR, maxG, maxB);
            return resultColor;
        }

        protected Color calculateNewPixelColor2(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(minR, minG, minB);
            return resultColor;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = Color.FromArgb(diffRed, diffGreen, diffBlue);
            return resultColor;
        }
    }

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }

    class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
        }
    }

    class GaussianFilter : MatrixFilter
    {
        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }

        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
    }

    class SobelFilter : MatrixFilter
    {
        public SobelFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1;
            kernel[0, 1] = 0;
            kernel[0, 2] = 1;
            kernel[1, 0] = -2;
            kernel[1, 1] = 0;
            kernel[1, 2] = 2;
            kernel[2, 0] = -1;
            kernel[2, 1] = 0;
            kernel[2, 2] = 1;
        }
    }

    class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 1] = -1;
            kernel[1, 0] = -1;
            kernel[1, 2] = -1;
            kernel[2, 1] = -1;
            kernel[1, 1] = 5;
            kernel[0, 0] = 0;
            kernel[0, 2] = 0;
            kernel[2, 0] = 0;
            kernel[2, 2] = 0;
        }
    }

    class ScharrFilter : MatrixFilter
    {
        public ScharrFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = 3;
            kernel[0, 1] = 0;
            kernel[0, 2] = -3;
            kernel[1, 0] = 10;
            kernel[1, 1] = 0;
            kernel[1, 2] = -10;
            kernel[2, 0] = 3;
            kernel[2, 1] = 0;
            kernel[2, 2] = -3;
        }
    }

    class PrewittFilter : MatrixFilter
    {
        public PrewittFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1;
            kernel[0, 1] = 0;
            kernel[0, 2] = 1;
            kernel[1, 0] = -1;
            kernel[1, 1] = 0;
            kernel[1, 2] = 1;
            kernel[2, 0] = -1;
            kernel[2, 1] = 0;
            kernel[2, 2] = 1;
        }
    }
}
