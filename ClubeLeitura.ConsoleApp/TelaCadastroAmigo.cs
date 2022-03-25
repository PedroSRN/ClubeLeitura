using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo; // responsavel por controlar a quantidade de amigos cadastrados
        public Notificador notificador;// responsavel pelas mensagens para o usuario
        public RepositorioAmigo repositorioAmigo;
        public string MostrarOpcoes()
        {
            MostrarTitulo("Cadastro de amigos");

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");
            
            Amigo Novoamigo = ObterAmigo();

            repositorioAmigo.Inserir(Novoamigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso","Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome do Amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do Responsavel: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digte o Endereço: ");
            string endereco= Console.ReadLine();

            bool nomeJaUtilizado;
            do
            {
                nomeJaUtilizado = repositorioAmigo.NomeJautilizado(nome);

                if (nomeJaUtilizado)
                {
                    notificador.ApresentarMensagem("Nome já utilizado, por gentileza informe outro", "Erro");

                    Console.Write("Digite o nome: ");
                    nome = Console.ReadLine();
                }

            } while (nomeJaUtilizado);

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo; 
        }


        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");


            bool temAmigosCadastrados = VisualizarAmigo("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo foi cadastrado Para poder Editar ", "Atencao");
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(numeroAmigo, amigoAtualizado);


            notificador.ApresentarMensagem("Amigo Editado com sucesso", "Sucesso");
        }

        public int ObterNumeroAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;
            do
            {
                Console.Write("Digite o número do amigo que deseja editar: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());
                numeroAmigoEncontrado = repositorioAmigo.VerificarNumeroAmigoExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                {
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", "Atencao");
                }

            } while (numeroAmigoEncontrado == false);
            return numeroAmigo;
        }


        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastrados = VisualizarAmigo("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo foi cadastrado Para poder Excluir ", "Atencao");
                return;
            }

            int numeroAmigo;
            bool numeroAmigoEncontrado;
            do
            {
                Console.Write("Digite o número do amigo que deseja editar: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = false;


                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] != null && amigos[i].numero == numeroAmigo)
                    {
                        numeroAmigoEncontrado = true;
                        break;
                    }
                }

                if (numeroAmigoEncontrado == false)
                {
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", "Atencao");
                }

            } while (numeroAmigoEncontrado == false);

            for (int i = 0; i < amigos.Length; i++)
            {
                if(amigos[i].numero == numeroAmigo)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluido com sucesso", "Sucesso");
        }

        public bool VisualizarAmigo(string tipo)
        {
            if(tipo == "Tela")
            MostrarTitulo("Visualização de Amigos");

            int quantidadeAmigosCadastrados = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if(amigos[i] != null)
                {
                    quantidadeAmigosCadastrados++;
                }

                if(quantidadeAmigosCadastrados == 0)
                {
                    return false;
                }
            }


            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                {
                    continue;
                }

                Amigo a = amigos[i]; //Cria um apelido de nome "a" para não precisar atribuir o nome completo da variavel

                Console.WriteLine("Número: " + a.numero);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsável: " + a.responsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine(); //pular linha
            }
            return true;
        }


        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

       

    }

}
