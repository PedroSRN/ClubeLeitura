
using System;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroCaixa
    {
        public Caixa[] caixas;
        public int numeroCaixa;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            MostrarTitulo("Inserindo nova Caixa");

            Caixa caixa = ObterCaixa();

            caixa.numero = ++numeroCaixa;

            int posicaoVazia = ObterPosicaoVazia();
            caixas[posicaoVazia] = caixa;

            notificador.ApresentarMensagem("Caixa inserida com sucesso!", "Sucesso");
        }

        private Caixa ObterCaixa()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa();

            caixa.etiqueta = etiqueta;
            caixa.cor = cor;

            return caixa;
        }

        public void EditarCaixa()
        {
            MostrarTitulo("Editando Caixa");

            VisualizarCaixas("Pesquisando");

            Console.Write("Digite o número da caixa que deseja editar: ");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroCaixa)
                {
                    Caixa caixa = ObterCaixa();

                    caixas[i].numero = numeroCaixa;
                    caixas[i] = caixa;

                    break;
                }
            }

            notificador.ApresentarMensagem("Caixa editada com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirCaixa()
        {
            MostrarTitulo("Excluindo Caixa");

            VisualizarCaixas("Pesquisando");

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].numero == numeroCaixa)
                {
                    caixas[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Caixa excluída com sucesso", "Sucesso");
        }

        public void VisualizarCaixas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    continue;

                Caixa c = caixas[i];

                Console.WriteLine("Número: " + c.numero);
                Console.WriteLine("Cor: " + c.cor);
                Console.WriteLine("Etiqueta: " + c.etiqueta);

                Console.WriteLine();
            }
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

        
    }
}