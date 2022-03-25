using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;

        public void Inserir(Amigo amigo)
        {
            amigo.numero = ++numeroAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }
        public void Editar(int numeroSelecionado, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numero == numeroAmigo)
                {


                    amigo.numero = numeroAmigo;
                    amigos[i] = amigo;

                    break;
                }
            }
        }
       
        
        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }
        public bool NomeJautilizado(string nomeInformado)
        {
            bool nomeJaUtilizado = false;
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].nome == nomeInformado)
                {
                    nomeJaUtilizado = true;
                    break;
                }
            }

            return nomeJaUtilizado;
        }
        public bool VerificarNumeroAmigoExiste(int numeroAmigo)
        {
            bool numeroAmigoEncontrado = false;
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroAmigo)
                {
                    numeroAmigoEncontrado = true;
                    break;
                }
            }

            return numeroAmigoEncontrado;
        }

      
    }
}
