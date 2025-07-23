using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudSqlServerDapper.Entities;
using CrudSqlServerDapper.Repositories;
using CrudSqlServerDapper.Validators;

namespace CrudSqlServerDapper.Controllers
{
    /// <summary>
    /// Controlador de clientes para gerenciar as operações CRUD.
    /// </summary>
    /// 
    public class ClientController
    {
        /// <summary>
        /// Método para executar as operações do controlador
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE CLIENTES\n");

            Console.WriteLine("(1) CADASTRAR CLIENTE");
            Console.WriteLine("(2) ATUALIZAR CLIENTE");
            Console.WriteLine("(3) EXCLUIR CLIENTE");
            Console.WriteLine("(4) PEQUISAR CLIENTES");

            Console.Write("\nINFORME A OPÇÃO DESEJADA...:");

            var opcao = Console.ReadLine();
            switch(opcao)
            {
                case "1": //caso seja a opcao 1
                    CreateClient(); //executando o método para cadastrar um cliente
                    break;

                default: // caso não seja nenhuma dos anteriores
                    Console.WriteLine("\nOPÇÃO INVÁLIDA! POR FAVOR, TENTE NOVAMENTE.");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S/N): ");
            var continuar = Console.ReadLine() ?? string.Empty;

            if (continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear(); //limpando a tela do console
                Execute(); //chamando o método novamente para continuar as operações
            }
            else
            {
               Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }



        /// <summary>
        /// Método para realizar o cadastro de um cliente.
        /// </summary>
        private void CreateClient()
        {
            
            Console.WriteLine("\n- CADASTRO DE CLIENTES -\n");

            //Criando um objeto da classe de entidade
            var client = new Client();

            Console.Write("INFORME O NOME......:");
            client.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("INFORME O EMAIL........:");
            client.Email = Console.ReadLine() ?? string.Empty;

            Console.Write("INFORME A DATA DE NASCIMENTO.....:");
            client.BirthDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

            // Instanciando a classe de validação
            var validator = new ClientValidator();

            //Executando as validações no objeto e capturar o resultado
            var result = validator.Validate(client);

            //verificando se os dados passaram nas regras de validação

            if (result.IsValid)
            {
                //Criando um objeto da classe repositorio
                var clientRepository = new ClientRepository();
                clientRepository.Insert(client); //gravando o cliente no banco de dados

                Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!");
            }
            else
            {
                Console.WriteLine("\nOCORRERAM ERROS DE VALIDAÇÃO!");

                //Exibindo os erros de validação

                foreach (var item in result.Errors)
                {
                    Console.WriteLine($"\tErro: {item.ErrorMessage}");
                }
            }


        }
    }
}
