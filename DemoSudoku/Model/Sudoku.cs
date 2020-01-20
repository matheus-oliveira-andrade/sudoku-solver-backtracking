using System;

namespace DemoSudoku.Model
{
    class Sudoku
    {
        public Sudoku()
        {
        }

        public bool VerificaIguaisColunaLinhaGrid(int[,] quadro, int linha, int coluna, int numero)
        {
            // Verifica linha
            for (int c = 0; c < quadro.GetLength(0); c++)
            {
                if (c == coluna)
                    continue;
                else if (quadro[linha, c] == numero)
                    return false;

            }
            // Verifica coluna
            for (int l = 0; l < quadro.GetLength(1); l++)
            {
                if (l == linha)
                    continue;
                else if (quadro[l, coluna] == numero)
                    return false;
            }

            int linhaMin = 0; int linhaMax = 0;
            int colunaMin = 0; int colunaMax = 0;
            if ((linha >= 0 && linha <= 2) && (coluna >= 0 && coluna <= 2))
            {
                linhaMin = 0; linhaMax = 2;
                colunaMin = 0; colunaMax = 2;
            }
            else if ((linha >= 3 && linha <= 5) && (coluna >= 0 && coluna <= 2))
            {
                linhaMin = 3; linhaMax = 5;
                colunaMin = 0; colunaMax = 2;
            }
            else if ((linha >= 6 && linha <= 8) && (coluna >= 0 && coluna <= 2))
            {
                linhaMin = 6; linhaMax = 8;
                colunaMin = 0; colunaMax = 2;
            }
            else if ((linha >= 0 && linha <= 2) && (coluna >= 3 && coluna <= 5))
            {
                linhaMin = 0; linhaMax = 2;
                colunaMin = 3; colunaMax = 5;
            }
            else if ((linha >= 3 && linha <= 5) && (coluna >= 3 && coluna <= 5))
            {
                linhaMin = 3; linhaMax = 5;
                colunaMin = 3; colunaMax = 5;
            }
            else if ((linha >= 6 && linha <= 8) && (coluna >= 3 && coluna <= 5))
            {
                linhaMin = 6; linhaMax = 8;
                colunaMin = 3; colunaMax = 5;
            }
            else if ((linha >= 6 && linha <= 8) && (coluna >= 0 && coluna <= 2))
            {
                linhaMin = 6; linhaMax = 8;
                colunaMin = 0; colunaMax = 2;
            }
            else if ((linha >= 3 && linha <= 5) && (coluna >= 6 && coluna <= 8))
            {
                linhaMin = 3; linhaMax = 5;
                colunaMin = 6; colunaMax = 8;
            }
            else if ((linha >= 6 && linha <= 8) && (coluna >= 6 && coluna <= 8))
            {
                linhaMin = 6; linhaMax = 8;
                colunaMin = 6; colunaMax = 8;
            }

            for (int l = linhaMin; l <= linhaMax; l++)
            {
                for (int c = colunaMin; c <= colunaMax; c++)
                {
                    if (linha == l && coluna == c)
                        continue;
                    else if (quadro[l, c] == numero)
                        return false;
                }
            }
            return true;
        }
    }
}
