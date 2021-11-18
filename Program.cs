using System;
using System.Threading;

namespace cadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {

            string opcao;


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
================================================
|       Bem vindo  ao sistema de cadastro de   |
|           pessoas física e jurídica          |  
================================================
");
            Console.ResetColor();
            Thread.Sleep(3000);

            barraCarregamento("Iniciando");

            Console.ResetColor();

            Console.Clear();

            do
            {
                Console.WriteLine(@$"
 ====================================================
|           Escolha uma das opções abaixo           |
| --------------------------------------------------|
|           1 - Pessoa Física                       |
|           2 - Pessoa Jurídica                     |
|                                                   |
|           0 - Sair                                |
=====================================================
");

            opcao = Console.ReadLine();

            switch (opcao) {

                case "1":
                    PessoaFisica pf = new PessoaFisica();
                    PessoaFisica novaPf = new PessoaFisica();
                    Endereco end = new Endereco();

                    end.logradouro = "Ayrton Senna";
                    end.numero = 100;
                    end.complemento = "";
                    end.enderecoComercial = false;

                    novaPf.endereco = end;
                    novaPf.cpf = "123456789";
                    novaPf.nome = "Pessoa Fisica";
                    novaPf.rendimento = 15000;
                    novaPf.dataNascimento = new DateTime(2000, 06, 15);

                    Console.WriteLine($@"Rua: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}");
                    
                    bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                    if (idadeValida == true) {

                        Console.WriteLine($"Cadastro aprovado!");
                        
                    } else {
                        Console.WriteLine($"Cadastro não aprovado!");
                        
                    }

                    Console.WriteLine(pf.pagarImposto(novaPf.rendimento));
                    

                    break;

                case "2":
                    PessoaJurica pj = new PessoaJurica();
                    PessoaJurica novapj = new PessoaJurica();
                    Endereco endPj = new Endereco();

                    endPj.logradouro = "Rua x";
                    endPj.numero = 100;
                    endPj.complemento = "Complemento";
                    endPj.enderecoComercial = true;

                    novapj.endereco = endPj;
                    novapj.cnpj = "12345678000199";
                    novapj.rendimento = 1500;
                    novapj.razaoSocial = "Pessoa juridica";

                    if(pj.validarCNPJ(novapj.cnpj))
                    {

                        Console.WriteLine("CNPJ Válido");
                    } else
                    {
                        Console.WriteLine($"CNPJ Inválido");
                    }

                    Console.WriteLine(pj.pagarImposto(novapj.rendimento));
                    
                    break;
                
                case "0":
                Console.Clear();
                Console.WriteLine($"Obrigado por utillizar nosso sistema.");

                barraCarregamento("Finalizando");

                Console.ResetColor();
                break;
            
            default:
                Console.ResetColor();
                Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
                break;
            }
        } while (opcao != "0");
        }
    
        static void barraCarregamento(string textoCarregamento) {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);
            for(var i = 0; i < 10; i++) 
            {
                Console.Write(".");
                Thread.Sleep(500);
            }

        }
    }
}
