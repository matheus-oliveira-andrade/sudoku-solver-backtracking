using DemoSudoku.Model;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSudoku
{
    public partial class FrmSudoku : Form
    {
        private Sudoku sudoku { get; set; } = new Sudoku();
        public int[,] Jogo { get; set; } = new int[9, 9];
        public bool[,] JogoBoleano { get; set; } = new bool[9, 9];


        public FrmSudoku()
        {
            InitializeComponent();
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormSudoku_Load(object sender, EventArgs e)
        {// Frufru
            PnlGrid1.BackColor = Color.LightBlue;
            PnlGrid3.BackColor = Color.LightBlue;
            PnlGrid5.BackColor = Color.LightBlue;
            PnlGrid7.BackColor = Color.LightBlue;
            PnlGrid9.BackColor = Color.LightBlue;
        }

        private void btnGerarNumeros_Click(object sender, EventArgs e)
        {
            CriaGame();
            GeraNUmeros();
            Soluciona(0, 0);
            GeraPartida();
            MostraGame();
            btnGerarNumeros.Enabled = false;
        }
        private void CriaGame()
        {
            // Método responsavel por limpar os campos da matriz interna do jogo
            for (int l = 0; l < Jogo.GetLength(0); l++)
            {
                for (int c = 0; c < Jogo.GetLength(1); c++)
                {
                    Jogo[l, c] = 0;
                }
            }
        }
        // Gera 20 numeros aleatórios dentro da matriz para facilitar o preenchimento depois
        private void GeraNUmeros()
        {

            Random r = new Random();
            int gerados = 0;            
            while (gerados <= 20)
            {
                int n = r.Next(1, 9);
                int linha = r.Next(0, 9);
                int coluna = r.Next(0, 9);
                if (Jogo[linha, coluna] == 0 && sudoku.VerificaIguaisColunaLinhaGrid(Jogo, linha, coluna, n))
                {
                    Jogo[linha, coluna] = n;
                    JogoBoleano[linha, coluna] = true;
                    MostraGame();
                    gerados++;
                }
                else continue;                
            }
        }
        // Resolve o Sudoku
        private bool Soluciona(int linha, int coluna)
        {
            // Se a linha e a coluna recebida for válida ele começa o processo
            if (EValido(linha, coluna))
            {
                // Se a posição for uma que foi gerada aleátoriamente ele vai para a proxima posição
                if (JogoBoleano[linha, coluna] == true)
                {
                    if ((coluna + 1) < 9)
                    {
                        return Soluciona(linha, coluna + 1);
                    }
                    else if ((linha + 1) < 9)
                    {
                        return Soluciona(linha + 1, 0);
                    }
                    else
                    {
                        return true;
                    }
                }
                // Se a posição for false ou seja estiver com 0
                else if (JogoBoleano[linha, coluna] == false)
                {
                    // Percorre de 1 a 9 para ver quais deste numeros são válidos na posição
                    for (int i = 1; i <= 9; i++)
                    {
                        // Verifica se o número se repete na linha, coluna ou na 3x3, caso não se repita retorna true
                        if (sudoku.VerificaIguaisColunaLinhaGrid(Jogo, linha, coluna, i))
                        {
                            Jogo[linha, coluna] = i;
                            MostraGame();
                            if ((coluna + 1) < 9)
                            {
                                if (Soluciona(linha, coluna + 1))
                                    return true;
                                else
                                    Jogo[linha, coluna] = 0;
                            }
                            else if ((linha + 1) < 9)
                            {
                                if (Soluciona(linha + 1, 0))
                                    return true;
                                else
                                    Jogo[linha, coluna] = 0;
                            }

                            else return true;
                        }
                    }

                }

                return false;
            }
            else return true;
        }
        // Verifica se a posição recebida no método é valida
        private bool EValido(int linha, int coluna)
        {
            return linha < 9 && coluna < 9;
        }
        private void GeraPartida()
        {
            int retirados = 40;
            Random r = new Random();
            while (retirados > 0)
            {
                // Gera uma linha aleátoria
                int linha = r.Next(0, 9);
                // Gera uma coluna aleátoria
                int coluna = r.Next(0, 9);
                if (Jogo[linha, coluna] != 0)
                {
                    Jogo[linha, coluna] = 0;
                    retirados--;
                }
                else
                {
                    continue;
                }
            }
        }

        private void MostraGame()
        {
            // linha 0
            var t = Task.Run(async delegate
            {
                await Task.Delay(70);
            });
            MkdTxtB1.Text = Jogo[0, 0] == 0 ? null : Jogo[0, 0].ToString(); t.Wait();
            MkdTxtB2.Text = Jogo[0, 1] == 0 ? null : Jogo[0, 1].ToString(); t.Wait();
            MkdTxtB3.Text = Jogo[0, 2] == 0 ? null : Jogo[0, 2].ToString(); t.Wait();
            MkdTxtB4.Text = Jogo[0, 3] == 0 ? null : Jogo[0, 3].ToString(); t.Wait();
            MkdTxtB5.Text = Jogo[0, 4] == 0 ? null : Jogo[0, 4].ToString(); t.Wait();
            MkdTxtB6.Text = Jogo[0, 5] == 0 ? null : Jogo[0, 5].ToString(); t.Wait();
            MkdTxtB7.Text = Jogo[0, 6] == 0 ? null : Jogo[0, 6].ToString(); t.Wait();
            MkdTxtB8.Text = Jogo[0, 7] == 0 ? null : Jogo[0, 7].ToString(); t.Wait();
            MkdTxtB9.Text = Jogo[0, 8] == 0 ? null : Jogo[0, 8].ToString(); t.Wait();


            // linha 1
            MkdTxtB10.Text =
                Jogo[1, 0] == 0 
                ?
                null
                :
                Jogo[1, 0].ToString(); t.Wait();
            MkdTxtB11.Text = Jogo[1, 1] == 0 ? null : Jogo[1, 1].ToString(); t.Wait();
            MkdTxtB12.Text = Jogo[1, 2] == 0 ? null : Jogo[1, 2].ToString(); t.Wait();
            MkdTxtB13.Text = Jogo[1, 3] == 0 ? null : Jogo[1, 3].ToString(); t.Wait();
            MkdTxtB14.Text = Jogo[1, 4] == 0 ? null : Jogo[1, 4].ToString(); t.Wait();
            MkdTxtB15.Text = Jogo[1, 5] == 0 ? null : Jogo[1, 5].ToString(); t.Wait();
            MkdTxtB16.Text = Jogo[1, 6] == 0 ? null : Jogo[1, 6].ToString(); t.Wait();
            MkdTxtB17.Text = Jogo[1, 7] == 0 ? null : Jogo[1, 7].ToString(); t.Wait();
            MkdTxtB18.Text = Jogo[1, 8] == 0 ? null : Jogo[1, 8].ToString(); t.Wait();

            // linha 2
            MkdTxtB19.Text = Jogo[2, 0] == 0 ? null : Jogo[2, 0].ToString(); t.Wait();
            MkdTxtB20.Text = Jogo[2, 1] == 0 ? null : Jogo[2, 1].ToString(); t.Wait();
            MkdTxtB21.Text = Jogo[2, 2] == 0 ? null : Jogo[2, 2].ToString(); t.Wait();
            MkdTxtB22.Text = Jogo[2, 3] == 0 ? null : Jogo[2, 3].ToString(); t.Wait();
            MkdTxtB23.Text = Jogo[2, 4] == 0 ? null : Jogo[2, 4].ToString(); t.Wait();
            MkdTxtB24.Text = Jogo[2, 5] == 0 ? null : Jogo[2, 5].ToString(); t.Wait();
            MkdTxtB25.Text = Jogo[2, 6] == 0 ? null : Jogo[2, 6].ToString(); t.Wait();
            MkdTxtB26.Text = Jogo[2, 7] == 0 ? null : Jogo[2, 7].ToString(); t.Wait();
            MkdTxtB27.Text = Jogo[2, 8] == 0 ? null : Jogo[2, 8].ToString(); t.Wait();

            //Linha 3            
            MkdTxtB28.Text = Jogo[3, 0] == 0 ? null : Jogo[3, 0].ToString(); t.Wait();
            MkdTxtB29.Text = Jogo[3, 1] == 0 ? null : Jogo[3, 1].ToString(); t.Wait();
            MkdTxtB30.Text = Jogo[3, 2] == 0 ? null : Jogo[3, 2].ToString(); t.Wait();
            MkdTxtB31.Text = Jogo[3, 3] == 0 ? null : Jogo[3, 3].ToString(); t.Wait();
            MkdTxtB32.Text = Jogo[3, 4] == 0 ? null : Jogo[3, 4].ToString(); t.Wait();
            MkdTxtB33.Text = Jogo[3, 5] == 0 ? null : Jogo[3, 5].ToString(); t.Wait();
            MkdTxtB34.Text = Jogo[3, 6] == 0 ? null : Jogo[3, 6].ToString(); t.Wait();
            MkdTxtB35.Text = Jogo[3, 7] == 0 ? null : Jogo[3, 7].ToString(); t.Wait();
            MkdTxtB36.Text = Jogo[3, 8] == 0 ? null : Jogo[3, 8].ToString(); t.Wait();

            //Linha 4
            MkdTxtB37.Text = Jogo[4, 0] == 0 ? null : Jogo[4, 0].ToString(); t.Wait();
            MkdTxtB38.Text = Jogo[4, 1] == 0 ? null : Jogo[4, 1].ToString(); t.Wait();
            MkdTxtB39.Text = Jogo[4, 2] == 0 ? null : Jogo[4, 2].ToString(); t.Wait();
            MkdTxtB40.Text = Jogo[4, 3] == 0 ? null : Jogo[4, 3].ToString(); t.Wait();
            MkdTxtB41.Text = Jogo[4, 4] == 0 ? null : Jogo[4, 4].ToString(); t.Wait();
            MkdTxtB42.Text = Jogo[4, 5] == 0 ? null : Jogo[4, 5].ToString(); t.Wait();
            MkdTxtB43.Text = Jogo[4, 6] == 0 ? null : Jogo[4, 6].ToString(); t.Wait();
            MkdTxtB44.Text = Jogo[4, 7] == 0 ? null : Jogo[4, 7].ToString(); t.Wait();
            MkdTxtB45.Text = Jogo[4, 8] == 0 ? null : Jogo[4, 8].ToString(); t.Wait();

            //Linha 5
            MkdTxtB46.Text = Jogo[5, 0] == 0 ? null : Jogo[5, 0].ToString(); t.Wait();
            MkdTxtB47.Text = Jogo[5, 1] == 0 ? null : Jogo[5, 1].ToString(); t.Wait();
            MkdTxtB48.Text = Jogo[5, 2] == 0 ? null : Jogo[5, 2].ToString(); t.Wait();
            MkdTxtB49.Text = Jogo[5, 3] == 0 ? null : Jogo[5, 3].ToString(); t.Wait();
            MkdTxtB50.Text = Jogo[5, 4] == 0 ? null : Jogo[5, 4].ToString(); t.Wait();
            MkdTxtB51.Text = Jogo[5, 5] == 0 ? null : Jogo[5, 5].ToString(); t.Wait();
            MkdTxtB52.Text = Jogo[5, 6] == 0 ? null : Jogo[5, 6].ToString(); t.Wait();
            MkdTxtB53.Text = Jogo[5, 7] == 0 ? null : Jogo[5, 7].ToString(); t.Wait();
            MkdTxtB54.Text = Jogo[5, 8] == 0 ? null : Jogo[5, 8].ToString(); t.Wait();

            // linha 6
            MkdTxtB55.Text = Jogo[6, 0] == 0 ? null : Jogo[6, 0].ToString(); t.Wait();
            MkdTxtB56.Text = Jogo[6, 1] == 0 ? null : Jogo[6, 1].ToString(); t.Wait();
            MkdTxtB57.Text = Jogo[6, 2] == 0 ? null : Jogo[6, 2].ToString(); t.Wait();
            MkdTxtB58.Text = Jogo[6, 3] == 0 ? null : Jogo[6, 3].ToString(); t.Wait();
            MkdTxtB59.Text = Jogo[6, 4] == 0 ? null : Jogo[6, 4].ToString(); t.Wait();
            MkdTxtB60.Text = Jogo[6, 5] == 0 ? null : Jogo[6, 5].ToString(); t.Wait();
            MkdTxtB61.Text = Jogo[6, 6] == 0 ? null : Jogo[6, 6].ToString(); t.Wait();
            MkdTxtB62.Text = Jogo[6, 7] == 0 ? null : Jogo[6, 7].ToString(); t.Wait();
            MkdTxtB63.Text = Jogo[6, 8] == 0 ? null : Jogo[6, 8].ToString(); t.Wait();

            // linha 7
            MkdTxtB64.Text = Jogo[7, 0] == 0 ? null : Jogo[7, 0].ToString(); t.Wait();
            MkdTxtB65.Text = Jogo[7, 1] == 0 ? null : Jogo[7, 1].ToString(); t.Wait();
            MkdTxtB66.Text = Jogo[7, 2] == 0 ? null : Jogo[7, 2].ToString(); t.Wait();
            MkdTxtB67.Text = Jogo[7, 3] == 0 ? null : Jogo[7, 3].ToString(); t.Wait();
            MkdTxtB68.Text = Jogo[7, 4] == 0 ? null : Jogo[7, 4].ToString(); t.Wait();
            MkdTxtB69.Text = Jogo[7, 5] == 0 ? null : Jogo[7, 5].ToString(); t.Wait();
            MkdTxtB70.Text = Jogo[7, 6] == 0 ? null : Jogo[7, 6].ToString(); t.Wait();
            MkdTxtB71.Text = Jogo[7, 7] == 0 ? null : Jogo[7, 7].ToString(); t.Wait();
            MkdTxtB72.Text = Jogo[7, 8] == 0 ? null : Jogo[7, 8].ToString(); t.Wait();

            // linha 8
            MkdTxtB73.Text = Jogo[8, 0] == 0 ? null : Jogo[8, 0].ToString(); t.Wait();
            MkdTxtB74.Text = Jogo[8, 1] == 0 ? null : Jogo[8, 1].ToString(); t.Wait();
            MkdTxtB75.Text = Jogo[8, 2] == 0 ? null : Jogo[8, 2].ToString(); t.Wait();
            MkdTxtB76.Text = Jogo[8, 3] == 0 ? null : Jogo[8, 3].ToString(); t.Wait();
            MkdTxtB77.Text = Jogo[8, 4] == 0 ? null : Jogo[8, 4].ToString(); t.Wait();
            MkdTxtB78.Text = Jogo[8, 5] == 0 ? null : Jogo[8, 5].ToString(); t.Wait();
            MkdTxtB79.Text = Jogo[8, 6] == 0 ? null : Jogo[8, 6].ToString(); t.Wait();
            MkdTxtB80.Text = Jogo[8, 7] == 0 ? null : Jogo[8, 7].ToString(); t.Wait();
            MkdTxtB81.Text = Jogo[8, 8] == 0 ? null : Jogo[8, 8].ToString(); t.Wait();
        }

    }
}
