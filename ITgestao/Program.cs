using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao;

namespace ITgestao
{
    class Program
    {
        static Equipamento[] _equip;
        static void Main(string[] args)
        {
            

            Console.WriteLine("Insira o id > 0: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Inventario inv = new Inventario(10);
                Rede _rede = new Rede(12);
                inv.Add(_rede);
            }
            catch (Exception ex)
            {
                // Exception that comes from creation of Equipment
                Console.WriteLine("Não foi criado");
                Console.WriteLine(ex.Message);
            }


                try
            {
                // Tenta inicializar um equipamento 
                Equipamento equi = new Equipamento(id);
                // Mostra a mensagem de sucesso
                Console.WriteLine($"Foi criado {equi.Id}");

                // Adiciona à lista de equipamentos


            } catch (IdBadException ex) {
                // Exception that comes from creation of Equipment
                Console.WriteLine("Não foi criado");
                Console.WriteLine(ex.Message);
            } catch (IdDuplicatedException ex)
                // Exeption that comes from equipments handler for a duplicate entry

            {

            }

            try
            {
                Rede _rede = new Rede(66, "1234");
                Console.WriteLine($"Foi criado {_rede.Id}");
                Console.WriteLine($"Foi criado {Utils.HasMethod(_rede, "Adiciona")}");
            } catch(InitBadException)
            {

            }

            




            Console.ReadKey();

        }


        
    }
}
