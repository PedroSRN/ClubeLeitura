using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas;
        public int numeroCaixa;

        public void Inserir(Caixa caixa)
        {
            caixa.numero = ++numeroCaixa;

            int posicaoVazia = ObterPosicaoVazia();
            caixas[posicaoVazia] = caixa;
        }
        public void Editar(int numeroSelecioando, Caixa caixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroSelecioando)
                {
                    caixa.numero = numeroSelecioando;
                    caixas[i] = caixa;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroSelecionado)
                {
                    caixas[i] = null;
                    break;
                }
            }
        }

        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            bool etiquetaJaUtilizada = false;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].etiqueta == etiquetaInformada)
                {
                    etiquetaJaUtilizada = true;
                    break;
                }
            }

            return etiquetaJaUtilizada;
        }

        public bool VerificarNumeroCaixaExiste(int numeroCaixa)
        {
            bool numeroCaixaEncontrado = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null && caixas[i].numero == numeroCaixa)
                {
                    numeroCaixaEncontrado = true;
                    break;
                }
            }

            return numeroCaixaEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    return i;
            }

            return -1;
        }

        public Caixa[] SelecionarTodos()
        {
            int quantidadeCaixas = ObterQtdCaixas();

            Caixa[] caixasInseridas = new Caixa[quantidadeCaixas];

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    caixasInseridas[i] = caixas[i];
            }

            return caixasInseridas;
        }

        public int ObterQtdCaixas()
        {
            int numeroCaixas = 0;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                    numeroCaixas++;
            }

            return numeroCaixas;
        }
    }
}
