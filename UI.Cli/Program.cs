using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao;
using ITgestao.ItemsNS;
using UtilsNS;

namespace UI.Cli
{
    class Program
    {
        static Item[] _equip;
        public static void ShowEquipamento(Item pub)
        {
            int pubDate = pub.Id;
            Console.WriteLine($"{pub.Id}");

            Console.WriteLine($"{pub.ToString()}");
        }
        static void Main(string[] args)
        {
            Computador _com = new Computador(12, "222");

            ShowEquipamento(_com);

            Console.WriteLine($"{_com.ToString()}");
            Console.WriteLine($"Serial: {_com.Serial}");
            //Console.ReadKey();

            Console.WriteLine($"Convert {Utils.ConverteMemoria(10024, Utils.MedidasMemoria.B, Utils.MedidasMemoria.MB)}");

            try
            {
                Console.WriteLine("Insira o id da entidade > 0: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Inventario inv = Inventario.getInstance(id);

                Console.WriteLine("Insira o numero de computadores/rede/generico random a inserir: ");
                int numero = Convert.ToInt32(Console.ReadLine());
                for (int i=1; i<=numero; i++)
                {
                    inv.Adiciona(new Computador(i, i.ToString()));
                    Console.WriteLine($"Adicionado Computador {i}...");
                    Inventario.getInstance(28).Adiciona(new Computador(i, i.ToString()));

                    

                    (new Computador(i, i.ToString())).AddToInventario(Inventario.getInstance(30));

                }

                object ob = Inventario.getInstance(28).linqtest(12);


                for (int i = 1+1000; i <= numero+1000; i++)
                {
                    inv.Adiciona(new Rede(i, i.ToString()));
                    Console.WriteLine($"Adicionado Rede {i}...");
                }

                for (int i = 1+2000; i <= numero+2000; i++)
                {
                    inv.Adiciona(new Generico(i, i.ToString()));
                    Console.WriteLine($"Adicionado Generico {i}...");
                }


                //Equipamento.Rede _rede = new Equipamento.Rede(12);
                //inv.Adiciona(_rede);

                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(@"ExampleNew.txt", FileMode.Create, FileAccess.Write);

                //formatter.Serialize(stream, _rede);
                //stream.Close();
            }
            catch (Exception ex)
            {
                // Exception that comes from creation of Equipment
                Console.WriteLine("==========\nNão foi criado");
                Console.WriteLine(ex.Message);
                Console.WriteLine("==========\n");
            }

            try
            {
                // Tenta inicializar um equipamento 
                Item equi = new Generico(1, "123");
                // Mostra a mensagem de sucesso
                Console.WriteLine($"Foi criado {equi.Id}");

                // Adiciona à lista de equipamentos
            }
            catch (IdBadException ex)
            {
                // Exception that comes from creation of Equipment
                Console.WriteLine("Não foi criado");
                Console.WriteLine(ex.Message);
            }
            catch (IdDuplicatedException ex)
            {
                throw;
            }
            // Exeption that comes from equipments handler for a duplicate entry

            try
            {
                Rede _rede = new Rede(66, "1234");
                Console.WriteLine($"Foi criado {_rede.Id}");
                Console.WriteLine($"Foi criado {Utils.HasMethod(_rede, "Adiciona")}");
            }
            catch (InitBadException)
            {
                throw;
            }

            Console.ReadKey();
        }
    }
}
