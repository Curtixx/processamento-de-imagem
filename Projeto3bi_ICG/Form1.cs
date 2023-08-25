using static System.Windows.Forms.LinkLabel;

namespace Projeto3bi_ICG
{
    public partial class Form1 : Form
    {
        byte r, g, b;
        int coluna_fogao;
        int linha_fogao;
        int coluna_panela;
        int linha_panela;
        Bitmap img_fogao;
        Bitmap img_panela;
        Bitmap imgnova;
        public Form1()
        {
            InitializeComponent();

            img_fogao = new Bitmap(@"D:\Downloads\imagem_proj\Imagem_A.jpg");
            img_panela = new Bitmap(@"D:\Downloads\imagem_proj\Panela.jpg");
            coluna_fogao = img_fogao.Width;
            linha_fogao = img_fogao.Height;
            coluna_panela = img_panela.Width;
            linha_panela = img_panela.Height;

            imgnova = new Bitmap(@"D:\Downloads\imagem_proj\Imagem_A.jpg");

        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public Color CriaCor(int a, byte r, byte g, byte b)
        {
            Color Cor = new Color();
            Cor = Color.FromArgb(a, r, g, b);
            return Cor;
        }


        public void processaImagem()
        {
            for (int i = 0; i <= coluna_panela - 1; i++)
            {
                for (int j = 0; j <= linha_panela - 1; j++)
                {
                    r = img_panela.GetPixel(i, j).R;
                    g = img_panela.GetPixel(i, j).G;
                    b = img_panela.GetPixel(i, j).B;

                    if (!(r >= 100 && g >= 100 && b < 110))
                    {
                        Color cor = CriaCor(255, r, g, b);
                        imgnova.SetPixel(i + 140, j, cor);
                    }

                }
            }

            imgnova.Save(@"D:\Downloads\imagem_proj\ImagemProcessada.jpg");
            pictureBox3.Load(@"D:\Downloads\imagem_proj\ImagemProcessada.jpg");
        }

        public void deixarImagemCinza()
        {
            for (int i = 0; i <= coluna_fogao - 1; i++)
            {
                for (int j = 0; j <= linha_fogao - 1; j++)
                {
                    r = imgnova.GetPixel(i, j).R;
                    g = imgnova.GetPixel(i, j).G;
                    b = imgnova.GetPixel(i, j).B;

                    byte grayLevel = (byte)((r * 0.30) + (g * 0.59) + (b * 0.11));
                    Color cor = CriaCor(255, grayLevel, grayLevel, grayLevel);
                    imgnova.SetPixel(i, j,cor);

                }
            }

            imgnova.Save(@"D:\Downloads\imagem_proj\ImagemProcessadaCinza.jpg");
        }

        public void deixarImagemBinaria()
        {
            for (int i = 0; i <= coluna_fogao - 1; i++)
            {
                for (int j = 0; j <= linha_fogao - 1; j++)
                {
                    r = imgnova.GetPixel(i, j).R;

                    if (r <= 127)
                    {
                        Color cor = CriaCor(255, 0, 0, 0);
                        imgnova.SetPixel(i, j, cor);

                    } else if (r > 127)
                    {
                        Color cor = CriaCor(255, 255, 255, 255);
                        imgnova.SetPixel(i, j, cor);
                    }

                }
            }

            imgnova.Save(@"D:\Downloads\imagem_proj\ImagemProcessadaBinaria.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processaImagem();
            deixarImagemCinza();
            deixarImagemBinaria();
        }
    }
}